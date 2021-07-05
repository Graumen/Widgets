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
            sb.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((ci.itbi ? 22 : 4) + x, (ci.itbi ? 6 : 4) + y, 50, 10), Color.Black);
            if (!lp.dead) sb.Draw(GetTexture("Widgets/sprites/wp"), new Rectangle((ci.itbi ? 22 : 4) + x, (ci.itbi ? 6 : 4) + y, (int)Mod0.SD(50 * lp.immuneTime, 0 == MP.it ? lp.immuneTime + Mod0.tit : MP.it), 10), Gradient(ci.itbrg, ci.itbsc, ci.itbec, Mod0.SD(lp.immuneTime, 0 == MP.it ? lp.immuneTime + Mod0.tit : MP.it)));
            sb.Draw(GetTexture("Widgets/sprites/bfg"), new Vector2((ci.itbi ? 18 : 0) + x, (ci.itbi ? 2 : 0) + y), Color.White);
            if (ci.itbi) sb.Draw(GetTexture("Widgets/sprites/itbi"), new Vector2(x, y), Color.White);
            base.DrawSelf(sb);
            Width.Set(ci.itbi ? 76 : 58, 0);
        }
    }
}