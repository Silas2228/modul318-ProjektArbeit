using SwissTransport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwissTransport.GUI.ViewModels
{
	public class StationMapWindowViewModel : BaseViewModel
	{
		#region Private Members
		private readonly Uri _urlsource;
		#endregion

		#region Constructors
		public StationMapWindowViewModel(Coordinate coordinate)
		{
			double ycoordinate = Convert.ToDouble(coordinate.YCoordinate);
			double xcoordinate = Convert.ToDouble(coordinate.XCoordinate);
			this._urlsource = new Uri($"https://www.google.com/maps/search/?api=1&query={xcoordinate.ToString().Replace(",", ".")},{ycoordinate.ToString().Replace(",", ".")}&zoom=20");
		}
		#endregion

		#region Properties
		public Uri UrlSource
		{
			get { return _urlsource; }
		}
		#endregion
	}
}
