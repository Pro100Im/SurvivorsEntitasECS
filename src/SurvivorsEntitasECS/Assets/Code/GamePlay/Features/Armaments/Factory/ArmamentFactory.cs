using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
//using Code.Gameplay.Features.Enchants;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public class ArmamentFactory : IArmamentFactory
    {
        private const int TargetBufferSize = 16;

        private readonly IIdentifierService _identifiers;
        private readonly IStaticDataService _staticDataService;

        public ArmamentFactory(IIdentifierService identifiers, IStaticDataService staticDataService)
        {
            _identifiers = identifiers;
            _staticDataService = staticDataService;
        }

        public GameEntity CreateVegetableBolt(int level, Vector3 at)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.VegetableBolt, level);
            ProjectileSetup setup = abilityLevel.ProjectileSetup;

            var entity = CreateProjectileEntity(at, abilityLevel, setup);
            entity.AddParentAbility(AbilityId.VegetableBolt);
            entity.With(x => x.isRotationAlignedAlongDirection = true);

            return entity;
        }

        public GameEntity CreateMushroom(int level, Vector3 at, float phase)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.OrbitingMushroom, level);
            ProjectileSetup setup = abilityLevel.ProjectileSetup;

            var entity = CreateProjectileEntity(at, abilityLevel, setup);
            entity.AddParentAbility(AbilityId.OrbitingMushroom);
            entity.AddOrbitPhase(phase);
            entity.AddOrbitRadius(setup.OrbitRadius);

            return entity;
        }

        public GameEntity CreateEffectAura(AbilityId parentAbilityId, int producerId, int level)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.GarlicAura, level);
            AuraSetup setup = abilityLevel.AuraSetup;

            var entity = CreateEntity.Empty();
            entity.AddId(_identifiers.Next());
            entity.AddParentAbility(parentAbilityId);
            entity.AddViewPrefab(abilityLevel.ViewPrefab);
            entity.AddLayerMask(CollisionLayer.Enemy.AsMask());
            entity.AddRadius(setup.Radius);
            entity.AddCollectTargetsInterval(setup.Interval);
            entity.AddCollectTargetsTimer(0);
            entity.AddTargetBuffer(new List<int>(TargetBufferSize));
            entity.With(x => x.AddEffectSetups(abilityLevel.EffectSetups), when: !abilityLevel.EffectSetups.IsNullOrEmpty());
            entity.With(x => x.AddStatusSetups(abilityLevel.StatusSetups), when: !abilityLevel.StatusSetups.IsNullOrEmpty());
            entity.AddProducerId(producerId);
            entity.AddWorldPosition(Vector3.zero);
            entity.With(x => x.isFollowingProducer = true);

            return entity;
        }

        private GameEntity CreateProjectileEntity(Vector3 at, AbilityLevel abilityLevel, ProjectileSetup setup)
        {
            var entity = CreateEntity.Empty();
            entity.AddId(_identifiers.Next());
            entity.With(x => x.isArmament = true);
            entity.AddViewPrefab(abilityLevel.ViewPrefab);
            entity.AddWorldPosition(at);
            entity.AddSpeed(setup.Speed);
            entity.With(x => x.AddEffectSetups(abilityLevel.EffectSetups), when: !abilityLevel.EffectSetups.IsNullOrEmpty());
            entity.With(x => x.AddStatusSetups(abilityLevel.StatusSetups), when: !abilityLevel.StatusSetups.IsNullOrEmpty());
            entity.With(x => x.AddTargetLimit(setup.Pierce), when: setup.Pierce > 0);
            entity.AddRadius(setup.ContactRadius);
            entity.AddTargetBuffer(new List<int>(TargetBufferSize));
            entity.AddProcessedTargets(new List<int>(TargetBufferSize));
            entity.AddLayerMask(CollisionLayer.Enemy.AsMask());
            entity.With(x => x.isMovementAvailable = true);
            entity.With(x => x.isReadyToCollectTargets = true);
            entity.With(x => x.isCollectingTargetsContinuously = true);
            entity.AddSelfDestructTimer(setup.Lifetime);

            return entity;
        }

        public GameEntity CreateExplosion(int producerId, Vector3 at)
        {
            //EnchantConfig config = _staticDataService.GetEnchantConfig(EnchantTypeId.ExplosiveArmaments);

            var entity = CreateEntity.Empty();
            entity.AddId(_identifiers.Next());
            entity.AddLayerMask(CollisionLayer.Enemy.AsMask());
            //entity.AddRadius(config.Radius);
            entity.AddTargetBuffer(new List<int>(TargetBufferSize));
            //entity.With(x => x.AddEffectSetups(config.EffectSetups), when: !config.EffectSetups.IsNullOrEmpty());
            //entity.With(x => x.AddStatusSetups(config.StatusSetups), when: !config.StatusSetups.IsNullOrEmpty());
            //entity.AddViewPrefab(config.ViewPrefab);
            entity.AddProducerId(producerId);
            entity.AddWorldPosition(at);
            entity.With(x => x.isReadyToCollectTargets = true);
            entity.AddSelfDestructTimer(1);

            return entity;
        }

    }
}