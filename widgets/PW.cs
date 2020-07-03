using Microsoft.Xna.Framework;
using static Terraria.Main;
using static Terraria.ModLoader.ModContent;
using Terraria.UI;
using Terraria;
namespace Widgets
{
    class PW : Widget
    {
        public static bool d, l, r, u;
        public static Widget widget;
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
        {
            var ci = GetInstance<Config>();
            var bc = ci.pwbc;
            var txt = $"X = {widget?.tp.X}\nY = {widget?.tp.Y}";

            d = new Rectangle((int)tp.X + 24, (int)tp.Y + 61, 34, 18).Contains(mouseX, mouseY);
            Height.Set(84, 0);
            if (0 < bc.A) Utils.DrawInvBG(sb, new Rectangle((int)tp.X, (int)tp.Y, (int)fontMouseText.MeasureString(txt).X + 89, 84), new Color(bc.R * bc.A / 255, bc.G * bc.A / 255, bc.B * bc.A / 255, bc.A));
            l = new Rectangle((int)tp.X + 5, (int)tp.Y + 24, 18, 34).Contains(mouseX, mouseY);
            r = new Rectangle((int)tp.X + 61, (int)tp.Y + 26, 18, 34).Contains(mouseX, mouseY);
            sb.Draw(GetTexture("Widgets/sprites/d"), new Vector2(24 + tp.X, 61 + tp.Y), Color.White * (d ? 1 : 0.5f));
            sb.Draw(GetTexture("Widgets/sprites/l"), new Vector2(5 + tp.X, 24 + tp.Y), Color.White * (l ? 1 : 0.5f));
            sb.Draw(GetTexture("Widgets/sprites/r"), new Vector2(61 + tp.X, 26 + tp.Y), Color.White * (r ? 1 : 0.5f));
            sb.Draw(GetTexture("Widgets/sprites/u"), new Vector2(26 + tp.X, 5 + tp.Y), Color.White * (u ? 1 : 0.5f));
            u = new Rectangle((int)tp.X + 26, (int)tp.Y + 5, 34, 18).Contains(mouseX, mouseY);
            Utils.DrawBorderString(sb, txt, new Vector2(84 + tp.X, 18 + tp.Y), ci.pwtc);
            base.DrawSelf(sb);
            Width.Set(89 + fontMouseText.MeasureString(txt).X, 0);
        }
        public override void MouseDown(UIMouseEvent a0)
        {
            if (ModPlayer.pm && widget != null)
            {
                if (d) widget.cp.Y++;
                if (l) widget.cp.X--;
                if (r) widget.cp.X++;
                if (u) widget.cp.Y--;
            }
            base.MouseDown(a0);
        }
    }
}