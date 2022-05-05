using System.Threading.Tasks;

namespace QAAutomationLab.CoreLayer.Clients
{
    public interface IBaseClient
    {
        Task<T> Get<T>(string url);

        Task<T> Post<T>(string url, object body);

        Task<T> Put<T>(string url, int id, object body);

        Task<T> Delete<T>(string url, int id);

        void AddHeader(string name, string value);
    }
}
