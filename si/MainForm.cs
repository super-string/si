using kvi;
using Oex;

namespace si {
	public partial class MainForm :Form {
		public MainForm() {
			InitializeComponent();
			siAppSet = new SiAppSet(this.ClientSize, new Point(1,1));
		}


		private SiAppSet siAppSet;
		private void MainForm_Load(object sender, EventArgs e) {
			this.Controls.Add(siAppSet);
		}
	}
}