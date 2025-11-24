using LiveCharts;
using System.Windows.Controls;

namespace konkurs {
    public partial class Chart : UserControl {
        public Chart() {
            InitializeComponent();
            DataContext = this;
        }

        public SeriesCollection Series { get; set; }
        public string[] Labels { get; set; }
    }
}