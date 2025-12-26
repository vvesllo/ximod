using Terraria;
using Terraria.ModLoader;
using ximod.Content.Projectiles.Friendly;
using ximod.Core;

namespace ximod.Content.Items.Weapons.Magic
{ 
	public class AncientTome : XiModMagic
    {
        protected override float GetShootAccuracy() => 5f;
        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.width = 28;
            Item.height = 30;

            Item.damage = 14;

            Item.useTime = 30;
            Item.useAnimation = 30;
            
            Item.mana = 5;

            Item.knockBack = 10;

            Item.shoot = ModContent.ProjectileType<AncientTomeProjectile>();
            Item.shootSpeed = 10f;
        }
    }
}
