using Code.Common.Entity;
using Code.Gameplay.Features.Hero.Behaviours;
using Entitas;
using UnityEngine;

namespace Code.GamePlay.Features.Hero.Registrars
{
    public class HeroRegistrar : MonoBehaviour
    {
        [SerializeField] private float _speed = 2;
        [Space]
        [SerializeField] private HeroAnimator _heroAnimator;

        private GameEntity _entity;

        private void Awake()
        {
            _entity = CreateEntity.Empty();
            _entity.AddTransform(transform);
            _entity.AddWorldPosition(transform.position);
            _entity.AddDirection(Vector2.zero);
            _entity.AddSpeed(_speed);
            _entity.AddHeroAnimator(_heroAnimator);
            _entity.AddSpriteRenderer(_heroAnimator.SpriteRenderer);
            _entity.isHero = true;
            _entity.isTurnedAlongDirection = true;
        }

        //public override void RegisterComponents()
        //{
        //    Entity.AddTransform(transform);
        //    Entity.AddWorldPosition(transform.position);
        //    Entity.AddDirection(Vector2.zero);
        //    Entity.AddSpeed(_speed);
        //    Entity.isHero = true;
        //}

        //public override void UnregisterComponents()
        //{
        //    Entity.RemoveTransform();
        //    Entity.RemoveWorldPosition();
        //    Entity.RemoveDirection();
        //    Entity.RemoveSpeed();
        //    Entity.isHero = false;
        //}
    }
}