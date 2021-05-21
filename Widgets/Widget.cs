using System.ComponentModel;
using System.Xml.Serialization;

namespace Acme.Packages.Widgets
{
	public class Widget
	{
		public Widget()
		{
			_name = "";
			_id = 0;
		}

		public Widget(string name, int id)
		{
			_name = name;
			_id = id;
		}

		private int _id;

		public int Id
		{
			get { return _id; }
			set 
			{
				_id = value;
				IsModified = true;
			}
		}

		private string _name;

		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				IsModified = true;
			}
		}

		private bool _isModified;

		[XmlIgnore]
		[Browsable(false)]
		public bool IsModified
		{
			get { return _isModified; }
			set { _isModified = value; }
		}
	
	}
}
