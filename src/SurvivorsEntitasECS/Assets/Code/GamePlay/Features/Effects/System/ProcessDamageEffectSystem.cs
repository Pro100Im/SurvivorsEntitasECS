using Entitas;

namespace Code.Gameplay.Features.Effects.Systems
{
    public class ProcessDamageEffectSystem : IExecuteSystem
    {

        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _effects;

        public ProcessDamageEffectSystem(GameContext game)
        {
            _game = game;

            _effects = game.GetGroup(GameMatcher
              .AllOf(
                GameMatcher.DamageEffect,
                GameMatcher.EffectValue,
                GameMatcher.TargetId));
        }

        public void Execute()
        {
            foreach(GameEntity effect in _effects)
            {
                GameEntity target = _game.GetEntityWithId(effect.targetId.Value);

                effect.isProcessed = true;

                if(target.isDead)
                    continue;

                target.ReplaceCurrentHp(target.currentHp.Value - effect.effectValue.Value);

                if(target.hasDamageTakenAnimator)
                    target.damageTakenAnimator.Value.PlayDamageTaken();
            }
        }
    }
}