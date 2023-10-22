
namespace kvi {
	public class KviTextBox :RichTextBox {
		KviCentral central;
		public KviTextBox() :base(){
			central = new KviCentral();
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

		internal int GetSelectionEnd(){
			return SelectionStart + SelectionLength;
		}

	}
}
