using Terraria;
namespace Widgets
{
    class MP : Terraria.ModLoader.ModPlayer
    {
        public static bool pm;
        public static int bd, blink, br, it;
        public override void ProcessTriggers(Terraria.GameInput.TriggersSet _)
        {
            if (Mod0.hk.JustPressed)
            {
                blink = 0;
                Main.NewText("Positioning Mode " + (pm ? "[c/ff0000:Off]" : "[c/00ff00:On]"));
                pm = !pm;
            }
            if (PW.d.md || PW.l.md || PW.r.md || PW.u.md) br++;
        }
        public override void OnHitByNPC(NPC _, int a, bool b) => it = Main.LocalPlayer.immuneTime;
        public override void OnHitByProjectile(Projectile _, int a, bool b) => it = Main.LocalPlayer.immuneTime;
    }
}