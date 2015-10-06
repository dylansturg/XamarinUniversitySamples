using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using Mailbox;

namespace iOSTableViews
{
	partial class EmailMessageViewController : UIViewController
	{
		public EmailItem Email { get; set; }

		public EmailMessageViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			SubjectLabel.Text = Email.Subject;
			BodyLabel.Text = Email.Body;
			GoBackButton.UserInteractionEnabled = true;
			GoBackButton.TouchUpInside += (sender, e) => DismissViewController (true, () => {
			});
		}

		partial void GoBackButton_TouchUpInside (UIButton sender)
		{
			DismissViewController(true, () => {});
		}
	}
}
