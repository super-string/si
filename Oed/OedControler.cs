
using kvi;

namespace Oed {
	internal class OedControler {
		internal OedMode Mode { get; private set; }
		internal CommandLogic command;

		internal OedControler(){
			Mode = new OedMode();
			command = new CommandLogic();
		}

		internal bool RecieveKey(Keys _key, OedPanel _target){
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
				case EditMode.Text:
					break;
				case EditMode.Command:
					break;
				default:
					break;
			}
		}
		private void event_Enter(OedPanel _target){
			switch(Mode.Mode) {
				case EditMode.Text:
					break;
				case EditMode.Command:
					command.RecieveCommand(_target);
					break;
				default:
					break;
			}
		}
	}
}
