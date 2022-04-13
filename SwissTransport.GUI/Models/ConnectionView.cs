using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwissTransport.GUI.Models
{
	public class ConnectionView
	{
		public ConnectionView(DateTime departure, DateTime arrival, string platform, string duration)
		{
			this.Departure = departure.ToString("dd.MM.yyyy HH:mm");
			this.Arrival = arrival.ToString("dd.MM.yyyy HH:mm");
			this.Platform = platform;
			this.Duration = duration;
		}

		#region Properties
		public string Departure { get; set; }
		public string Arrival { get; set; }
		public string Platform { get; set; }
		public string Duration { get; set; }
		#endregion
	}
}
