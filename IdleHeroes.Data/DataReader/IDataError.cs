namespace IdleHeroes.Data
{
    public interface IDataError
    {
        void NoAbilityError(string id);
        void RepeatedAbilityIdError(string id);
        void NoActionError(string id);
        void RepeatedActionIdError(string id);
    }
}
