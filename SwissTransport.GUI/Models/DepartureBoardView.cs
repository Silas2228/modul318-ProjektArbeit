using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwissTransport.GUI.Models
{
	public class DepartureBoardView
	{ 
		private string _name = string.Empty;
		private string _to = string.Empty;
		private string _category = string.Empty;
		private string _departure = string.Empty;
		private string _categoryAndNumber = string.Empty;
		private string _number = string.Empty;
		public DepartureBoardView(string name, string to, string category, string departure, string number)
		{
			this._name = name;
			this._to = to;
			this._category = category;
			this._departure = departure;
			this._number = number;
			this._categoryAndNumber = category + number;
		}

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public string To
		{
			get { return _to; }
			set { _to = value; }
		}

		public string Departure
		{
			get { return _departure; }
			set { _departure = value; }
		}
		
		public string CategoryAndNumber
		{
			get { return _categoryAndNumber; }
			set { _categoryAndNumber = value; }
		}
	}
}
