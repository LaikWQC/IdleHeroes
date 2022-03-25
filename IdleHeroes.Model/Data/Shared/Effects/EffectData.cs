using IdleHeroes.Data;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class EffectData
    {
        public EffectData(EffectDto dto, IEnumerable<ActionOfEffectData> actions)
        {
            Id = dto.Id;
            TargetType = dto.TargetType;
            DurationType = dto.DurationType;
            Duration = dto.Duration;
            Actions = actions.ToList().AsReadOnly();
        }

        public string Id { get; }
        public EffectTargetTypes TargetType { get; }
        public DurationTypes DurationType { get; }
        public int Duration { get; }
        public ICollection<ActionOfEffectData> Actions { get; }
    }
}
