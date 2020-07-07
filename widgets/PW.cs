using Microsoft.Xna.Framework;
using static Terraria.Main;
using static Terraria.ModLoader.ModContent;
using Terraria;
namespace Widgets
{
    class PW : Widget
    {
        public static PWB d, l, r, u;
        public static Widget widget;
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
        {
            var ci = GetInstance<Config>();
            var bc = ci.pwbc;
            var txt = $"X = {widget?.cp.X}\nY = {widget?.cp.Y}";

            Height.Set(84, 0);
            if (0 < bc.A) Utils.DrawInvBG(sb, new Rectangle((int)tp.X, (int)tp.Y, (int)fontMouseText.MeasureString(txt).X + 89, 84), new Color(bc.R * bc.A / 255, bc.G * bc.A / 255, bc.B * bc.A / 255, bc.A));
            Utils.DrawBorderString(sb, txt, new Vector2(84 + tp.X, 18 + tp.Y), ci.pwtc);
            base.DrawSelf(sb);
            Width.Set(89 + fontMouseText.MeasureString(txt).X, 0);
        }
        public override void OnInitialize()
        {
            d = new PWB(18, 34, 24, 61, GetTexture("Widgets/sprites/d"));
            Append(d);
            d.omd += D;
            l = new PWB(34, 18, 5, 24, GetTexture("Widgets/sprites/l"));
            Append(l);
            l.omd += L;
            r = new PWB(34, 18, 61, 26, GetTexture("Widgets/sprites/r"));
            Append(r);
            r.omd += R;
            u = new PWB(18, 34, 26, 5, GetTexture("Widgets/sprites/u"));
            Append(u);
            u.omd += U;
            void D() { widget.cp.Y++; }
            void L() { widget.cp.X--; }
            void R() { widget.cp.X++; }
            void U() { widget.cp.Y--; }
        }
    }
}