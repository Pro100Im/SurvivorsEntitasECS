namespace Code.Gameplay.Features.Cooldowns
{
    public static class CooldownEntityExtensions
    {
        public static GameEntity PutOnCooldown(this GameEntity entity)
        {
            if(!entity.hasCooldown)
                return entity;

            entity.isCooldownUp = false;
            entity.ReplaceCooldownLeft(entity.cooldown.Value);

            return entity;
        }

        public static GameEntity PutOnCooldown(this GameEntity entity, float cooldown)
        {
            if(!entity.hasCooldown)
                return entity;

            entity.isCooldownUp = false;
            entity.ReplaceCooldown(cooldown);
            entity.ReplaceCooldownLeft(cooldown);

            return entity;
        }
    }
}