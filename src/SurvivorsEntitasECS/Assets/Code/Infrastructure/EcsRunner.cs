using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Input.Service;
using Code.GamePlay.Features;
using Code.Infrastructure.Systems;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
    public class EcsRunner : MonoBehaviour
    {
        private ISystemFactory _systemFactory;

        private BattleFeature _battleFeature;

        [Inject]
        private void Construct(ISystemFactory systemFactory)
        {
            _systemFactory = systemFactory;
        }

        private void Start()
        {
            _battleFeature = _systemFactory.Create<BattleFeature>();
            _battleFeature.Initialize();
        }

        private void Update() 
        {
            _battleFeature.Execute();
            _battleFeature.Cleanup();
        }

        private void OnDestroy() 
        {
            _battleFeature.TearDown();
        }
    }
}