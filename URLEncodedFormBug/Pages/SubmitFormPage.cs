using Xamarin.Forms;

namespace URLEncodedFormBug
{
	public class SubmitFormPage : ContentPage
	{
		public SubmitFormPage()
		{
			var viewModel = new SubmitFormViewModel();
			BindingContext = viewModel;

			var submitButton = new Button
			{
				Text = "Submit"
			};
			submitButton.SetBinding(Button.CommandProperty, nameof(viewModel.SubmitButtonTappedCommand));

			var activityIndicator = new ActivityIndicator();
			activityIndicator.SetBinding(IsVisibleProperty, nameof(viewModel.IsBusy));
			activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, nameof(viewModel.IsBusy));

			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.Center,
				Children = {
					submitButton,
					activityIndicator
				}
			};
		}
	}
}
