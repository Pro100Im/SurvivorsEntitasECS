using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Effects.Factory;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class PeriodicDamageStatusSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        private readonly IEffectFactory _effectFactory;
        private readonly IGroup<GameEntity> _statuses;

        public PeriodicDamageStatusSystem(GameContext game, ITimeService timeService, IEffectFactory effectFactory)
        {
            _timeService = timeService;
            _effectFactory = effectFactory;
            _statuses = game.GetGroup(GameMatcher
              .AllOf(
                GameMatcher.Status,
                GameMatcher.Period,
                GameMatcher.TimeSinceLastTick,
                GameMatcher.EffectValue,
                GameMatcher.ProducerId,
                GameMatcher.TargetId));
        }

        public void Execute()
        {
            foreach(GameEntity status in _statuses)
            {
                if(status.timeSinceLastTick.Value >= 0)
                    status.ReplaceTimeSinceLastTick(status.timeSinceLastTick.Value - _timeService.DeltaTime);
                else
                {
                    status.ReplaceTimeSinceLastTick(status.period.Value);

                    _effectFactory.CreateEffect(new EffectSetup { EffectTypeId = EffectTypeId.Damage, Value = status.effectValue.Value },
                      status.producerId.Value,
                      status.targetId.Value);
                }
            }
        }
    }
}