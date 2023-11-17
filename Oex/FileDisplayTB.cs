using kvi;

namespace Oex {
	internal class FileDisplayTB {
		internal KviTextBox ktb;
		internal FileItemType Type { get; private set;}

		internal FileDisplayTB(String _name, FileItemType _type) {
			ktb = new KviTextBox();
			ktb.Text = _name;
			ktb.Name = _name;
			Type = _type;
			ktb.Multiline = false;
			ktb.BorderStyle = BorderStyle.None;
			ktb.ExpandEvent.OverEscapeHandler += ExpandEvent_OverEscapeHandler;
			ktb.GotFocus += Ktb_GotFocusHandler;
		}

		private void Ktb_GotFocusHandler(object? sender, EventArgs e) {
			ktb.Parent.Select();
		}

		private void ExpandEvent_OverEscapeHandler() {
			ktb.Parent.Select();
		}

		/// <summary>
		///	kTextBoxのコントロールサイズをセットする。
		/// </summary>
		/// <param name="_xSize"></param>
		/// <param name="_ySize"></param>
		/// <returns></returns>
		internal bool SetSize(int _xSize, int _ySize){
			ktb.Width = _xSize;
			ktb.Height = _ySize;
			return true;
		}
		internal bool SetSize(Size _size){
			ktb.Width = _size.Width;
			ktb.Height = _size.Height;
			return true;
		}
	}
}
