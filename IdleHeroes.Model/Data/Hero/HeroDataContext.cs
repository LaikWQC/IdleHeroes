﻿using IdleHeroes.Data;
using System.Collections.Generic;

namespace IdleHeroes.Model
{
    public class HeroDataContext
    {
        public Dictionary<string, AbilityData> Abiities { get; } = new Dictionary<string, AbilityData>();
        public Dictionary<string, ActionData> Actions { get; } = new Dictionary<string, ActionData>();
    }

    public static class HeroDataContextEx
    {
        public static HeroDataContext CreateDataContext(this DataDocument doc, IDataError error)
        {
            var context = new HeroDataContext();

            foreach (var dto in doc.Abilities)
            {
                var id = dto.Id;
                if (context.Abiities.ContainsKey(id))
                    error.RepeatedAbilityIdError(id);
                else context.Abiities.Add(id, new AbilityData(id, dto.CooldownMulti));
            }

            var actionBuilder = new ActionDataBuilder(error);
            foreach (var dto in doc.Actions)
                dto.CreateAction(actionBuilder);
            foreach(var kvp in actionBuilder.Actions)
                context.Actions.Add(kvp.Key, kvp.Value);

            return context;
        }
    }
}
