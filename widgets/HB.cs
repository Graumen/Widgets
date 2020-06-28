using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
namespace Widgets
{
    class HB : Widget
    {
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch a0)
        {
            var f0 = GetInstance<Config>();
            var f1 = Terraria.Main.LocalPlayer;

            Height.Set(f0.f27 ? 22 : 18, 0);
            a0.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((f0.f27 ? 24 : 4) + (int)f8.X, (f0.f27 ? 6 : 4) + (int)f8.Y, 50, 10), Color.Black);
            a0.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((f0.f27 ? 24 : 4) + (int)f8.X, (f0.f27 ? 6 : 4) + (int)f8.Y, 50 * f1.statLife / f1.statLifeMax2, 10), Gradient(f0.f28, f0.f29, f0.f30, (float)f1.statLife / f1.statLifeMax2));
            a0.Draw(GetTexture("Widgets/sprites/bfg"), new Vector2((f0.f27 ? 20 : 0) + f8.X, (f0.f27 ? 2 : 0) + f8.Y), Color.White);
            if (f0.f27) a0.Draw(GetTexture("Widgets/sprites/hbi"), new Vector2(f8.X, f8.Y), Color.White);
            base.DrawSelf(a0);
            Width.Set(f0.f27 ? 78 : 58, 0);
        }
    }
}