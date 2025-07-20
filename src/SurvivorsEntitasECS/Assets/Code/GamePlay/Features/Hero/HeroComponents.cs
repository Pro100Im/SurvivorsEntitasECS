using Code.Gameplay.Features.Hero.Behaviours;
using Entitas;
using UnityEngine;

namespace Assets.Code.GamePlay.Features.Hero
{
    [Game] public class Hero : IComponent { }
    [Game] public class HeroAnimatorComponent : IComponent { public HeroAnimator Value; }
}