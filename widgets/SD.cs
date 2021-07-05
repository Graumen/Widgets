using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using System.Linq;
using Terraria;
namespace Widgets
{
    class SD : Widget
    {
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
        {
            var txt = $"{Main.projectile.Where(_ => _.timeLeft > 0 && _.WipableTurret).Count()}/{Main.LocalPlayer.maxTurrets}";

            Height.Set(22, 0);
            sb.Draw(GetTexture("Widgets/sprites/sdi"), new Vector2(x, y), Color.White);
            Utils.DrawBorderString(sb, txt, new Vector2(31 + x, y), GetInstance<Config>().sdc);
            base.DrawSelf(sb);
            Width.Set(31 + Main.fontMouseText.MeasureString(txt).X, 0);
        }
    }
}