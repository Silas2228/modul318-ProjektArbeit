using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwissTransport.GUI.Models
{
	public class DepartureBoardView
	{
		#region Constructors
		public DepartureBoardView(string name, string to, string category, string departure, string number)
		{
			this.Name = name;
			this.To = to;
			this.Departure = departure;
			this.Category = category;
			this.Railway = category + number;
		}
		#endregion

		#region Properties
		public string Name { get; set; } = string.Empty;
		public string To { get; set; } = string.Empty;
		public string Departure { get; set; } = string.Empty;
		public string Category { get; set; } = string.Empty;
		public string Railway { get; set; } = string.Empty;
		#endregion
	}
}
