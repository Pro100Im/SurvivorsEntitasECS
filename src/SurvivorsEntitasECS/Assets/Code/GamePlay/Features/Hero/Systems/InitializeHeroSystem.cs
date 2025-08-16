using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Levels;
using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
  public class InitializeHeroSystem : IInitializeSystem
  {
        private readonly IHeroFactory _heroFactory;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IAbilityUpgradeService _abilityUpgradeService;

        public InitializeHeroSystem(IHeroFactory heroFactory, ILevelDataProvider levelDataProvider, IAbilityUpgradeService abilityUpgradeService)
        {
            _heroFactory = heroFactory;
            _levelDataProvider = levelDataProvider;

            _abilityUpgradeService = abilityUpgradeService;
        }

        public void Initialize()
        {
            //var hero = _heroFactory.CreateHero(_levelDataProvider.StartPoint);
            _abilityUpgradeService.InitializeAbility(AbilityId.VegetableBolt);

            //_abilityFactory.CreateVegetableBoltAbility(1);
            //_abilityFactory.CreateOrbitingMushroomAbility(1);
            //_abilityFactory.CreateGarlicAuraAbility();

            //_statusApplier.ApplyStatus(new Statuses.StatusSetup()
            //{
            //    StatusTypeId = Statuses.StatusTypeId.PoisonEnchant,
            //    Duration = 10
            //}, hero.id.Value, hero.id.Value);

            //_statusApplier.ApplyStatus(new Statuses.StatusSetup()
            //{
            //    StatusTypeId = Statuses.StatusTypeId.ExplosiveEnchant,
            //    Duration = 15
            //}, hero.id.Value, hero.id.Value);
        }
    }
}