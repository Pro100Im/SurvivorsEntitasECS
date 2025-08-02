using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Abilities.Factory
{
    public class AbilityFactory : IAbilityFactory
    {
        private readonly IIdentifierService _identifiers;
        private readonly IStaticDataService _staticDataService;

        public AbilityFactory(IIdentifierService identifiers, IStaticDataService staticDataService)
        {
            _identifiers = identifiers;
            _staticDataService = staticDataService;
        }

        public GameEntity CreateVegetableBoltAbility(int level)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.VegetableBolt, level);

            var entity = CreateEntity.Empty();

            entity.AddId(_identifiers.Next());
            entity.AddAbilityId(AbilityId.VegetableBolt);
            entity.AddCooldown(abilityLevel.Cooldown);
            entity.With(x => x.isVegetableBoltAbility = true);
            entity.PutOnCooldown();

            return entity;
        }

        public GameEntity CreateOrbitingMushroomAbility(int level)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.OrbitingMushroom, level);

            var entity = CreateEntity.Empty();

            entity.AddId(_identifiers.Next());
            entity.AddAbilityId(AbilityId.OrbitingMushroom);
            entity.AddCooldown(abilityLevel.Cooldown);
            entity.With(x => x.isOrbitingMushroomAbility = true);
            entity.With(x => x.isRecreatedOnUpgrade = true);
            entity.PutOnCooldown();

            return entity;
        }

        public GameEntity CreateGarlicAuraAbility()
        {
            var entity = CreateEntity.Empty();

            entity.AddId(_identifiers.Next());
            entity.AddAbilityId(AbilityId.GarlicAura);
            entity.With(x => x.isGarlicAuraAbility = true);
            entity.With(x => x.isRecreatedOnUpgrade = true);

            return entity;
        }
    }
}