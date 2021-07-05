using Microsoft.Xna.Framework;
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

            d.tex = GetTexture("Widgets/sprites/d");
            Height.Set(84, 0);
            if (0 < bc.A) Utils.DrawInvBG(sb, new Rectangle(x, y, 170, 84), new Color(bc.R * bc.A / 255, bc.G * bc.A / 255, bc.B * bc.A / 255, bc.A));
            l.tex = GetTexture("Widgets/sprites/l");
            r.tex = GetTexture("Widgets/sprites/r");
            u.tex = GetTexture("Widgets/sprites/u");
            Utils.DrawBorderString(sb, $"X = {widget?.x}\nY = {widget?.y}", new Vector2(84 + x, 18 + y), ci.pwtc);
            base.DrawSelf(sb);
            Width.Set(170, 0);
        }
        public override void OnInitialize()
        {
            d = new PWB(18, 24, 61, 34);
            l = new PWB(34, 5, 24, 18);
            r = new PWB(34, 61, 26, 18);
            u = new PWB(18, 26, 5, 34);
            Append(d);
            Append(l);
            Append(r);
            Append(u);
        }
    }
}