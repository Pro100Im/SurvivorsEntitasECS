using Code.Common.Entity;
using Code.Gameplay.StaticData;

namespace Code.Gameplay.Features.LevelUp.Services
{
    public class LevelUpService : ILevelUpService
    {
        public float CurrentExperience { get; private set; }
        public int CurrentLevel { get; private set; }

        private readonly IStaticDataService _staticData;

        public LevelUpService(IStaticDataService staticData) =>
          _staticData = staticData;

        public float ExperienceForLevelUp() => _staticData.ExperienceForLevel(CurrentLevel + 1);

        public void AddExperience(float value)
        {
            CurrentExperience += value;
            UpdateLevel();
        }

        private void UpdateLevel()
        {
            if(CurrentLevel+1 >= _staticData.MaxLevel())
                return;

            float experienceForLevelUp = _staticData.ExperienceForLevel(CurrentLevel + 1);

            if(CurrentExperience < experienceForLevelUp)
                return;

            CurrentExperience -= experienceForLevelUp;
            CurrentLevel++;

            CreateEntity.Empty().isLevelUp = true;

            UpdateLevel();
        }
    }
}