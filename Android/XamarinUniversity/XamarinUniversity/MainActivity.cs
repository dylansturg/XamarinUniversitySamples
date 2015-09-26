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

			_instructorList.ItemClick += (sender, e) => 
			{
				var selectedInstructor = InstructorData.Instructors[e.Position];
				var alertBuilder = new AlertDialog.Builder(this);
				alertBuilder.SetTitle("Clicked An Instructor");
				alertBuilder.SetMessage(selectedInstructor.Name);
				alertBuilder.SetNeutralButton("OK", (s, args)=> {});
				var alert = alertBuilder.Create();
				alert.Show();
			};
		}
	}
}


