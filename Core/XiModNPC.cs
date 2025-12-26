using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using ximod.Content.Items.Weapons.Magic;
using ximod.Content.Projectiles.Friendly;

namespace ximod.Core
{
    class XiModNPC : GlobalNPC
    {
        private void GasolineFireExplosion(NPC npc, Player player, NPC.HitInfo hit)
        {
            for (int i=0; i < 5; i++)
            {
                Vector2 velocity = new Vector2(0, -Main.rand.NextFloat(3f, 10f));

                Projectile.NewProjectile(
                    player.GetSource_OnHit(npc),
                    npc.Center,
                    velocity.RotatedBy(
                        MathHelper.ToRadians(
                            Main.rand.NextFloat(-50f, 50f)
                        )
                    ),
                    ModContent.ProjectileType<GasolineFire>(),
                    10, 0f
                );
            }
        }

        private void OnKill(NPC npc, Player player, NPC.HitInfo hit)
        {
            if (player.GetModPlayer<XiModPlayer>().accessoryGasoline) 
                GasolineFireExplosion(npc, player, hit);
        }
        public override void OnHitByItem(NPC npc, Player player, Item item, NPC.HitInfo hit, int damageDone)
        {
            if (npc.life < 0) OnKill(npc, player, hit);
        }

        public override void OnHitByProjectile(NPC npc, Projectile projectile, NPC.HitInfo hit, int damageDone)
        {
            if (npc.life < 0) OnKill(npc, Main.player[projectile.owner], hit);
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            switch (npc.type)
            {
            case NPCID.SandSlime: 
            case NPCID.Vulture: 
            case NPCID.Antlion:
                npcLoot.Add(
                    ItemDropRule.Common(
                        ModContent.ItemType<AncientTome>(),
                        20
                    )
                );
                break;
            }
        }
    }
}