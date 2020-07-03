using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
namespace Widgets
{
    class ITB : Widget
    {
        protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
        {
            var ci = GetInstance<Config>();
            var lp = Terraria.Main.LocalPlayer;

            Height.Set(ci.itbi ? 22 : 18, 0);
            sb.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((ci.itbi ? 22 : 4) + (int)tp.X, (ci.itbi ? 6 : 4) + (int)tp.Y, 50, 10), Color.Black);
            if (!lp.dead) sb.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((ci.itbi ? 22 : 4) + (int)tp.X, (ci.itbi ? 6 : 4) + (int)tp.Y, (int)Mod0.SD(50 * lp.immuneTime, 0 == ModPlayer.it ? lp.immuneTime + Mod0.tit : ModPlayer.it), 10), Gradient(ci.itbrg, ci.itbsc, ci.itbec, Mod0.SD(lp.immuneTime, 0 == ModPlayer.it ? lp.immuneTime + Mod0.tit : ModPlayer.it)));
            sb.Draw(GetTexture("Widgets/sprites/bfg"), new Vector2((ci.itbi ? 18 : 0) + tp.X, (ci.itbi ? 2 : 0) + tp.Y), Color.White);
            if (ci.itbi) sb.Draw(GetTexture("Widgets/sprites/itbi"), new Vector2(tp.X, tp.Y), Color.White);
            base.DrawSelf(sb);
            Width.Set(ci.itbi ? 76 : 58, 0);
        }
    }
}