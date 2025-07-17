using Code.Gameplay.Common.Time;
using Code.GamePlay.Features.Movement.Systems;

namespace Code.GamePlay.Features.Movement
{
    public class MovementFeature : Feature
    {
        public MovementFeature(GameContext gameContext, ITimeService timeService) 
        {
            Add(new DirectionalDeltaMoveSystem(gameContext, timeService));
        }
    }
}