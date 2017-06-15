using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;
using XamarinSocialLogin.Droid.Authentication;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticateDroid))]
namespace XamarinSocialLogin.Droid.Authentication
{
    public class AuthenticateDroid : IAuthenticate
    {
        public async Task<MobileServiceUser> AuthenticateAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
        {
            try
            {
                return await client.LoginAsync(Xamarin.Forms.Forms.Context, MobileServiceAuthenticationProvider.Facebook);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: ", ex.Message);
                return null;
            } 
        }
    }
}