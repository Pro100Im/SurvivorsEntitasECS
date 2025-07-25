//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public Code.Gameplay.Input.AxisInput axisInput { get { return (Code.Gameplay.Input.AxisInput)GetComponent(InputComponentsLookup.AxisInput); } }
    public bool hasAxisInput { get { return HasComponent(InputComponentsLookup.AxisInput); } }

    public void AddAxisInput(UnityEngine.Vector2 newValue) {
        var index = InputComponentsLookup.AxisInput;
        var component = (Code.Gameplay.Input.AxisInput)CreateComponent(index, typeof(Code.Gameplay.Input.AxisInput));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAxisInput(UnityEngine.Vector2 newValue) {
        var index = InputComponentsLookup.AxisInput;
        var component = (Code.Gameplay.Input.AxisInput)CreateComponent(index, typeof(Code.Gameplay.Input.AxisInput));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAxisInput() {
        RemoveComponent(InputComponentsLookup.AxisInput);
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherAxisInput;

    public static Entitas.IMatcher<InputEntity> AxisInput {
        get {
            if (_matcherAxisInput == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.AxisInput);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherAxisInput = matcher;
            }

            return _matcherAxisInput;
        }
    }
}
