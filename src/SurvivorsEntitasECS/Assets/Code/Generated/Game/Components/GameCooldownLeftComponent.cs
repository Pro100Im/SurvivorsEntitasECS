//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Code.Gameplay.Features.Cooldowns.CooldownLeft cooldownLeft { get { return (Code.Gameplay.Features.Cooldowns.CooldownLeft)GetComponent(GameComponentsLookup.CooldownLeft); } }
    public bool hasCooldownLeft { get { return HasComponent(GameComponentsLookup.CooldownLeft); } }

    public void AddCooldownLeft(float newValue) {
        var index = GameComponentsLookup.CooldownLeft;
        var component = (Code.Gameplay.Features.Cooldowns.CooldownLeft)CreateComponent(index, typeof(Code.Gameplay.Features.Cooldowns.CooldownLeft));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCooldownLeft(float newValue) {
        var index = GameComponentsLookup.CooldownLeft;
        var component = (Code.Gameplay.Features.Cooldowns.CooldownLeft)CreateComponent(index, typeof(Code.Gameplay.Features.Cooldowns.CooldownLeft));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCooldownLeft() {
        RemoveComponent(GameComponentsLookup.CooldownLeft);
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

    static Entitas.IMatcher<GameEntity> _matcherCooldownLeft;

    public static Entitas.IMatcher<GameEntity> CooldownLeft {
        get {
            if (_matcherCooldownLeft == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CooldownLeft);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCooldownLeft = matcher;
            }

            return _matcherCooldownLeft;
        }
    }
}
