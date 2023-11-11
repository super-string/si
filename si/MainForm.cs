using kvi;
using Oex;

namespace si {
	public partial class MainForm :Form {
		public MainForm() {
			InitializeComponent();
			oex = new OexPanel(this.ClientSize,new Point(1, 1));
		}


		private OexPanel oex;
		private void MainForm_Load(object sender, EventArgs e) {
			this.Controls.Add(oex);
		}
	}
}