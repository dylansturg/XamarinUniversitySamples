using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TipCalculator
{
	[Activity (Label = "TipCalculator", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private EditText _priceInput;
		private TextView _tipOut;
		private TextView _totalOut;
		private Button _calculateButton;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			_calculateButton = FindViewById<Button> (Resource.Id.myButton);
			_priceInput = FindViewById<EditText> (Resource.Id.price_input);
			_tipOut = FindViewById<TextView> (Resource.Id.tip_display);
			_totalOut = FindViewById<TextView> (Resource.Id.total_display);

			_calculateButton.Click += (sender, e) => 
			{
				double price;
				if(!double.TryParse(_priceInput.Text, out price)){
					// Android broke
					return;
				}

				var tipAmt = price * 0.15;
				var totalAmt = price + tipAmt;

				_tipOut.Text = tipAmt.ToString();
				_totalOut.Text = totalAmt.ToString();

			};

		}
	}
}


