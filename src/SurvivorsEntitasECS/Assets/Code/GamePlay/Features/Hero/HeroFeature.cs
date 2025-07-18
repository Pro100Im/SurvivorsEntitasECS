using Code.GamePlay.Features.Hero.Systems;
using Code.GamePlay.Features.Movement.Systems;

namespace Code.GamePlay.Features.Hero
{
    public class HeroFeature : Feature
    {
        public HeroFeature(GameContext gameContext, InputContext inputContext)
        {
            Add(new SetHeroDiractionalByInputSystem(gameContext, inputContext));
            Add(new AnimateHeroMovementSystem(gameContext));
        }
    }
}