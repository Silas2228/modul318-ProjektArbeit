using SwissTransport.Core;
using SwissTransport.GUI.Helpers;
using SwissTransport.GUI.Models;
using SwissTransport.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwissTransport.GUI.ViewModels
{
	public class SearchConnectionControlViewModel : BaseViewModel
	{
		#region Private Members
		private string _fromstation = string.Empty;
		private string _tostation = string.Empty;
		private string _date = DateTime.Now.ToString("dd.MM.yyyy");
		private string _time = DateTime.Now.ToString("HH:mm");
		private ObservableCollection<ConnectionView> _connectionViews;
		private readonly ITransport _transport;
		private readonly RelayCommand _searchConnectionsButtonCommand;
		private readonly RelayCommand _clearButtonCommand;
		#endregion

		#region Constructors
		public SearchConnectionControlViewModel()
		{
			_connectionViews = new ObservableCollection<ConnectionView>();
			_transport = new Transport();
			_searchConnectionsButtonCommand = new RelayCommand(SearchConnectionButtonClick, o => SearchButtonCommandCanExecute());
			_clearButtonCommand = new RelayCommand(ClearButtonClick, o => ClearButtonCommandCanExecute());
		}
		#endregion

		#region Properties
		public string FromStation
		{
			get { return _fromstation; }
			set { _fromstation = value; OnPropertyChanged(); }
		}

		public string ToStation
		{
			get { return _tostation; }
			set { _tostation = value; OnPropertyChanged(); }
		}

		public string Date
		{
			get { return _date; }
			set
			{
				if (!string.IsNullOrEmpty(value))
				{
					if (!DateTime.TryParseExact(value, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
					{
						ClearButtonCommand.RaiseCanExecuteChanged();
						SearchConnectionsButtonCommand.RaiseCanExecuteChanged();
					}
				}

				_date = value; OnPropertyChanged();
			}
		}

		public string Time
		{
			get { return _time; }
			set
			{
				if (!string.IsNullOrEmpty(value))
				{
					if (!DateTime.TryParseExact(value, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
					{
						ClearButtonCommand.RaiseCanExecuteChanged();
						SearchConnectionsButtonCommand.RaiseCanExecuteChanged();
					}
				}

				_time = value; OnPropertyChanged();
			}
		}

		public ObservableCollection<ConnectionView> ConnectionViews
		{
			get { return _connectionViews; }
			set { _connectionViews = value; OnPropertyChanged(); }
		}

		public RelayCommand SearchConnectionsButtonCommand
		{
			get { return _searchConnectionsButtonCommand; }
		}

		public RelayCommand ClearButtonCommand
		{
			get { return _clearButtonCommand; }
		}

		#endregion

		#region Public Methods

		public void SearchConnectionButtonClick(object parameter)
		{
			GetConnections();
		}

		public void ClearButtonClick(object parameter)
		{
			this.FromStation = string.Empty;
			this.ToStation = string.Empty;
			this.Date = string.Empty;
			this.Time = string.Empty;
		}
		#endregion

		#region Private Methods
		private void GetConnections()
		{
			try
			{
				ConnectionViews.Clear();
				if (!string.IsNullOrEmpty(FromStation) && !string.IsNullOrEmpty(ToStation))
				{
					IList<Connection> connections = new List<Connection>();

					if (!string.IsNullOrEmpty(Date) && !string.IsNullOrEmpty(Time))
					{
						connections = _transport.GetConnections(FromStation, ToStation, Convert.ToDateTime(Date + " " + Time)).ConnectionList;
					}
					else
					{
						connections = _transport.GetConnections(FromStation, ToStation).ConnectionList;
					}

					foreach (Connection connection in connections)
					{
						ConnectionViews.Add(new ConnectionView(Convert.ToDateTime(connection.From.Departure), Convert.ToDateTime(connection.To.Arrival), connection.From.Platform, connection.Duration, connection.From.Station.Name, connection.To.Station.Name));
					}
				}
			}
			catch
			{
			}
		}

		private bool SearchButtonCommandCanExecute()
		{
			if (!string.IsNullOrEmpty(Date) || !string.IsNullOrEmpty(Time))
			{
				if (!DateTime.TryParseExact(Date, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _) || !DateTime.TryParseExact(Time, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
				{
					return false;
				}
			}


			if (!string.IsNullOrEmpty(FromStation) && !string.IsNullOrEmpty(ToStation))
			{
				return true;
			}

			return false;
		}

		private bool ClearButtonCommandCanExecute()
		{
			if (!string.IsNullOrEmpty(FromStation) || !string.IsNullOrEmpty(ToStation) || !string.IsNullOrEmpty(Date) || !string.IsNullOrEmpty(Time))
			{
				return true;
			}

			return false;
		}
		#endregion
	}
}
