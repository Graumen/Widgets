using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
namespace Widgets
{
    class ITB : Widget
    {
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch a0)
        {
            var f0 = GetInstance<Config>();
            var f1 = Terraria.Main.LocalPlayer;

            Height.Set(f0.f33 ? 22 : 18, 0);
            a0.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((f0.f33 ? 22 : 4) + (int)f8.X, (f0.f33 ? 6 : 4) + (int)f8.Y, 50, 10), Color.Black);
            if (!f1.dead) a0.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((f0.f33 ? 22 : 4) + (int)f8.X, (f0.f33 ? 6 : 4) + (int)f8.Y, (int)Mod0.SD(50 * f1.immuneTime, 0 == ModPlayer.f4 ? f1.immuneTime + Mod0.f6 : ModPlayer.f4), 10), Gradient(f0.f34, f0.f35, f0.f36, Mod0.SD(f1.immuneTime, 0 == ModPlayer.f4 ? f1.immuneTime + Mod0.f6 : ModPlayer.f4)));
            a0.Draw(GetTexture("Widgets/sprites/bfg"), new Vector2((f0.f33 ? 18 : 0) + f8.X, (f0.f33 ? 2 : 0) + f8.Y), Color.White);
            if (f0.f33) a0.Draw(GetTexture("Widgets/sprites/itbi"), new Vector2(f8.X, f8.Y), Color.White);
            base.DrawSelf(a0);
            Width.Set(f0.f33 ? 76 : 58, 0);
        }
    }
}