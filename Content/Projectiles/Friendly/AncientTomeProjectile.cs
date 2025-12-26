using Microsoft.Xna.Framework;
using Terraria;
using ximod.Core;

namespace ximod.Content.Projectiles.Friendly
{ 
	public class AncientTomeProjectile : XiModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;

            Projectile.hostile = false;
            Projectile.friendly = true;

            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;

            Projectile.penetrate = -1;
            Projectile.timeLeft = 5 * 60;
        }

        public override void AI()
        {
            UpdateFrame(1);

            int targetIndex = GetNearestEnemyIndex(200f);
            if (targetIndex < 0)
            {
                Projectile.velocity *= 0.95f;
            }
            else
            {
                NPC target = Main.npc[targetIndex];

                Vector2 direction = target.Center - Projectile.Center;
                Vector2 directionNormalized = Vector2.Normalize(direction);
            
                Projectile.velocity = Vector2.Lerp(
                    Projectile.velocity, 
                    directionNormalized * 5f,
                    0.08f
                );
            }

            Lighting.AddLight(
                Projectile.Center,
                new Vector3(0.2f, 0.2f, 0)
            );
        }
    }
}
