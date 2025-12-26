using Terraria;
using Terraria.ModLoader;

namespace ximod.Core
{
    public abstract class XiModProjectile : ModProjectile
    {
        protected void UpdateFrame(int speed)
        {
            Projectile.frameCounter++;
            if (Projectile.frameCounter > speed)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
            }
            if (Projectile.frame > Main.projFrames[Projectile.type] - 1)
            {
                Projectile.frame = 0;
            }
        } 

        protected int GetNearestEnemyIndex(float minDistance)
        {
            int nearestEnemyIndex = -1;
            float smallestDistance = minDistance;
            for (int i=0; i < Main.npc.Length; i++)
            {
                NPC entity = Main.npc[i];
                if (entity.active && !entity.friendly)
                {
                    float distance = (entity.Center - Projectile.Center).Length();
                    if (distance < smallestDistance)
                    {
                        smallestDistance = distance;
                        nearestEnemyIndex = i;
                    }
                }
            }
            return nearestEnemyIndex;
        }
    }
}