using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace WordDroid
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

			// new code goes here
			EditText txtUsername = FindViewById<EditText>(Resource.Id.txtUsername);
			EditText txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);

			TextView txtLogin = FindViewById<TextView>(Resource.Id.txtLogin);

			Button cmdLogin = FindViewById<Button>(Resource.Id.cmdLogin);

			cmdLogin.Click += (sender, e) =>
			{
				// Get username and password
				string strUser = WordDroid.LoginValidator.Combine(txtUsername.Text, txtPassword.Text);

				if (string.IsNullOrWhiteSpace(strUser))
				{
					txtLogin.Text = "No information supplied";
				}

				else
				{
					txtLogin.Text = strUser;
				}
			};
        }
    }
}

