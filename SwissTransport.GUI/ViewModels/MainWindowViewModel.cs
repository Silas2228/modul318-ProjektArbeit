using SwissTransport.GUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SwissTransport.GUI.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
		#region Private Members
		private Visibility _searchConnectionControlVisibility;
		private Visibility _departureBoardControlVisibility = Visibility.Collapsed;
		private readonly RelayCommand _searchConnectionButtonCommand;
		private readonly RelayCommand _departureBoardButtonCommand;
		#endregion

		#region Constructors
		public MainWindowViewModel()
		{
			_searchConnectionButtonCommand = new RelayCommand(SearchConnectionButtonClick);
			_departureBoardButtonCommand = new RelayCommand(DepartureBoardButtonClick);
		}
		#endregion

		#region Properties
		public Visibility SearchConnectionControlVisibility
		{
			get { return _searchConnectionControlVisibility; }
			set { _searchConnectionControlVisibility = value; OnPropertyChanged(); }
		}

		public Visibility DepartureBoardControlVisibility
		{
			get { return _departureBoardControlVisibility; }
			set { _departureBoardControlVisibility = value; OnPropertyChanged(); }
		}

		public RelayCommand SearchConnectionButtonCommand
		{
			get { return _searchConnectionButtonCommand; }
		}

		public RelayCommand DepartureBoardButtonCommand
		{
			get { return _departureBoardButtonCommand; }
		}
		#endregion

		#region Public Methods
		public void SearchConnectionButtonClick(object parameter)
		{
			SearchConnectionControlVisibility = Visibility.Visible;
			DepartureBoardControlVisibility = Visibility.Collapsed;
		}

		public void DepartureBoardButtonClick(object parameter)
		{
			DepartureBoardControlVisibility = Visibility.Visible;
			SearchConnectionControlVisibility = Visibility.Collapsed;
		}
		#endregion
	}
}
