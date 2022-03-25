using IdleHeroes.Data;
using System.Linq;

namespace IdleHeroes.Model
{
    public class EnemyAvatar : Avatar
    {
        public EnemyAvatar(IBattleContext context) : base(CreateDto(), CreateContainer(), context)
        {
            ChooseAbility();
        }
        private static int count = 1;
        private static AvatarStats CreateDto() => new AvatarStats($"Dummy_{count++}", 2.5, 50);
        private static AbilitiesContainer CreateContainer()
        {
            var builder = new HeroAvatarBuilder();
            builder.Power = 5;

            var action = new DamageActionBuilder(100);
            var ability = new AbilityBuilder(new AbilityData(new AbilityDto() { Name = "Scare", Chance = 80, ChanceType = ChanceTypes.Normal }, new ActionData[0]));            
            ability.AddAction(action);
            builder.Abilities.Add("Scare", ability);

            return new AbilitiesContainer(builder.Abilities.Values.Select(x => x.Create(builder)));
        }
    }
}
