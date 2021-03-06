using System.Net.Http;

namespace ExpenseClaims.Client.Services.Base
{
    public partial class BaseClient : IBaseClient
    {
        public string BaseAddress { 
            get
            {
                return _baseUrl;
            }
        }

        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }
    }
}
