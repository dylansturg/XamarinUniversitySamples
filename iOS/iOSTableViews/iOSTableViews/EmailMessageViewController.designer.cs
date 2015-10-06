// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace iOSTableViews
{
	[Register ("EmailMessageViewController")]
	partial class EmailMessageViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel BodyLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton GoBackButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel SubjectLabel { get; set; }

		[Action ("GoBackButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void GoBackButton_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (BodyLabel != null) {
				BodyLabel.Dispose ();
				BodyLabel = null;
			}
			if (GoBackButton != null) {
				GoBackButton.Dispose ();
				GoBackButton = null;
			}
			if (SubjectLabel != null) {
				SubjectLabel.Dispose ();
				SubjectLabel = null;
			}
		}
	}
}
