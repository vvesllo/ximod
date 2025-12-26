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
    public abstract class XiModMagic : ModItem
    {
        protected virtual float GetShootAccuracy() => 0f;
     
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Magic;
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
    }
}