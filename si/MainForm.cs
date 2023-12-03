using kvi;
using Oex;

namespace si {
	public partial class MainForm :Form {
		public MainForm() {
			InitializeComponent();
			siAppSet = new SiAppSet(this.ClientSize, new Point(1, 1));
			siAppSet.Dock = DockStyle.Fill;
		}


		private SiAppSet siAppSet;
		private void MainForm_Load(object sender, EventArgs e) {
			this.Controls.Add(siAppSet);
		}

		private void MainForm_ResizeEnd(object sender, EventArgs e) {
			//siAppSet.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);
		}
	}
}