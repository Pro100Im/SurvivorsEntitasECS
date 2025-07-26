using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Effects.Systems
{
    public class RemoveEffectsWithoutTargetsSystem : IExecuteSystem
    {
        private readonly GameContext _game;

        private readonly IGroup<GameEntity> _effects;
        private readonly List<GameEntity> _buffer = new(128);

        public RemoveEffectsWithoutTargetsSystem(GameContext game)
        {
            _game = game;

            _effects = game.GetGroup(GameMatcher
              .AllOf(
                GameMatcher.Effect,
                GameMatcher.TargetId));
        }

        public void Execute()
        {
            foreach(GameEntity effect in _effects.GetEntities(_buffer))
            {
                GameEntity target = _game.GetEntityWithId(effect.targetId.Value);

                if(target == null)
                    effect.Destroy();
            }
        }
    }
}