using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities.Configs;
//using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class OrbitingMushroomAbilitySystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IArmamentFactory _armamentFactory;
        //private readonly IAbilityUpgradeService _abilityUpgradeService;

        private readonly List<GameEntity> _buffer = new(1);

        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _heroes;

        public OrbitingMushroomAbilitySystem(
          GameContext game,
          IArmamentFactory armamentFactory,
          IStaticDataService staticDataService)
        //IAbilityUpgradeService abilityUpgradeService)
        {
            _staticDataService = staticDataService;
            //_abilityUpgradeService = abilityUpgradeService;
            _armamentFactory = armamentFactory;

            _abilities = game.GetGroup(GameMatcher
              .AllOf(
                GameMatcher.OrbitingMushroomAbility,
                GameMatcher.CooldownUp));

            _heroes = game.GetGroup(GameMatcher
              .AllOf(
                GameMatcher.Hero,
                GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach(GameEntity ability in _abilities.GetEntities(_buffer))
                foreach(GameEntity hero in _heroes)
                {
                    int level = 1;/*_abilityUpgradeService.GetAbilityLevel(AbilityId.OrbitingMushroom);*/
                    AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.OrbitingMushroom, level);

                    int projectileCount = abilityLevel.ProjectileSetup.ProjectileCount;

                    for(int i = 0; i < projectileCount; i++)
                    {
                        float phase = (2 * Mathf.PI * i) / projectileCount;

                        CreateProjectile(hero, phase, level);
                    }

                    ability.PutOnCooldown(abilityLevel.Cooldown);
                }
        }

        private void CreateProjectile(GameEntity hero, float phase, int level)
        {
            var entity = _armamentFactory.CreateMushroom(level, hero.worldPosition.Value + Vector3.up, phase);

            entity.AddProducerId(hero.id.Value);
            entity.AddOrbitCenterPosition(hero.worldPosition.Value);
            entity.AddOrbitCenterFollowTarget(hero.id.Value);
            entity.isMoving = true;
        }
    }
}