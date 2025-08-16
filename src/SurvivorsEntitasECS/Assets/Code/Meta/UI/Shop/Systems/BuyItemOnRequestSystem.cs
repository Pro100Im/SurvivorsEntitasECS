using Code.Common.Entity;
using Code.Meta.UI.Shop.Items;
using Code.Meta.UI.Shop.Service;
using Entitas;

namespace Code.Meta.UI.Shop.Systems
{
    public class BuyItemOnRequestSystem : IExecuteSystem
    {
        private readonly IGroup<MetaEntity> _shopItemPurchaseRequests;
        private readonly IGroup<MetaEntity> _storages;
        private IShopUIService _shopUIService;

        public BuyItemOnRequestSystem(MetaContext meta, IShopUIService shopUIService)
        {
            _shopUIService = shopUIService;

            _storages = meta.GetGroup(MetaMatcher
              .AllOf(
                MetaMatcher.Storage,
                MetaMatcher.Gold));

            _shopItemPurchaseRequests = meta.GetGroup(MetaMatcher
              .AllOf(
                MetaMatcher.BuyRequest,
                MetaMatcher.ShopItemId));
        }

        public void Execute()
        {
            foreach(MetaEntity storage in _storages)
            {
                foreach(MetaEntity request in _shopItemPurchaseRequests)
                {
                    ShopItemConfig config = _shopUIService.GetConfig(request.shopItemId.Value);

                    if(storage.gold.Value >= config.Price)
                    {
                        storage.ReplaceGold(storage.gold.Value - config.Price);

                        var stopItem = CreateMetaEntity.Empty();

                        stopItem.AddShopItemId(request.shopItemId.Value);
                        stopItem.isPurchased = true;

                        _shopUIService.UpdatePurchasedItem(request.shopItemId.Value);
                    }

                    request.isDestructed = true;
                }
            }
        }
    }
}