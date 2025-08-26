using CommunityToolkit.Maui.Alerts;
using System.Diagnostics;

namespace ColorMaker;

public partial class Test : ContentPage
{
    bool isRandom = false;
    int red, green, blue;
    string hexVal;
    public Test()
	{
		InitializeComponent();
        red = green = blue = 0;
	}

    private void ReRender(Color color)
    {
        Debug.WriteLine(color.ToString());
        bxDarkPre.BackgroundColor = color;
        bxLightPre.BackgroundColor = color;
        hexVal = color.ToHex();
        lblHexVal.Text = "Hex Value: " + hexVal;

    }
    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        var slider = (Slider)sender;
        int v = Convert.ToInt32(slider.Value);

        if(isRandom == false)
        {
            if (slider == sldRed)
            {
                red = v;
                lblRed.Text = "Red Value: " + v;
            }

            else if (slider == sldGreen)
            {
                green = v;
                lblGreen.Text = "Green Value: " + v;
            }
            else
            {
                blue = v;
                lblBlue.Text = "blue Value: " + v;
            }

            Color color = Color.FromRgb(red, green, blue);

            ReRender(color);
        }
    }
    private void btnRandom_Clicked(object sender, EventArgs e)
    {
        var rand = new Random();

        red = rand.Next(256);
        green = rand.Next(256);
        blue = rand.Next(256);
        var color = Color.FromRgb(red, green, blue);

        isRandom = true;

        ReRender(color);

        sldRed.Value = red;
        sldGreen.Value = green;
        sldBlue.Value = blue;
        lblRed.Text = "Red Value: " + red;
        lblGreen.Text = "Green Value: " + green;
        lblBlue.Text = "Blue Value: " + blue;

        isRandom = false;
    }

    private async void btnCopy_Clicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(hexVal);

        var toast = Toast.Make("Color Copied!", 
            CommunityToolkit.Maui.Core.ToastDuration.Short, 
            12);
        await toast.Show();

        var old = lblHexVal.Text;
        lblHexVal.Text = "Copied!";
        await Task.Delay(1200);
        lblHexVal.Text = old;
    }

    //private String convert_RGBtoHEX(double red, double green, double blue)
    //{
    //    int r = Convert.ToInt32(red);
    //    int g = Convert.ToInt32(green);
    //    int b = Convert.ToInt32(blue);
    //    String newHex = $"#{r:x2}{g:x2}{b:x2}";
    //    return newHex;
    //}
    //private void sldRed_ValueChanged(object sender, ValueChangedEventArgs e)
    //{
    //    lblRed.Text = "Red Value: " + $"{sldRed.Value:F0}";
    //    String newHex = convert_RGBtoHEX(sldRed.Value, sldGreen.Value, sldBlue.Value);
    //    lblHexVal.Text = "HEX Value: " + newHex;
    //    bxDarkPre.BackgroundColor = Color.FromArgb(newHex);
    //    bxLightPre.BackgroundColor = Color.FromArgb(newHex);
    //}

    //private void sldGreen_ValueChanged(object sender, ValueChangedEventArgs e)
    //{
    //    lblGreen.Text = "Green Value: " + $"{sldGreen.Value:F0}";
    //    String newHex = convert_RGBtoHEX(sldRed.Value, sldGreen.Value, sldBlue.Value);
    //    lblHexVal.Text = "HEX Value: " + newHex;
    //    bxDarkPre.BackgroundColor = Color.FromArgb(newHex);
    //    bxLightPre.BackgroundColor = Color.FromArgb(newHex);
    //}

    //private void sldBlue_ValueChanged(object sender, ValueChangedEventArgs e)
    //{
    //    lblBlue.Text = "Blue Value: " + $"{sldBlue.Value:F0}";
    //    String newHex = convert_RGBtoHEX(sldRed.Value, sldGreen.Value, sldBlue.Value);
    //    lblHexVal.Text = "HEX Value: " + newHex;
    //    bxDarkPre.BackgroundColor = Color.FromArgb(newHex);
    //    bxLightPre.BackgroundColor = Color.FromArgb(newHex);
    //}

    //private void btnRandom_Clicked(object sender, EventArgs e)
    //{
    //    Random rdm = new Random();
    //    int r = rdm.Next(256);
    //    int g = rdm.Next(256);
    //    int b = rdm.Next(256);
    //    sldRed.Value = r;
    //    sldGreen.Value = g;
    //    sldBlue.Value = b;
    //    sldBlue.Value = b;
    //    lblRed.Text = "Red Value: " + r;
    //    lblGreen.Text = "Green Value: " + g;
    //    lblBlue.Text = "Blue Value: " + b;
    //    String newHex = convert_RGBtoHEX(r, g, b);
    //    bxDarkPre.BackgroundColor = Color.FromArgb(newHex);
    //    bxLightPre.BackgroundColor = Color.FromArgb(newHex);
    //}

    //private async void btnCopy_Clicked(object sender, EventArgs e)
    //{
    //    if(!(lblHexVal.Text == "Copied!"))
    //    {
    //        var hex = lblHexVal.Text?.Replace("HEX Value:", "").Trim();
    //        await Clipboard.SetTextAsync(hex);

    //        var old = lblHexVal.Text;
    //        lblHexVal.Text = "Copied!";
    //        await Task.Delay(1200);
    //        lblHexVal.Text = old;
    //    }

    //}
}