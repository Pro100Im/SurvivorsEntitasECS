using Code.GamePlay.Features.LifeTime.Systems;
using Code.Infrastructure.Systems;

namespace Code.GamePlay.Features.LifeTime
{
    public class DeathFeature : Feature
    {
        public DeathFeature(ISystemFactory systemFactory) 
        {
            Add(systemFactory.Create<MarkDeadSystem>());
        }
    }
}