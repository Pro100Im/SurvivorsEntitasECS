using Entitas;
using UnityEngine;

namespace Code.GamePlay
{
    public class Id : IComponent { public int Value; }
    public class WorldPos : IComponent { public Vector3 Value; }

    class CheckImprovements
    {
        public CheckImprovements()
        {
            GameEntity entity = null;

            int id = entity.id.Value;
        }
    }
}


