using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Code.GamePlay.Features.LifeTime.Systems
{
    public class MarkDeadSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(128);

        public MarkDeadSystem(GameContext gameContext)
        {
            _entities = gameContext
                .GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CurrentHp,
                    GameMatcher.MaxHp)
                .NoneOf(GameMatcher.Dead));
        }

        public void Execute()
        {
            foreach(var entity in _entities.GetEntities(_buffer)) 
            {
                if(entity.currentHp.Value <= 0)
                {
                    entity.isDead = true;
                    entity.isProcessingDeath = true;
                }
            }
        }
    }
}