using Code.Common.Entity;
using Code.Common.Extensions;
//using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.Effects;
using Code.Infrastructure.Identifiers;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IIdentifierService _identifiers;

        public EnemyFactory(IIdentifierService identifiers)
        {
            _identifiers = identifiers;
        }

        public GameEntity CreateEnemy(EnemyTypeId typeId, Vector3 at)
        {
            switch(typeId)
            {
                case EnemyTypeId.Goblin:
                    return CreateGoblin(at);
            }

            throw new Exception($"Enemy with type id {typeId} does not exist");
        }

        private GameEntity CreateGoblin(Vector2 at)
        {
            //Dictionary<Stats, float> baseStats = InitStats.EmptyStatDictionary()
            //    .With(x => x[Stats.Speed] = 1)
            //    .With(x => x[Stats.MaxHp] = 3)
            //    .With(x => x[Stats.Damage] = 1);

            var entity = CreateEntity.Empty();
            entity.AddId(_identifiers.Next());
            entity.AddEnemyTypeId(EnemyTypeId.Goblin);
            entity.AddWorldPosition(at);
            entity.AddDirection(Vector2.zero);
            //entity.AddBaseStats(baseStats);
            //entity.AddStatModifiers(InitStats.EmptyStatDictionary());
            //entity.AddSpeed(baseStats[Stats.Speed]);
            //entity.AddCurrentHp(baseStats[Stats.MaxHp]);
            //entity.AddMaxHp(baseStats[Stats.MaxHp]);;
            entity.AddSpeed(1);
            entity.AddCurrentHp(3);
            entity.AddMaxHp(3);
            entity.AddEffectSetups(new List<EffectSetup> { new EffectSetup() { EffectTypeId = EffectTypeId.Damage, Value = 1/*baseStats[Stats.Damage]*/ } });
            entity.AddRadius(0.3f);
            entity.AddTargetBuffer(new List<int>(1));
            entity.AddCollectTargetsInterval(0.5f);
            entity.AddCollectTargetsTimer(0f);
            entity.AddLayerMask(CollisionLayer.Hero.AsMask());
            entity.AddViewPath("Gameplay/Enemies/Goblins/Torch/goblin_torch_blue");
            entity.With(x => x.isEnemy = true);
            entity.With(x => x.isTurnedAlongDirection = true);
            entity.With(x => x.isMovementAvailable = true);

            return entity;
        }
    }
}