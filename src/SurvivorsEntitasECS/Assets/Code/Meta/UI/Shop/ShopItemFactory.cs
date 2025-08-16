using System;
using Code.Common.Entity;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using Code.Meta.UI.Shop.Items;
using Code.Meta.UI.Shop.Systems;

namespace Code.Meta.UI.Shop
{
    public class ShopItemFactory : IShopItemFactory
    {
        private readonly IStaticDataService _staticData;
        private readonly IIdentifierService _identifiers;

        public ShopItemFactory(IStaticDataService staticData, IIdentifierService identifiers)
        {
            _identifiers = identifiers;
            _staticData = staticData;
        }

        public MetaEntity CreateShopItem(ShopItemId shopItemId)
        {
            ShopItemConfig config = _staticData.GetShopItemConfig(shopItemId);

            switch(config.Kind)
            {
                case ShopItemKind.Booster:
                    var boost = CreateMetaEntity.Empty();
                    //boost.AddId(_identifiers.Next());
                    boost.AddGoldGainBoost(config.Boost);
                    boost.AddDuration(config.Duration);

                    return boost;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}