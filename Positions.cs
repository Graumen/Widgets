using Microsoft.Xna.Framework;
using Terraria.ModLoader.Config;
namespace Widgets
{
    class Positions : ModConfig
    {
        [Label("")]
        [Range(0f, 9999f)]
        [System.ComponentModel.DefaultValue("500,500")]
        public Vector2 ad, blb, ftb, hb, hd, itb, mad, md, pw, rtc, sd;
        public override ConfigScope Mode => ConfigScope.ClientSide;
    }
}