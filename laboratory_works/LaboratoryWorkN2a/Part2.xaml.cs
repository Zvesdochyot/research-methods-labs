﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaboratoryWorkN2a
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Part2 : ContentPage
    {
        private readonly Picker ratePicker, timePicker, iterationPicker;

        public Part2()
        {
            Title = "Main task";

            var titleLabel = new Label()
            {
                Text = "Perceptron tuning",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
            var mainFrame = new Frame
            {
                Content = titleLabel,
                BorderColor = Color.Gray,
                BackgroundColor = Color.FromHex("121212"),
                CornerRadius = 8
            };

            var rateLabel = new Label()
            {
                Text = "Model learning rate:",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
            ratePicker = new Picker
            {
                Title = "Choose learning rate",
                TitleColor = Color.FromHex("ff0266"),
                TextColor = Color.FromHex("ff0266"),
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Picker)),
                Items = { "0.001", "0.01", "0.05", "0.1", "0.2", "0.3" }
            };
            var firstFlexLayout = new FlexLayout()
            {
                Direction = FlexDirection.Row,
                JustifyContent = FlexJustify.Center,
                Children = { rateLabel, ratePicker }
            };

            var timeLabel = new Label()
            {
                Text = "Time deadline:",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
            timePicker = new Picker
            {
                Title = "Choose time",
                TitleColor = Color.FromHex("ff0266"),
                TextColor = Color.FromHex("ff0266"),
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Picker)),
                Items = { "0.5 с", "1 с", "2 с", "5 с" }
            };
            var secondFlexLayout = new FlexLayout()
            {
                Direction = FlexDirection.Row,
                JustifyContent = FlexJustify.Center,
                Children = { timeLabel, timePicker }
            };

            var iterationLabel = new Label()
            {
                Text = "Iterations deadline:",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
            iterationPicker = new Picker
            {
                Title = "Choose iterations count",
                TitleColor = Color.FromHex("ff0266"),
                TextColor = Color.FromHex("ff0266"),
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Picker)),
                Items = { "100", "200", "500", "1000" }
            };
            var thirdFlexLayout = new FlexLayout()
            {
                Direction = FlexDirection.Row,
                JustifyContent = FlexJustify.Center,
                Children = { iterationLabel, iterationPicker }
            };

            var solveButton = new Button()
            {
                Text = "Start the process!",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.FromHex("121212"),
                TextColor = Color.FromHex("ff0266"),
                BorderColor = Color.Gray,
                TranslationY = 100
            };
            solveButton.Clicked += ShowResult;

            var stackLayout = new StackLayout()
            {
                Margin = 20,
                Spacing = 10,
                Children = { mainFrame, firstFlexLayout, secondFlexLayout, thirdFlexLayout, solveButton }
            };
            Content = stackLayout;
        }

        private async void ShowResult(object sender, EventArgs e)
        {
            if (ratePicker.SelectedIndex == -1 || timePicker.SelectedIndex == -1 || iterationPicker.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "You need to select all perceptron settings.", "Try again");
                return;
            }

            var points = new Point[] { new Point(0, 6), new Point(1, 5), new Point(3, 3), new Point(2, 4) };
            double[] rateData = new double[] { 0.001, 0.01, 0.05, 0.1, 0.2, 0.3 };
            double[] timeData = new double[] { 500, 1000, 2000, 5000 };
            double[] iterationData = new double[] { 100, 200, 500, 1000 };

            const int threshold = 4;
            double w1 = 0;
            double w2 = 0;

            int iterationsCount = 0;
            int iterationsPointCount = 0;
            int success = 0;
            var startTime = DateTime.Now;

            while (iterationsCount < iterationData[iterationPicker.SelectedIndex] && success < 4 
                && (DateTime.Now - startTime).TotalMilliseconds <= timeData[timePicker.SelectedIndex])
            {
                int currentPoint = iterationsPointCount % 4;
                iterationsPointCount++;

                double y = w1 * points[currentPoint].X + w2 * points[currentPoint].Y;

                if (((currentPoint < 2) && y >= threshold) || ((currentPoint >= 2) && y < threshold))
                {
                    success++;
                    continue;
                }

                double delta = threshold - y;
                w1 += delta * points[currentPoint].X * rateData[ratePicker.SelectedIndex];
                w2 += delta * points[currentPoint].Y * rateData[ratePicker.SelectedIndex];
                w1 = Math.Ceiling(w1 * Math.Pow(10, 7)) / Math.Pow(10, 7);
                w2 = Math.Ceiling(w2 * Math.Pow(10, 7)) / Math.Pow(10, 7);
                success = 0;
                iterationsCount++;
            }

            await DisplayAlert("Result", $"Parameter values:\nW1 = {w1}\nW2 = {w2}\n" +
                $"Execution time = {(DateTime.Now - startTime).TotalMilliseconds} ms\n" +
                $"Number of iterations = {iterationsCount}", "Got it!");
        }
    }
}