using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaboratoryWorkN2a
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Part1 : ContentPage
    {
        public Part1()
        {
            Title = "Welcome screen";

            var titleLabel = new Label()
            {
                Text = "Laboratory work #2a",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
            };
            var mainFrame = new Frame
            {
                Content = titleLabel,
                BorderColor = Color.Gray,
                BackgroundColor = Color.FromHex("121212"),
                CornerRadius = 8,
                TranslationY = 100
            };

            var authorLabel = new Label()
            {
                Text = "Author: Nakarlovich Rostyslav Ruslanovich",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label)),
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                TranslationY = 100
            };

            var facultyLabel = new Label()
            {
                Text = "Faculty: Informatics and Computer Science",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label)),
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                TranslationY = 100
            };

            var groupLabel = new Label()
            {
                Text = "Group name: IV-92",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label)),
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                TranslationY = 100
            };

            var variantLabel = new Label()
            {
                Text = "Group list number: 14",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label)),
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                TranslationY = 100
            };

            var stackLayout = new StackLayout
            {
                Margin = 20,
                Spacing = 10,
                Children = { mainFrame, authorLabel, facultyLabel, groupLabel, variantLabel } 
            };
            Content = stackLayout;
        }
    }
}