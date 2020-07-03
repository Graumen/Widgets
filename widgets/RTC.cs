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
            var ms = Main.fontMouseText.MeasureString(System.DateTime.Now.ToString(ci.rtcfm));

            Height.Set(ms.Y, 0);
            if (0 < bc.A) Utils.DrawInvBG(sb, new Rectangle((int)tp.X, (int)tp.Y, (int)ms.X + 16, (int)ms.Y), new Color(bc.R * bc.A / 255, bc.G * bc.A / 255, bc.B * bc.A / 255, bc.A));
            Utils.DrawBorderString(sb, System.DateTime.Now.ToString(ci.rtcfm), new Vector2(8 + tp.X, 4 + tp.Y), ci.rtctc);
            base.DrawSelf(sb);
            Width.Set(ms.X + 16, 0);
        }
    }
}