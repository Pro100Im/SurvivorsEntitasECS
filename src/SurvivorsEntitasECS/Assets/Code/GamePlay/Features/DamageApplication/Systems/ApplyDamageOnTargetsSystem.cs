using Entitas;

namespace Code.GamePlay.Features.DamageApplication.Systems
{
    public class ApplyDamageOnTargetsSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;

        private readonly IGroup<GameEntity> _damageDealers;
        public ApplyDamageOnTargetsSystem(GameContext gameContext)
        {
            _gameContext = gameContext;

            _damageDealers = _gameContext.GetGroup(GameMatcher
                .AllOf(
                GameMatcher.TargetBuffer,
                GameMatcher.Damage));
        }

        public void Execute()
        {
            foreach(var damageDealer in _damageDealers)
            {
                foreach(var targetId in damageDealer.targetBuffer.Value)
                {
                    var target = _gameContext.GetEntityWithId(targetId);

                    if(!target.hasCurrentHp)
                        continue;

                    target.ReplaceCurrentHp(target.currentHp.Value - damageDealer.damage.Value);

                    if(!target.hasDamageTakenAnimator)
                        continue;

                    target.damageTakenAnimator.Value.PlayDamageTaken();
                }
            }
        }
    }
}