using SwissTransport.GUI.ViewModels;
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
	/// Interaction logic for SearchConnectionControl.xaml
	/// </summary>
	public partial class SearchConnectionControl : UserControl
	{
		private readonly SearchConnectionControlViewModel searchConnectionControlViewModel;
		public SearchConnectionControl()
		{
			InitializeComponent();
			searchConnectionControlViewModel = new SearchConnectionControlViewModel();
			this.grdSearchConnectionControl.DataContext = searchConnectionControlViewModel;
			this.txtFrom.Focus();
		}

		private void TxtFromPreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				txtTo.Focus();
			}
		}
	}
}
