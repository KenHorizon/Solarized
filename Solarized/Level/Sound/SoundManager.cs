using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using NVorbis;
using System;
using System.Collections.Generic;
using System.IO;

namespace Solarized.Level.Sound
{
    public static class SoundManager
    {
        private static Dictionary<ResourceLocation<SoundEffect>, SoundEffect> Sounds = new Dictionary<ResourceLocation<SoundEffect>, SoundEffect>();
        
        public static void Load(ContentManager content, ResourceLocation<SoundEffect> soundId)
        {
            if (Sounds.ContainsKey(soundId))
            {
                return;
            }
            Sounds[soundId] = LoadOgg(Path.Combine(content.RootDirectory, soundId.FilePath + ".ogg"));
        }
        private static SoundEffect LoadOgg(string filePath)
        {
            string path = $"../../../Content/{filePath}";
            using (var stream = File.OpenRead(path))
            using (var vorbis = new VorbisReader(stream, false))
            {
                int channels = vorbis.Channels;
                int sampleRate = vorbis.SampleRate;

                var floatBuffer = new float[4096];
                var samples = new List<float>();
                int samplesRead;
                while ((samplesRead = vorbis.ReadSamples(floatBuffer, 0, floatBuffer.Length)) > 0)
                {
                    for (int i = 0; i < samplesRead; i++)
                        samples.Add(floatBuffer[i]);
                }

                byte[] pcmBytes = new byte[samples.Count * 2];
                for (int i = 0; i < samples.Count; i++)
                {
                    short s = (short)(MathHelper.Clamp(samples[i], -1f, 1f) * short.MaxValue);
                    pcmBytes[2 * i] = (byte)(s & 0xFF);
                    pcmBytes[2 * i + 1] = (byte)((s >> 8) & 0xFF);
                }

                var audioChannels = channels == 1 ? AudioChannels.Mono : AudioChannels.Stereo;
                return new SoundEffect(pcmBytes, sampleRate, audioChannels);
            }
        }
        public static void Play(ResourceLocation<SoundEffect> soundId, bool loop = false, float volume = 1.0F, float pitch = 0F, float pan = 0F)
        {
            Load(GamePanel.ContentManager, soundId);
            if (!Sounds.ContainsKey(soundId))
            {
                return;
            }
            SoundEffectInstance instance = Sounds[soundId].CreateInstance();
            instance.IsLooped = loop;
            Sounds[soundId].Play(volume, pitch, pan);

        }
    }
    public static class MusicManager
    {
        private static OggStream Music;

        public static void Play(ResourceLocation<SoundEffect> resourceLocation)
        {
            Music = new OggStream(resourceLocation.FilePath);
            Music.Play();
        }

        public static void Update()
        {
            Music?.Update();
        }

        public static void Stop()
        {
            Music = null;
        }
    }
    public class OggStream
    {
        private VorbisReader Reader;
        private DynamicSoundEffectInstance Instance;
        private float[] ReadBuffer;

        public OggStream(string filePath)
        {
            string path = $"../../../Content/{filePath}.ogg";
            Reader = new VorbisReader(File.OpenRead(path), false);
            Instance = new DynamicSoundEffectInstance(
                Reader.SampleRate,
                Reader.Channels == 1 ? AudioChannels.Mono : AudioChannels.Stereo
            );

            ReadBuffer = new float[4096];
        }

        public void Play()
        {
            if (Instance.State != SoundState.Playing)
            {
                Instance.Play();
            }
        }

        public void Update()
        {
            if (Instance.PendingBufferCount < 2)
            {
                int samplesRead = Reader.ReadSamples(ReadBuffer, 0, ReadBuffer.Length);

                if (samplesRead == 0)
                {
                    Reader.TimePosition = TimeSpan.Zero;
                    samplesRead = Reader.ReadSamples(ReadBuffer, 0, ReadBuffer.Length);
                }

                byte[] pcmBytes = new byte[samplesRead * 2];
                for (int i = 0; i < samplesRead; i++)
                {
                    short s = (short)(MathHelper.Clamp(ReadBuffer[i], -1f, 1f) * short.MaxValue);
                    pcmBytes[2 * i] = (byte)(s & 0xFF);
                    pcmBytes[2 * i + 1] = (byte)((s >> 8) & 0xFF);
                }

                Instance.SubmitBuffer(pcmBytes, 0, pcmBytes.Length);
            }
        }
    }
}
