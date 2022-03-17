namespace IdleHeroes.Model
{
    public class AvatarStats
    {
        public AvatarStats(string name, double attackCooldown, int hp)
        {
            Name = name;
            AttackCooldown = attackCooldown;
            AttackSpeed = 1 / attackCooldown;
            HP = new LimitedValue(hp);
        }

        public string Name { get; }
        public LimitedValue HP { get; }
        public double AttackCooldown { get; }
        public double AttackSpeed { get; }
    }
}
