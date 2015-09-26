using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace XamarinUniversity
{
	[Activity (Label = "XamarinUniversity", MainLauncher = true, Icon = "@drawable/Icon")]
	public class MainActivity : Activity
	{
		private ListView _instructorList;
		private IListAdapter _instructorsAdapter;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			_instructorList = FindViewById<ListView> (Resource.Id.instructor_list);
			_instructorsAdapter = new InstructorAdapter (this, InstructorData.Instructors);
			_instructorList.Adapter = _instructorsAdapter;
			_instructorList.FastScrollEnabled = true;

			_instructorList.ItemClick += (sender, e) => 
			{
				var detailsIntent = new Intent(this, typeof(InstructorDetailsActivity));
				detailsIntent.PutExtra("position", e.Position);
				StartActivity(detailsIntent);
			};
		}
	}
}


