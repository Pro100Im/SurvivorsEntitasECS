using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems.StatusVisuals
{
    public class UnapplyPoisonVisualsSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _game;

        public UnapplyPoisonVisualsSystem(GameContext game) : base(game)
        {
            _game = game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
          context.CreateCollector(GameMatcher
            .AllOf(
              GameMatcher.Poison,
              GameMatcher.Status,
              GameMatcher.Unapplied)
            .Added());

        protected override bool Filter(GameEntity entity) => entity.isStatus && entity.isPoison && entity.hasTargetId;

        protected override void Execute(List<GameEntity> statuses)
        {
            foreach(GameEntity status in statuses)
            {
                GameEntity target = _game.GetEntityWithId(status.targetId.Value);

                if(target is { hasStatusVisuals: true })
                    target.statusVisuals.Value.UnapplyPoison();
            }
        }
    }
}