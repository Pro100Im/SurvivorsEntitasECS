using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Input.Service;
using Code.GamePlay.Features;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
    public class EcsRunner : MonoBehaviour
    {
        private GameContext _gameContext;
        private InputContext _inputContext;

        private ITimeService _timeService;
        private IInputService _inputService;
        private ICameraProvider _cameraProvider;

        private BattleFeature _battleFeature;

        [Inject]
        private void Construct(GameContext gameContext, InputContext inputContext, ITimeService timeService, IInputService inputService, ICameraProvider cameraProvider)
        {
            _gameContext = gameContext;
            _inputContext = inputContext;

            _timeService = timeService;
            _inputService = inputService;
            _cameraProvider = cameraProvider;
        }

        private void Start()
        {
            _battleFeature = new BattleFeature(_gameContext, _inputContext, _timeService, _inputService, _cameraProvider);
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