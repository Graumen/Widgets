using Microsoft.Xna.Framework;
using static Terraria.Main;
using static Terraria.ModLoader.ModContent;
namespace Widgets
{
    class FTB : Widget
    {
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch a0)
        {
            var f0 = GetInstance<Config>();
            var f1 = LocalPlayer;
            var f2 = f1.carpetTime;
            var f3 = f1.wingTime;

            Height.Set(f0.f16 ? 22 : 18, 0);
            if ((0 < f1.jump || f1.releaseJump) && 1 < Mod0.f8) Terraria.Utils.DrawBorderString(a0, "" + Mod0.f8, new Vector2((f0.f16 ? 85 : 63) + f8.X, f8.Y), Color.White);
            a0.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((f0.f16 ? 26 : 4) + (int)f8.X, (f0.f16 ? 6 : 4) + (int)f8.Y, 50, 10), Color.Black);
            if (0 == f1.velocity.Y && f1.releaseJump || Mod0.f1) a0.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((f0.f16 ? 26 : 4) + (int)f8.X, (f0.f16 ? 6 : 4) + (int)f8.Y, Mod0.f2 ? 50 : 0 < f1.jump ? (int)Mod0.SD(50 * f1.jump, f1.jump + Mod0.f3) : f1.mount.Active ? (int)Mod0.SD(50 * f1.mount.FlyTime, f1.mount.FlyTime + Mod0.f3) : 0 < f3 ? (int)Mod0.SD(50 * f3, Mod0.f3 + f3) : 0 < f1.rocketTime ? (int)Mod0.SD(50 * f1.rocketTime, f1.rocketTimeMax) : (int)Mod0.SD(50 * f2, f2 + Mod0.f3), 10), Gradient(f0.f17, f0.f18, f0.f19, Mod0.f2 ? 1 : 0 < f1.jump ? Mod0.SD(f1.jump, f1.jump + Mod0.f3) : f1.mount.Active ? Mod0.SD(f1.mount.FlyTime, f1.mount.FlyTime + Mod0.f3) : 0 < f3 ? Mod0.SD(f3, Mod0.f3 + f3) : 0 < f1.rocketTime ? Mod0.SD(f1.rocketTime, f1.rocketTimeMax) : Mod0.SD(f2, f2 + Mod0.f3)));
            a0.Draw(GetTexture("Widgets/sprites/bfg"), new Vector2((f0.f16 ? 22 : 0) + f8.X, (f0.f16 ? 2 : 0) + f8.Y), Color.White);
            if (f0.f16) a0.Draw((0 < Mod0.f8 || 0 == f1.velocity.Y) && f1.releaseJump || 0 < f1.jump ? GetTexture("Widgets/sprites/ftbi2") : Mod0.f1 ? 0 < f3 || f1.mount.Active ? GetTexture("Widgets/sprites/ftbi4") : 0 < f1.rocketBoots && 0 < f1.rocketTime ? GetTexture("Widgets/sprites/ftbi3") : GetTexture("Widgets/sprites/ftbi") : GetTexture("Widgets/sprites/ftbi5"), new Vector2(f8.X, f8.Y), Color.White);
            base.DrawSelf(a0);
            Width.Set((1 < Mod0.f8 ? 5 + fontMouseText.MeasureString("" + Mod0.f8).X : 0) + (f0.f16 ? 80 : 58), 0);
        }
    }
}