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
        private void OnTimerUpdate()
        {
            OnUpdate?.Invoke();
        }
        public event Action OnUpdate;
        public void Start() => _time?.Start();
        public void Stop() => _time?.Pause();
        public double DeltaTime => _time.DeltaTime;
    }
}
