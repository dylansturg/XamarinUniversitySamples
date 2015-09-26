using System;
using System.Collections.Generic;
using Android.Widget;
using Android.Content;
using Android.Views;

namespace XamarinUniversity
{
	public class InstructorAdapter : BaseAdapter<Instructor>, ISectionIndexer
	{
		private List<Instructor> _instructors;
		private Context _context;

		private Java.Lang.Object[] _sectionHeaders;
		private Dictionary<int, int> _positionsForSectionMap;
		private Dictionary<int, int> _sectionForPositionsMap;

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

			_sectionHeaders = SectionIndexerBuilder.BuildSectionHeaders (instructors);
			_sectionForPositionsMap = SectionIndexerBuilder.BuildSectionForPositionMap (instructors);
			_positionsForSectionMap = SectionIndexerBuilder.BuildPositionForSectionMap (instructors);
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			if (convertView == null) {
				convertView = LayoutInflater.FromContext (_context).Inflate (Resource.Layout.InstructorListItem, parent, false);
				var holder = new ViewHolder 
				{
					Name = convertView.FindViewById<TextView> (Resource.Id.instructor_title),
					Specialty = convertView.FindViewById<TextView> (Resource.Id.instructor_detail),
					Photo = convertView.FindViewById<ImageView> (Resource.Id.instructor_image)
				};

				convertView.Tag = holder;
			}

			var instructor = _instructors [position];
			var cachedViews = (ViewHolder) convertView.Tag;

			cachedViews.Name.Text = instructor.Name;
			cachedViews.Specialty.Text = instructor.Specialty;
			cachedViews.Photo.SetImageDrawable (ImageAssetManager.Get(_context, instructor.ImageUrl));

			return convertView;
		}


		public int GetPositionForSection (int sectionIndex)
		{
			return _positionsForSectionMap [sectionIndex];
		}
		public int GetSectionForPosition (int position)
		{
			return _sectionForPositionsMap [position];
		}
		public Java.Lang.Object[] GetSections ()
		{
			return _sectionHeaders;
		}
	}
}

