using Code.Common.Entity;
using UnityEngine;

namespace Code.GamePlay.Features.Hero.Registrars
{
    public class HeroRegistrar : MonoBehaviour
    {
        [SerializeField] private float _speed = 2;

        private GameEntity _entity;

        private void Awake()
        {
            _entity = CreateEntity.Empty();
            _entity.AddWorldPosition(transform.position);
            _entity.AddDirection(Vector2.zero);
            _entity.AddSpeed(_speed);
        }
    }
}