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
        public bool f0;

        [DefaultValue(true)]
        [Label("Follow Player")]
        public bool f1;

        [DefaultValue(typeof(Color), "63,81,151,179")]
        [Label("Background Color")]
        public Color f2;

        [Header("[c/ffff00:Breath and Lava Immunity Bar]")]

        [DefaultValue("Vanilla")]
        [DrawTicks]
        [Label("Visibility")]
        [OptionStrings(new string[] { "Always", "Vanilla", "Off" })]
        public string f3;

        [DefaultValue(true)]
        [Label("Follow Player")]
        public bool f4;

        [DefaultValue(true)]
        [Label("Icon")]
        public bool f5;

        [DefaultValue(false)]
        [Label("Reverse Breath Bar Gradient")]
        public bool f6;

        [DefaultValue(typeof(Color), "0,128,255,255")]
        [Label("Breath Bar Start Color")]
        public Color f7;

        [DefaultValue(typeof(Color), "0,128,255,255")]
        [Label("Breath Bar End Color")]
        public Color f8;

        [DefaultValue(false)]
        [Label("Reverse Lava Immunity Bar Gradient")]
        public bool f9;

        [DefaultValue(typeof(Color), "255,85,0,255")]
        [Label("Lava Immunity Bar Start Color")]
        public Color f10;

        [DefaultValue(typeof(Color), "255,85,0,255")]
        [Label("Lava Immunity Bar End Color")]
        public Color f11;

        [Header("[c/ffff00:Buff Display]")]

        [DefaultValue("Current + Max Buffs")]
        [DrawTicks]
        [Label("Visibility")]
        [OptionStrings(new string[] { "Current + Max Buffs", "Current Buffs", "Off" })]
        public string f12;

        [ColorNoAlpha]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        [Label("Color")]
        public Color f13;

        [Header("[c/ffff00:Flight Time Bar]")]

        [DefaultValue("Only in Flight, not on first Jump")]
        [DrawTicks]
        [Label("Visibility")]
        [OptionStrings(new string[] { "Always", "Only in Flight", "Only in Flight, not on first Jump", "Off" })]
        public string f14;

        [DefaultValue(true)]
        [Label("Follow Player")]
        public bool f15;

        [DefaultValue(true)]
        [Label("Icon")]
        public bool f16;

        [DefaultValue(false)]
        [Label("Reverse Gradient")]
        public bool f17;

        [DefaultValue(typeof(Color), "0,255,255,255")]
        [Label("Bar Start Color")]
        public Color f18;

        [DefaultValue(typeof(Color), "0,255,255,255")]
        [Label("Bar End Color")]
        public Color f19;

        [Header("[c/ffff00:Heal Display]")]

        [DefaultValue(true)]
        [Label("Visibility")]
        public bool f20;

        [DefaultValue(75)]
        [Label("Show until")]
        [Range(1, 100)]
        [Slider]
        [Tooltip("% Efficiency")]
        public int f21;

        [DefaultValue(true)]
        [Label("Follow Player")]
        public bool f22;

        [ColorNoAlpha]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        [Label("Text Color")]
        public Color f23;

        [Header("[c/ffff00:Health Bar]")]

        [DefaultValue(true)]
        [Label("Visibility")]
        public bool f24;

        [DefaultValue(100)]
        [Label("Show from")]
        [Slider]
        [Tooltip("% Health")]
        public int f25;

        [DefaultValue(true)]
        [Label("Follow Player")]
        public bool f26;

        [DefaultValue(true)]
        [Label("Icon")]
        public bool f27;

        [DefaultValue(false)]
        [Label("Reverse Gradient")]
        public bool f28;

        [DefaultValue(typeof(Color), "0,255,0,255")]
        [Label("Bar Start Color")]
        public Color f29;

        [DefaultValue(typeof(Color), "255,0,0,255")]
        [Label("Bar End Color")]
        public Color f30;

        [Header("[c/ffff00:Invincibility Time Bar]")]

        [DefaultValue("Only while Invincible")]
        [DrawTicks]
        [Label("Visibility")]
        [OptionStrings(new string[] { "Always", "Only while Invincible", "Off" })]
        public string f31;

        [DefaultValue(true)]
        [Label("Follow Player")]
        public bool f32;

        [DefaultValue(true)]
        [Label("Icon")]
        public bool f33;

        [DefaultValue(false)]
        [Label("Reverse Gradient")]
        public bool f34;

        [DefaultValue(typeof(Color), "255,0,255,255")]
        [Label("Bar Start Color")]
        public Color f35;

        [DefaultValue(typeof(Color), "255,0,255,255")]
        [Label("Bar End Color")]
        public Color f36;

        [Header("[c/ffff00:Mana Display]")]

        [DefaultValue("Default")]
        [DrawTicks]
        [Label("Visibility")]
        [OptionStrings(new string[] { "Always", "Default", "Off" })]
        public string f37;

        [DefaultValue(true)]
        [Label("Follow Player")]
        public bool f38;

        [DefaultValue(false)]
        [Label("Bar")]
        public bool f39;

        [DefaultValue(true)]
        [Label("Icon")]
        public bool f40;

        [DefaultValue(false)]
        [Label("Reverse Gradient")]
        public bool f41;

        [DefaultValue(typeof(Color), "77,106,255,255")]
        [Label("Bar Start Color")]
        public Color f42;

        [DefaultValue(typeof(Color), "77,106,255,255")]
        [Label("Bar End Color")]
        public Color f43;

        [Header("[c/ffff00:Minion Display]")]

        [DefaultValue(true)]
        [Label("Visibility")]
        public bool f44;

        [DefaultValue(false)]
        [Label("Follow Player")]
        public bool f45;

        [ColorNoAlpha]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        [Label("Text Color")]
        public Color f46;

        [Header("[c/ffff00:Positioning Widget]")]

        [DefaultValue(typeof(Color), "63,81,151,179")]
        [Label("Background Color")]
        public Color f47;

        [ColorNoAlpha]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        [Label("Text Color")]
        public Color f48;

        [Header("[c/ffff00:Real Time Clock]")]

        [DefaultValue(true)]
        [Label("Visibility")]
        public bool f49;

        [DefaultValue(false)]
        [Label("Follow Player")]
        public bool f50;

        [DefaultValue("H:mm")]
        [DrawTicks]
        [Label("Format")]
        [OptionStrings(new string[] { "H:m", "H:m:s", "H:m:ss", "H:mm", "H:mm:s", "H:mm:ss", "HH:m", "HH:m:s", "HH:m:ss", "HH:mm", "HH:mm:s", "HH:mm:ss" })]
        public string f51;

        [DefaultValue(typeof(Color), "63,81,151,179")]
        [Label("Background Color")]
        public Color f52;

        [ColorNoAlpha]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        [Label("Text Color")]
        public Color f53;

        [Header("[c/ffff00:Sentry Display]")]

        [DefaultValue(true)]
        [Label("Visibility")]
        public bool f54;

        [DefaultValue(false)]
        [Label("Follow Player")]
        public bool f55;

        [ColorNoAlpha]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        [Label("Text Color")]
        public Color f56;

        [Header("[c/ffff00:Miscellaneous]")]

        [DefaultValue(true)]
        [Label("Vanilla Health and Mana Displays")]
        public bool f57;

        [DefaultValue(true)]
        [Label("Hover Text")]
        [Tooltip("Show additional Information when hovering over some Widgets")]
        public bool f58;

        [DefaultValue(true)]
        [Label("Blink")]
        [Tooltip("Widgets blink when selected")]
        public bool f59;

        [ColorNoAlpha]
        [DefaultValue(typeof(Color), "255,255,255,255")]
        [Label("Blink Color")]
        public Color f60;
        public override ConfigScope Mode => ConfigScope.ClientSide;
    }
}