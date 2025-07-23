using Code.GamePlay.Features.DamageApplication.Systems;
using Code.Infrastructure.Systems;

namespace Code.GamePlay.Features.DamageApplication
{
    public class DamageApplicationFeature : Feature
    {
        public DamageApplicationFeature(ISystemFactory systemFactory) 
        {
            Add(systemFactory.Create<ApplyDamageOnTargetsSystem>());
        }
    }
}