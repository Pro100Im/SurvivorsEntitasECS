using Code.GamePlay.Features.Movement.Systems;
using Code.Infrastructure.Systems;

namespace Code.GamePlay.Features.Movement
{
    public class MovementFeature : Feature
    {
        public MovementFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<DirectionalDeltaMoveSystem>());
            Add(systemFactory.Create<UpdateTransformPositionSystem>());
            Add(systemFactory.Create<TurnAlongDirectionSystem>());
        }
    }
}