using Code.Gameplay.Common.Visuals;
using Code.Infrastructure.View;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Code.GamePlay.Common
{
    [Game] public class Id : IComponent { [PrimaryEntityIndex] public int Value; }
    [Game] public class WorldPosition : IComponent { public Vector3 Value; }
    [Game] public class Damage : IComponent { public float Value; }

    [Game] public class TransformComponent : IComponent { public Transform Value; }
    [Game] public class SpriteRendererComponent : IComponent { public SpriteRenderer Value; }
    [Game] public class DamageTakenAnimatorComponent : IComponent { public IDamageTakenAnimator Value; }
}