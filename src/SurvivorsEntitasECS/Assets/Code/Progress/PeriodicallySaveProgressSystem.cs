using Code.Gameplay.Common.Time;
using Code.Progress.SaveLoad;
using Entitas;

namespace Code.Progress
{
    public class PeriodicallySaveProgressSystem : IExecuteSystem
    {
        private readonly ITimeService _time;

        private readonly float _interval;

        private readonly ISaveLoadService _saveLoadService;

        private float _timeToExecute;

        public PeriodicallySaveProgressSystem(float executeIntervalSeconds, ITimeService time,
          ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
            _interval = executeIntervalSeconds;
            _time = time;
        }

        public void Execute()
        {
            _timeToExecute -= _time.DeltaTime;

            if(_timeToExecute > 0)
                return;

            _timeToExecute = _interval;

            _saveLoadService.SaveProgress();
        }
    }
}