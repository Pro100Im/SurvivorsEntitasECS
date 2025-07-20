using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.GamePlay.Features.Hero.Registrars
{
    public class HeroRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private float _speed = 2;
        [SerializeField] private float _maxHp = 100;
        [SerializeField] private float _damage = 1;

        public override void RegisterComponents()
        {
            Entity.AddWorldPosition(transform.position);
            Entity.AddDirection(Vector2.zero);
            Entity.AddSpeed(_speed);
            Entity.AddDamage(_damage);
            Entity.AddMaxHp(_maxHp);
            Entity.AddCurrentHp(_maxHp);

            Entity.isHero = true;
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