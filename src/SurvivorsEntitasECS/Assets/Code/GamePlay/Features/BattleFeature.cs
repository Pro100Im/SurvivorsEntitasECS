using Code.Common.Destruct;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.TargetCollection;
using Code.GamePlay.Features.DamageApplication;
using Code.GamePlay.Features.Hero;
using Code.GamePlay.Features.Movement;
using Code.GamePlay.Input;
using Code.Infrastructure.Systems;

namespace Code.GamePlay.Features
{
    public class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InputFeature>());
            Add(systemFactory.Create<HeroFeature>());
            Add(systemFactory.Create<EnemyFeature>());
            Add(systemFactory.Create<MovementFeature>());
            Add(systemFactory.Create<CollectTargetsFeature>());
            Add(systemFactory.Create<DamageApplicationFeature>());
            Add(systemFactory.Create<ProcessDestructedFeature>());
        }
    }
}