namespace ColorMaker;

public partial class Test : ContentPage
{
	public Test()
	{
		InitializeComponent();
	}
    private String convert_RGBtoHEX(double red, double green, double blue)
    {
        int r = Convert.ToInt32(red);
        int g = Convert.ToInt32(green);
        int b = Convert.ToInt32(blue);
        String newHex = $"#{r:x2}{g:x2}{b:x2}";
        return newHex;
    }
    private void sldRed_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        lblRed.Text = "Red Value: " + $"{sldRed.Value:F0}";
        String newHex = convert_RGBtoHEX(sldRed.Value, sldGreen.Value, sldBlue.Value);
        lblHexVal.Text = "HEX Value: " + newHex;
        bxDarkPre.BackgroundColor = Color.FromArgb(newHex);
        bxLightPre.BackgroundColor = Color.FromArgb(newHex);
    }

    private void sldGreen_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        lblGreen.Text = "Green Value: " + $"{sldGreen.Value:F0}";
        String newHex = convert_RGBtoHEX(sldRed.Value, sldGreen.Value, sldBlue.Value);
        lblHexVal.Text = "HEX Value: " + newHex;
        bxDarkPre.BackgroundColor = Color.FromArgb(newHex);
        bxLightPre.BackgroundColor = Color.FromArgb(newHex);
    }

    private void sldBlue_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        lblBlue.Text = "Blue Value: " + $"{sldBlue.Value:F0}";
        String newHex = convert_RGBtoHEX(sldRed.Value, sldGreen.Value, sldBlue.Value);
        lblHexVal.Text = "HEX Value: " + newHex;
        bxDarkPre.BackgroundColor = Color.FromArgb(newHex);
        bxLightPre.BackgroundColor = Color.FromArgb(newHex);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Random rdm = new Random();
        int r = rdm.Next(256);
        int g = rdm.Next(256);
        int b = rdm.Next(256);
        sldRed.Value = r;
        sldGreen.Value = g;
        sldBlue.Value = b;
        lblRed.Text = "Red Value: " + r;
        lblGreen.Text = "Green Value: " + g;
        lblBlue.Text = "Blue Value: " + b;
        String newHex = convert_RGBtoHEX(r, g, b);
        bxDarkPre.BackgroundColor = Color.FromArgb(newHex);
        bxLightPre.BackgroundColor = Color.FromArgb(newHex);
    }

    private async void btnCopy_Clicked(object sender, EventArgs e)
    {
        var hex = lblHexVal.Text?.Replace("HEX Value:", "").Trim();
        await Clipboard.SetTextAsync(hex);

        var old = lblHexVal.Text;
        lblHexVal.Text = "Copied!";
        await Task.Delay(1200);
        lblHexVal.Text = old;

    }
}