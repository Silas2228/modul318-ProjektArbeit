using SwissTransport.GUI.ViewModels;
using SwissTransport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SwissTransport.GUI
{
	/// <summary>
	/// Interaction logic for StationMapWindow.xaml
	/// </summary>
	public partial class StationMapWindow : Window
	{
		private readonly StationMapWindowViewModel _stationMapWindowViewModel;
		public StationMapWindow(Coordinate coordinate)
		{
			InitializeComponent();
			_stationMapWindowViewModel = new StationMapWindowViewModel(coordinate);
			this.WebBrowser.Source = _stationMapWindowViewModel.UrlSource;
		}
	}
}
