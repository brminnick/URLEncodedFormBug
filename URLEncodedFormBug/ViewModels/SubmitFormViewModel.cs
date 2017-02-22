using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections.Generic;

using Xamarin.Forms;

namespace URLEncodedFormBug
{
	public class SubmitFormViewModel : BaseViewModel
	{
		#region Fields
		bool _isBusy;
		Command _submitButtonTappedCommand;
		HttpClient _client;
		#endregion

		#region Properties
		public Command SubmitButtonTappedCommand => _submitButtonTappedCommand ??
			(_submitButtonTappedCommand = new Command(async () => await ExecuteSubmitButtonTappedCommand()));

		public bool IsBusy
		{
			get { return _isBusy; }
			set { SetProperty(ref _isBusy, value); }
		}

		HttpClient Client => _client ?? (_client = CreateHttpClient());
		#endregion

		#region Methods
		async Task ExecuteSubmitButtonTappedCommand()
		{
			await PostAsyncWithFormUrlEncodedContent();
		}

		async Task PostAsyncWithFormUrlEncodedContent()
		{
			var url = @"http://mondaypunday.com/321";
			var result = false;

			IsBusy = true;
			try
			{
				var answerList = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("answer", "Catastrophe") };

				using (HttpContent httpContent = new FormUrlEncodedContent(answerList))
				{
					var htmlContent = string.Empty;

					using (var response = await Client.PostAsync(url, httpContent))
					{
						if (response.StatusCode == HttpStatusCode.OK)
							htmlContent = await response.Content.ReadAsStringAsync();
					}

					result |= htmlContent.Contains("Correct!");

					if (result)
						await Application.Current.MainPage.DisplayAlert("Success", "", "OK");
					else
						await Application.Current.MainPage.DisplayAlert("Failed", "", "OK");
				}
			}
			catch (Exception e)
			{
				await Application.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
			}
			finally
			{
				IsBusy = false;
			}

		}

		HttpClient CreateHttpClient()
		{
			var httpTimeout = TimeSpan.FromSeconds(30);
			HttpClient client;

			if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android)
				client = new HttpClient { Timeout = httpTimeout };
			else
				client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip })
				{
					Timeout = httpTimeout
				};

			client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
			client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));

			return client;
		}
		#endregion
	}
}
