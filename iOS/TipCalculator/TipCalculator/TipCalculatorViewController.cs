using System;
using Foundation;
using UIKit;

namespace TipCalculator
{
	public partial class TipCalculatorViewController : UIViewController
	{
		private const string TipFormat = "Tip is {0:C}";

		private UILabel _tipLabel;
		private UIButton _calculateButton;
		private UITextField _priceField;
		private UISegmentedControl _tipPercentages;

		public TipCalculatorViewController () : base ()
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_tipLabel = new UILabel ();
			_calculateButton = new UIButton (UIButtonType.Custom);
			_priceField = new UITextField ();
			_tipPercentages = new UISegmentedControl ();

			View.AddSubview (_priceField);
			View.AddSubview (_calculateButton);
			View.AddSubview (_tipLabel);
			View.AddSubview (_tipPercentages);

			_priceField.TranslatesAutoresizingMaskIntoConstraints = false;
			_priceField.KeyboardType = UIKeyboardType.DecimalPad;
			_priceField.BorderStyle = UITextBorderStyle.RoundedRect;
			_priceField.Placeholder = "Enter Total Amount:";

			View.AddConstraint (NSLayoutConstraint.Create (View, NSLayoutAttribute.Top, NSLayoutRelation.Equal, _priceField, NSLayoutAttribute.TopMargin, 1, -28));
			View.AddConstraint (NSLayoutConstraint.Create (View, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, _priceField, NSLayoutAttribute.CenterX, 1, 0));
			View.AddConstraint (NSLayoutConstraint.Create (View, NSLayoutAttribute.Width, NSLayoutRelation.Equal, _priceField, NSLayoutAttribute.Width, 1, 40));
			View.AddConstraint (NSLayoutConstraint.Create (_priceField, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1, 35));


			_calculateButton.TranslatesAutoresizingMaskIntoConstraints = false;
			_calculateButton.SetTitle ("Calculate", UIControlState.Normal);
			_calculateButton.SetTitleColor (UIColor.White, UIControlState.Normal);
			_calculateButton.SetTitleColor (UIColor.Blue, UIControlState.Highlighted);
			_calculateButton.BackgroundColor = UIColor.Green;
			_calculateButton.TouchUpInside += (sender, e) => CalculateCurrentTip();

			View.AddConstraint(NSLayoutConstraint.Create(_priceField, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, _calculateButton, NSLayoutAttribute.Top, 1, -8));
			View.AddConstraint (NSLayoutConstraint.Create (_calculateButton, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, View, NSLayoutAttribute.CenterX, 1, 0));
			View.AddConstraint (NSLayoutConstraint.Create (_calculateButton, NSLayoutAttribute.Width, NSLayoutRelation.Equal, View, NSLayoutAttribute.Width, 1, -40));

			_tipPercentages.TranslatesAutoresizingMaskIntoConstraints = false;
			_tipPercentages.InsertSegment ("10%", 0, false);
			_tipPercentages.InsertSegment ("15%", 1, false);
			_tipPercentages.InsertSegment ("20%", 2, false);
			_tipPercentages.InsertSegment ("25%", 3, false);
			_tipPercentages.SelectedSegment = 2;
			_tipPercentages.ValueChanged += (sender, e) => CalculateCurrentTip();

			View.AddConstraint (NSLayoutConstraint.Create (_calculateButton, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, _tipPercentages, NSLayoutAttribute.Top, 1, -8)); 
			View.AddConstraint (NSLayoutConstraint.Create (_tipPercentages, NSLayoutAttribute.Width, NSLayoutRelation.Equal, View, NSLayoutAttribute.Width, 1, -40)); 
			View.AddConstraint (NSLayoutConstraint.Create (_tipPercentages, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, View, NSLayoutAttribute.CenterX, 1, 0));

			_tipLabel.TranslatesAutoresizingMaskIntoConstraints = false;
			_tipLabel.TextColor = UIColor.Blue;
			_tipLabel.Text = string.Format (TipFormat, 0);
			_tipLabel.TextAlignment = UITextAlignment.Center;

			View.AddConstraint (NSLayoutConstraint.Create (_tipLabel, NSLayoutAttribute.Top, NSLayoutRelation.Equal, _tipPercentages, NSLayoutAttribute.Bottom, 1, 8));
			View.AddConstraint (NSLayoutConstraint.Create (_tipLabel, NSLayoutAttribute.Width, NSLayoutRelation.Equal, View, NSLayoutAttribute.Width, 1, -40));
			View.AddConstraint (NSLayoutConstraint.Create (_tipLabel, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, View, NSLayoutAttribute.CenterX, 1, 0));


			View.BackgroundColor = UIColor.Yellow;
			View.AddGestureRecognizer (new UITapGestureRecognizer (() => _priceField.ResignFirstResponder ()));
		}

		private void CalculateCurrentTip(){
			_priceField.ResignFirstResponder();

			var price = 0.0;
			if (!double.TryParse (_priceField.Text, out price)) {
				return;
			}

			var percentage = ((_tipPercentages.SelectedSegment * 5) + 10) / 100.0;
			var tip = price * percentage;

			_tipLabel.Text = string.Format (TipFormat, tip);
		}

	}
}

