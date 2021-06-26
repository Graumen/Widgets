using System.ComponentModel;
using System.Reflection;
using Terraria.ModLoader.Config;
namespace Widgets
{
    class Positions : ModConfig
    {
        [Header("[c/ffff00:Ammo Display]")]

        [DefaultValue(330)]
        [Label("X")]
        [Range(0, 9999)]
        public int adx;

        [DefaultValue(372)]
        [Label("Y")]
        [Range(0, 9999)]
        public int ady;

        [Header("[c/ffff00:Breath and Lava Immunity Bar]")]

        [DefaultValue(332)]
        [Label("X")]
        [Range(0, 9999)]
        public int blbx;

        [DefaultValue(336)]
        [Label("Y")]
        [Range(0, 9999)]
        public int blby;

        [Header("[c/ffff00:Flight Time Bar]")]

        [DefaultValue(250)]
        [Label("X")]
        [Range(0, 9999)]
        public int ftbx;

        [DefaultValue(336)]
        [Label("Y")]
        [Range(0, 9999)]
        public int ftby;

        [Header("[c/ffff00:Heal Display]")]

        [DefaultValue(382)]
        [Label("X")]
        [Range(0, 9999)]
        public int hdx;

        [DefaultValue(428)]
        [Label("Y")]
        [Range(0, 9999)]
        public int hdy;

        [Header("[c/ffff00:Health Bar]")]

        [DefaultValue(250)]
        [Label("X")]
        [Range(0, 9999)]
        public int hbx;

        [DefaultValue(360)]
        [Label("Y")]
        [Range(0, 9999)]
        public int hby;

        [Header("[c/ffff00:Invincibility Time Bar]")]

        [DefaultValue(250)]
        [Label("X")]
        [Range(0, 9999)]
        public int itbx;

        [DefaultValue(384)]
        [Label("Y")]
        [Range(0, 9999)]
        public int itby;

        [Header("[c/ffff00:Mana Display]")]

        [DefaultValue(382)]
        [Label("X")]
        [Range(0, 9999)]
        public int madx;

        [DefaultValue(452)]
        [Label("Y")]
        [Range(0, 9999)]
        public int mady;

        [Header("[c/ffff00:Minion Display]")]

        [DefaultValue(376)]
        [Label("X")]
        [Range(0, 9999)]
        public int mdx;

        [DefaultValue(372)]
        [Label("Y")]
        [Range(0, 9999)]
        public int mdy;

        [Header("[c/ffff00:Positioning Widget]")]

        [DefaultValue(250)]
        [Label("X")]
        [Range(0, 9999)]
        public int pwx;

        [DefaultValue(250)]
        [Label("Y")]
        [Range(0, 9999)]
        public int pwy;

        [Header("[c/ffff00:Real Time Clock]")]

        [DefaultValue(250)]
        [Label("X")]
        [Range(0, 9999)]
        public int rtcx;

        [DefaultValue(408)]
        [Label("Y")]
        [Range(0, 9999)]
        public int rtcy;

        [Header("[c/ffff00:Sentry Display]")]

        [DefaultValue(380)]
        [Label("X")]
        [Range(0, 9999)]
        public int sdx;

        [DefaultValue(404)]
        [Label("Y")]
        [Range(0, 9999)]
        public int sdy;
        public override ConfigScope Mode => ConfigScope.ClientSide;
        public static void Save()
        {
            var save = typeof(ConfigManager).GetMethod("Save", BindingFlags.NonPublic | BindingFlags.Static);

            if (null != save) save.Invoke(null, new object[] { Terraria.ModLoader.ModContent.GetInstance<Positions>() });
        }
    }
}