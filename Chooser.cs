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
			Image.ImageLocation = path;
		}

		public void ClearImage()
		{
			Image.ImageLocation = null;
		}

		public void SetDelete(Action<Object, EventArgs> action)
		{
			Delete.Click += new EventHandler(action);
		}
	}
}
