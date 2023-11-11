
namespace Oed {
	internal class OedModeCtrl {
		internal OedMode Mode { get; private set; }
		public OedModeCtrl() {
			Mode = OedMode.Text;
		}

		public bool IntoText() {
			if(Mode == OedMode.Text) {
				return false;
			}

			Mode = OedMode.Text;
			return true;
		}
		public bool IntoCommand() {
			if(Mode != OedMode.Command) {
				return false;
			}

			Mode = OedMode.Command;
			return true;
		}
	}

	internal enum OedMode {
		Text,
		Command,
	}
}
