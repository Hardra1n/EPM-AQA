namespace QAAutomationLab.CoreLayer.Clients
{
    public interface IBaseClient<T>
        where T : class
    {
        T Get();

        T Post(object body);

        T Put(int id, object body);

        T Delete(int id);
    }
}
