using Xamarin.Forms;

namespace LaboratoryWorkN1a
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            Children.Add(new Part1());
            Children.Add(new Part2());
        }
    }
}
