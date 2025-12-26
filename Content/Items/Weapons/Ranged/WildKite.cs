using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using ximod.Core;

namespace ximod.Content.Items.Weapons.Ranged
{ 
	public class WildKite : XiModRanged
    {
        protected override float GetShootAccuracy() => 15f;
        protected override double GetAmmoConservationChance() => 0.5f;
        protected override bool IsAllowedAmmo(Item ammo)
        {
            return ammo.type == ItemID.Grenade 
                || ammo.type == ItemID.BouncyGrenade 
                || ammo.type == ItemID.StickyGrenade 
                || ammo.type == ItemID.Beenade;
        }

        protected override int GetProjectileFromItem(int itemType)
        {
            return itemType switch
            {
                ItemID.Grenade => ProjectileID.Grenade,
                ItemID.BouncyGrenade => ProjectileID.BouncyGrenade,
                ItemID.StickyGrenade => ProjectileID.StickyGrenade,
                ItemID.Beenade => ProjectileID.Beenade,
                _ => 0
            };
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.width = 34;
            Item.height = 24;

            Item.damage = 67;

            Item.useTime = 45;
            Item.useAnimation = 45;
            
            Item.knockBack = 2;

            Item.shoot = ProjectileID.Grenade;
            
            Item.shootSpeed = 10;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            return ShootSpecial(
                player,
                source,
                position,
                velocity,
                type,
                damage,
                knockback
            );
        }
    }
}
