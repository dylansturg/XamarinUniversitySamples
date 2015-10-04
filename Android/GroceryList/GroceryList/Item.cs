using System;
using Android.OS;
using Mono;

using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using Java.Interop;

namespace GroceryList
{
	public class Item : Java.Lang.Object, IParcelable
	{
		private static readonly IParcelableCreator _creator = new ItemCreator();

		[ExportAttribute("CREATOR")]
		public static IParcelableCreator GetCreator(){
			return _creator;
		}

		public string Name { get; set;}
		public int Count { get; set;}

		public Item(){}
		public Item(Parcel parcel){
			Name = parcel.ReadString ();
			Count = parcel.ReadInt ();
		}

		public override string ToString(){
			return Name;
		}

		public int DescribeContents(){
			return 0;
		}

		public void WriteToParcel(Parcel dest, ParcelableWriteFlags flags){
			dest.WriteString (Name);
			dest.WriteInt (Count);
		}
	}

	public class ItemCreator : Java.Lang.Object, IParcelableCreator
	{
		public Java.Lang.Object CreateFromParcel(Parcel source)
		{
			return new Item (source);
		}

		public Java.Lang.Object[] NewArray(int size)
		{
			return new Item[size];
		}
	}
}

