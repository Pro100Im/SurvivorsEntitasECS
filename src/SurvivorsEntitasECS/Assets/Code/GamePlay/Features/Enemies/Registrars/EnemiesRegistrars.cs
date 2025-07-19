using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.GamePlay.Features.Enemies.Registrars
{
    public class EnemiesRegistrars : EntityComponentRegistrar
    {
        [SerializeField] private float _speed = 1f;

        public override void RegisterComponents()
        {
            Entity.AddWorldPosition(transform.position);
            Entity.AddDirection(Vector2.zero);
            Entity.AddSpeed(_speed);
            Entity.isEnemy = true;
            Entity.isTurnedAlongDirection = true;
        }

        public override void UnregisterComponents()
        {
            Entity.RemoveWorldPosition();
            Entity.RemoveDirection();
            Entity.RemoveSpeed();
        }
    }
}