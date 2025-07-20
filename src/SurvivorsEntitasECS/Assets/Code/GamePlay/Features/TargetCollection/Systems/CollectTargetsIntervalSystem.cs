using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
  public class CollectTargetsIntervalSystem : IExecuteSystem
  {
    private readonly ITimeService _time;
    private readonly IGroup<GameEntity> _entities;

    public CollectTargetsIntervalSystem(GameContext game, ITimeService time)
    {
      _time = time;
      _entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.TargetBuffer,
          GameMatcher.CollectTargetsInterval,
          GameMatcher.CollectTargetsTimer));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities)
      {
        entity.ReplaceCollectTargetsTimer(entity.collectTargetsTimer.Value - _time.DeltaTime);

        if (entity.collectTargetsTimer.Value <= 0)
        {
          entity.isReadyToCollectTargets = true;
          entity.ReplaceCollectTargetsTimer(entity.collectTargetsInterval.Value);
        }
      }
    }
  }
}