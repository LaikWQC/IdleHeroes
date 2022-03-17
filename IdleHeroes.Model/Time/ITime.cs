using System;

namespace IdleHeroes.Model.Time
{
    public interface ITime
    {
        event Action<double> OnUpdate;
        void Start();
        void Pause();
    }
}
