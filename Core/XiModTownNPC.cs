using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ximod.Content.Items.Accessories;

namespace ximod.Core
{
    class XiModTownNPC : GlobalNPC
    {
        private void ModifyMerchantShop(NPCShop shop)
        {
            shop.Add(ModContent.ItemType<PlasticKnife>());
        }

        public override void ModifyShop(NPCShop shop)
        {
            switch (shop.NpcType)
            {
            case NPCID.Merchant:
                ModifyMerchantShop(shop);
                break;
            default:
                break;
            }
        }
    }
}