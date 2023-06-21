using Microsoft.Maui.Embedding;
using Microsoft.Maui.Platform;

namespace SampleApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	private MauiContext mauiContext;

    public MainPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
#if ANDROID
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiEmbedding<Microsoft.Maui.Controls.Application>();
        var mauiApp = builder.Build();
        mauiContext = new MauiContext(mauiApp.Services, Microsoft.Maui.ApplicationModel.Platform.CurrentActivity);

		var btn = new Button
		{
			Text="Hey!",
			BackgroundColor=new Color(60,125,255)
		};

		var aOSBtn = btn.ToPlatform(mauiContext);

		var win = new Com.Hjq.Window.EasyWindow(Microsoft.Maui.ApplicationModel.Platform.CurrentActivity);
		win.SetContentView(aOSBtn);
		win.SetDraggable();
		
		win.Show();
#endif
    }

    private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}


