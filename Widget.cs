﻿using Microsoft.Xna.Framework;
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
                if (!md && GetInstance<Config>().ht) hoverItemName = ht;
                if (ModPlayer.pm) LocalPlayer.mouseInterface = true;
            }
            if (GetInstance<Config>().blink && ModPlayer.pm && PW.widget == this) sb.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((int)tp.X, (int)tp.Y, (int)Width.Pixels, (int)Height.Pixels), new Color(ci.R * ModPlayer.blink / 255, ci.G * ModPlayer.blink / 255, ci.B * ModPlayer.blink / 255, ModPlayer.blink));
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
            if (ModPlayer.pm)
            {
                if (PW.d || PW.l || PW.r || PW.u)
                {
                    ModPlayer.br = true;
                    PlaySound(12);
                }
                else
                {
                    if (PW.widget != this) ModPlayer.blink = 0;
                    md = true;
                    PW.widget = this;
                }
            }
            x = mouseX - Left.Pixels;
            y = mouseY - Top.Pixels;
        }
        public override void MouseUp(UIMouseEvent _)
        {
            if (ModPlayer.pm) Mod0.Save();
            md = ModPlayer.br = false;
            ModPlayer.bd = 0;
        }
        public void TU()
        {
            pos = md && PW.widget == this ? new Vector2(mouseX - x, mouseY - y) : !flw || ModPlayer.pm ? cp : LocalPlayer.Center - screenPosition + new Vector2(-(RealScreenWidth / 2 - cp.X), LocalPlayer.gfxOffY - (RealScreenHeight / 2 - cp.Y));
            tp = new Vector2((int)(0 > pos.X ? 0 : pos.X + Width.Pixels > (int)(RealScreenWidth / UIScale) ? (int)(RealScreenWidth / UIScale) - Width.Pixels : pos.X), (int)(0 > pos.Y ? 0 : pos.Y + Height.Pixels > (int)(RealScreenHeight / UIScale) ? (int)(RealScreenHeight / UIScale) - Height.Pixels : pos.Y));
            Left.Set(tp.X, 0);
            Top.Set(tp.Y, 0);
            if (ModPlayer.pm)
            {
                cp = tp;
                if (PW.widget == this)
                {
                    if (150 < ModPlayer.bd)
                    {
                        if (PW.d) cp.Y++;
                        if (PW.l) cp.X--;
                        if (PW.r) cp.X++;
                        if (PW.u) cp.Y--;
                        ModPlayer.bd = 151;
                    }
                    if (cd) ModPlayer.blink--;
                    else ModPlayer.blink++;
                    if (ds) PW.widget = null;
                }
            }
            if (!GetInstance<Config>().blink || md || ModPlayer.br) ModPlayer.blink = 0;
            if (1 > ModPlayer.blink) cd = false;
            if (99 < ModPlayer.blink) cd = true;
            if (ModPlayer.br) ModPlayer.bd++;
        }
    }
}