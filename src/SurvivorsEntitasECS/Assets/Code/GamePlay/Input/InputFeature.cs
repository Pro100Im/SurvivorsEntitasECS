using Code.Gameplay.Input.Service;
using Code.Gameplay.Input.Systems;

namespace Code.GamePlay.Input
{
    public class InputFeature : Feature
    {
        public InputFeature(InputContext input, IInputService inputService) 
        {
            Add(new InitializeInputSystem());
            Add(new EmitInputSystem(input, inputService));
        }
    }
}