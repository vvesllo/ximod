using Microsoft.Xna.Framework;
using Terraria;
using ximod.Core;

namespace ximod.Content.Projectiles.Friendly
{ 
	public class ThrowingGrenadeProjectile : XiModProjectile
    {
       

        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;

            Projectile.hostile = false;
            Projectile.friendly = true;

            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;

            Projectile.penetrate = -1;
            Projectile.timeLeft = 5 * 60;
        }
    }
}
