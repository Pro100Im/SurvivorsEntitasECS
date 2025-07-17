using Code.Gameplay.Common.Time;
using Code.GamePlay.Features.Movement;

namespace Code.GamePlay.Features
{
    public class BattleFeature : Feature
    {
        public BattleFeature(GameContext gameContext, ITimeService timeService)
        {
            Add(new MovementFeature(gameContext, timeService));
        }
    }
}