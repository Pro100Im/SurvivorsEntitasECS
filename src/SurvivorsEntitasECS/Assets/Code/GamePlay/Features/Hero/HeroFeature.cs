using Code.Gameplay.Cameras.Systems;
using Code.GamePlay.Features.Hero.Systems;
using Code.GamePlay.Features.Movement.Systems;
using Code.Infrastructure.Systems;

namespace Code.GamePlay.Features.Hero
{
    public class HeroFeature : Feature
    {
        public HeroFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<SetHeroDiractionalByInputSystem>());
            Add(systemFactory.Create<CameraFollowHeroSystem>());
            Add(systemFactory.Create<AnimateHeroMovementSystem>());
        }
    }
}