using Code.Gameplay.Common.Time;
using Code.Gameplay.Input.Service;
using Code.GamePlay.Features.Movement;
using Code.GamePlay.Input;

namespace Code.GamePlay.Features
{
    public class BattleFeature : Feature
    {
        public BattleFeature(GameContext gameContext, InputContext inputContext, ITimeService timeService, IInputService inputService)
        {
            Add(new MovementFeature(gameContext, timeService));
            Add(new InputFeature(inputContext, inputService));
        }
    }
}