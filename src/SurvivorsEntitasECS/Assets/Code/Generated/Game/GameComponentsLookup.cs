//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

    public const int Hero = 0;
    public const int HeroAnimator = 1;
    public const int Destructed = 2;
    public const int SelfDestructTimer = 3;
    public const int View = 4;
    public const int ViewPath = 5;
    public const int ViewPrefab = 6;
    public const int Damage = 7;
    public const int DamageTakenAnimator = 8;
    public const int Id = 9;
    public const int SpriteRenderer = 10;
    public const int Transform = 11;
    public const int WorldPosition = 12;
    public const int AbilityId = 13;
    public const int GarlicAuraAbility = 14;
    public const int OrbitingMushroomAbility = 15;
    public const int ParentAbility = 16;
    public const int RecreatedOnUpgrade = 17;
    public const int UpgradeRequest = 18;
    public const int VegetableBoltAbility = 19;
    public const int Armament = 20;
    public const int EffectSetups = 21;
    public const int FollowingProducer = 22;
    public const int Processed = 23;
    public const int Cooldown = 24;
    public const int CooldownLeft = 25;
    public const int CooldownUp = 26;
    public const int DamageEffect = 27;
    public const int Effect = 28;
    public const int EffectValue = 29;
    public const int HealEffect = 30;
    public const int ProducerId = 31;
    public const int TargetId = 32;
    public const int Enemy = 33;
    public const int EnemyAnimator = 34;
    public const int EnemyTypeId = 35;
    public const int SpawnTimer = 36;
    public const int CurrentHp = 37;
    public const int Dead = 38;
    public const int MaxHp = 39;
    public const int ProcessingDeath = 40;
    public const int Direction = 41;
    public const int MovementAvailable = 42;
    public const int Moving = 43;
    public const int RotationAlignedAlongDirection = 44;
    public const int Speed = 45;
    public const int TurnedAlongDirection = 46;
    public const int CollectingTargetsContinuously = 47;
    public const int CollectTargetsInterval = 48;
    public const int CollectTargetsTimer = 49;
    public const int LayerMask = 50;
    public const int ProcessedTargets = 51;
    public const int Radius = 52;
    public const int Reached = 53;
    public const int ReadyToCollectTargets = 54;
    public const int TargetBuffer = 55;
    public const int TargetLimit = 56;

    public const int TotalComponents = 57;

    public static readonly string[] componentNames = {
        "Hero",
        "HeroAnimator",
        "Destructed",
        "SelfDestructTimer",
        "View",
        "ViewPath",
        "ViewPrefab",
        "Damage",
        "DamageTakenAnimator",
        "Id",
        "SpriteRenderer",
        "Transform",
        "WorldPosition",
        "AbilityId",
        "GarlicAuraAbility",
        "OrbitingMushroomAbility",
        "ParentAbility",
        "RecreatedOnUpgrade",
        "UpgradeRequest",
        "VegetableBoltAbility",
        "Armament",
        "EffectSetups",
        "FollowingProducer",
        "Processed",
        "Cooldown",
        "CooldownLeft",
        "CooldownUp",
        "DamageEffect",
        "Effect",
        "EffectValue",
        "HealEffect",
        "ProducerId",
        "TargetId",
        "Enemy",
        "EnemyAnimator",
        "EnemyTypeId",
        "SpawnTimer",
        "CurrentHp",
        "Dead",
        "MaxHp",
        "ProcessingDeath",
        "Direction",
        "MovementAvailable",
        "Moving",
        "RotationAlignedAlongDirection",
        "Speed",
        "TurnedAlongDirection",
        "CollectingTargetsContinuously",
        "CollectTargetsInterval",
        "CollectTargetsTimer",
        "LayerMask",
        "ProcessedTargets",
        "Radius",
        "Reached",
        "ReadyToCollectTargets",
        "TargetBuffer",
        "TargetLimit"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Assets.Code.GamePlay.Features.Hero.Hero),
        typeof(Assets.Code.GamePlay.Features.Hero.HeroAnimatorComponent),
        typeof(Code.Common.Destructed),
        typeof(Code.Common.SelfDestructTimer),
        typeof(Code.Common.View),
        typeof(Code.Common.ViewPath),
        typeof(Code.Common.ViewPrefab),
        typeof(Code.GamePlay.Common.Damage),
        typeof(Code.GamePlay.Common.DamageTakenAnimatorComponent),
        typeof(Code.GamePlay.Common.Id),
        typeof(Code.GamePlay.Common.SpriteRendererComponent),
        typeof(Code.GamePlay.Common.TransformComponent),
        typeof(Code.GamePlay.Common.WorldPosition),
        typeof(Code.Gameplay.Features.Abilities.AbilityIdComponent),
        typeof(Code.Gameplay.Features.Abilities.GarlicAuraAbility),
        typeof(Code.Gameplay.Features.Abilities.OrbitingMushroomAbility),
        typeof(Code.Gameplay.Features.Abilities.ParentAbility),
        typeof(Code.Gameplay.Features.Abilities.RecreatedOnUpgrade),
        typeof(Code.Gameplay.Features.Abilities.UpgradeRequest),
        typeof(Code.Gameplay.Features.Abilities.VegetableBoltAbility),
        typeof(Code.Gameplay.Features.Armaments.Armament),
        typeof(Code.Gameplay.Features.Armaments.EffectSetups),
        typeof(Code.Gameplay.Features.Armaments.FollowingProducer),
        typeof(Code.Gameplay.Features.Armaments.Processed),
        typeof(Code.Gameplay.Features.Cooldowns.Cooldown),
        typeof(Code.Gameplay.Features.Cooldowns.CooldownLeft),
        typeof(Code.Gameplay.Features.Cooldowns.CooldownUp),
        typeof(Code.Gameplay.Features.Effects.DamageEffect),
        typeof(Code.Gameplay.Features.Effects.Effect),
        typeof(Code.Gameplay.Features.Effects.EffectValue),
        typeof(Code.Gameplay.Features.Effects.HealEffect),
        typeof(Code.Gameplay.Features.Effects.ProducerId),
        typeof(Code.Gameplay.Features.Effects.TargetId),
        typeof(Code.Gameplay.Features.Enemies.Enemy),
        typeof(Code.Gameplay.Features.Enemies.EnemyAnimatorComponent),
        typeof(Code.Gameplay.Features.Enemies.EnemyTypeIdComponent),
        typeof(Code.Gameplay.Features.Enemies.SpawnTimer),
        typeof(Code.Gameplay.Features.Lifetime.CurrentHp),
        typeof(Code.Gameplay.Features.Lifetime.Dead),
        typeof(Code.Gameplay.Features.Lifetime.MaxHp),
        typeof(Code.Gameplay.Features.Lifetime.ProcessingDeath),
        typeof(Code.GamePlay.Features.Movement.Direction),
        typeof(Code.GamePlay.Features.Movement.MovementAvailable),
        typeof(Code.GamePlay.Features.Movement.Moving),
        typeof(Code.GamePlay.Features.Movement.RotationAlignedAlongDirection),
        typeof(Code.GamePlay.Features.Movement.Speed),
        typeof(Code.GamePlay.Features.Movement.TurnedAlongDirection),
        typeof(Code.Gameplay.Features.TargetCollection.CollectingTargetsContinuously),
        typeof(Code.Gameplay.Features.TargetCollection.CollectTargetsInterval),
        typeof(Code.Gameplay.Features.TargetCollection.CollectTargetsTimer),
        typeof(Code.Gameplay.Features.TargetCollection.LayerMask),
        typeof(Code.Gameplay.Features.TargetCollection.ProcessedTargets),
        typeof(Code.Gameplay.Features.TargetCollection.Radius),
        typeof(Code.Gameplay.Features.TargetCollection.Reached),
        typeof(Code.Gameplay.Features.TargetCollection.ReadyToCollectTargets),
        typeof(Code.Gameplay.Features.TargetCollection.TargetBuffer),
        typeof(Code.Gameplay.Features.TargetCollection.TargetLimit)
    };
}
