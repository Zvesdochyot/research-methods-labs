using Xamarin.Forms;

namespace LaboratoryWorkN2a
{
    public partial class App : Application
    {
        public App()
        {
            MainPage = new MainPage()
            {
                BackgroundColor = Color.FromHex("121212"),
                BarTextColor = Color.FromHex("ff0266"),
                BarBackgroundColor = Color.FromHex("121212")
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
