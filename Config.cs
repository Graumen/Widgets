using System.ComponentModel;
using Terraria.ModLoader.Config;
namespace Widgets
{
    class Config : ModConfig
    {
        [Header("[c/ffff00:Current Ammo]")]

        [DefaultValue(true)]
        [Label("Visibility")]
        public bool cav;

        [DefaultValue(true)]
        [Label("Follow Player")]
        public bool caf;

        [DefaultValue(44)]
        [Label("Height")]
        [Range(0, 9999)]
        public int cah;

        [DefaultValue(44)]
        [Label("Width")]
        [Range(0, 9999)]
        public int caw;

        [DefaultValue(50)]
        [Label("X Position")]
        [Range(-9999, 9999)]
        public int cax;

        [DefaultValue(15)]
        [Label("Y Position")]
        [Range(-9999, 9999)]
        public int cay;

        [Header("[c/ffff00:Flight Time Bar]")]

        [DefaultValue(true)]
        [Label("Visibility")]
        public bool ftv;

        [DefaultValue(true)]
        [Label("Follow Player")]
        public bool ftf;

        [DefaultValue(50)]
        [Label("X Position")]
        [Range(-9999, 9999)]
        public int ftx;

        [DefaultValue(-15)]
        [Label("Y Position")]
        [Range(-9999, 9999)]
        public int fty;

        [Header("[c/ffff00:Minion Utilization]")]

        [DefaultValue(true)]
        [Label("Visibility")]
        public bool muv;

        [DefaultValue(496)]
        [Label("X Position")]
        [Range(-9999, 9999)]
        public int mux;

        [DefaultValue(25)]
        [Label("Y Position")]
        [Range(-9999, 9999)]
        public int muy;
        public override ConfigScope Mode => ConfigScope.ClientSide;
    }
}