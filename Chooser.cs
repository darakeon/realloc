using System;
using System.Windows.Forms;

namespace realloc
{
	public partial class Chooser : Form
	{
		public Chooser()
		{
			InitializeComponent();
		}

		public void SetImage(String path)
		{
			if (path != null && path.EndsWith(".mp4"))
			{
				Image.ImageLocation = null;
			}
			else
			{
				Image.ImageLocation = path;
			}
		}

		public void SetDelete(Action<Object, EventArgs> action)
		{
			Delete.Click += new EventHandler(action);
		}
	}
}
