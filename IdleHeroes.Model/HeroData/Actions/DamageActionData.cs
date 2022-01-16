﻿namespace IdleHeroes.Model
{
    public class DamageActionData : ActionData
    {
        private readonly int _potency;

        public DamageActionData(string id, int potency) : base(id)
        {
            _potency = potency;
        }
    }
}