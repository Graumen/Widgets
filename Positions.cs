using Microsoft.Xna.Framework;
using Terraria.ModLoader.Config;
namespace Widgets
{
    class Positions : ModConfig
    {
        [Label("")]
        [Range(0f, 9999f)]
        [System.ComponentModel.DefaultValue("500,500")]
        public Vector2 f0, f1, f2, f3, f4, f5, f6, f7, f8, f9, f10;
        public override ConfigScope Mode => ConfigScope.ClientSide;
    }
}