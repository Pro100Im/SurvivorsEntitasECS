using UnityEngine;

namespace Code.Common.Extensions
{
    public static class GameEntityExtensions
    {
        public static void AddView(this GameEntity entity, MonoBehaviour view)
        {
            //entity.AddView(new ViewComponent { view = view });
        }
    }
}