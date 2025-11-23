using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Windows.Controls;

namespace konkurs {
    public partial class LChart : UserControl {
        public LChart() {
            InitializeComponent();

            // domyślny wykres
            chart.Series = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = new double[] { 0, 1, 2 }
                }
            };
        }

        public void Update(IEnumerable<double> values) {
            chart.Series = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = values
                }
            };
        }
    }
}
