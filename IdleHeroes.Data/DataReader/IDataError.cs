namespace IdleHeroes.Data
{
    public interface IDataError
    {
        void NoAbilityError(string id);
        void RepeatedAbilityIdError(string id);
        void NoActionError(string id);
        void RepeatedActionIdError(string id);
        void NoSharedPerkError(string id);
        void RepeatedSharedPerkIdError(string id);
        void IncorrectPerkTypeError(string type);
        void IncorrectActionTypeError(string type);
        void IncorrectTag(string value);
    }

    public class DataErrorBase : IDataError
    {
        public virtual void IncorrectActionTypeError(string type) { }
        public virtual void IncorrectPerkTypeError(string type) { }
        public virtual void NoAbilityError(string id) { }
        public virtual void NoActionError(string id) { }
        public virtual void NoSharedPerkError(string id) { }
        public virtual void RepeatedAbilityIdError(string id) { }
        public virtual void RepeatedActionIdError(string id) { }
        public virtual void RepeatedSharedPerkIdError(string id) { }
        public void IncorrectTag(string value) { }
    }
}
