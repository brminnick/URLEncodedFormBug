using Xamarin.Forms;

namespace URLEncodedFormBug
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new SubmitFormPage();
		}
	}
}
