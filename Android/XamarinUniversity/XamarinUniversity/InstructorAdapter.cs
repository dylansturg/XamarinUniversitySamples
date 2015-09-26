using System;
using System.Collections.Generic;
using Android.Widget;
using Android.Content;
using Android.Views;

namespace XamarinUniversity
{
	public class InstructorAdapter : BaseAdapter<Instructor>
	{
		private List<Instructor> _instructors;
		private Context _context;

		public override Instructor this [int position] { get { return _instructors [position]; } }

		public override int Count {
			get {
				return _instructors.Count;
			}
		}

		public InstructorAdapter(Context ctx, List<Instructor> instructors)
		{
			_instructors = instructors;
			_context = ctx;
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			if (convertView == null) {
				convertView = LayoutInflater.FromContext (_context).Inflate (Resource.Layout.InstructorListItem, parent, false);
			}

			var instructor = _instructors [position];
			var nameView = convertView.FindViewById<TextView> (Resource.Id.instructor_title);
			var specialityView = convertView.FindViewById<TextView> (Resource.Id.instructor_detail);
			var instructorImage = convertView.FindViewById<ImageView> (Resource.Id.instructor_image);

			nameView.Text = instructor.Name;
			specialityView.Text = instructor.Specialty;

			var instructorDrawable = Android.Graphics.Drawables.Drawable.CreateFromStream (_context.Assets.Open (instructor.ImageUrl), null);
			instructorImage.SetImageDrawable (instructorDrawable);

			return convertView;
		}
	}
}

