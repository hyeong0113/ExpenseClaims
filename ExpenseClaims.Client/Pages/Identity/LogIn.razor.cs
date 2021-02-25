using ExpenseClaims.Application.DTOs.Identity;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.Identity
{
    public partial class LogIn
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAutenticated { get; set; } = false;
        public TokenRequest Token { get; set; } = new TokenRequest();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public async Task OnSubmit()
        {
            Token.Email = UserName;
            Token.Password = Password;

            var response = await Http.PostAsJsonAsync("api/identity/token", Token);
            var jToken = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            string tokenKey = jToken["data"]["jwToken"].ToString();
            await localStorage.SetItemAsync("token", tokenKey);
            IsAutenticated = true;

            NavigationManager.NavigateTo("/");
        }
    }
}
