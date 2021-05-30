using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaboratoryWorkN1a
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Part2 : ContentPage
    {
        private readonly Entry inputEntry;

        public Part2()
        {
            Title = "Main task";

            var titleLabel = new Label()
            {
                Text = "Fermat's factorization method",
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
                CornerRadius = 8
            };

            inputEntry = new Entry()
            {
                Placeholder = "Enter the number..",
                Keyboard = Keyboard.Numeric,
                BackgroundColor = Color.FromHex("121212"),
                PlaceholderColor = Color.FromHex("ff0266"),
                TextColor = Color.FromHex("ff0266"),
                TranslationY = 100
            };

            var solveButton = new Button()
            {
                Text = "Factorize!",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.FromHex("121212"),
                TextColor = Color.FromHex("ff0266"),
                BorderColor = Color.Gray,
                TranslationY = 130
            };
            solveButton.Clicked += ShowResult;

            var stackLayout = new StackLayout()
            {
                Margin = 20,
                Spacing = 10
            };
            stackLayout.Children.Add(mainFrame);
            stackLayout.Children.Add(inputEntry);
            stackLayout.Children.Add(solveButton);
            Content = stackLayout;
        }

        private async void ShowResult(object sender, EventArgs e)
        {
            if (!Int64.TryParse(inputEntry.Text, out long element) || element <= 1)
            {
                await DisplayAlert("Error", "Wrong input, please try again.", "Try again");
                return;
            }
            else
            {
                if ((element % 2) == 0)
                {
                    await DisplayAlert("Result", $"Number 1 = 2\nNumber 2 = {element / 2}", "Got it!");
                    return;
                }

                long a, b;
                a = Convert.ToInt64(Math.Ceiling(Math.Sqrt(element)));
                if (a * a == element)
                {
                    await DisplayAlert("Result", $"Number 1 = {a}\nNumber 2 = {a}", "Got it!");
                    return;
                }

                int counter = 0;
                while (true)
                {
                    long tempValue = a * a - element;
                    b = Convert.ToInt64(Math.Sqrt(tempValue));
                    if (b * b == tempValue)
                    {
                        break;
                    }
                    a++;
                    counter++;
                    if (counter == 100)
                    {
                        await DisplayAlert("Error", "The program could not find an answer in 100 iterations, please try again.", "Try again");
                        return;
                    }
                }
                await DisplayAlert("Result", $"Number 1 = {a - b}\nNumber 2 = {a + b}", "Got it!");
            }
        }
    }
}