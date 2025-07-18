using Entitas;
using UnityEngine;

namespace Code.GamePlay.Features.Hero.Systems
{
    public class SetHeroDiractionalByInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<InputEntity> _inputs;

        public SetHeroDiractionalByInputSystem(GameContext gameContext, InputContext inputContext)
        {
            _heroes = gameContext.GetGroup(GameMatcher.Hero);
            _inputs = inputContext.GetGroup(InputMatcher.Input);
        }

        public void Execute()
        {
            foreach(var input in _inputs)
            {
                foreach(var hero in _heroes)
                {
                    hero.isMoving = input.hasAxisInput;

                    if(input.hasAxisInput)
                        hero.ReplaceDirection(input.axisInput.Value.normalized);
                }
            }
        }
    }
}