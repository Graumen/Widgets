using Microsoft.Xna.Framework;
using Terraria;
namespace Widgets
{
    class RTC : Widget
    {
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch a0)
        {
            var f0 = Terraria.ModLoader.ModContent.GetInstance<Config>();
            var f1 = f0.f52;
            var f2 = Main.fontMouseText.MeasureString(System.DateTime.Now.ToString(f0.f51));

            Height.Set(f2.Y, 0);
            if (0 < f1.A) Utils.DrawInvBG(a0, new Rectangle((int)f8.X, (int)f8.Y, (int)f2.X + 16, (int)f2.Y), new Color(f1.R * f1.A / 255, f1.G * f1.A / 255, f1.B * f1.A / 255, f1.A));
            Utils.DrawBorderString(a0, System.DateTime.Now.ToString(f0.f51), new Vector2(8 + f8.X, 4 + f8.Y), f0.f53);
            base.DrawSelf(a0);
            Width.Set(f2.X + 16, 0);
        }
    }
}