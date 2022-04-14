using SwissTransport.Core;
using SwissTransport.GUI.Helpers;
using SwissTransport.GUI.Models;
using SwissTransport.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SwissTransport.GUI.ViewModels
{
	public class DepartureBoardViewModel : BaseViewModel
	{
		#region Private Members
		private string _station = string.Empty;
		private const string id = "id";
		private Station _stationBoard;
		private string _transportation = string.Empty;
		private ObservableCollection<StationBoard> _stationBoards;
		private ObservableCollection<DepartureBoardView> _departureBoardViews;
		private readonly ITransport _transport;
		private readonly RelayCommand _clearButtonCommand;
		private readonly RelayCommand _searchStationsButtonCommand;
		private readonly RelayCommand _mapButtonCommand;
		#endregion

		#region Constructors
		public DepartureBoardViewModel()
		{
			_stationBoard = new Station();
			_stationBoards = new ObservableCollection<StationBoard>();
			_departureBoardViews = new ObservableCollection<DepartureBoardView>();
			_transport = new Transport();
			_clearButtonCommand = new RelayCommand(ClearButtonClick, o => ClearButtonCommandCanExecute());
			_searchStationsButtonCommand = new RelayCommand(SearchStationsButtonClick, o => SearchStationsCommandCanExecute());
			_mapButtonCommand = new RelayCommand(MapButtonClick, o => MapCommandCanExecute());
			Transportations = new Dictionary<string,string>();
			Transportations.Add(string.Empty, string.Empty);
			Transportations.Add("Zug","train");
			Transportations.Add("tram","tram");
			Transportations.Add("Schiff","ship");
			Transportations.Add("Bus","bus");
			Transportations.Add("Seilbahn", "cableway");
		}
		#endregion

		#region Properties
		public string Station
		{
			get { return _station; }
			set { _station = value; OnPropertyChanged(); }
		}

		public string Transportation
		{
			get { return _transportation; }
			set { _transportation = value; OnPropertyChanged(); }
		}

		public Station StationBoard
		{
			get { return _stationBoard; }
			set
			{
				_stationBoard = value;
				OnPropertyChanged();
				MapButtonComand.RaiseCanExecuteChanged();
			}
		}

		public ObservableCollection<StationBoard> StationBoards
		{
			get { return _stationBoards; }
			set { _stationBoards = value; OnPropertyChanged(); }
		}

		public ObservableCollection<DepartureBoardView> DepartureBoardViews
		{
			get { return _departureBoardViews; }
			set { _departureBoardViews = value; OnPropertyChanged(); }
		}

		public IDictionary<string, string> Transportations { get; set; }

		public RelayCommand ClearButtonComand
		{
			get { return _clearButtonCommand; }
		}

		public RelayCommand SearchStationsButtonComand
		{
			get { return _searchStationsButtonCommand; }
		}

		public RelayCommand MapButtonComand
		{
			get { return _mapButtonCommand; }
		}
		#endregion

		#region Public Methods
		public void GetConnections()
		{
			try
			{
				DepartureBoardViews.Clear();
				StationBoardRoot stationBoardRoot = new StationBoardRoot();

				if (string.IsNullOrEmpty(Transportation))
				{
					stationBoardRoot = _transport.GetStationBoard(this.Station, id);
				}
				else
				{
					string transportation = Transportations.Where(x => x.Key.Equals(Transportation)).FirstOrDefault().Value;
					stationBoardRoot = _transport.GetStationBoard(this.Station, id, transportation);
				}

				foreach (StationBoard station in stationBoardRoot.Entries)
				{
					DepartureBoardViews.Add(new DepartureBoardView(station.Name, station.To, station.Category, station.Stop.Departure.ToString("HH:mm"), station.Number));
				}
			}
			catch
			{

			}
		}

		public List<Station> GetStations()
		{
			return _transport.GetStations(Station).StationList;
		}

		public void ClearButtonClick(object parameter)
		{
			this.Station = string.Empty;
			this.Transportation = string.Empty;
		}

		public void SearchStationsButtonClick(object parameter)
		{
			GetConnections();
		}

		public void MapButtonClick(object parameter)
		{
			try
			{
				Station? station = this._transport.GetStations(this.Station).StationList.FirstOrDefault();
				if (station != null)
				{
					this.StationBoard = station;
					StationMapWindow stationMapWindow = new StationMapWindow(StationBoard.Coordinate);
					stationMapWindow.ShowDialog();
				}
			}
			catch
			{

			}
		}
		#endregion

		#region Private Methods
		private bool ClearButtonCommandCanExecute()
		{
			return !string.IsNullOrEmpty(this.Station);
		}

		private bool SearchStationsCommandCanExecute()
		{
			return !string.IsNullOrEmpty(this.Station);
		}

		private bool MapCommandCanExecute()
		{
			if (!string.IsNullOrEmpty(this.Station))
			{
				return true;
			}

			return false;
		}
		#endregion
	}
}
