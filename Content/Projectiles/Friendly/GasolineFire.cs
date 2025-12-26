using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ximod.Content.Projectiles.Friendly
{ 
	public class GasolineFire : ModProjectile
    {
        private bool isTileCollided=false;

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            Projectile.width = 6;
            Projectile.height = 6;

            Projectile.hostile = false;
            Projectile.friendly = true;

            Projectile.penetrate = -1;
            Projectile.timeLeft = Main.rand.Next(120, 180);
        }
        
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            isTileCollided = true;
            return false;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.OnFire, 3 * 60);
        }

        public override void AI()
        {
            Projectile.frame = (Projectile.frame + 1) % Main.projFrames[Projectile.type];

            if (isTileCollided)
            {
                Projectile.velocity *= 0;
            }
            else
            {
                Projectile.velocity.Y += 0.2f;
            }            

            Projectile.rotation += (float)Projectile.velocity.Length() / 0.1f;

            Dust.NewDust(
                Projectile.Center,
                3, 3,
                DustID.Flare,
                Main.rand.NextFloat(-2f, 3f), -5f
            );

            Lighting.AddLight(
                Projectile.Center,
                new Vector3(1f, 0.8f, 0)
            );
        }
    }
}
