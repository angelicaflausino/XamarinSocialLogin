using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinSocialLogin.Models;

namespace XamarinSocialLogin.Services
{
    public class AzureService
    {
        public MobileServiceClient Client { get; set; } = null;
        const string _facebook = "https://graph.facebook.com/";
        //Modificar para url do seu servico na azure
        const string _appUrl = "https://alpha2login.azurewebsites.net";

        public void Initialize()
        {
            Client = new MobileServiceClient(_appUrl);
        }

        public async Task<MobileServiceUser> LoginFacebookAsync()
        {
            Initialize();
            var auth = DependencyService.Get<IAuthenticate>();
            var user = await auth.AuthenticateAsync(Client, MobileServiceAuthenticationProvider.Facebook);

            if(user == null)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Erro:", "Usuário ou senha inválido", "OK");
                });

                return null;
            }

            return user;
        }

        public async Task<User> GetUserInfo()
        {
            User user = new User();
            string token = await GetUserIdentityAzure();

            if (!string.IsNullOrWhiteSpace(token))
            {
                using(HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync($"{_facebook}me?fields=id,name,picture.width(200)&access_token={token}"))
                    {
                        var data = JObject.Parse(await response.Content.ReadAsStringAsync());
                        user.Id = data["id"].ToString();
                        user.Name = data["name"].ToString();
                        user.Token = token;
                        user.Photo = data["picture"]["data"]["url"].ToString();
                    }
                }

                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<string> GetUserIdentityAzure()
        {
            var userInfo = await Client.InvokeApiAsync<List<Identity>>("/.auth/me");

            if(userInfo.Count > 0)
            {
                var identity = userInfo[0];
                return identity.AccessToken;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
