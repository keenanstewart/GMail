using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;
using System.Net.Http;

namespace WordDroid
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			// Visual Basic error:
			// Make sure WordDroid does not contain a reference to WordAPI
			// Does not need the reference
			// https://forums.xamarin.com/discussion/42672/stable-service-release-xamarin-android-5-1-2-bug-fixes-for-5-1-0
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.activity_main);

			// new code goes here
			EditText txtUsername = FindViewById<EditText>(Resource.Id.txtUsername);
			EditText txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);

			TextView txtLogin = FindViewById<TextView>(Resource.Id.txtLogin);
			TextView txtUrl = FindViewById<TextView>(Resource.Id.txtUrl);

			Button cmdLogin = FindViewById<Button>(Resource.Id.cmdLogin);

			cmdLogin.Click += cmdLogin_Click;

			txtLogin.Click += (sender, e) =>
			{
				txtLogin.Focusable = true;
			};

			txtLogin.RequestFocus();
			txtPassword.RequestFocus();
		}

		private async void cmdLogin_Click(object sender, EventArgs e)
		{
			EditText txtUsername = FindViewById<EditText>(Resource.Id.txtUsername);
			EditText txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);

			TextView txtLogin = FindViewById<TextView>(Resource.Id.txtLogin);
			TextView txtUrl = FindViewById<TextView>(Resource.Id.txtUrl);

			// Get username and password
			//string strUser = WordDroid.LoginValidator.Combine(txtUsername.Text, txtPassword.Text);
			string strUsername = txtUsername.Text;
			string strPassword = txtPassword.Text;
			//string strUsername = "keenan";
			//string strPassword = "Malcolm";

			if (string.IsNullOrWhiteSpace(strUsername))
			{
				txtLogin.Text = "No information supplied";
			}

			else
			{
				/* */
				// Login uri 
				// http://localhost/KeenApi/api/Word/Login/keenan/Malcolm
				string strIP = Resources.GetString(Resource.String.LoginURL);
				var uri = strIP + "/Word/Login/";
				uri += strUsername + "/" + strPassword;
				// We will sign in first and then be able to view WinningNumbers
				HttpClient client = new HttpClient();
				var response = await client.GetAsync(uri);
				var respons2 = await client.GetStringAsync(uri);
				txtUrl.Text = response.ToString();
			/* */
				if (Convert.ToBoolean(respons2))
				{
					var intent = new Intent(this, typeof(CustomWordActivity));
					intent.PutExtra("DATA_PASS", txtUsername.Text + " " + txtPassword.Text);
					this.StartActivity(intent);
				}

				else
				{
					txtUrl.Text = "Invalid login attempt URL";
					txtLogin.Text = "Invalid login attempt Login";
				}
			/* */
			}
		}
	}
}
