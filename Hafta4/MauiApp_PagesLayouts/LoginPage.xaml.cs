namespace MauiApp_PagesLayouts
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnGotoRegistration_Clicked(object sender, EventArgs e)
        {
            registerStack.IsVisible = true;
            loginStack.IsVisible = false;
        }

        private void btnGotoLogin_Clicked(object sender, EventArgs e)
        {
            loginStack.IsVisible = true;
            registerStack.IsVisible = false;
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new AppShell();
        }
    }
}
