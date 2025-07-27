using System;
using Code.Common.Entity;
using Code.Common.Extensions;
//using Code.Gameplay.Features.Enchants;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Statuses.Factory
{
    public class StatusFactory : IStatusFactory
    {
        private readonly IIdentifierService _identifiers;

        public StatusFactory(IIdentifierService identifiers)
        {
            _identifiers = identifiers;
        }

        public GameEntity CreateStatus(StatusSetup setup, int producerId, int targetId)
        {
            GameEntity status;
            switch(setup.StatusTypeId)
            {
                case StatusTypeId.Poison:
                    status = CreatePoisonStatus(setup, producerId, targetId);
                    break;
                case StatusTypeId.Freeze:
                    status = CreateFreezeStatus(setup, producerId, targetId);
                    break;
                case StatusTypeId.PoisonEnchant:
                    status = CreatePoisonEnchantStatus(setup, producerId, targetId);
                    break;
                case StatusTypeId.ExplosiveEnchant:
                    status = CreateExplosiveEnchantStatus(setup, producerId, targetId);
                    break;

                default:
                    throw new Exception($"Status with type id {setup.StatusTypeId} does not exist");
            }

            status
              .With(x => x.AddDuration(setup.Duration), when: setup.Duration > 0)
              .With(x => x.AddTimeLeft(setup.Duration), when: setup.Duration > 0)
              .With(x => x.AddPeriod(setup.Period), when: setup.Period > 0)
              .With(x => x.AddTimeSinceLastTick(0), when: setup.Period > 0);

            return status;
        }

        private GameEntity CreatePoisonStatus(StatusSetup setup, int producerId, int targetId)
        {
            var entity = CreateEntity.Empty();
            entity.AddId(_identifiers.Next());
            entity.AddStatusTypeId(StatusTypeId.Poison);
            entity.AddEffectValue(setup.Value);
            entity.AddProducerId(producerId);
            entity.AddTargetId(targetId);
            entity.With(x => x.isStatus = true);
            entity.With(x => x.isPoison = true);

            return entity;
        }

        private GameEntity CreateFreezeStatus(StatusSetup setup, int producerId, int targetId)
        {
            var entity = CreateEntity.Empty();
            entity.AddId(_identifiers.Next());
            entity.AddStatusTypeId(StatusTypeId.Freeze);
            entity.AddEffectValue(setup.Value);
            entity.AddProducerId(producerId);
            entity.AddTargetId(targetId);
            entity.With(x => x.isStatus = true);
            entity.With(x => x.isFreeze = true);

            return entity;
        }

        private GameEntity CreatePoisonEnchantStatus(StatusSetup setup, int producerId, int targetId)
        {
            var entity = CreateEntity.Empty();
            entity.AddId(_identifiers.Next());
            entity.AddStatusTypeId(StatusTypeId.PoisonEnchant);
            //entity.AddEnchantTypeId(EnchantTypeId.PoisonArmaments);
            entity.AddEffectValue(setup.Value);
            entity.AddProducerId(producerId);
            entity.AddTargetId(targetId);
            entity.With(x => x.isStatus = true);
            //entity.With(x => x.isPoisonEnchant = true);

            return entity;
        }

        private GameEntity CreateExplosiveEnchantStatus(StatusSetup setup, int producerId, int targetId)
        {
            var entity = CreateEntity.Empty();
            entity.AddId(_identifiers.Next());
            entity.AddStatusTypeId(StatusTypeId.ExplosiveEnchant);
            //entity.AddEnchantTypeId(EnchantTypeId.ExplosiveArmaments);
            entity.AddEffectValue(setup.Value);
            entity.AddProducerId(producerId);
            entity.AddTargetId(targetId);
            entity.With(x => x.isStatus = true);
            //entity.With(x => x.isExplosiveEnchant = true);

            return entity;
        }
    }
}