//using Code.Gameplay.Features.Abilities;
//using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Abilities.Factory;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Levels;
using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
  public class InitializeHeroSystem : IInitializeSystem
  {
        private readonly IHeroFactory _heroFactory;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IAbilityFactory _abilityFactory;

        public InitializeHeroSystem(IHeroFactory heroFactory, ILevelDataProvider levelDataProvider, IAbilityFactory abilityFactory)
        {
            _heroFactory = heroFactory;
            _levelDataProvider = levelDataProvider;
            _abilityFactory = abilityFactory;
        }

        public void Initialize()
        {
            _heroFactory.CreateHero(_levelDataProvider.StartPoint);
            _abilityFactory.CreateVegetableBoltAbility(1);
        }

        //private readonly IAbilityUpgradeService _abilityUpgradeService;

        //public InitializeHeroSystem(IAbilityUpgradeService abilityUpgradeService)
        //{
        //  _abilityUpgradeService = abilityUpgradeService;
        //}

        //public void Initialize()
        //{
        //  _abilityUpgradeService.InitializeAbility(AbilityId.VegetableBolt);
        //}
    }
}