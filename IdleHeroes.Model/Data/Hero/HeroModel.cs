using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class HeroModel
    {
        public HeroModel(IEnumerable<JobModel> jobs)
        {
            Jobs = jobs.ToList().AsReadOnly();
            CurrentJob = Jobs.FirstOrDefault();
        }

        public ICollection<JobModel> Jobs { get; }
        public JobModel CurrentJob { get; private set; }

        public void ChangeJob(string name)
        {
            var job = Jobs.FirstOrDefault(x => x.Name == name);
            if (job != null) CurrentJob = job;
        }
        public IEnumerable<IPerk> GetPerks() => Jobs.SelectMany(job => job.Perks.Where(perk=>perk.IsAllowTo(CurrentJob)).Select(x=>x.Value));
    }
}
