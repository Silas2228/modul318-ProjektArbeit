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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SwissTransport.GUI.Controls
{
	/// <summary>
	/// Interaction logic for DepartureBoardControl.xaml
	/// </summary>
	public partial class DepartureBoardControl : UserControl
	{
		private readonly DepartureBoardViewModel departureBoardViewModel;
		public DepartureBoardControl()
		{
			InitializeComponent();
			departureBoardViewModel = new DepartureBoardViewModel();
			this.grdDepartureBoardControl.DataContext = departureBoardViewModel;
		}

		public void CmbautocompleteTextChanged(object sender, TextChangedEventArgs e)
		{
			try
			{
				List<string> stationnames = new List<string>();
				List<Station> stations = departureBoardViewModel.GetStations();
				foreach (Station s in stations)
				{
					stationnames.Add(s.Name);
				}
				cmbautocomplete.ItemsSource = stationnames;
				cmbautocomplete.IsDropDownOpen = true;
			}
			catch
			{

			}
		}

		private void cmbautocomplete_GotFocus(object sender, RoutedEventArgs e)
		{
			BtnSearchStations.TabIndex = 0;
		}
	}
}
