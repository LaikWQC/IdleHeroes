namespace IdleHeroes.Model
{
    public class DamageActionModel : ActionModel
    {
        public DamageActionModel(double damage) 
        {
            Damage = damage;
        }

        public double Damage { get; }

        public override void UseAction(IBattleContext context)
        {
            context.Enemy.TakeDamage(MathEx.GetRandomNumber(1,Damage));
        }
    }
}
