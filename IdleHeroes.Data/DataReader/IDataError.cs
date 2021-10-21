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
    }

    public class NoDataError : IDataError
    {
        public void IncorrectActionTypeError(string type) { }
        public void IncorrectPerkTypeError(string type) { }
        public void NoAbilityError(string id) { }
        public void NoActionError(string id) { }
        public void NoSharedPerkError(string id) { }
        public void RepeatedAbilityIdError(string id) { }
        public void RepeatedActionIdError(string id) { }
        public void RepeatedSharedPerkIdError(string id) { }
    }
}
