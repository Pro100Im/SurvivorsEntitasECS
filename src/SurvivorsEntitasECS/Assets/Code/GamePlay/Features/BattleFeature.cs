using Code.Common.Destruct;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Armaments;
using Code.Gameplay.Features.EffectApplication;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Systems;
using Code.Gameplay.Features.TargetCollection;
using Code.GamePlay.Features.Hero;
using Code.GamePlay.Features.LifeTime;
using Code.GamePlay.Features.Movement;
using Code.GamePlay.Input;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View;

namespace Code.GamePlay.Features
{
    public class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InputFeature>());
            Add(systemFactory.Create<BindViewFeature>());

            Add(systemFactory.Create<HeroFeature>());
            Add(systemFactory.Create<EnemyFeature>());
            Add(systemFactory.Create<MovementFeature>());
            Add(systemFactory.Create<AbilityFeature>());
            Add(systemFactory.Create<ArmamentFeature>());
            Add(systemFactory.Create<CollectTargetsFeature>());
            Add(systemFactory.Create<EffectApplicationFeature>());
            Add(systemFactory.Create<EffectFeature>());
            Add(systemFactory.Create<StatusFeature>());

            Add(systemFactory.Create<DeathFeature>());
            Add(systemFactory.Create<StatusVisualsFeature>());
            Add(systemFactory.Create<ProcessDestructedFeature>());
        }
    }
}