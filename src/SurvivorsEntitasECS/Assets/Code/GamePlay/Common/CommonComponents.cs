using Code.Infrastructure.View;
using Entitas;
using UnityEngine;

namespace Code.GamePlay.Common
{
    [Game] public class Id : IComponent { public int Value; }
    [Game] public class WorldPosition : IComponent { public Vector3 Value; }
    [Game] public class TransformComponent : IComponent { public Transform Value; }

    [Game] public class Radius : IComponent { public float Value; }

}