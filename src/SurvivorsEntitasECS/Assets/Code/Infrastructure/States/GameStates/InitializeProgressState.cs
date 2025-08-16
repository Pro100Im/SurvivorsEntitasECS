using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Common.Time;
using Code.Gameplay.StaticData;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Progress.Data;
using Code.Progress.Provider;
using Code.Progress.SaveLoad;

namespace Code.Infrastructure.States.GameStates
{
    public class InitializeProgressState : SimpleState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IStaticDataService _staticDataService;

        private readonly ISaveLoadService _saveLoadService;

        public InitializeProgressState(
          IGameStateMachine stateMachine,
          IProgressProvider progressProvider,
          ISaveLoadService saveLoadService,
          IStaticDataService staticDataService)
        {
            _saveLoadService = saveLoadService;
            _stateMachine = stateMachine;
            _staticDataService = staticDataService;
        }

        public override void Enter()
        {
            InitializeProgress();

            _stateMachine.Enter<ActualizeProgressState>();
        }

        private void InitializeProgress()
        {
            if(_saveLoadService.HasSavedProgress)
                _saveLoadService.LoadProgress();
            else
                CreateNewProgress();
        }

        private void CreateNewProgress()
        {
            _saveLoadService.CreateProgress();

            var entity = CreateMetaEntity.Empty();

            entity.With(x => x.isStorage = true);
            entity.AddGold(0);
            entity.AddGoldPerSecond(_staticDataService.AfkGain.GoldPerSecond);
        }
    }
}