using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using Artech.FrameworkDE;
using Artech.Architecture.UI.Framework.Packages;
using Artech.Architecture.UI.Framework.Services;
using System.IO;
using System.Xml.Xsl;
using System.Xml;
using System.Globalization;
using System.Drawing;
using DailyDilbert;

namespace Artech.Samples.DailyDilbert
{
	[Guid("B94EB5F4-F7E5-45d2-B5F7-78AAC50630FE")]
	public partial class DilbertWindow : AbstractToolWindow
	{
		public static Guid guid = typeof(DilbertWindow).GUID;

		private XslCompiledTransform transform;

		public XslCompiledTransform Transform
		{
			get
			{
				if (transform == null)
				{
					XmlDocument xmlTransform = new XmlDocument();
					xmlTransform.LoadXml(Resources.Transform);
					transform = new XslCompiledTransform();
					transform.Load(xmlTransform);
				}

				return transform; 
			}
		}

		public DilbertWindow()
		{
			InitializeComponent();
		}

		protected string GetFailPage(string errorDescription)
		{
			return string.Format(Resources.FailPage, errorDescription);
		}

		protected override void OnLoad(EventArgs e)
		{
			string documentText;
			StringWriter textWriter = null;

			try
			{
				textWriter = new StringWriter(CultureInfo.InvariantCulture);
				Transform.Transform("http://feeds.feedburner.com/DilbertDailyStrip", new XsltArgumentList(), textWriter);
				documentText = textWriter.ToString();
			}
			catch (Exception exception)
			{
				documentText = GetFailPage(exception.Message);
			}
			finally
			{
				if (textWriter != null)
					textWriter.Dispose();
			}

			webBrowser.DocumentText = documentText;
		}

		public override Icon Icon
		{
			get
			{
				return Resources.Dilbert;
			}
		}

		
	}
}
