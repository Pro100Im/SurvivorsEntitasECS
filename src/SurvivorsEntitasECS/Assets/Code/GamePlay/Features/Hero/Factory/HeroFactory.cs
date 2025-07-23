using Code.Common.Entity;
using Code.Common.Extensions;
//using Code.Gameplay.Features.CharacterStats;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Factory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IIdentifierService _identifiers;

        public HeroFactory(IIdentifierService identifiers)
        {
            _identifiers = identifiers;
        }

        public GameEntity CreateHero(Vector3 at)
        {
            //Dictionary<Stats, float> baseStats = InitStats.EmptyStatDictionary()
            //  .With(x => x[Stats.Speed] = 2)
            //  .With(x => x[Stats.MaxHp] = 100);

            var entity = CreateEntity.Empty();
            entity.AddId(_identifiers.Next());
            entity.AddWorldPosition(at);
            //entity.AddBaseStats(baseStats);
            //entity.AddStatModifiers(InitStats.EmptyStatDictionary());
            entity.AddDirection(Vector2.zero);
            //entity.AddSpeed(baseStats[Stats.Speed]);
            //entity.AddCurrentHp(baseStats[Stats.MaxHp]);
            //entity.AddMaxHp(baseStats[Stats.MaxHp]);
            entity.AddSpeed(2);
            entity.AddCurrentHp(100);
            entity.AddMaxHp(100);
            //entity.AddExperience(0);
            entity.AddViewPath("Gameplay/Hero/hero");
            //entity.AddPickupRadius(1f);
            entity.With(x => x.isHero = true);
            entity.With(x => x.isTurnedAlongDirection = true);
            entity.With(x => x.isMovementAvailable = true);

            return entity;
        }

    }
}