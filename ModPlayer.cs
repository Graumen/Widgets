using Terraria;
namespace Widgets
{
    class ModPlayer : Terraria.ModLoader.ModPlayer
    {
        public static bool f0, f1;
        public static int f2, f3, f4;
        public override void OnHitByNPC(NPC a0, int a1, bool a2) => f4 = Main.LocalPlayer.immuneTime;
        public override void OnHitByProjectile(Projectile a0, int a1, bool a2) => f4 = Main.LocalPlayer.immuneTime;
        public override void ProcessTriggers(Terraria.GameInput.TriggersSet a0)
        {
            if (Mod0.f9.JustPressed)
            {
                f2 = 0;
                Main.NewText("Positioning Mode " + (f1 ? "[c/ff0000:Off]" : "[c/00ff00:On]"));
                f1 = !f1;
            }
        }
    }
}