using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Loot.Configs;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Loot.Factory
{
    public class LootFactory : ILootFactory
    {
        private readonly IIdentifierService _identifiers;
        private readonly IStaticDataService _staticDataService;

        public LootFactory(IIdentifierService identifiers, IStaticDataService staticDataService)
        {
            _identifiers = identifiers;
            _staticDataService = staticDataService;
        }

        public GameEntity CreateLootItem(LootTypeId typeId, Vector3 at)
        {
            LootConfig config = _staticDataService.GetLootConfig(typeId);

            var entity = CreateEntity.Empty();
            entity.AddId(_identifiers.Next());
            entity.AddWorldPosition(at);
            entity.AddLootTypeId(typeId);
            entity.AddViewPrefab(config.ViewPrefab);
            entity.With(x => x.AddExperience(config.Experience), when: config.Experience > 0);
            entity.With(x => x.AddEffectSetups(config.EffectSetups), when: !config.EffectSetups.IsNullOrEmpty());
            entity.With(x => x.AddStatusSetups(config.StatusSetups), when: !config.StatusSetups.IsNullOrEmpty());
            entity.With(x => x.isPullable = true);

            return entity;
        }
    }
}