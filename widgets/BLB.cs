using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
namespace Widgets
{
    class BLB : Widget
    {
        protected override void DrawSelf(SpriteBatch a0)
        {
            var f0 = GetInstance<Config>();
            var f1 = Terraria.Main.LocalPlayer;
            var f2 = "Always" == f0.f3 || 0 < f1.breath && f1.breath < f1.breathMax && 0 < f1.lavaTime && f1.lavaTime < f1.lavaMax || ModPlayer.f1;

            void DrawBar(bool a1, Color a2, float a3, SpriteBatch a4, Texture2D a5, int a6 = 0)
            {
                a4.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((int)f8.X + (a1 ? 20 : 4), (int)f8.Y + 4 + a6, 50, 10), Color.Black);
                a4.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((int)f8.X + (a1 ? 20 : 4), (int)f8.Y + 4 + a6, (int)a3, 10), a2);
                a4.Draw(GetTexture("Widgets/sprites/bfg"), new Vector2((a1 ? 16 : 0) + f8.X, f8.Y + a6), Color.White);
                if (a1) a4.Draw(a5, new Vector2(f8.X, f8.Y + a6), Color.White);
            }
            Height.Set(f2 ? 34 : 18, 0);
            DrawBar(f0.f5, Gradient(f0.f9, f0.f10, f0.f11, Mod0.SD(f1.lavaTime, f1.lavaMax)), Mod0.SD(50 * f1.lavaTime, f1.lavaMax), a0, GetTexture("Widgets/sprites/bli"), f2 ? 16 : 0);
            if ("Always" == f0.f3 || 0 < f1.breath && f1.breath < f1.breathMax || ModPlayer.f1) DrawBar(f0.f5, Gradient(f0.f6, f0.f7, f0.f8, Mod0.SD(f1.breath, f1.breathMax)), Mod0.SD(50 * f1.breath, f1.breathMax), a0, GetTexture("Widgets/sprites/bbi"));
            base.DrawSelf(a0);
            Width.Set(f0.f5 ? 74 : 58, 0);
        }
    }
}