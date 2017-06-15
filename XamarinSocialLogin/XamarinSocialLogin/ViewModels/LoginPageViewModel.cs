using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using XamarinSocialLogin.Services;

namespace XamarinSocialLogin.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        INavigationService _navigationService;

        public DelegateCommand SignInCommand { get; private set; }

        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SignInCommand = new DelegateCommand(SignInExecute);
        }

        async void SignInExecute()
        {
            try
            {
                var service = new AzureService();
                var userClient = await service.LoginFacebookAsync();

                if (userClient != null)
                {
                    var user = await service.GetUserInfo();
                    var navParams = new NavigationParameters();
                    navParams.Add("user", user);
                    await _navigationService.NavigateAsync("NavPage/MainPage", navParams);
                }

            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Erro: ", ex.Message);
            }
        }
    }
}
