using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;
using Mailbox;

namespace iOSTableViews
{
	partial class TableViewController : UITableViewController
	{
		private IList<EmailItem> _emails;
		private EmailItem _selectedEmail;

		public TableViewController (IntPtr handle) : base (handle)
		{
			_emails = new EmailServer ().Email;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			TableView.ContentInset = new UIEdgeInsets (20, 0, 0, 0);
		}

		public override nint RowsInSection (UITableView tableView, nint section)
		{
			return _emails.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = TableView.DequeueReusableCell ("EmailCell");
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Subtitle, "EmailCell");
			}


			cell.TextLabel.Text = _emails [indexPath.Row].Subject;
			cell.TextLabel.Font = UIFont.FromName ("Helvetica Light", 14);

			cell.DetailTextLabel.Text = _emails [indexPath.Row].Body;
			cell.DetailTextLabel.Font = UIFont.FromName ("Helvetica Light", 12);
			cell.DetailTextLabel.TextColor = UIColor.LightGray;

			cell.ImageView.Image = _emails [indexPath.Row].GetImage ();

			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			return cell;
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "PresentDetails") {
				var controller = segue.DestinationViewController as EmailMessageViewController;
				controller.Email = _selectedEmail;
			} else {
				base.PrepareForSegue (segue, sender);
			}
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			_selectedEmail = _emails [indexPath.Row];

			PerformSegue ("PresentDetails", this);
		}
	}
}
