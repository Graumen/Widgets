using Microsoft.Xna.Framework;
using static Terraria.Main;
using static Terraria.ModLoader.ModContent;
using Terraria;
namespace Widgets
{
    class PW : Widget
    {
        public static bool f0, f1, f2, f3;
        public static Widget f4;
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch a0)
        {
            var f5 = GetInstance<Config>();
            var f6 = f5.f47;
            var f7 = $"X = {f4?.f8.X}\nY = {f4?.f8.Y}";

            f0 = new Rectangle((int)f8.X + 24, (int)f8.Y + 61, 34, 18).Contains(mouseX, mouseY);
            Height.Set(84, 0);
            if (0 < f6.A) Utils.DrawInvBG(a0, new Rectangle((int)f8.X, (int)f8.Y, (int)fontMouseText.MeasureString(f7).X + 89, 84), new Color(f6.R * f6.A / 255, f6.G * f6.A / 255, f6.B * f6.A / 255, f6.A));
            f1 = new Rectangle((int)f8.X + 5, (int)f8.Y + 24, 18, 34).Contains(mouseX, mouseY);
            f2 = new Rectangle((int)f8.X + 61, (int)f8.Y + 26, 18, 34).Contains(mouseX, mouseY);
            a0.Draw(GetTexture("Widgets/sprites/d"), new Vector2(24 + f8.X, 61 + f8.Y), Color.White * (f0 ? 1 : 0.5f));
            a0.Draw(GetTexture("Widgets/sprites/l"), new Vector2(5 + f8.X, 24 + f8.Y), Color.White * (f1 ? 1 : 0.5f));
            a0.Draw(GetTexture("Widgets/sprites/r"), new Vector2(61 + f8.X, 26 + f8.Y), Color.White * (f2 ? 1 : 0.5f));
            a0.Draw(GetTexture("Widgets/sprites/u"), new Vector2(26 + f8.X, 5 + f8.Y), Color.White * (f3 ? 1 : 0.5f));
            f3 = new Rectangle((int)f8.X + 26, (int)f8.Y + 5, 34, 18).Contains(mouseX, mouseY);
            Utils.DrawBorderString(a0, f7, new Vector2(84 + f8.X, 18 + f8.Y), f5.f48);
            base.DrawSelf(a0);
            Width.Set(89 + fontMouseText.MeasureString(f7).X, 0);
        }
        public override void MouseDown(Terraria.UI.UIMouseEvent a0)
        {
            if (ModPlayer.f1 && f4 != null)
            {
                if (f0) f4.f9.Y++;
                if (f1) f4.f9.X--;
                if (f2) f4.f9.X++;
                if (f3) f4.f9.Y--;
            }
            base.MouseDown(a0);
        }
    }
}