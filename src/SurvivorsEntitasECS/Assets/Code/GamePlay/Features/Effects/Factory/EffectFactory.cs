using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Effects.Factory
{
    public class EffectFactory : IEffectFactory
    {
        private readonly IIdentifierService _identifiers;

        public EffectFactory(IIdentifierService identifiers)
        {
            _identifiers = identifiers;
        }

        public GameEntity CreateEffect(EffectSetup setup, int producerId, int targetId)
        {
            switch(setup.EffectTypeId)
            {
                case EffectTypeId.Unknown:
                    break;
                case EffectTypeId.Damage:
                    return CreateDamage(producerId, targetId, setup.Value);
                case EffectTypeId.Heal:
                    return CreateHeal(producerId, targetId, setup.Value);
            }

            throw new Exception($"Effect with type id {setup.EffectTypeId} does not exist");
        }

        private GameEntity CreateDamage(int producerId, int targetId, float value)
        {
            var entity = CreateEntity.Empty();
            entity.AddId(_identifiers.Next());
            entity.With(x => x.isEffect = true);
            entity.With(x => x.isDamageEffect = true);
            entity.AddEffectValue(value);
            entity.AddProducerId(producerId);
            entity.AddTargetId(targetId);

            return entity;
        }

        private GameEntity CreateHeal(int producerId, int targetId, float value)
        {
            var entity = CreateEntity.Empty();
            entity.AddId(_identifiers.Next());
            entity.With(x => x.isEffect = true);
            entity.With(x => x.isHealEffect = true);
            entity.AddEffectValue(value);
            entity.AddProducerId(producerId);
            entity.AddTargetId(targetId);

            return entity;
        }
    }
}