namespace QAAutomationLab.CoreLayer.Clients
{
    public interface IBaseClient
    {
        T Get<T>();

        T Post<T>(object body);

        T Put<T>(int id, object body);

        T Delete<T>(int id);
    }
}
