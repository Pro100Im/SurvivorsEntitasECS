using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class VegetableBoltAbilitySystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(4);

        private readonly IArmamentFactory _armamentFactory;
        private readonly IAbilityUpgradeService _abilityUpgradeService;
        private readonly IStaticDataService _staticDataService;

        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _enemies;

        public VegetableBoltAbilitySystem(
          GameContext game,
          IArmamentFactory armamentFactory,
          IAbilityUpgradeService abilityUpgradeService,
          IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _armamentFactory = armamentFactory;
            _abilityUpgradeService = abilityUpgradeService;

            _abilities = game.GetGroup(GameMatcher
              .AllOf(
                GameMatcher.VegetableBoltAbility,
                GameMatcher.CooldownUp));

            _heroes = game.GetGroup(GameMatcher
              .AllOf(
                GameMatcher.Hero,
                GameMatcher.WorldPosition));

            _enemies = game.GetGroup(GameMatcher
              .AllOf(
                GameMatcher.Enemy,
                GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach(GameEntity ability in _abilities.GetEntities(_buffer))
                foreach(GameEntity hero in _heroes)
                {
                    if(_enemies.count <= 0)
                        continue;

                    var level = _abilityUpgradeService.GetAbilityLevel(AbilityId.VegetableBolt);
                    var entity = _armamentFactory.CreateVegetableBolt(level, hero.worldPosition.Value);

                    entity.AddProducerId(hero.id.Value);
                    entity.ReplaceDirection((FirstAvailableTarget().worldPosition.Value - hero.worldPosition.Value).normalized);
                    entity.With(x => x.isMoving = true);

                    ability
                      .PutOnCooldown(_staticDataService.GetAbilityLevel(AbilityId.VegetableBolt, level).Cooldown);
                }
        }

        private GameEntity FirstAvailableTarget()
        {
            return _enemies.AsEnumerable().First();
        }
    }
}