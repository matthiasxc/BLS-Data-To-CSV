using System.Windows;
using ParsingBLSData.ViewModel;

namespace ParsingBLSData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void GoToBTables(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://bls.gov/webapps/legacy/cesbtab1.htm"); 
        }

        private void GoToATablesPage(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://bls.gov/webapps/legacy/cpsatab1.htm");
        }

        private void GoToStateEmployment(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://data.bls.gov/cgi-bin/dsrv?la");
        }

        private void GoToStateIndustryTables(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://data.bls.gov/cgi-bin/dsrv?sm");
        }

        private void GoToSmoothMetro(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.bls.gov/lau/metrossa.htm");
        }
    }
}
