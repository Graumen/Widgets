using Microsoft.Xna.Framework;
using System.ComponentModel;
using Terraria.ModLoader.Config;
namespace Widgets
{
    class Config : ModConfig
    {
        [Header("[c/ffff00:Ammo Display]")]

        [DefaultValue(true)]
        [Label("Visibility")]
        public bool adv;

        [DefaultValue(true)]
        [Label("Follow Player")]
        public bool adf;

        [DefaultValue(typeof(Color), "63,81,151,179")]
        [Label("Background Color")]
        public Color adc;

        [Header("[c/ffff00:Breath and Lava Immunity Bar]")]

        [DefaultValue("Vanilla")]
        [DrawTicks]
        [Label("Visibility")]
        [OptionStrings(new string[] { "Always", "Vanilla", "Off" })]
        public string blbv;

        [DefaultValue(true)]
        [Label("Follow Player")]
        public bool blbf;

        [DefaultValue(true)]
        [Label("Icon")]
        public bool blbi;

        [DefaultValue(false)]
        [Label("Reverse Breath Bar Gradient")]
        public bool bbrg;

        [DefaultValue(typeof(Color), "0,128,255,255")]
        [Label("Breath Bar Start Color")]
        public Color bbsc;

        [DefaultValue(typeof(Color), "0,128,255,255")]
        [Label("Breath Bar End Color")]
        public Color bbec;

        [DefaultValue(false)]
        [Label("Reverse Lava Immunity Bar Gradient")]
        public bool lbrg;

        [DefaultValue(typeof(Color), "255,85,0,255")]
        [Label("Lava Immunity Bar Start Color")]
        public Color lbsc;

        [DefaultValue(typeof(Color), "255,85,0,255")]
        [Label("Lava Immunity Bar End Color")]
        public Color lbec;

        [Header("[c/ffff00:Buff Display]")]

        [DefaultValue("Current + Max Buffs")]
        [DrawTicks]
        [Label("Visibility")]
        [OptionStrings(new string[] { "Current + Max Buffs", "Current Buffs", "Off" })]
        public string bdv;

        [ColorNoAlpha]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        [Label("Color")]
        public Color bdc;

        [Header("[c/ffff00:Flight Time Bar]")]

        [DefaultValue("Only in Flight, not on first Jump")]
        [DrawTicks]
        [Label("Visibility")]
        [OptionStrings(new string[] { "Always", "Only in Flight", "Only in Flight, not on first Jump", "Off" })]
        public string ftbv;

        [DefaultValue(true)]
        [Label("Follow Player")]
        public bool ftbf;

        [DefaultValue(true)]
        [Label("Icon")]
        public bool ftbi;

        [DefaultValue(false)]
        [Label("Reverse Gradient")]
        public bool ftbrg;

        [DefaultValue(typeof(Color), "0,255,255,255")]
        [Label("Bar Start Color")]
        public Color ftbsc;

        [DefaultValue(typeof(Color), "0,255,255,255")]
        [Label("Bar End Color")]
        public Color ftbec;

        [Header("[c/ffff00:Heal Display]")]

        [DefaultValue(true)]
        [Label("Visibility")]
        public bool hdv;

        [DefaultValue(75)]
        [Label("Show until")]
        [Range(1, 100)]
        [Slider]
        [Tooltip("% Efficiency")]
        public int hdsu;

        [DefaultValue(true)]
        [Label("Follow Player")]
        public bool hdf;

        [ColorNoAlpha]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        [Label("Text Color")]
        public Color hdc;

        [Header("[c/ffff00:Health Bar]")]

        [DefaultValue(true)]
        [Label("Visibility")]
        public bool hbv;

        [DefaultValue(100)]
        [Label("Show from")]
        [Slider]
        [Tooltip("% Health")]
        public int hbsf;

        [DefaultValue(true)]
        [Label("Follow Player")]
        public bool hbf;

        [DefaultValue(true)]
        [Label("Icon")]
        public bool hbi;

        [DefaultValue(false)]
        [Label("Reverse Gradient")]
        public bool hbrg;

        [DefaultValue(typeof(Color), "0,255,0,255")]
        [Label("Bar Start Color")]
        public Color hbsc;

        [DefaultValue(typeof(Color), "255,0,0,255")]
        [Label("Bar End Color")]
        public Color hbec;

        [Header("[c/ffff00:Invincibility Time Bar]")]

        [DefaultValue("Only while Invincible")]
        [DrawTicks]
        [Label("Visibility")]
        [OptionStrings(new string[] { "Always", "Only while Invincible", "Off" })]
        public string itbv;

        [DefaultValue(true)]
        [Label("Follow Player")]
        public bool itbf;

        [DefaultValue(true)]
        [Label("Icon")]
        public bool itbi;

        [DefaultValue(false)]
        [Label("Reverse Gradient")]
        public bool itbrg;

        [DefaultValue(typeof(Color), "255,0,255,255")]
        [Label("Bar Start Color")]
        public Color itbsc;

        [DefaultValue(typeof(Color), "255,0,255,255")]
        [Label("Bar End Color")]
        public Color itbec;

        [Header("[c/ffff00:Mana Display]")]

        [DefaultValue("Default")]
        [DrawTicks]
        [Label("Visibility")]
        [OptionStrings(new string[] { "Always", "Default", "Off" })]
        public string madv;

        [DefaultValue(true)]
        [Label("Follow Player")]
        public bool madf;

        [DefaultValue(false)]
        [Label("Bar")]
        public bool madb;

        [DefaultValue(true)]
        [Label("Icon")]
        public bool madi;

        [DefaultValue(false)]
        [Label("Reverse Gradient")]
        public bool madrg;

        [DefaultValue(typeof(Color), "77,106,255,255")]
        [Label("Bar Start Color")]
        public Color madsc;

        [DefaultValue(typeof(Color), "77,106,255,255")]
        [Label("Bar End Color")]
        public Color madec;

        [Header("[c/ffff00:Minion Display]")]

        [DefaultValue(true)]
        [Label("Visibility")]
        public bool mdv;

        [DefaultValue(false)]
        [Label("Follow Player")]
        public bool mdf;

        [ColorNoAlpha]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        [Label("Text Color")]
        public Color mdc;

        [Header("[c/ffff00:Positioning Widget]")]

        [DefaultValue(typeof(Color), "63,81,151,179")]
        [Label("Background Color")]
        public Color pwbc;

        [ColorNoAlpha]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        [Label("Text Color")]
        public Color pwtc;

        [Header("[c/ffff00:Real Time Clock]")]

        [DefaultValue(true)]
        [Label("Visibility")]
        public bool rtcv;

        [DefaultValue(false)]
        [Label("Follow Player")]
        public bool rtcflw;

        [DefaultValue("H:mm")]
        [DrawTicks]
        [Label("Format")]
        [OptionStrings(new string[] { "H:m", "H:m:s", "H:m:ss", "H:mm", "H:mm:s", "H:mm:ss", "HH:m", "HH:m:s", "HH:m:ss", "HH:mm", "HH:mm:s", "HH:mm:ss" })]
        public string rtcfm;

        [DefaultValue(typeof(Color), "63,81,151,179")]
        [Label("Background Color")]
        public Color rtcbc;

        [ColorNoAlpha]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        [Label("Text Color")]
        public Color rtctc;

        [Header("[c/ffff00:Sentry Display]")]

        [DefaultValue(true)]
        [Label("Visibility")]
        public bool sdv;

        [DefaultValue(false)]
        [Label("Follow Player")]
        public bool sdf;

        [ColorNoAlpha]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        [Label("Text Color")]
        public Color sdc;

        [Header("[c/ffff00:Miscellaneous]")]

        [DefaultValue(true)]
        [Label("Vanilla Health and Mana Displays")]
        public bool hv;

        [DefaultValue(true)]
        [Label("Hover Text")]
        [Tooltip("Show additional Information when hovering over some Widgets")]
        public bool ht;

        [DefaultValue(true)]
        [Label("Blink")]
        [Tooltip("Widgets blink when selected")]
        public bool blink;

        [ColorNoAlpha]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        [Label("Blink Color")]
        public Color bc;
        public override ConfigScope Mode => ConfigScope.ClientSide;
    }
}