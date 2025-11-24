using LiveCharts.Wpf;
using LiveCharts;
using System.Reflection.Emit;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace konkurs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SeriesCollection LineSeriesCollection { get; set; }
        public string[] Labels { get; set; }
        bool tryb_nocny = false;
        int passa = 0;
        public MainWindow()
        {
            InitializeComponent();
            if (!tryb_nocny) {
                cont.Background = Brushes.White;
                tryb_nocny = true;
            } else {
                cont.Background = Brushes.Blue;
                tryb_nocny = false;
            }

            LineSeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Nastrój",
                    Values = new ChartValues<double> { 3, 5, 7, 4, 6, 8, 67 }
                }
            };

            Labels = new[] { "18.11", "19.11", "20.11", "21.11", "22.11", "23.11", "24.11" };

            DataContext = this;
        }
        private void ust_Click(object sender, RoutedEventArgs e)
        {
            strona1.Visibility = Visibility.Collapsed;
            strona2.Visibility = Visibility.Collapsed;
            strona3.Visibility = Visibility.Collapsed;
            strona_ust.Visibility = Visibility.Visible;
        }
        private void trybnoc_Click(object sender, RoutedEventArgs e)
        {
            tryb_nocny = !tryb_nocny;
            ToggleTheme(tryb_nocny);
        }
        private void ToggleTheme(bool tn) {
            var dict = new ResourceDictionary();

            if (tn)
                dict.Source = new Uri("Themes/NightTheme.xaml", UriKind.Relative);
            else
                dict.Source = new Uri("Themes/DayTheme.xaml", UriKind.Relative);

            // Replace theme dictionary
            Application.Current.Resources.MergedDictionaries[0] = dict;
        }
        private void RButton_Click_1(object sender, RoutedEventArgs e) {
            strona1.Visibility = Visibility.Visible;
            strona2.Visibility = Visibility.Collapsed;
            strona3.Visibility = Visibility.Collapsed;
            strona_ust.Visibility = Visibility.Collapsed;
        }

        private void RButton_Click_2(object sender, RoutedEventArgs e) {
            strona1.Visibility = Visibility.Collapsed;
            strona2.Visibility = Visibility.Visible;
            strona3.Visibility = Visibility.Collapsed;
            strona_ust.Visibility = Visibility.Collapsed;
        }

        private void RButton_Click_3(object sender, RoutedEventArgs e) {
            strona1.Visibility = Visibility.Collapsed;
            strona2.Visibility = Visibility.Collapsed;
            strona3.Visibility = Visibility.Visible;
            strona_ust.Visibility = Visibility.Collapsed;
        }
    }
}