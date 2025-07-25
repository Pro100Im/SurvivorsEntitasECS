//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Code.Gameplay.Features.TargetCollection.ReadyToCollectTargets readyToCollectTargetsComponent = new Code.Gameplay.Features.TargetCollection.ReadyToCollectTargets();

    public bool isReadyToCollectTargets {
        get { return HasComponent(GameComponentsLookup.ReadyToCollectTargets); }
        set {
            if (value != isReadyToCollectTargets) {
                var index = GameComponentsLookup.ReadyToCollectTargets;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : readyToCollectTargetsComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherReadyToCollectTargets;

    public static Entitas.IMatcher<GameEntity> ReadyToCollectTargets {
        get {
            if (_matcherReadyToCollectTargets == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ReadyToCollectTargets);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherReadyToCollectTargets = matcher;
            }

            return _matcherReadyToCollectTargets;
        }
    }
}
