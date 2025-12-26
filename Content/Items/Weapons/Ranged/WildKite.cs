using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using ximod.Content.Items.Ammo;
using ximod.Content.Projectiles.Friendly;
using ximod.Core;

namespace ximod.Content.Items.Weapons.Ranged
{ 
	public class WildKite : ModItem

    {
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.noMelee = true;

            Item.width = 34;
            Item.height = 24;

            Item.damage = 34;

            Item.useTime = 40;
            Item.useAnimation = 40;
            
            Item.knockBack = 2;

            Item.shoot = ModContent.ProjectileType<ThrowingGrenadeProjectile>();
            Item.useAmmo = ModContent.ItemType<ThrowingGrenade>();

            Item.shootSpeed = 15;
        }
    }  
}
