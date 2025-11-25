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
        int currentStreak = 0;
        DateTime lastEntryDate = DateTime.MinValue;
        string username;
        public MainWindow()
        {
            InitializeComponent();
            pasta.Text = $"🔥Passa: {currentStreak}";
            LoadChart40(Chart3);
            LoadChart24(Chart1);
            LoadStreak();
            username = FileManager.Load("user/username.txt");
            if (string.IsNullOrWhiteSpace(username)) {
                powitaj.Visibility = Visibility.Visible;
            }
            nazwauz.Text = "Nazwa użytkownika: " + username;
            dziendobry.Text = "Dzień dobry " + username + "!";
            notatka.Text = FileManager.Load("user/note.txt");
        }
        private void ust_Click(object sender, RoutedEventArgs e)
        {
            strona1.Visibility = Visibility.Collapsed;
            strona2.Visibility = Visibility.Collapsed;
            strona3.Visibility = Visibility.Collapsed;
            strona_ust.Visibility = Visibility.Visible;
            LoadChart40(Chart3);
            LoadChart24(Chart1);
        }
        private void RButton_Click_1(object sender, RoutedEventArgs e) {
            strona1.Visibility = Visibility.Visible;
            strona2.Visibility = Visibility.Collapsed;
            strona3.Visibility = Visibility.Collapsed;
            strona_ust.Visibility = Visibility.Collapsed;
            LoadChart40(Chart3);
            LoadChart24(Chart1);
        }

        private void RButton_Click_2(object sender, RoutedEventArgs e) {
            strona1.Visibility = Visibility.Collapsed;
            strona2.Visibility = Visibility.Visible;
            strona3.Visibility = Visibility.Collapsed;
            strona_ust.Visibility = Visibility.Collapsed;
            LoadChart40(Chart3);
            LoadChart24(Chart1);
        }

        private void RButton_Click_3(object sender, RoutedEventArgs e) {
            strona1.Visibility = Visibility.Collapsed;
            strona2.Visibility = Visibility.Collapsed;
            strona3.Visibility = Visibility.Visible;
            strona_ust.Visibility = Visibility.Collapsed;
            LoadChart40(Chart3);
            LoadChart24(Chart1);
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
            username = FileManager.Load("user/username.txt");
            nazwauz.Text = "Nazwa użytkownika: " + username;
            dziendobry.Text = "Dzień dobry " + username + "!";
        }

        // wybieranie emocji
        private void em1_MD(object sender, MouseEventArgs e) {
            FileManager.Append("user/emocje.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "; " + "1");
            LoadChart40(Chart3);
            LoadChart24(Chart1);
            UpdateStreak();
            pasta.Text = $"🔥Passa: {currentStreak}";
            strona1.Visibility = Visibility.Collapsed;
            strona2.Visibility = Visibility.Collapsed;
            strona3.Visibility = Visibility.Visible;
            strona_ust.Visibility = Visibility.Collapsed;
        }
        private void em2_MD(object sender, MouseEventArgs e) {
            FileManager.Append("user/emocje.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "; " + "2");
            LoadChart40(Chart3);
            LoadChart24(Chart1);
            UpdateStreak();
            pasta.Text = $"🔥Passa: {currentStreak}";
            strona1.Visibility = Visibility.Collapsed;
            strona2.Visibility = Visibility.Collapsed;
            strona3.Visibility = Visibility.Visible;
            strona_ust.Visibility = Visibility.Collapsed;
        }
        private void em3_MD(object sender, MouseEventArgs e) {
            FileManager.Append("user/emocje.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "; " + "3");
            LoadChart40(Chart3);
            LoadChart24(Chart1);
            UpdateStreak();
            pasta.Text = $"🔥Passa: {currentStreak}";
            strona1.Visibility = Visibility.Collapsed;
            strona2.Visibility = Visibility.Collapsed;
            strona3.Visibility = Visibility.Visible;
            strona_ust.Visibility = Visibility.Collapsed;
        }
        private void em4_MD(object sender, MouseEventArgs e) {
            FileManager.Append("user/emocje.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "; " + "4");
            LoadChart40(Chart3);
            LoadChart24(Chart1);
            UpdateStreak();
            pasta.Text = $"🔥Passa: {currentStreak}";
            strona1.Visibility = Visibility.Collapsed;
            strona2.Visibility = Visibility.Collapsed;
            strona3.Visibility = Visibility.Visible;
            strona_ust.Visibility = Visibility.Collapsed;
        }
        private void em5_MD(object sender, MouseEventArgs e) {
            FileManager.Append("user/emocje.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "; " + "5");
            LoadChart40(Chart3);
            LoadChart24(Chart1);
            UpdateStreak();

            pasta.Text = $"🔥Passa: {currentStreak}";
            strona1.Visibility = Visibility.Collapsed;
            strona2.Visibility = Visibility.Collapsed;
            strona3.Visibility = Visibility.Visible;
            strona_ust.Visibility = Visibility.Collapsed;
        }
        private void zatwierdzimie(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(wybraneimie.Text)) {
                MessageBox.Show("Wybrana nazwa użytkownika nie może być pusta!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
            } else if (wybraneimie.Text.Length > 32) {
                MessageBox.Show("Wybrana nazwa użytkownika nie może być dłuższa niż 32 znaki!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
            } else {
                powitaj.Visibility = Visibility.Collapsed;
                username = wybraneimie.Text;
                FileManager.Save("user/username.txt", username);
                nazwauz.Text = "Nazwa użytkownika: " + username;
                dziendobry.Text = "Dzień dobry " + username + "!";
            }
        }
        private void LoadChart(LiveCharts.Wpf.CartesianChart chart) {
            string path = "user/emocje.txt";

            // If file does not exist or is empty — clear chart
            if (!File.Exists(path)) {
                chart.Series = new SeriesCollection();
                chart.DataContext = null;
                chart.DataContext = chart.Series;
                return;
            }

            var lines = File.ReadAllLines(path);
            if (lines.Length == 0) {
                chart.Series = new SeriesCollection();
                chart.DataContext = null;
                chart.DataContext = chart.Series;
                return;
            }

            var timestamps = new List<string>();
            var values = new ChartValues<double>();

            foreach (var line in lines) {
                // Expected format: 2025-01-01 12:00:00; 3
                var parts = line.Split(';');
                if (parts.Length != 2)
                    continue;

                if (!DateTime.TryParse(parts[0].Trim(), out DateTime time))
                    continue;

                if (!double.TryParse(parts[1].Trim(), out double value))
                    continue;

                timestamps.Add(time.ToString("dd-MM"));
                values.Add(value);
            }

            // Force LiveCharts to refresh by replacing Series entirely
            chart.Series = null;
            chart.Series = new SeriesCollection
            {
        new LiveCharts.Wpf.LineSeries
        {
            Title = "Humor",
            Values = values,
            PointGeometry = LiveCharts.Wpf.DefaultGeometries.Circle,
            PointGeometrySize = 8
        }
    };

            // Update labels
            chart.AxisX.Clear();
            chart.AxisX.Add(new LiveCharts.Wpf.Axis {
                Labels = timestamps
            });

            // Rebind DataContext to force visual update
            chart.DataContext = null;
            chart.DataContext = chart.Series;
        }
        private void LoadChart24(LiveCharts.Wpf.CartesianChart chart) {
            string path = "user/emocje.txt";

            if (!File.Exists(path)) {
                chart.Series = new SeriesCollection();
                chart.AxisX.Clear();
                chart.AxisY.Clear();
                return;
            }

            var lines = File.ReadAllLines(path);
            if (lines.Length == 0) {
                chart.Series = new SeriesCollection();
                chart.AxisX.Clear();
                chart.AxisY.Clear();
                return;
            }

            DateTime now = DateTime.Now;
            DateTime last24 = now.AddHours(-24);

            var timestamps = new List<string>();
            var values = new ChartValues<double>();

            foreach (var line in lines) {
                var parts = line.Split(';');
                if (parts.Length != 2) continue;

                if (!DateTime.TryParse(parts[0].Trim(), out DateTime time)) continue;
                if (!double.TryParse(parts[1].Trim(), out double val)) continue;

                // 🔥 FILTER LAST 24 HOURS ONLY
                if (time < last24)
                    continue;

                timestamps.Add(time.ToString("HH:mm"));  // hour:minute
                values.Add(val);
            }

            // No recent data → clear chart
            if (values.Count == 0) {
                chart.Series = new SeriesCollection();
                chart.AxisX.Clear();
                chart.AxisY.Clear();
                return;
            }

            // Force full redraw
            chart.Series = null;

            chart.Series = new SeriesCollection
            {
        new LineSeries
        {
            Title = "Humor (ostatnie 24h)",
            Values = values,
            PointGeometry = DefaultGeometries.Circle,
            PointGeometrySize = 8
        }
    };

            chart.AxisX.Clear();
            chart.AxisX.Add(new Axis {
                Title = "Czas",
                Labels = timestamps
            });

            chart.AxisY.Clear();
            chart.AxisY.Add(new Axis {
                Title = "Poziom nastroju",
                MinValue = 0,
                MaxValue = 5
            });

            chart.DataContext = null;
            chart.DataContext = chart.Series;
        }
        private void LoadChart40(LiveCharts.Wpf.CartesianChart chart) {
            string path = "user/emocje.txt";

            if (!File.Exists(path)) {
                chart.Series = new SeriesCollection();
                chart.AxisX.Clear();
                chart.AxisY.Clear();
                return;
            }

            var lines = File.ReadAllLines(path);

            var last = lines.Reverse().Take(40).Reverse().ToList();

            if (last.Count == 0) {
                chart.Series = new SeriesCollection();
                chart.AxisX.Clear();
                chart.AxisY.Clear();
                return;
            }

            var timestamps = new List<string>();
            var values = new ChartValues<double>();

            foreach (var line in last) {
                var parts = line.Split(';');
                if (parts.Length != 2) continue;

                if (!DateTime.TryParse(parts[0].Trim(), out DateTime time)) continue;
                if (!double.TryParse(parts[1].Trim(), out double val)) continue;

                timestamps.Add(time.ToString("dd-MM HH:mm"));
                values.Add(val);
            }

            chart.Series = null;
            chart.Series = new SeriesCollection
            {
        new LineSeries
        {
            Title = "Humor",
            Values = values,
            PointGeometry = DefaultGeometries.Circle,
            PointGeometrySize = 8
        }
    };

            chart.AxisX.Clear();
            chart.AxisX.Add(new Axis {
                Title = "Czas",
                Labels = timestamps
            });

            chart.AxisY.Clear();
            chart.AxisY.Add(new Axis {
                Title = "Nastrój",
                MinValue = 0,
                MaxValue = 5
            });

            chart.DataContext = null;
            chart.DataContext = chart.Series;
        }
        private void LoadStreak() {
            string streakPath = "user/streak.txt";

            if (File.Exists(streakPath)) {
                int.TryParse(File.ReadAllText(streakPath), out currentStreak);
            } else {
                currentStreak = 0;
            }

            // Get last date from emocje.txt
            if (File.Exists("user/emocje.txt")) {
                var lastLine = File.ReadLines("user/emocje.txt").LastOrDefault();

                if (lastLine != null) {
                    var parts = lastLine.Split(';');
                    if (parts.Length == 2 && DateTime.TryParse(parts[0].Trim(), out DateTime d))
                        lastEntryDate = d.Date;
                }
            }
            string lastDatePath = "user/lastDate.txt";

            if (File.Exists(lastDatePath)) {
                DateTime.TryParse(File.ReadAllText(lastDatePath), out lastEntryDate);
            } else {
                // fallback to emocje.txt
                if (File.Exists("user/emocje.txt")) {
                    var lastLine = File.ReadLines("user/emocje.txt").LastOrDefault();

                    if (lastLine != null) {
                        var parts = lastLine.Split(';');
                        if (parts.Length == 2 && DateTime.TryParse(parts[0].Trim(), out DateTime d))
                            lastEntryDate = d.Date;
                    }
                }
            }   
        }
        private void UpdateStreak() {
            DateTime today = DateTime.Now.Date;

            if (lastEntryDate == today) {
                // Already counted today → do nothing
                return;
            } else if (lastEntryDate == today.AddDays(-1)) {
                // Continue streak
                currentStreak++;
            } else {
                // Reset streak
                currentStreak = 1;
            }

            lastEntryDate = today;

            File.WriteAllText("user/streak.txt", currentStreak.ToString());
            File.WriteAllText("user/lastDate.txt", lastEntryDate.ToString("yyyy-MM-dd"));
        }

        private void notatka_Changed(object sender, TextChangedEventArgs e) {
            FileManager.Save("user/note.txt", notatka.Text);
        }
    }
}