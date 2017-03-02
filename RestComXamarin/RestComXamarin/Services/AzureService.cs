using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestComXamarin.Services
{
    public class AzureService<T>
    {
        IMobileServiceClient Client;
        IMobileServiceTable<T> table;

        public AzureService()
        {
            string MyAppServiceURL = "http://meodemoxamarin.azurewebsites.net/";
            Client = new MobileServiceClient(MyAppServiceURL);
            table = Client.GetTable<T>();
        }
        public Task<IEnumerable<T>> GetTable()
        {
            return table.ToEnumerableAsync();
        }
    }
}
