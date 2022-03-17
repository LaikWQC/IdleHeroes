using IdleHeroes.Model.Time;
using System;

namespace IdleHeroes.Model.Services
{
    public class TimeService : Singletone<TimeService>
    {
        private ITime _time;

        public void Initialize(ITime time)
        {
            if(_time!=null)
            {
                Stop();
                _time.OnUpdate -= OnTimerUpdate;
            }        
            _time = time;
            _time.OnUpdate += OnTimerUpdate;
        }
        private void OnTimerUpdate(double deltaTime)
        {
            OnUpdate?.Invoke(deltaTime);
        }
        public event Action<double> OnUpdate;
        public void Start() => _time?.Start();
        public void Stop() => _time?.Pause();
    }
}
