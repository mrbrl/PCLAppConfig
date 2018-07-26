using System;
using Xamarin.Forms;

namespace DemoApp
{
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
            try
            {
                InitializeComponent();
            }
            catch (InvalidOperationException soe)
            {
                if (!soe.Message.Contains("MUST"))
                    throw;
            }

            BindingContext = new MainViewModel();
		}
    }
}
