using Terraria.ModLoader;

namespace ximod.Core
{
    class XiModPlayer : ModPlayer
    {
        public bool accessoryGasoline;

        public override void ResetEffects()
        {
            accessoryGasoline = false;
        }
    }
}