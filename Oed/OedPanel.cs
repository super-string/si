using kvi;

namespace Oed {
	public class OedPanel :Control {
		public ExternalIF ExtIF{ get; set; }

		RichTextBox filePath;
		KviTextBox textKtb;
		KviTextBox commandKtb;

		public OedPanel(Size _size, Point _location){
			ExtIF = new ExternalIF();
			filePath = new RichTextBox();
			filePath.Multiline = false;
			filePath.ReadOnly = true;

			textKtb = new KviTextBox();
			commandKtb = new KviTextBox();

			SetSize(_size);
			SetLocation(_location);

			this.Controls.Add(filePath);
			this.Controls.Add(textKtb);
			this.Controls.Add(commandKtb);
		}

		public bool ReadFile(string _filePath) {
			filePath.Text = _filePath;
			using(var sr = new StreamReader(_filePath)) {
				if(sr != null) {
					textKtb.Text = sr.ReadToEnd();
				}
			}
			return true;
		}
		public bool SetLocation(Point _location){
			Location = _location;
			filePath.Location = _location;
			textKtb.Location = new Point(_location.X, _location.Y + filePath.Height);
			commandKtb.Location = new Point(_location.X, textKtb.Location.Y + textKtb.Height);
			return true;
		}

		public bool SetSize(Size _size){
			Size = _size;
			filePath.Size = new Size(_size.Width, filePath.Font.Height + 2);
			commandKtb.Width = _size.Width;
			commandKtb.Height = commandKtb.Font.Height + 2;
			textKtb.Width = _size.Width;
			textKtb.Height = _size.Height - filePath.Height - commandKtb.Height;
			return true;
		}
	}
}