using kvi;

namespace si {
	public partial class MainForm :Form {
		public MainForm() {
			InitializeComponent();
			rtb = new KviTextBox();
		}


		KviTextBox rtb;
		private void MainForm_Load(object sender, EventArgs e) {
			rtb.Location = new Point(10, 10);
			rtb.Size = new Size(200, 200);
			rtb.Text = "hogeaaa\nfuga\nereki\n";
			rtb.Font = new Font("MS Gothic", 10);
			this.Controls.Add(rtb);
		}
	}
}