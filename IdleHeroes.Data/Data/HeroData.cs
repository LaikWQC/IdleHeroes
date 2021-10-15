using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Data
{
    public class HeroData
    {
        public HeroData(IEnumerable<JobData> jobs)
        {
            Jobs = jobs.ToList().AsReadOnly();
            CurrentJob = Jobs.FirstOrDefault();
        }

        public ICollection<JobData> Jobs { get; }
        public JobData CurrentJob { get; private set; }

        public void ChangeJob(string name)
        {
            var job = Jobs.FirstOrDefault(x => x.Name == name);
            if (job != null) CurrentJob = job;
        }
        public IEnumerable<PerkData> GetPerks() => Jobs.SelectMany(x => x.GetPerks(CurrentJob?.AvailableTags));
    }
}
