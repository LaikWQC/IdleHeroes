using System.Collections.Generic;

namespace IdleHeroes.Data
{
    public class DataDocument
    {
        public List<JobDto> Jobs { get; } = new List<JobDto>();
        public List<AbilityDto> Abilities { get; } = new List<AbilityDto>();
        public List<ActionDto> Actions { get; } = new List<ActionDto>();

        public DataContext CreateDataContext(IDataError error)
        {
            var context = new DataContext();

            foreach(var dto in Abilities)
            {
                var id = dto.Id;
                if (context.Abiities.ContainsKey(id))
                    error.RepeatedAbilityIdError(id);
                else context.Abiities.Add(id, new AbilityData(id, dto.CooldownMulti));
            }

            var actionBuilder = new ActionDataBuilder();
            foreach (var dto in Actions)
            {
                var id = dto.Id;
                if (context.Actions.ContainsKey(id))
                    error.RepeatedActionIdError(id);
                dto.CreateAction(actionBuilder);
            }
            actionBuilder.Actions.ForEach(x => context.Actions.Add(x.Id, x));

            return context;
        }
    }
}
