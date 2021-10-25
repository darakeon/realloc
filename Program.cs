using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace realloc
{
	public static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main()
		{
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			var chooser = new Chooser();

			var folders = Directory
				.GetDirectories(Config.Destiny)
				.OrderBy(f => f)
				.Where(f => f != Config.Origin)
				.ToArray();

			for (var f = 0; f < folders.Length; f++)
			{
				var folder = folders[f];
				var dir = new DirectoryInfo(folder);
				chooser.Controls.Add(createButton(dir.Name, f));
			}

			var file = getFile(Config.Origin);

			chooser.setImage(file);

			Application.Run(chooser);
		}

		private static Button createButton(String name, Int32 index)
		{
			var x = 358 + index % 2 * 81;
			var y = 12 + index / 2 * 29;

			return new Button
			{
				Location = new Point(x, y),
				Name = name,
				Size = new Size(75, 23),
				TabIndex = index + 1,
				Text = name,
				UseVisualStyleBackColor = true
			};
		}

		private static String getFile(String path)
		{
			var file = Directory
				.GetFiles(path)
				.FirstOrDefault();

			if (file != null)
				return file;

			var directory = Directory
				.GetDirectories(path)
				.FirstOrDefault();

			if (directory != null)
				return getFile(directory);

			return null;
		}
	}
}
