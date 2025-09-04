using Microsoft.Xna.Framework;
using Solarized.Level.Registry;
using Solarized.NPCs;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Solarized.Level
{
    /// <summary>
    /// WorldLevel handle all adding entity, entity ticks and update and also handle client side
    /// management such as playing sound, particles, and date and time.
    /// </summary>
    public class WorldLevel
    {
        private List<BaseEntity> entities = new List<BaseEntity>();
        private GamePanel game;
        public WorldLevel(GamePanel game)
        {
            this.game = game;
        }
        public void AddEntity(RegistryKey<BaseEntity> entity)
        {
            entities.Add(entity.Get());
            Debug.WriteLine($"Added Entity {entity.RegistryName()}");
        }

        public void RemoveEntity(RegistryKey<BaseEntity> entity)
        {
            if (entities.Remove(entity.Get()))
            {
                Debug.WriteLine($"Remove Entity {entity.RegistryName()}");
            }
        }
        public List<BaseEntity> GetAllEntity()
        {
            return entities;
        }
        public void Tick(GameTime gameTime)
        {
            foreach (var entity in entities)
            {
                entity.Tick(gameTime);
            }
        }
    }
}
