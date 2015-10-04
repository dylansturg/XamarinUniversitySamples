
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

namespace GroceryList
{
	[Activity (Label = "Details")]			
	public class DetailsActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			var item = (Item)Intent.GetParcelableExtra("item");

			if (item == null) {
				return;
			}

			FindViewById<TextView> (Resource.Id.details_name_field).Text = item.Name;
			FindViewById<TextView> (Resource.Id.details_count_field).Text = item.Count.ToString();
		}
	}
}

