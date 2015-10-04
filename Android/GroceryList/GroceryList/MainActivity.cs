using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace GroceryList
{
	[Activity (Label = "GroceryList", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		Item[] items = {
			new Item{
				Name = "Milk",
				Count = 1,
			},

			new Item{
				Name = "Eggs",
				Count = 12
			},

			new Item{
				Name = "Cake",
				Count = 9000,
			}
		};
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			var itemListButton = FindViewById<Button> (Resource.Id.items_button);
			itemListButton.Click += (sender, e) => {
				var intent = new Intent (this, typeof(ItemsActivity));
				intent.PutExtra("items", items);
				StartActivity (intent);
			};

			var addItemButton = FindViewById<Button> (Resource.Id.add_item_button);
			addItemButton.Click += (sender, e) => {
				StartActivity (new Intent (this, typeof(AddItemActivity)));
			};

			var aboutButton = FindViewById<Button> (Resource.Id.about_button);
			aboutButton.Click += (sender, e) => {
				StartActivity (new Intent (this, typeof(AboutActivity)));
			};

		}
	}
}


