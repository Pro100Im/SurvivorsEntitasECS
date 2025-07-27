using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems.StatusVisuals
{
    public class ApplyPoisonVisualsSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _game;

        public ApplyPoisonVisualsSystem(GameContext game) : base(game)
        {
            _game = game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
          context.CreateCollector(GameMatcher.Poison.Added());

        protected override bool Filter(GameEntity entity) => entity.isStatus && entity.isPoison && entity.hasTargetId;

        protected override void Execute(List<GameEntity> statuses)
        {
            foreach(GameEntity status in statuses)
            {
                GameEntity target = _game.GetEntityWithId(status.targetId.Value);

                if(target is { hasStatusVisuals: true })
                    target.statusVisuals.Value.ApplyPoison();
            }
        }
    }
}