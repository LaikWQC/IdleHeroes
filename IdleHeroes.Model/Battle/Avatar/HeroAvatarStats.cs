namespace IdleHeroes.Model
{
    public class HeroAvatarStats : AvatarStats
    {
        public HeroAvatarStats(string name, double attackCooldown, int hp, int hpRegen) 
            : base(name, attackCooldown, hp)
        {
            HpRegen = hpRegen;
        }

        public int HpRegen { get; }
    }
}
