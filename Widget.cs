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
        float f0, f1;
        public bool f2, f3, f4, f5;
        public string f6;
        public Vector2 f7, f8, f9;
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch a0)
        {
            var f0 = GetInstance<Config>().f60;

            if (IsMouseHovering)
            {
                if (!f5 && GetInstance<Config>().f58) hoverItemName = f6;
                if (ModPlayer.f1) LocalPlayer.mouseInterface = true;
            }
            if (GetInstance<Config>().f59 && ModPlayer.f1 && PW.f4 == this) a0.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((int)f8.X, (int)f8.Y, (int)Width.Pixels, (int)Height.Pixels), new Color(f0.R * ModPlayer.f2 / 255, f0.G * ModPlayer.f2 / 255, f0.B * ModPlayer.f2 / 255, ModPlayer.f2));
        }
        public Color Gradient(bool a0, Color a1, Color a2, float a3)
        {
            byte[] f0 = { a2.R, a2.G, a2.B }, f1 = { a1.R, a1.G, a1.B };
            float f2 = System.Drawing.Color.FromArgb(a2.R, a2.G, a2.B).GetHue(), f3 = System.Drawing.Color.FromArgb(a1.R, a1.G, a1.B).GetHue(), f4 = f2 - f3, dc = -180 == f4 && a0 || -180 > f4 ? 360 + f2 : !a0 && 180 == f4 || 180 < f4 ? f2 - 360 : f2, f5 = dc - (dc - f3) * a3, f6 = f5 < 0 ? f5 + 360 : (int)f5 > 359 ? f5 - 360 : f5, f7 = f6 / 60 - (int)f6 / 60, f8 = 1 - Mod0.SD(f0.Min() - (f0.Min() - f1.Min()) * a3, f0.Max() - (f0.Max() - f1.Max()) * a3);
            byte f9 = (byte)(a2.A - (a2.A - a1.A) * a3), f10 = (byte)((f0.Max() - (f0.Max() - f1.Max()) * a3) * f9 / 255), f11 = (byte)((1 - f8) * f10), f12 = (byte)((1 - f7 * f8) * f10), f13 = (byte)((1 - (1 - f7) * f8) * f10);

            if (60 > f6) return new Color(f10, f13, f11, f9);
            else if (120 > f6) return new Color(f12, f10, f11, f9);
            else if (180 > f6) return new Color(f11, f10, f13, f9);
            else if (240 > f6) return new Color(f11, f12, f10, f9);
            else if (300 > f6) return new Color(f13, f11, f10, f9);
            else return new Color(f10, f11, f12, f9);
        }
        public override void MouseDown(UIMouseEvent a0)
        {
            if (ModPlayer.f1)
            {
                if (PW.f0 || PW.f1 || PW.f2 || PW.f3)
                {
                    ModPlayer.f0 = true;
                    PlaySound(12);
                }
                else
                {
                    if (PW.f4 != this) ModPlayer.f2 = 0;
                    f5 = true;
                    PW.f4 = this;
                }
            }
            f0 = mouseX - Left.Pixels;
            f1 = mouseY - Top.Pixels;
        }
        public override void MouseUp(UIMouseEvent a0)
        {
            if (ModPlayer.f1) Mod0.Save();
            f5 = ModPlayer.f0 = false;
            ModPlayer.f3 = 0;
        }
        public void TU()
        {
            f7 = f5 && PW.f4 == this ? new Vector2(mouseX - f0, mouseY - f1) : !f4 || ModPlayer.f1 ? f9 : LocalPlayer.Center - screenPosition + new Vector2(-(RealScreenWidth / 2 - f9.X), LocalPlayer.gfxOffY - (RealScreenHeight / 2 - f9.Y));
            f8 = new Vector2((int)(0 > f7.X ? 0 : f7.X + Width.Pixels > (int)(RealScreenWidth / UIScale) ? (int)(RealScreenWidth / UIScale) - Width.Pixels : f7.X), (int)(0 > f7.Y ? 0 : f7.Y + Height.Pixels > (int)(RealScreenHeight / UIScale) ? (int)(RealScreenHeight / UIScale) - Height.Pixels : f7.Y));
            Left.Set(f8.X, 0);
            Top.Set(f8.Y, 0);
            if (ModPlayer.f1)
            {
                f9 = f8;
                if (PW.f4 == this)
                {
                    if (150 < ModPlayer.f3)
                    {
                        if (PW.f0) f9.Y++;
                        if (PW.f1) f9.X--;
                        if (PW.f2) f9.X++;
                        if (PW.f3) f9.Y--;
                        ModPlayer.f3 = 151;
                    }
                    if (f2) ModPlayer.f2--;
                    else ModPlayer.f2++;
                    if (f3) PW.f4 = null;
                }
            }
            if (!GetInstance<Config>().f59 || f5 || ModPlayer.f0) ModPlayer.f2 = 0;
            if (1 > ModPlayer.f2) f2 = false;
            if (99 < ModPlayer.f2) f2 = true;
            if (ModPlayer.f0) ModPlayer.f3++;
        }
    }
}