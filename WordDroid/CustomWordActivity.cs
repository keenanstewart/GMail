
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;
using System.Net.Http;

namespace WordDroid
{
	[Activity(Label = "CustomWordActivity")]
	public class CustomWordActivity : Activity
	{
		TextView txtResults;
		TextView txtMessage;
		string txtValues;

		protected async override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			string strIP = Resources.GetString(Resource.String.LoginURL);
			SetContentView(Resource.Layout.CustomWordActivity);

			Button cmdNewNumbers = FindViewById<Button>(Resource.Id.cmdNewNumbers);

			Button cmdNewNumbersList = FindViewById<Button>(Resource.Id.cmdNewNumbersList);

			Button cmdStartWordQuiz = FindViewById<Button>(Resource.Id.cmdStartWordQuiz);

			cmdNewNumbers.Click += cmdNewNumbers_Click;

			cmdNewNumbersList.Click += cmdNewNumbersList_Click;

			cmdStartWordQuiz.Click += cmdStartWordQuiz_Click;

			/* */
			// TODO: Call Login to return true/false
			// https://xamarinhelp.com/connecting-remote-database-xamarin-forms/
			// Winning Numbers
			// http://localhost/KeenApi/api/LottoMax/WinningNumbers
			var uri = strIP + "/LottoMax/WinningNumbers";

			HttpClient client = new HttpClient();
			var response = await client.GetStringAsync(uri);

			txtValues = Intent.GetStringExtra("DATA_PASS");   // Data from MainActivity
			txtResults = FindViewById<TextView>(Resource.Id.txtResults);
			txtMessage = FindViewById<TextView>(Resource.Id.txtMessage);

			txtResults.Text = txtValues;
			txtMessage.Text = "Is this working yet?: \nWinning numbers:\n";
			txtMessage.Text += response;
			/* */
		}

		private async void cmdNewNumbers_Click(object sender, EventArgs e)
		{
			string strIP = Resources.GetString(Resource.String.LoginURL);
			var uri = strIP + "/LottoMax/WinningNumbers";

			HttpClient client = new HttpClient();
			var response = await client.GetStringAsync(uri);

			txtValues = Intent.GetStringExtra("DATA_PASS");   // Data from MainActivity
			txtResults = FindViewById<TextView>(Resource.Id.txtResults);
			txtMessage = FindViewById<TextView>(Resource.Id.txtMessage);

			txtResults.Text = txtValues;
			txtMessage.Text = "New Winning Numbers: \nWinning numbers:\n";
			txtMessage.Text += response;
		}

		private async void cmdNewNumbersList_Click(object sender, EventArgs e)
		{
			string strIP = Resources.GetString(Resource.String.LoginURL);
			var uri = strIP + "/LottoMax/WinningNumbersList";

			HttpClient client = new HttpClient();
			var response = await client.GetStringAsync(uri);

			txtValues = Intent.GetStringExtra("DATA_PASS");   // Data from MainActivity
			txtResults = FindViewById<TextView>(Resource.Id.txtResults);
			txtMessage = FindViewById<TextView>(Resource.Id.txtMessage);

			txtResults.Text = txtValues;
			txtMessage.Text = "New Winning Numbers List: \nWinning numbers:\n";
			txtMessage.Text += response.ToString();
		}

		private void cmdStartWordQuiz_Click(object sender, EventArgs e)
		{
			// Login uri 
			// http://192.168.0.4/KeenApi/api/Word/WordOne
			//var uri = strIP + "KeenApi/api/Word/WordOne";

			//HttpClient client = new HttpClient();
			//var response = await client.GetStringAsync(uri);
			//var intent = new Intent(this, typeof(start));
			//this.StartActivity(intent);
			var intent = new Intent(this, typeof(WordQuiz.StartWordQuiz));
			this.StartActivity(intent);
		}
	}
}

