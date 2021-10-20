﻿namespace IdleHeroes.Data
{
    public class DamageActionDto : ActionDto
    {
        public int Potency { get; set; }

        public override void CreateAction(IActionDataBuilder builder)
        {
            builder.AddDamageAction(this);
        }
    }
}