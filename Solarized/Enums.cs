using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solarized.Content
{
    public enum GameState
    {
        None,
        Play,
        Pause,
        GameOver,
        Shop
    }
    public enum EntityClass
    {
        Object,
        Player,
        Enemy,
        Boss,
        NPC
    }
    public enum DamageType
    {
        Physical,
        Magic,
        TrueDamage
    }
    public enum ProjectileType
    {
        Single,
        Rocket,
        LaserBeam
    }
    public enum Align
    {
        Centered,
        Left
    }
    public enum FontStyle
    {
        Default,
        Shadow
    }
}
