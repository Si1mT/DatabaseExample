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
using DatabaseExample;

namespace DatabaseExample
{
    class CustomAdapter : BaseAdapter<Stock>
    {
        List<Stock> posts;
        Activity context;

        public CustomAdapter(Activity context, List<Stock> posts) : base()
        {
            this.posts = posts;
            this.context = context;
        }

        public override Stock this[int position]
        {
            get
            {
                return posts[position];
            }
        }

        public override int Count
        {
            get
            {
                return posts.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);

            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = posts[position].Symbol;
            //view.FindViewById<TextView>(Resource.Id.textView_date).Text = posts[position].Date;
            //view.FindViewById<TextView>(Resource.Id.textView_text).Text = posts[position].PostText;
            //view.FindViewById<TextView>(Resource.Id.textView_like).Text = posts[position].Likes + " Likes";

            return view;
        }
    }
}