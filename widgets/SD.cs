using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using System.Linq;
using Terraria;
namespace Widgets
{
    class SD : Widget
    {
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch a0)
        {
            var f0 = $"{Main.projectile.Where(_ => _.timeLeft > 0 && _.WipableTurret).Count()}/{Main.LocalPlayer.maxTurrets}";

            Height.Set(22, 0);
            a0.Draw(GetTexture("Widgets/sprites/sdi"), new Vector2(f8.X, f8.Y), Color.White);
            Utils.DrawBorderString(a0, f0, new Vector2(31 + f8.X, f8.Y), GetInstance<Config>().f56);
            base.DrawSelf(a0);
            Width.Set(31 + Main.fontMouseText.MeasureString(f0).X, 0);
        }
    }
}