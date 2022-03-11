using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Lis.Monitoring.Dto.Communication;

namespace Lis.Monitoring.Manager.Forms {
	public partial class ChartForm : Form {
		ICollection<DeviceParameterDataDto> _data;
		public ChartForm(ICollection<DeviceParameterDataDto> data) {
			_data = data;
			InitializeComponent();
		}

		public void DrawChartValues() {
			try {
				Series series = new Series("Teplota");
				series.ChartType = SeriesChartType.Spline;
				series.Color = Color.Black;
				double maxAxisY = 30;

				foreach(DeviceParameterDataDto dataValue in _data) {
					//series.Points.Add(Decimal.ToDouble(dataValue.Value));
					double value = Decimal.ToDouble((decimal)dataValue.Value);
					series.Points.AddXY(dataValue.Inserted.ToString("HH:mm"), value);

					if(value > maxAxisY) {
						maxAxisY = value;
					}
				}
				chart.ChartAreas[0].AxisY.Maximum = maxAxisY + 10;
				//if(chkContClearOldValues.Checked && chart.Series.First().Points.Count > 6 * 200) {
				//	for(int i = 0; i < 200; i++) {
				//		chart.Series.First().Points.RemoveAt(i);
				//	}
				//}

				series.Color = Color.MidnightBlue;

				chart.Series.Add(series);
			

			} catch {

			}
		}

		private void ChartForm_Load(object sender, EventArgs e) {
			DrawChartValues();
		}
	}
}
