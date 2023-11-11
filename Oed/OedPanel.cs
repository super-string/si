using kvi;

namespace Oed {
	public class OedPanel :Control {
		public ExternalIF ExtIF{ get; set; }
		private OedCentral central;

		internal RichTextBox filePath;
		internal KviTextBox textKtb;
		internal KviTextBox commandKtb;

		public OedPanel(Size _size, Point _location){
			central = new OedCentral();
			ExtIF = new ExternalIF();

			filePath = new RichTextBox();
			filePath.Multiline = false;
			filePath.ReadOnly = true;

			textKtb = new KviTextBox();
			textKtb.ExtIF.PressColonHandler += selectCommandKtb;

			commandKtb = new KviTextBox();
			commandKtb.Multiline = false;
			commandKtb.ExtIF.PressColonHandler += selectTextKtb;
			commandKtb.ExtIF.PressEnterHandler += recieveCommand;

			SetSize(_size);
			SetLocation(_location);

			this.Controls.Add(filePath);
			this.Controls.Add(textKtb);
			this.Controls.Add(commandKtb);

			GotFocus += gotFocusHandler;
		}

		protected override void OnKeyDown(KeyEventArgs e){
			base.OnKeyDown(e);
			central.RecieveKey(e.KeyData, this);
		}

		public bool ReloadFile(string _filePath) {
			filePath.Text = _filePath;
			using(var sr = new StreamReader(_filePath)) {
				if(sr != null) {
					textKtb.Text = sr.ReadToEnd();
				}
			}
			return true;
		}

		//フォーム内表示調整ロジック
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
		//フォーム内表示調整ロジックーーー

		//イベントハンドラ
		private void gotFocusHandler(object? sender, EventArgs e){
			textKtb.Select();
		}
		private void selectCommandKtb(){
			commandKtb.Select();
			SendKeys.Send("i");
		}
		private void selectTextKtb(){
			commandKtb.Clear();
			textKtb.Select();
		}
		private void recieveCommand(){
			central.command.RecieveCommand(this);
		}
		//イベントハンドラーーー
	}
}