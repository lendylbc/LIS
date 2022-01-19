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
				chart.ChartAreas[0].AxisY.Maximum = 40;
			

				foreach(DeviceParameterDataDto dataValue in _data) {
					//series.Points.Add(Decimal.ToDouble(dataValue.Value));
					series.Points.AddXY(dataValue.Inserted.ToString("HH:mm"), Decimal.ToDouble(dataValue.Value));
				}

				//if(chkContClearOldValues.Checked && chart.Series.First().Points.Count > 6 * 200) {
				//	for(int i = 0; i < 200; i++) {
				//		chart.Series.First().Points.RemoveAt(i);
				//	}
				//}


					chart.Series.Add(series);
			

			} catch {

			}
		}

		private void ChartForm_Load(object sender, EventArgs e) {
			DrawChartValues();
		}
	}
}
