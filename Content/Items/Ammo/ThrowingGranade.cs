using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using ximod.Content.Projectiles.Friendly;

namespace ximod.Content.Items.Ammo
{
    public class ThrowingGrenade : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 10;
            Item.height = 10;

            Item.damage = 67;
            Item.DamageType = DamageClass.Ranged;
            Item.maxStack = 9999; // The maximum number of items that can be contained within a single stack
            Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible
            Item.knockBack = 2f; // Sets the item's knockback. Ammunition's knockback added together with weapon and projectiles.
            Item.value = 1000; // Item price in copper coins (can be converted with Item.sellPrice/Item.buyPrice)
            Item.rare = ItemRarityID.Green; // The color that the item's name will be in-game.
            Item.shoot = ModContent.ProjectileType<ThrowingGrenadeProjectile>();
            Item.ammo = Item.type;


        }
    }
}
