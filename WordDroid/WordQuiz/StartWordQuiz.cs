using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net.Http;

namespace WordDroid.WordQuiz
{
	[Activity(Label = "StartWordQuiz")]
	public class StartWordQuiz : Activity
	{
		TextView txtStartWordQuiz;
		TextView txtWordTarget;

		TextView txtWordID;
		TextView txtDailyWord;
		TextView txtWordThemeID;
		TextView txtWordThemeName;
		TextView txtPronunciation;
		TextView txtMeaning;
		TextView txtEtymology;
		TextView txtUsage;
		TextView txtThoughtADay;
		TextView txtNotes;

		Button cmdNextWord;
		Button cmdPreviousWord;
		Button cmdGoHome;

		//string strIP = "http://192.168.0.4/keenAPI/api/";
		int iWordCount = 1;

		protected async override void OnCreate(Bundle savedInstanceState)
		{
			string strIP = Resources.GetString(Resource.String.LoginURL);
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.StartWordQuiz);
			txtStartWordQuiz = FindViewById<TextView>(Resource.Id.txtStartWordQuiz);
			txtWordTarget = FindViewById<TextView>(Resource.Id.txtWordTarget);

			cmdGoHome = FindViewById<Button>(Resource.Id.cmdGoHome);
			cmdPreviousWord = FindViewById<Button>(Resource.Id.cmdGetPreviousWord);
			cmdNextWord = FindViewById<Button>(Resource.Id.cmdGetNextWord);

			txtWordID = FindViewById<TextView>(Resource.Id.txtWordID);
			txtDailyWord = FindViewById<TextView>(Resource.Id.txtDailyWord);
			txtWordThemeID = FindViewById<TextView>(Resource.Id.txtWordThemeID);
			txtWordThemeName = FindViewById<TextView>(Resource.Id.txtDailyWordThemeName);
			txtPronunciation = FindViewById<TextView>(Resource.Id.txtPronunciation);
			txtMeaning = FindViewById<TextView>(Resource.Id.txtMeaning);
			txtEtymology = FindViewById <TextView>(Resource.Id.txtEtymology);
			txtUsage = FindViewById<TextView>(Resource.Id.txtUsage);
			txtThoughtADay = FindViewById<TextView>(Resource.Id.txtThoughtADay);
			txtNotes = FindViewById<TextView>(Resource.Id.txtNotes);

			cmdGoHome.Click += cmdGoHome_Click;
			cmdPreviousWord.Click += cmdPreviousWord_Click;
			cmdNextWord.Click += cmdNextWord_Click;

			txtStartWordQuiz.Text = "In start word quiz";

			// http://192.168.0.4/KeenApi/api/Word/WordOne
			// http://localhost/KeenAPI/api/Word/NextWord?WordCount=13
			//var uri = strIP + "KeenApi/api/Word/WordOne";
			var uri = strIP + "/Word/NextWord?WordCount=" + iWordCount;

			HttpClient client = new HttpClient();
			var response = await client.GetStringAsync(uri);

			txtWordTarget.Text = response.ToString();
			txtWordTarget.Visibility = Android.Views.ViewStates.Invisible;

			try
			{
				txtWordID.Text = "WordID: " + GetNextField("Id", "WordsmithThemeId", response);
				txtWordThemeID.Text = "WordThemeID: " + GetNextField("WordsmithThemeId",
												"DailyWord", response);
				txtDailyWord.Text = "DailyWord: " + GetNextField("DailyWord",
												"WordThemeName", response);
				txtWordThemeName.Text = "WordThemeName: " + GetNextField("WordThemeName",
												"Pronunciation", response);
				txtPronunciation.Text = "Pronunciation: " + GetNextField("Pronunciation",
												"Meaning", response);
				txtMeaning.Text = "Meaning: " + GetNextField("Meaning",
												"Etymology", response);
				txtEtymology.Text = "Etymology: " + GetNextField("Etymology",
												"Usage", response);
				txtUsage.Text = "Usage: " + GetNextField("Usage",
												"ThoughtADay", response);
				txtThoughtADay.Text = "ThoughtADay: " + GetNextField("ThoughtADay",
												"Notes", response);
				txtNotes.Text = "Notes: " + GetNextField("Notes",
												"InputDate", response);
			}

			catch (Exception ex)
			{
				txtStartWordQuiz.Text = "Exception occurred in cmdNextWord_Click: " + ex.Message.ToString();
			}
		}

		private async void cmdPreviousWord_Click(object sender, EventArgs e)
		{
			string strIP = Resources.GetString(Resource.String.LoginURL);

			// Todo, get next word
			if (iWordCount > 1)
			{
				iWordCount--;
			}

			txtStartWordQuiz.Text = "TODO: GetNextWord!";
			var uri = strIP + "/Word/NextWord?WordCount=" + iWordCount;

			HttpClient client = new HttpClient();
			var response = await client.GetStringAsync(uri);

			txtWordTarget.Text = response.ToString();
			txtWordTarget.Visibility = Android.Views.ViewStates.Invisible;

			try
			{
				txtWordID.Text = "WordID: " + GetNextField("Id", "WordsmithThemeId", response);
				txtWordThemeID.Text = "WordThemeID: " + GetNextField("WordsmithThemeId",
												"DailyWord", response);
				txtDailyWord.Text = "DailyWord: " + GetNextField("DailyWord",
												"WordThemeName", response);
				txtWordThemeName.Text = "WordThemeName: " + GetNextField("WordThemeName",
												"Pronunciation", response);
				txtPronunciation.Text = "Pronunciation: " + GetNextField("Pronunciation",
												"Meaning", response);
				txtMeaning.Text = "Meaning: " + GetNextField("Meaning",
												"Etymology", response);
				txtEtymology.Text = "Etymology: " + GetNextField("Etymology",
												"Usage", response);
				txtUsage.Text = "Usage: " + GetNextField("Usage",
												"ThoughtADay", response);
				txtThoughtADay.Text = "ThoughtADay: " + GetNextField("ThoughtADay",
												"Notes", response);
				txtNotes.Text = "Notes: " + GetNextField("Notes",
												"InputDate", response);
			}

			catch (Exception ex)
			{
				txtStartWordQuiz.Text = "Exception occurred in cmdNextWord_Click: " + ex.Message.ToString();
			}
		}

		private async void cmdNextWord_Click(object sender, EventArgs e)
		{
			string strIP = Resources.GetString(Resource.String.LoginURL);
			/*
			 * 			return Id + ":" +
					DailyWord + ":" +
					WordsmithThemeId + ":" +
					WordsmithThemeName + ":" +
					Pronunciation + ":" +
					Meaning + ":" +
					Etymology + ":" +
					Usage + ":" +
					ThoughtADay + ":" +
					Notes;
			 * */
			// Todo, get next word
			iWordCount++;
			txtStartWordQuiz.Text = "TODO: GetNextWord!";
			var uri = strIP + "/Word/NextWord?WordCount=" + iWordCount;

			HttpClient client = new HttpClient();
			var response = await client.GetStringAsync(uri);

			txtWordTarget.Text = response.ToString();
			txtWordTarget.Visibility = Android.Views.ViewStates.Invisible;

			try
			{
				txtWordID.Text = "WordID: " + GetNextField("Id", "WordsmithThemeId", response);
				txtWordThemeID.Text = "WordThemeID: " + GetNextField("WordsmithThemeId",
												"DailyWord", response);
				txtDailyWord.Text = "DailyWord: " + GetNextField("DailyWord",
												"WordThemeName", response);
				txtWordThemeName.Text = "WordThemeName: " + GetNextField("WordThemeName",
												"Pronunciation", response);
				txtPronunciation.Text = "Pronunciation: " + GetNextField("Pronunciation",
												"Meaning", response);
				txtMeaning.Text = "Meaning: " + GetNextField("Meaning",
												"Etymology", response);
				txtEtymology.Text = "Etymology: " + GetNextField("Etymology",
												"Usage", response);
				txtUsage.Text = "Usage: " + GetNextField("Usage",
												"ThoughtADay", response);
				txtThoughtADay.Text = "ThoughtADay: " + GetNextField("ThoughtADay",
												"Notes", response);
				txtNotes.Text = "Notes: " + GetNextField("Notes",
												"InputDate", response);
			}

			catch (Exception ex)
			{
				txtStartWordQuiz.Text = "Exception occurred in cmdNextWord_Click: " + ex.Message.ToString();
			}
		}

		private void cmdGoHome_Click(object sender, EventArgs e)
		{
			var intent = new Intent(this, typeof(CustomWordActivity));
			this.StartActivity(intent);
		}

		private string GetWordID(string WordID, string WordsmithThemeId, string response)
		{
			// First sample "Id\":3,\"Wo"
			int start = response.IndexOf(WordID) + 4;
			int end = response.IndexOf(WordsmithThemeId) - 
					(response.IndexOf(WordID) + 4) - 
					2;
			return response.Substring(start, end);
		}

		private string GetNextField(string firstField, string secondField, string response)
		{
			// First sample "Id\":3,\"Wo"
			int start = response.IndexOf(firstField) + firstField.Length + 2;
			int end = response.IndexOf(secondField) - start - 2;
			//int end = response.IndexOf(secondField) - start;
			return response.Substring(start, end);
		}
	}
}