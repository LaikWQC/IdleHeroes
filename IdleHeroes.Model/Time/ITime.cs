using System;

namespace IdleHeroes.Model.Time
{
    public interface ITime
    {
        event Action OnUpdate;
        void Start();
        void Pause();
        double DeltaTime { get; }
    }
}
