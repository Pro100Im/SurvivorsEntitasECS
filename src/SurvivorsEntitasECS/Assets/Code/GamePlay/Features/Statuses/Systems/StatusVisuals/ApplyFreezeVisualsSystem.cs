using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems.StatusVisuals
{
    public class ApplyFreezeVisualsSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _game;

        public ApplyFreezeVisualsSystem(GameContext game) : base(game)
        {
            _game = game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
          context.CreateCollector(GameMatcher.Freeze.Added());

        protected override bool Filter(GameEntity entity) => entity.isStatus && entity.isFreeze && entity.hasTargetId;

        protected override void Execute(List<GameEntity> statuses)
        {
            foreach(GameEntity status in statuses)
            {
                GameEntity target = _game.GetEntityWithId(status.targetId.Value);

                if(target is { hasStatusVisuals: true })
                    target.statusVisuals.Value.ApplyFreeze();
            }
        }
    }
}