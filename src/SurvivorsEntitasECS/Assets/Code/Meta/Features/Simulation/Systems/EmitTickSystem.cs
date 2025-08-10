using Code.Common.Entity;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Meta.Features.Simulation.Systems
{
    public class EmitTickSystem : IExecuteSystem
    {
        private readonly ITimeService _time;

        private readonly float _interval;

        private float _timeToExecute;

        public EmitTickSystem(float interval, ITimeService time)
        {
            _time = time;

            _interval = interval;
        }

        public void Execute()
        {
            _timeToExecute -= _time.DeltaTime;

            if(_timeToExecute > 0)
                return;

            _timeToExecute = _interval;

            CreateMetaEntity.Empty()
              .AddTick(_interval);
        }
    }
}