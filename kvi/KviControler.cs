namespace kvi {
	internal class KviControler {
		internal KviEditMode Mode { get; private set; }

		internal KviControler(){
			Mode = new KviEditMode();
		}

		internal bool RecieveKey(Keys _key, KviTextBox _target){
			if(_key == (Keys.Control | Keys.OemOpenBrackets)){
				if(Mode.IntoNormal()){ 
					_target.SelectionLength = 0;
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
				case (Keys.Oem1):
					event_Colon(_target);
					break;
				case (Keys.Enter):
					event_Enter(_target);
					break;
				default:
					break;
			}
			return true;
		}

		private void event_Ctrl_w(KviTextBox _target){
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
		private void event_esc(KviTextBox _target){
			switch(Mode.Mode) {
				case EditMode.Normal:
					_target.ExtIF.OverEsc();
					break;
				case EditMode.Insert:
					if(Mode.IntoNormal()){ 
						_target.SelectionLength = 0;
					}
					break;
				case EditMode.Select:
					if(Mode.IntoNormal()){ 
						_target.SelectionLength = 0;
					}
					break;
				default:
					break;
			}
		}
		private void event_Colon(KviTextBox _target){
			switch(Mode.Mode) {
				case EditMode.Normal:
					_target.ExtIF.PressColon();
					break;
				case EditMode.Insert:
					break;
				case EditMode.Select:
					break;
				default:
					break;
			}
		}
		private void event_Enter(KviTextBox _target) {
			switch(Mode.Mode) {
				case EditMode.Normal:
					_target.ExtIF.PressEnter();
					break;
				case EditMode.Insert:
					_target.ExtIF.PressEnter();
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
