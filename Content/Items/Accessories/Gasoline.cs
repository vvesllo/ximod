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
            Item.width = 24;
            Item.height = 30;

            Item.accessory = true;
            Item.rare = ItemRarityID.Green;
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
                .AddIngredient(ItemID.Gel, 15)
                .AddIngredient(RecipeGroupID.IronBar, 7)
                .Register();
        }
    }
}
