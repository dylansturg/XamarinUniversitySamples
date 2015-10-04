
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
	[Activity (Label = "Items")]			
	public class ItemsActivity : Activity
	{
		private ListView _list;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView(Resource.Layout.Items);

			var items = (Item[])Intent.GetParcelableArrayExtra ("items");
			var adapter = new ArrayAdapter<Item> (this, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, items);

			_list = FindViewById<ListView> (Resource.Id.items_list);
			_list.Adapter = adapter;
		}
	}
}

