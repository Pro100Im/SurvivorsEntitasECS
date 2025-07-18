using Entitas;
using UnityEngine;

namespace Code.GamePlay.Features.Movement.Systems
{
    public class AnimateHeroMovementSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;

        public AnimateHeroMovementSystem(GameContext gameContext)
        {
            _heroes = gameContext
                .GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero, GameMatcher.HeroAnimator));
        }

        public void Execute()
        {
            foreach(var hero in _heroes)
            {
                if(hero.isMoving)
                    hero.heroAnimator.Value.PlayMove();
                else
                    hero.heroAnimator.Value.PlayIdle();
            }
        }
    }
}
