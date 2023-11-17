
namespace Oed {
	internal class OedMode {
		internal EditMode Mode { get; private set; }
		public OedMode() {
			Mode = EditMode.Text;
		}

		public bool IntoText() {
			if(Mode == EditMode.Text) {
				return false;
			}

			Mode = EditMode.Text;
			return true;
		}
		public bool IntoCommand() {
			if(Mode != EditMode.Command) {
				return false;
			}

			Mode = EditMode.Command;
			return true;
		}
	}

	internal enum EditMode {
		Text,
		Command,
	}
}
