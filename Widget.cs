using Microsoft.Xna.Framework;
using static Terraria.GameInput.PlayerInput;
using static Terraria.Main;
using static Terraria.ModLoader.ModContent;
using System.Linq;
using Terraria.UI;
namespace Widgets
{
    class Widget : UIState
    {
        float x, y;
        public bool cd, ds, flw, md;
        public string ht;
        public Vector2 pos, tp, cp;
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
        {
            var ci = GetInstance<Config>().bc;

            if (IsMouseHovering)
            {
                if (!(md && MP.pm) && GetInstance<Config>().ht) hoverItemName = ht;
                if (MP.pm) LocalPlayer.mouseInterface = true;
            }
            if (PW.widget == this) sb.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((int)tp.X, (int)tp.Y, (int)Width.Pixels, (int)Height.Pixels), new Color(ci.R * MP.blink / 255, ci.G * MP.blink / 255, ci.B * MP.blink / 255, MP.blink));
        }
        public Color Gradient(bool rg, Color start, Color end, float rate)
        {
            byte[] ec = { end.R, end.G, end.B }, sc = { start.R, start.G, start.B };
            float eh = System.Drawing.Color.FromArgb(end.R, end.G, end.B).GetHue(), sh = System.Drawing.Color.FromArgb(start.R, start.G, start.B).GetHue(), hd = eh - sh, dc = -180 == hd && rg || -180 > hd ? 360 + eh : !rg && 180 == hd || 180 < hd ? eh - 360 : eh, rh = dc - (dc - sh) * rate, la = rh < 0 ? rh + 360 : (int)rh > 359 ? rh - 360 : rh, ha = la / 60 - (int)la / 60, rs = 1 - Mod0.SD(ec.Min() - (ec.Min() - sc.Min()) * rate, ec.Max() - (ec.Max() - sc.Max()) * rate);
            byte ra = (byte)(end.A - (end.A - start.A) * rate), c1 = (byte)((ec.Max() - (ec.Max() - sc.Max()) * rate) * ra / 255), c2 = (byte)((1 - rs) * c1), c3 = (byte)((1 - ha * rs) * c1), c4 = (byte)((1 - (1 - ha) * rs) * c1);

            if (60 > la) return new Color(c1, c4, c2, ra);
            else if (120 > la) return new Color(c3, c1, c2, ra);
            else if (180 > la) return new Color(c2, c1, c4, ra);
            else if (240 > la) return new Color(c2, c3, c1, ra);
            else if (300 > la) return new Color(c4, c2, c1, ra);
            else return new Color(c1, c2, c3, ra);
        }
        public override void MouseDown(UIMouseEvent _)
        {
            if (!(PW.d.cm || PW.l.cm || PW.r.cm || PW.u.cm) && MP.pm)
            {
                md = true;
                PW.widget = this;
            }
            x = mouseX - Left.Pixels;
            y = mouseY - Top.Pixels;
        }
        public override void MouseUp(UIMouseEvent _)
        {
            md = false;
            Mod0.Save();
        }
        public void TU()
        {
            pos = md && PW.widget == this ? new Vector2(mouseX - x, mouseY - y) : !flw || MP.pm ? cp : LocalPlayer.Center - screenPosition + new Vector2(-(RealScreenWidth / 2 - cp.X), LocalPlayer.gfxOffY - (RealScreenHeight / 2 - cp.Y));
            tp = new Vector2((int)(0 > pos.X ? 0 : pos.X + Width.Pixels > (int)(RealScreenWidth / UIScale) ? (int)(RealScreenWidth / UIScale) - Width.Pixels : pos.X), (int)(0 > pos.Y ? 0 : pos.Y + Height.Pixels > (int)(RealScreenHeight / UIScale) ? (int)(RealScreenHeight / UIScale) - Height.Pixels : pos.Y));
            Left.Set(tp.X, 0);
            Top.Set(tp.Y, 0);
            if (MP.pm)
            {
                cp = tp;
                if (PW.widget == this)
                {
                    if (29 < MP.br)
                    {
                        if (PW.d.md) PW.widget.cp.Y++;
                        if (PW.l.md) PW.widget.cp.X--;
                        if (PW.r.md) PW.widget.cp.X++;
                        if (PW.u.md) PW.widget.cp.Y--;
                        MP.br = 30;
                    }
                    if (cd) MP.blink -= 2;
                    else if (59 < MP.bd)
                    {
                        MP.bd = 60;
                        MP.blink += 2;
                    }
                    if (ds) PW.widget = null;
                    MP.bd++;
                }
            }
            if (!GetInstance<Config>().blink || md || PW.d.md || PW.l.md || PW.r.md || PW.u.md) MP.bd = MP.blink = 0;
            if (1 > MP.blink) cd = false;
            if (99 < MP.blink) cd = true;
        }
    }
}