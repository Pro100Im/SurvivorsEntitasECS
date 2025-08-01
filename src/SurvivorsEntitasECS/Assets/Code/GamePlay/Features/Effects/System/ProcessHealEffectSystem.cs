using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Effects.Systems
{
    public class ProcessHealEffectSystem : IExecuteSystem
    {
        private readonly GameContext _game;

        private readonly IGroup<GameEntity> _effects;

        public ProcessHealEffectSystem(GameContext game)
        {
            _game = game;

            _effects = game.GetGroup(GameMatcher
              .AllOf(
                GameMatcher.HealEffect,
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

                if(target.hasCurrentHp && target.hasMaxHp)
                {
                    float newValue = Mathf.Min(target.currentHp.Value + effect.effectValue.Value, target.maxHp.Value);
                    target.ReplaceCurrentHp(newValue);
                }
            }
        }
    }
}