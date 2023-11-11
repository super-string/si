
namespace Oex {
	internal class OexCentral {
		internal EditModeCtrl Mode { get; private set; }
		private DirectoryDisplayData displayData;

		internal OexCentral(OexPanel _target){
			displayData = new DirectoryDisplayData();
			Mode = new EditModeCtrl();

			refreshDirectory_DisplayAndData(_target);
		}

		internal bool RecieveKey(Keys _key, OexPanel _target){
			if(_key == (Keys.Control | Keys.OemOpenBrackets)){
				if(Mode.IntoNormal()){
					_target.PointCursor(_target.SelectionStart);
				}
				return true;
			}

			switch(_key) {
				case (Keys.Control | Keys.W):
					event_Ctrl_w(_target);
					break;
				case Keys.H:
					event_h(_target);
					break;
				case Keys.L:
					event_l(_target);
					break;
				case Keys.J:
					event_j(_target);
					break;
				case Keys.K:
					event_k(_target);
					break;
				case Keys.I:
					event_i(_target);
					break;
				default:
					break;
			}
			return true;
		}

		private bool refreshDirectory_DisplayAndData(OexPanel _target){
			_target.refreshDirectoryPathDisplay(displayData.DirectoryData.GetCurrentPath());
			displayData.DirectoryData.RefleshList();
			_target.refreshItemDisplay(displayData.GetDisplayFileNameList(_target.displayNum));
			return true;
		}

		private void event_Ctrl_w(OexPanel _target){
			switch(Mode.Mode) {
				case EditMode.Normal:
					_target.ExtIF.OverEsc();
					break;
				case EditMode.Insert:
					break;
				case EditMode.Select:
					break;
				default:
					break;
			}
		}
		private void event_i(OexPanel _target){
			switch(Mode.Mode) {
				case EditMode.Normal:
					Mode.IntoInsert();
					break;
				case EditMode.Insert:
					break;
				case EditMode.Select:
					break;
				default:
					break;
			}
		}
		private void event_esc(OexPanel _target){
			switch(Mode.Mode) {
				case EditMode.Normal:
					break;
				case EditMode.Insert:
					if(Mode.IntoNormal()){ 
						_target.PointCursor(_target.SelectionStart);
					}
					break;
				case EditMode.Select:
					if(Mode.IntoNormal()){ 
						_target.PointCursor(_target.SelectionStart);
					}
					break;
				default:
					break;
			}
		}

		private void event_l(OexPanel _target) {
			switch(Mode.Mode) {
				case EditMode.Normal:
					displayData.DirectoryData.MoveDownCurrentPathTo(displayData.DirectoryData.GetItemName(displayData.SelectStart));
					refreshDirectory_DisplayAndData(_target);
					break;
				case EditMode.Insert:
					break;
				case EditMode.Select:
					break;
				default:
					break;
			}
		}
		private void event_j(OexPanel _target) {
			switch(Mode.Mode) {
				case EditMode.Normal:
					int dst = CursorMoving.MoveVertical(1, displayData);
					displayData.SelectStart = dst;
					_target.PointCursor(dst);
					break;
				case EditMode.Insert:
					break;
				case EditMode.Select:
					break;
				default:
					break;
			}
		}
		private void event_k(OexPanel _target) {
			switch(Mode.Mode) {
				case EditMode.Normal:
					int dst = CursorMoving.MoveVertical(-1, displayData);
					displayData.SelectStart = dst;
					_target.PointCursor(dst);
					break;
				case EditMode.Insert:
					break;
				case EditMode.Select:
					break;
				default:
					break;
			}
		}
		private void event_h(OexPanel _target) {
			switch(Mode.Mode) {
				case EditMode.Normal:
					displayData.DirectoryData.MoveUpCurrentPath();
					refreshDirectory_DisplayAndData(_target);
					break;
				case EditMode.Insert:
					break;
				case EditMode.Select:
					break;
				default:
					break;
			}
		}
	}
}
