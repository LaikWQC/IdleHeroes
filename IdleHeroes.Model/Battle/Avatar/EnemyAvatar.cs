﻿namespace IdleHeroes.Model
{
    public class EnemyAvatar : Avatar
    {
        public EnemyAvatar(IBattleContext context) : base(CreateDto(), CreateContainer(), context)
        {
            ChooseAbility();
        }
        private static int count = 1;
        private static AvatarDto CreateDto() => new AvatarDto() { Name = $"Dummy_{count++}", AttackCooldown = 2.5, HP = 50 };
        private static AbilitiesContainer CreateContainer()
        {
            var statistic = new HeroStatistic();
            statistic.Power = 5;

            var ability = new AbilityModel.Builder("Scare", 100);
            var action = new DamageActionModel.Builder(100);
            ability.AddAction(action.Product);
            ability.Finish();
            action.Finish(statistic);

            return new AbilitiesContainer(new AbilityModel[] { ability.Product });
        }
    }
}
