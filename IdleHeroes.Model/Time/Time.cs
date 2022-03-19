using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IdleHeroes.Model.Time
{
    public class Time : ITime
    {
        private Task _loopTask;
        private int _fps;
        private CancellationTokenSource _cts;

        public Time(int fps = 60)
        {
            _fps = Math.Min(Math.Max(fps, 1), 500);
        }

        public async Task Loop(CancellationToken token)
        {
            var lastUpdateTime = DateTime.UtcNow;
            var baseDeltaTime = 1d / _fps;
            while (!token.IsCancellationRequested)
            {
                var timeNow = DateTime.UtcNow;
                DeltaTime = (timeNow - lastUpdateTime).TotalSeconds;
                lastUpdateTime = timeNow;
                OnUpdate?.Invoke();

                var nextUpdateTime = timeNow.AddSeconds(baseDeltaTime).AddMilliseconds(-1);
                while (DateTime.UtcNow < nextUpdateTime)
                    await Task.Delay(1);
            }
        }

        public event Action OnUpdate;
        public double DeltaTime { get; private set; }

        public void Start()
        {
            Pause();
            _cts = new CancellationTokenSource();
            _loopTask = new Task(async () => await Loop(_cts.Token));
            _loopTask.Start();
        }

        public void Pause()
        {
            _cts?.Cancel();
            _loopTask = null;
        }
    }
}
