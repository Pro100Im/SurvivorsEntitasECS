using Code.Common.Extensions;
using Entitas;
using UnityEngine;

namespace Code.GamePlay.Features.Movement.Systems
{
    public class TurnAlongDirectionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;

        public TurnAlongDirectionSystem(GameContext gameContext)
        {
            _movers = gameContext
                .GetGroup(GameMatcher
                .AllOf(GameMatcher.TurnedAlongDirection, GameMatcher.Direction, GameMatcher.SpriteRenderer));
        }

        public void Execute()
        {
            foreach(var mover in _movers)
            {
                var scaleX = Mathf.Abs(mover.spriteRenderer.Value.transform.localScale.x);
                var faceDir = mover.direction.Value.x < 0 ? -1 : 1;

                mover.spriteRenderer.Value.transform.SetScaleX(scaleX * faceDir);
            }
        }
    }
}
