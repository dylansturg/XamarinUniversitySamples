using System;

using UIKit;

namespace iOSTableViews
{
	public partial class ViewController : UIViewController
	{
		private UITableView _tableView;
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad();

			_tableView = new UITableView (View.Frame);
			View.AddSubview (_tableView);
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

