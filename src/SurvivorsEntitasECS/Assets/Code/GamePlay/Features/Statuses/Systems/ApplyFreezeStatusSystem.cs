using System.Collections.Generic;
using Code.Common.Entity;
using Code.Gameplay.Features.CharacterStats;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class ApplyFreezeStatusSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly List<GameEntity> _buffer = new(32);

        public ApplyFreezeStatusSystem(GameContext game)
        {
            _statuses = game.GetGroup(GameMatcher
              .AllOf(
                GameMatcher.Id,
                GameMatcher.Status,
                GameMatcher.Freeze,
                GameMatcher.ProducerId,
                GameMatcher.TargetId,
                GameMatcher.EffectValue)
              .NoneOf(GameMatcher.Affected));
        }

        public void Execute()
        {
            foreach(GameEntity status in _statuses.GetEntities(_buffer))
            {
                var entity = CreateEntity.Empty();

                entity.AddStatChange(Stats.Speed);
                entity.AddTargetId(status.targetId.Value);
                entity.AddProducerId(status.producerId.Value);
                entity.AddEffectValue(status.effectValue.Value);
                entity.AddApplierStatusLink(status.id.Value);

                status.isAffected = true;
            }
        }
    }
}