using LiveCharts.Wpf;
using LiveCharts;
using System.Reflection.Emit;
using System.Text;
using System.Windows;
using System.IO;
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
            LoadChart();
            Chart3.Series = new SeriesCollection
{
                new LineSeries
                {
                    Title = "Nastrój",
                    Values = new ChartValues<double> { 1, 2, 3, 4, 5, 6 }
                },
                new LineSeries
                {
                    Title = "Cwel",
                    Values = new ChartValues<double> { 6, 5, 4, 3, 2, 1 }
                }
            };
            Chart3.Labels = new[] { "19.11", "20.11", "21.11", "22.11", "23.11", "24.11" };
        }
        private void ust_Click(object sender, RoutedEventArgs e)
        {
            strona1.Visibility = Visibility.Collapsed;
            strona2.Visibility = Visibility.Collapsed;
            strona3.Visibility = Visibility.Collapsed;
            strona_ust.Visibility = Visibility.Visible;
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
        private void tworcy_Click(object sender, RoutedEventArgs e) {
            Tworcy.Visibility = Visibility.Visible;
        }
        private void zamknijtw(object sender, RoutedEventArgs e) {
            Tworcy.Visibility = Visibility.Collapsed    ;
        }
        private void zmien_Click(object sender, RoutedEventArgs e) {
            if (Username.Text.Length <= 0)
                MessageBox.Show("Nazwa użytkownika nie może być pusta!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (Username.Text.Length > 32)
                MessageBox.Show("Maksymalny rozmiar nazwy to 32", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            else {
                FileManager.Save("user/username.txt", Username.Text);
            }
        }

        // wybieranie emocji
        private void em1_MD(object sender, MouseEventArgs e) {
            MessageBox.Show("1");
            FileManager.Append("user/emocje.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "; " + "1");
            LoadChart();
        }
        private void em2_MD(object sender, MouseEventArgs e) {
            MessageBox.Show("2");
            FileManager.Append("user/emocje.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "; " + "2");
            LoadChart();
        }
        private void em3_MD(object sender, MouseEventArgs e) {
            MessageBox.Show("3");
            FileManager.Append("user/emocje.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "; " + "3");
            LoadChart();
        }
        private void em4_MD(object sender, MouseEventArgs e) {
            MessageBox.Show("4");
            FileManager.Append("user/emocje.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "; " + "4");
            LoadChart();
        }
        private void em5_MD(object sender, MouseEventArgs e) {
            MessageBox.Show("5");
            FileManager.Append("user/emocje.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "; " + "5");
            LoadChart();
        }
            private void LoadChart() { 
            var lines = File.ReadAllLines("user/emocje.txt");

            List<DateTime> timestamps = new List<DateTime>();
            ChartValues<double> values = new ChartValues<double>();

            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length != 2)
                    continue;

                DateTime time = DateTime.Parse(parts[0].Trim());
                double val = double.Parse(parts[1].Trim());

                timestamps.Add(time);
                values.Add(val);
            }

            // Fill chart values
            Chart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Humor",
                    Values = values,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 8
                }
            };

            // Convert timestamps to a human-readable X-axis label
            Chart1.Labels = timestamps
                .Select(t => t.ToString("HH:mm:ss")).ToArray();
        }
    }

}