using System;
using System.Collections.Generic;
using Code.Gameplay.Common.Physics;
using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
  public class CastForTargetsWithLimitSystem : IExecuteSystem, ITearDownSystem
  {
    private readonly IPhysicsService _physicsService;
    private readonly IGroup<GameEntity> _ready;
    private readonly List<GameEntity> _buffer = new(64);
    private GameEntity[] _targetCastBuffer = new GameEntity[128];

    public CastForTargetsWithLimitSystem(GameContext game, IPhysicsService physicsService)
    {
      _physicsService = physicsService;
      _ready = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.ReadyToCollectTargets,
          GameMatcher.Radius,
          GameMatcher.TargetBuffer,
          GameMatcher.ProcessedTargets,
          GameMatcher.TargetLimit,
          GameMatcher.WorldPosition,
          GameMatcher.LayerMask)
      );
    }

    public void Execute()
    {
      foreach (GameEntity entity in _ready.GetEntities(_buffer))
      {
        for (int i = 0; i < Math.Min(TargetCountInRadius(entity), entity.targetLimit.Value); i++)
        {
          int targetId = _targetCastBuffer[i].id.Value;

          if (!AlreadyProcessed(entity, targetId))
          {
            entity.targetBuffer.Value.Add(targetId);
            entity.processedTargets.Value.Add(targetId);
          }
        }

        if (!entity.isCollectingTargetsContinuously)
          entity.isReadyToCollectTargets = false;
      }
    }

    private bool AlreadyProcessed(GameEntity entity, int targetId)
    {
      return entity.processedTargets.Value.Contains(targetId);
    }

    private int TargetCountInRadius(GameEntity entity)
    {
      return _physicsService.CircleCastNonAlloc(entity.worldPosition.Value, radius: entity.radius.Value, entity.layerMask.Value, _targetCastBuffer);
    }

    public void TearDown()
    {
      _targetCastBuffer = null;
    }
  }
}