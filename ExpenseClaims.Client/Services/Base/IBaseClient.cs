using System.Net.Http;

namespace ExpenseClaims.Client.Services.Base
{
    public partial interface IBaseClient
    {
        public string BaseAddress { get; }
        public HttpClient HttpClient { get; }
    }
}
