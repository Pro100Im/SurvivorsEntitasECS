using Code.Gameplay.Features.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class EnemyDeathSystem : IExecuteSystem
    {
        private const float DeathAnimationTime = 2;

        private readonly IGroup<GameEntity> _enemies;

        public EnemyDeathSystem(GameContext game)
        {
            _enemies = game.GetGroup(GameMatcher
              .AllOf(
                GameMatcher.Enemy,
                GameMatcher.EnemyAnimator,
                GameMatcher.Dead,
                GameMatcher.ProcessingDeath));
        }

        public void Execute()
        {
            foreach(GameEntity enemy in _enemies)
            {
                enemy.isMovementAvailable = false;
                enemy.isTurnedAlongDirection = false;

                enemy.RemoveTargetCollectionComponents();
                enemy.enemyAnimator.Value.PlayDied();
                enemy.ReplaceSelfDestructTimer(DeathAnimationTime);
            }
        }
    }
}