
using System.ComponentModel;

namespace Project_3_CodeQuotes
{
    public partial class MainPage : ContentPage
    {
        List<string> quotes = new List<string>();
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadMauiAsset();
        }
        async Task LoadMauiAsset()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("codequotes_50.txt");
            using var reader = new StreamReader(stream);

            while(reader.Peek() != -1)
            {
                quotes.Add(reader.ReadLine());
            }
        }
        Random rand = new Random();
        static List<Color> GetColorGradient(Color a, Color b, int steps)
        {
            if (steps < 2) steps = 2;
            var list = new List<Color>(steps);
            for (int i = 0; i < steps; i++)
            {
                float t = i / (float)(steps - 1);
                list.Add(new Color(
                    a.Red + (b.Red - a.Red) * t,
                    a.Green + (b.Green - a.Green) * t,
                    a.Blue + (b.Blue - a.Blue) * t,
                    a.Alpha + (b.Alpha - a.Alpha) * t));
            }
            return list;
        }

        private void btnGenerateQuote_Clicked(object sender, EventArgs e)
        {
            var startColor =
                Color.FromRgb(
                    rand.Next(0, 256),
                    rand.Next(0, 256),
                    rand.Next(0, 256));
            var endColor =
                Color.FromRgb(
                    rand.Next(0, 256),
                    rand.Next(0, 256),
                    rand.Next(0, 256));
            var colors = GetColorGradient(startColor, endColor, 6);
            float stopOffset = .0f;
            var stops = new GradientStopCollection();
            foreach (var c in colors)
            {
                stops.Add(new GradientStop(c, stopOffset));
                stopOffset += 0.2f;
            }
            var gradients =
                new LinearGradientBrush(stops,
                    new Point(0, 0),
                    new Point(1, 1));
            Container.Background = gradients;

            int index = rand.Next(quotes.Count);
            lblQuotes.Text = quotes[index];
        }

    }
}
