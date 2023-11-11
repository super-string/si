
namespace Oed {
	internal class OedCentral {
		internal OedModeCtrl Mode { get; private set; }

		internal OedCentral(OedPanel _target){
			Mode = new OedModeCtrl();
		}

		internal bool RecieveKey(Keys _key, OedPanel _target){
			if(_key == (Keys.Control | Keys.OemOpenBrackets)){
				if(Mode.IntoText()){
				}
				return true;
			}

			switch(_key) {
				case (Keys.Control | Keys.W):
					event_Ctrl_w(_target);
					break;
				case Keys.Enter:
					event_Enter(_target);
					break;
				default:
					break;
			}
			return true;
		}

		private void event_Ctrl_w(OedPanel _target){
			switch(Mode.Mode) {
				case OedMode.Text:
					break;
				case OedMode.Command:
					break;
				default:
					break;
			}
		}
		private void event_Enter(OedPanel _target){
			switch(Mode.Mode) {
				case OedMode.Text:
					break;
				case OedMode.Command:
					break;
				default:
					break;
			}
		}
	}
}
