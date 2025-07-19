using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Cameras.Systems;
using Code.GamePlay.Features.Hero.Systems;
using Code.GamePlay.Features.Movement.Systems;

namespace Code.GamePlay.Features.Hero
{
    public class HeroFeature : Feature
    {
        public HeroFeature(GameContext gameContext, InputContext inputContext, ICameraProvider cameraProvider)
        {
            Add(new SetHeroDiractionalByInputSystem(gameContext, inputContext));
            Add(new CameraFollowHeroSystem(gameContext, cameraProvider));
            Add(new AnimateHeroMovementSystem(gameContext));
        }
    }
}