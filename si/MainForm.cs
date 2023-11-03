using kvi;
using Oex;

namespace si {
	public partial class MainForm :Form {
		public MainForm() {
			InitializeComponent();
			oex = new OexPanel();
		}


		private OexPanel oex;
		private void MainForm_Load(object sender, EventArgs e) {
			oex.SetSize(this.ClientSize);
			oex.SetLocation(new Point(1, 1));
			this.Controls.Add(oex);
		}
	}
}