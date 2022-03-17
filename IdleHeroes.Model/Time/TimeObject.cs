using IdleHeroes.Model.Services;

namespace IdleHeroes.Model.Time
{
    public abstract class TimeObject
    {
        public TimeObject()
        {
            SubscribeToTime();
        }

        public void SubscribeToTime()
        {
            TimeService.Instance.OnUpdate += Update;
        }
        public void UnSubscribeFromTime()
        {
            TimeService.Instance.OnUpdate -= Update;
        }
        public virtual void Dispose()
        {
            UnSubscribeFromTime();
        }

        protected virtual void Update(double deltaTime) { }
    }
}
