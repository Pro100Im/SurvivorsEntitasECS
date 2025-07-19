using Code.GamePlay.Features.Hero;
using Code.GamePlay.Features.Movement;
using Code.GamePlay.Input;
using Code.Infrastructure.Systems;

namespace Code.GamePlay.Features
{
    public class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InputFeature>());
            Add(systemFactory.Create<HeroFeature>());
            Add(systemFactory.Create<MovementFeature>());
        }
    }
}