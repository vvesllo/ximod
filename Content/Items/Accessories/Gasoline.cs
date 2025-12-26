using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ximod.Core;

namespace ximod.Content.Items.Accessories
{ 
	public class Gasoline : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;

            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<XiModPlayer>().accessoryGasoline = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddTile(TileID.Anvils)
                .AddIngredient(ItemID.Dynamite, 1)
                .AddIngredient(ItemID.Torch, 25)
                .AddIngredient(ItemID.Gel, 5)
                .AddIngredient(RecipeGroupID.IronBar, 7)
                .Register();
        }
    }
}
