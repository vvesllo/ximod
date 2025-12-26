using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace ximod.Core
{
    public abstract class XiModRanged : ModItem
    {
        protected virtual double GetAmmoConservationChance() => 0f;
        protected virtual float GetShootAccuracy() => 0f;
        protected virtual bool IsAllowedAmmo(Item ammo) => false;
        protected virtual int GetProjectileFromItem(int itemType) => 0;
        protected bool ShootSpecial(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int selectedAmmoType = 0;
            int selectedItem = -1;

            for (int i = 0; i < player.inventory.Length; i++)
            {
                Item item = player.inventory[i];
                if (item.stack > 0 && IsAllowedAmmo(item))
                {
                    selectedAmmoType = GetProjectileFromItem(item.type);
                    selectedItem = i;
                    break;
                }
            }

            if (selectedAmmoType == 0)
                return false;
                
            player.inventory[selectedItem].stack--;

            Projectile.NewProjectile(
                source, 
                position, 
                velocity, 
                selectedAmmoType, 
                damage, 
                knockback, 
                player.whoAmI
            );

            return false;
        }

        private int GetTotalAmmoCount(Player player)
        {
            int ammoCount = 0;
            foreach (Item item in player.inventory)
            {
                if (item.stack > 0 && IsAllowedAmmo(item))
                    ammoCount += item.stack;
            }
            return ammoCount;
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.noMelee = true;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            float shootAccuracy = GetShootAccuracy();
            
            velocity = velocity.RotatedBy(MathHelper.ToRadians(Main.rand.NextFloat(
                -shootAccuracy, 
                shootAccuracy
            )));
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() > GetAmmoConservationChance();
        }
        
        public override bool CanUseItem(Player player)
        {
            foreach (Item item in player.inventory)
            {
                if (item.stack > 0 && IsAllowedAmmo(item))
                    return true;
            }
            return false;
        }
        public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Player player = Main.LocalPlayer;
            if (!player.active)
                return;
         
            int ammoCount = GetTotalAmmoCount(player);
            string text = ammoCount.ToString();

            Vector2 offset = new Vector2(
                -frame.Width / 2f - 2f,
                frame.Height / 2f - 5f
            );
         
            Vector2 drawPosition = position + offset * scale;


            Utils.DrawBorderString(
                spriteBatch,
                text,
                drawPosition,
                Color.White,
                scale * 0.7f
            );
        }
    }    
}