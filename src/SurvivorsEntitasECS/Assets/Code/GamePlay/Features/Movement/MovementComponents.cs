using Entitas;
using UnityEngine;

namespace Code.GamePlay.Features.Movement
{
    [Game] public class Speed : IComponent { public float Value; }
    [Game] public class Direction : IComponent { public Vector2 Value; }
    [Game] public class Moving : IComponent { }
    [Game] public class MovementAvailable : IComponent { }
    [Game] public class TurnedAlongDirection : IComponent { }
    [Game] public class RotationAlignedAlongDirection : IComponent { }
}