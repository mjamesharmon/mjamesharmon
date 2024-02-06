using System;
using System.Net.Sockets;
using System.Text;

namespace Updater.Core.Extensions
{
	public class ImageOptions
	{
		private string? _light = null;

		private string? _dark = null;

		private string? _alt_text = null;

		private string? _all_img = null;

		public ImageOptions Light(string light)
		{
			_light = light;
			return this;
		}


		public ImageOptions Dark(string dark)
		{
			_dark = dark;
			return this;
		}


		public ImageOptions AlternateText(string text)
		{
			_alt_text = text;
			return this;
		}

		public ImageOptions AlternateImage(string image)
		{
			_all_img = image;
			return this;
		}

		public string ToHtml()
        {
			StringBuilder image = new StringBuilder();
			image.AppendLine("\n<picture>");
			image.AppendLineOrOmit(_dark,
				v => "<source media=\"(prefers-color-scheme: dark)\""
				+ $"srcset=\"{v}\" >");
            image.AppendLineOrOmit(_light,
	            v => "<source media=\"(prefers-color-scheme: light)\""
                + $"srcset=\"{v}\" >");
			image.AppendLine(
				$"<img alt=\"{_alt_text}\" src=\"{_all_img}\" >");
            image.AppendLine("</picture>\n");
			return image.ToString();
        }
	}
}


