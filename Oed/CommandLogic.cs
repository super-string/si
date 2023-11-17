namespace Oed {
	internal class CommandLogic {
		internal bool RecieveCommand(OedPanel _target){
			switch(_target.commandKtb.Text) {
				case "q":
					_target.ExpandEvent.FileClose();
					break;
				default:
					break;
			}
			return true;
		}
	}
}
