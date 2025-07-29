using Code.Common.EntityIndices;
using Entitas;

namespace Code.Gameplay.Features.CharacterStats.Systems
{
    public class StatChangeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statOwners;

        private readonly GameContext _game;

        public StatChangeSystem(GameContext game)
        {
            _game = game;

            _statOwners = game.GetGroup(GameMatcher
              .AllOf(
                GameMatcher.Id,
                GameMatcher.BaseStats,
                GameMatcher.StatModifiers));
        }

        public void Execute()
        {
            foreach(GameEntity statOwner in _statOwners)
            {
                foreach(Stats stat in statOwner.baseStats.Value.Keys)
                {
                    statOwner.statModifiers.Value[stat] = 0;

                    foreach(GameEntity statChange in _game.TargetStatChanges(stat, statOwner.id.Value))
                    {
                        statOwner.statModifiers.Value[stat] += statChange.effectValue.Value;
                    }
                }
            }
        }
    }
}