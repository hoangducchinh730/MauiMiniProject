using System;
using static System.Net.Mime.MediaTypeNames;

namespace ColorMaker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private string convert_RGBtoHEX(double red, double green, double blue)
        {
            int r = Convert.ToInt32(red);
            int g = Convert.ToInt32(green);
            int b = Convert.ToInt32(blue);
            return $"#{r:X2}{g:X2}{b:X2}";
        }
        private void sldRed_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblRed.Text = $"Red Value: {sldRed.Value:F0}";
            string newHex = convert_RGBtoHEX(sldRed.Value, sldGreen.Value, sldBlue.Value);
            lblHex.Text = "HEX Value: " + newHex;
            boxLightPre.BackgroundColor = Color.FromArgb(newHex);
            boxDarkPre.BackgroundColor = Color.FromArgb(newHex);
        }

        private void sldGreen_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblGreen.Text = $"Green Value: {sldGreen.Value:F0}";
            string newHex = convert_RGBtoHEX(sldRed.Value, sldGreen.Value, sldBlue.Value);
            lblHex.Text = "HEX Value: " + newHex;
            boxLightPre.BackgroundColor = Color.FromArgb(newHex);
            boxDarkPre.BackgroundColor = Color.FromArgb(newHex);
        }
        private void sldBlue_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblBlue.Text = $"Blue Value: {sldBlue.Value:F0}";
            string newHex = convert_RGBtoHEX(sldRed.Value, sldGreen.Value, sldBlue.Value);
            lblHex.Text = "HEX Value: " + newHex;
            boxLightPre.BackgroundColor = Color.FromArgb(newHex);
            boxDarkPre.BackgroundColor = Color.FromArgb(newHex);
        }

        private void imgbtnCopy_Clicked(object sender, EventArgs e)
        {
            Clipboard.SetTextAsync(lblHex.Text.Substring(11));
        }

        private void btnRandom_Clicked(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int r = rnd.Next(256);
            int g = rnd.Next(256);
            int b = rnd.Next(256);
            sldRed.Value = r;
            sldGreen.Value = g;
            sldBlue.Value = b;
            string newHex = convert_RGBtoHEX(r, g, b);
            lblHex.Text = "HEX Value: " + newHex;
            boxLightPre.BackgroundColor = Color.FromArgb(newHex);
            boxDarkPre.BackgroundColor = Color.FromArgb(newHex);
        }
    }
}
