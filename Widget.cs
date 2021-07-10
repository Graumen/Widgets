using Microsoft.Xna.Framework;
using static Terraria.Main;
using static Terraria.ModLoader.ModContent;
using System.Linq;
using Terraria.UI;
namespace Widgets
{
    class Widget : UIState
    {
        public bool cd, click, drawn, ds, flw, md;
        public int cx, cy, h, mx, my, w, x, y;
        public string ht;
        Widget d, l, r, u;
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
        {
            var ci = GetInstance<Config>();

            if (IsMouseHovering)
            {
                if (!(md && MP.pm) && ci.ht) hoverItemName = ht;
                if (MP.pm) LocalPlayer.mouseInterface = true;
            }
            if (PW.widget == this) sb.Draw(GetTexture("Widgets/sprites/wp"), GetDimensions().ToRectangle(), new Color(ci.bc.R * MP.blink / 255, ci.bc.G * MP.blink / 255, ci.bc.B * MP.blink / 255, MP.blink));
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
                md = Mod0.md = true;
                PW.widget = this;
            }
            mx = mouseX - x;
            my = mouseY - y;
        }
        public override void MouseUp(UIMouseEvent _)
        {
            md = false;
            Mod0.Save();
            Positions.Save();
        }
        public void TU()
        {
            h = (int)Height.Pixels;
            w = (int)Width.Pixels;

            var vp = new Vector2(spriteBatch.GraphicsDevice.Viewport.Width, spriteBatch.GraphicsDevice.Viewport.Height);
            var cr = new Rectangle(md && PW.widget == this ? mouseX - mx : !flw || MP.pm ? cx : (int)(LocalPlayer.Center.X - (vp.X / 2 - cx) - screenPosition.X), md && PW.widget == this ? mouseY - my : !flw || MP.pm ? cy : (int)(LocalPlayer.Center.Y - (vp.Y / 2 - cy) - screenPosition.Y + LocalPlayer.gfxOffY), w, h);

            if (MP.pm)
            {
                if (PW.widget == this)
                {
                    if (29 < MP.br || click)
                    {
                        if (29 < MP.br) MP.br = 30;
                        if (PW.d.md) PW.widget.cy++;
                        if (PW.l.md) PW.widget.cx--;
                        if (PW.r.md) PW.widget.cx++;
                        if (PW.u.md) PW.widget.cy--;
                        click = false;
                    }
                    if (cd) MP.blink -= 1;
                    else if (59 < MP.bd)
                    {
                        MP.bd = 60;
                        MP.blink += 1;
                    }
                    if (ds) PW.widget = null;
                    MP.bd++;
                }
            }
            if ((!MP.pm && flw || Mod0.md && PW.widget == this) && drawn)
            {
                d = Mod0.wl.Where(_ => _ != this && _.GetDimensions().ToRectangle().Intersects(new Rectangle(x, h + y, w, cr.Y - y))).OrderBy(a => a.y).FirstOrDefault();
                l = Mod0.wl.Where(_ => _ != this && _.GetDimensions().ToRectangle().Intersects(new Rectangle(cr.X, y, x - cr.X, h))).OrderBy(a => a.w + a.x).LastOrDefault();
                r = Mod0.wl.Where(_ => _ != this && _.GetDimensions().ToRectangle().Intersects(new Rectangle(w + x, y, cr.X - x, h))).OrderBy(a => a.x).FirstOrDefault();
                u = Mod0.wl.Where(_ => _ != this && _.GetDimensions().ToRectangle().Intersects(new Rectangle(x, cr.Y, w, y - cr.Y))).OrderBy(a => a.h + a.y).LastOrDefault();
            }
            else d = l = r = u = null;
            if (!GetInstance<Config>().blink || md || PW.d.md || PW.l.md || PW.r.md || PW.u.md) MP.bd = MP.blink = 0;
            if (1 > MP.blink) cd = false;
            if (169 < MP.blink) cd = true;
            Left.Set(d != l && l != null && l != u ? l.w + l.x : 0 > cr.X ? 0 : d != r && null != r && r != u ? r.x - w : cr.X + w > vp.X / UIScale ? vp.X / UIScale - w : cr.X, 0);
            Top.Set(d != null ? d.y - h : cr.Y + h > vp.Y / UIScale ? vp.Y / UIScale - h : null != u ? u.h + u.y : 0 > cr.Y ? 0 : cr.Y, 0);
            x = (int)Left.Pixels;
            y = (int)Top.Pixels;
        }
    }
}