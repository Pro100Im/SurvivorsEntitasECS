using Code.Common.Extensions;
using Code.Infrastructure.View.Registrars;
using System.Collections.Generic;
using UnityEngine;

namespace Code.GamePlay.Features.Enemies.Registrars
{
    public class EnemiesRegistrars : EntityComponentRegistrar
    {
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _maxHp = 3;
        [SerializeField] private float _damage = 1;
        [SerializeField] private float _radius = 0.3f;
        [SerializeField] private float _collectInterval = 0.5f;

        public override void RegisterComponents()
        {
            Entity.AddWorldPosition(transform.position);
            Entity.AddDirection(Vector2.zero);
            Entity.AddSpeed(_speed);
            Entity.AddDamage(_damage);
            Entity.AddMaxHp(_maxHp);
            Entity.AddCurrentHp(_maxHp);
            Entity.AddTargetBuffer(new List<int>(1));
            Entity.AddRadius(_radius);
            Entity.AddCollectTargetsInterval(_collectInterval);
            Entity.AddCollectTargetsTimer(0);
            Entity.AddLayerMask(CollisionLayer.Hero.AsMask());

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