namespace kvi {
	internal class KviCentral {
		internal EditModeCtrl Mode { get; private set; }

		internal KviCentral(){
			Mode = new EditModeCtrl();
		}

		internal bool RecieveKey(Keys _key, KviTextBox _target){
			if(_key == (Keys.Control | Keys.OemOpenBrackets)){
				if(Mode.IntoNormal()){ 
					_target.SelectionLength = 0;
				}
				return true;
			}

			switch(_key) {
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

		private void event_i(KviTextBox _target){
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

		private void event_l(KviTextBox _target) {
			switch(Mode.Mode) {
				case EditMode.Normal:
					_target.PointCursor(CursorMoving.MoveHolizontal(_target.SelectionStart, 1, _target.Text));
					break;
				case EditMode.Insert:
					break;
				case EditMode.Select:
					break;
				default:
					break;
			}
		}
		private void event_j(KviTextBox _target) {
			switch(Mode.Mode) {
				case EditMode.Normal:
					_target.PointCursor(CursorMoving.MoveVertical(_target.SelectionStart, +1, _target.Text));
					break;
				case EditMode.Insert:
					break;
				case EditMode.Select:
					break;
				default:
					break;
			}
		}
		private void event_k(KviTextBox _target) {
			switch(Mode.Mode) {
				case EditMode.Normal:
					_target.PointCursor(CursorMoving.MoveVertical(_target.SelectionStart, -1, _target.Text));
					break;
				case EditMode.Insert:
					break;
				case EditMode.Select:
					break;
				default:
					break;
			}
		}
		private void event_h(KviTextBox _target) {
			switch(Mode.Mode) {
				case EditMode.Normal:
					_target.PointCursor(CursorMoving.MoveHolizontal( _target.SelectionStart, -1, _target.Text));
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
