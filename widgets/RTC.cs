using Microsoft.Xna.Framework;
using Terraria;
namespace Widgets
{
    class RTC : Widget
    {
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
        {
            var ci = Terraria.ModLoader.ModContent.GetInstance<Config>();
            var bc = ci.rtcbc;
            var ml = "H:m" == ci.rtcfm || "H:mm" == ci.rtcfm ? 56 : "H:m:s" == ci.rtcfm || "H:m:ss" == ci.rtcfm || "H:mm:s" == ci.rtcfm || "H:mm:ss" == ci.rtcfm ? 82 : "HH:m" == ci.rtcfm || "HH:mm" == ci.rtcfm ? 57 : 83;

            Height.Set(28, 0);
            if (0 < bc.A) Utils.DrawInvBG(sb, new Rectangle(x, y, ml, 28), new Color(bc.R * bc.A / 255, bc.G * bc.A / 255, bc.B * bc.A / 255, bc.A));
            Utils.DrawBorderString(sb, System.DateTime.Now.ToString(ci.rtcfm), new Vector2((ml - Main.fontMouseText.MeasureString(System.DateTime.Now.ToString(ci.rtcfm)).X) / 2 + x, 4 + y), ci.rtctc);
            base.DrawSelf(sb);
            Width.Set(ml, 0);
        }
    }
}