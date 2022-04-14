using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwissTransport.GUI.Models
{
	public class ConnectionView
	{
		#region Constructors
		public ConnectionView(DateTime departure, DateTime arrival, string platform, string duration, string from, string to)
		{
			this.Departure = departure.ToString("dd.MM.yyyy HH:mm");
			this.Arrival = arrival.ToString("dd.MM.yyyy HH:mm");
			this.Platform = platform;
			this.Duration = duration;
			this.From = from;
			this.To = to;
		}
		#endregion

		#region Properties
		public string From { get; set; } = string.Empty;
		public string To { get; set; } = string.Empty;
		public string Departure { get; set; } = string.Empty;
		public string Arrival { get; set; } = string.Empty;
		public string Platform { get; set; } = string.Empty;
		public string Duration { get; set; } = string.Empty;
		#endregion
	}
}	
