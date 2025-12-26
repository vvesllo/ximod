using Terraria;
using Terraria.ModLoader;

namespace ximod.Content.Items.Accessories
{ 
	public class PlasticKnife : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 26;

            Item.accessory = true;
            Item.value = Item.buyPrice(silver: 50);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic).Base += 5;
        }
    }
}
