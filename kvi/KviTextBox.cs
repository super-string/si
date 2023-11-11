
namespace kvi {
	public class KviTextBox :RichTextBox {
		private KviCentral central;
		public  ExternalIF ExtIF{ get; private set; }
		public void AddOverEscEvent(Action e){
			ExtIF.OverEscapeHandler += e;
		}
		public void RemoveOverEscEvent(Action e){
			ExtIF.OverEscapeHandler -= e;
		}

		public KviTextBox() :base(){
			central = new KviCentral();
			ExtIF = new ExternalIF();
		}

		protected override void OnGotFocus(EventArgs e) {
			base.OnGotFocus(e);
			central.Mode.IntoNormal();
			ReadOnly = true;
		}

		protected override void OnKeyDown(KeyEventArgs e) {
			base.OnKeyDown(e);
			if(central.Mode.Mode != EditMode.Insert){
				ReadOnly = true;
			}
			else{
				ReadOnly = false;
			}

			central.RecieveKey(e.KeyData, this);
		}

		//カーソル操作IF
			internal bool PointCursor(int _idx){
				SelectionStart = _idx;
				SelectionLength = 0;
				return true;
			}
			internal bool SelectRange(int _startIdx, int _endIdx){
				SelectionStart = _startIdx;
				SelectionLength = _endIdx - SelectionStart;
				return true;
			}

		//文字列編集IF
			internal bool CutText(){
				Cut();
				return true;
			}
			internal bool YankText(){
				Copy();
				return true;
			}
			internal bool PutText(){
				Paste();
				return true;
			}

		//情報取得IF
			internal int GetSelectionEnd(){
				return SelectionStart + SelectionLength;
			}
	}
}
