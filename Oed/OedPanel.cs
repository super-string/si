﻿using kvi;

namespace Oed {
	public class OedPanel :Control {
		public OedEvent ExpandEvent{ get; set; }
		private OedControler controler;

		internal RichTextBox filePath;
		internal KviTextBox textKtb;
		internal KviTextBox commandKtb;

		public OedPanel(Size _size, Point _location){
			controler = new OedControler();
			ExpandEvent = new OedEvent();

			filePath = new RichTextBox();
			filePath.Multiline = false;
			filePath.ReadOnly = true;

			textKtb = new KviTextBox();
			textKtb.ExpandEvent.PressColonHandler += selectCommandKtb;

			commandKtb = new KviTextBox();
			commandKtb.Multiline = false;
			commandKtb.ExpandEvent.PressColonHandler += selectTextKtb;
			commandKtb.ExpandEvent.PressEnterHandler += recieveCommand;

			SetSize(_size);
			SetLocation(_location);

			this.Controls.Add(filePath);
			this.Controls.Add(textKtb);
			this.Controls.Add(commandKtb);

			GotFocus += gotFocusHandler;
		}

		protected override void OnKeyDown(KeyEventArgs e){
			base.OnKeyDown(e);
			controler.RecieveKey(e.KeyData, this);
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

		//アプリ初期化IF
		public bool ReloadOed(string _filePath){
			reloadFile(_filePath);
			selectTextKtb();
			return true;
		}

		public bool reloadFile(string _filePath) {
			filePath.Text = _filePath;
			using(var sr = new StreamReader(_filePath)) {
				if(sr != null) {
					textKtb.Text = sr.ReadToEnd();
				}
			}
			return true;
		}
		//アプリ初期化IFーーー

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
			controler.command.RecieveCommand(this);
		}
		//イベントハンドラーーー
	}
}