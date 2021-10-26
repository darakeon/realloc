using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace realloc
{
	public static class Program
	{
		private static String file;
		private static Process process;

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

			setImage(chooser);

			setDelete(chooser);

			var folders = Directory
				.GetDirectories(Config.Destiny)
				.OrderBy(f => f)
				.Where(f => f != Config.Origin)
				.ToArray();

			for (var f = 0; f < folders.Length; f++)
			{
				var folder = folders[f];
				var dir = new DirectoryInfo(folder);
				var button = createButton(dir.Name, f, folder, chooser);
				chooser.Controls.Add(button);
			}

			Application.Run(chooser);
		}

		private static void setImage(Chooser chooser)
		{
			file = getFile(Config.Origin);

			if (file.EndsWith(".mp4"))
			{
				process = Process.Start(
					Config.VideoPlayer, $"\"{file}\""
				);
				chooser.ClearImage();
			}
			else
			{
				chooser.SetImage(file);
			}
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

			if (path == Config.Origin)
				return null;

			Directory.Delete(path);
			
			return getFile(Config.Origin);
		}

		private static void setDelete(Chooser chooser)
		{
			chooser.SetDelete((_, _) =>
			{
				File.Delete(file);
				setImage(chooser);
			});
		}

		private static Button createButton(String name, Int32 index, String path, Chooser chooser)
		{
			var x = 358 + index % 2 * 81;
			var y = 12 + 29 + index / 2 * 29;

			var button = new Button
			{
				Location = new Point(x, y),
				Name = name,
				Size = new Size(75, 23),
				TabIndex = index + 1,
				Text = name,
				UseVisualStyleBackColor = true,
			};

			button.Click += new EventHandler(moveFile(path, chooser));

			return button;
		}

		private static Action<Object, EventArgs> moveFile(String path, Chooser chooser)
		{
			return (_, _) =>
			{
				if (process != null)
				{
					process.Kill();
					process = null;
					Thread.Sleep(1000);
				}

				var name = new FileInfo(file).Name;

				path = addDate(path, name);
				var newPath = Path.Combine(path, name);

				File.Move(file, newPath);
				setImage(chooser);
			};
		}

		private static String addDate(String path, String name)
		{
			var yearPath = addDatePart(path, name, @"\\\d{4}$", 0, 4);

			return yearPath == path 
				? path 
				: addDatePart(yearPath, name, @"\\\d{2}$", 5, 2);
		}

		private static String addDatePart(String path, String name, String pattern, Int32 start, Int32 count)
		{
			var dirs = Directory
				.GetDirectories(path)
				.Where(d => Regex.IsMatch(d, pattern));

			if (!dirs.Any())
				return path;

			var year = name.Substring(start, count);
			path = Path.Combine(path, year);

			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);
			
			return path;
		}
	}
}
