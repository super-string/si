
namespace kvi {
	internal class EditModeCtrl {
		internal EditMode Mode { get; private set; }
		public EditModeCtrl() {
			Mode = EditMode.Normal;
		}

		public bool IntoNormal() {
			if(Mode == EditMode.Normal) {
				return false;
			}

			Mode = EditMode.Normal;
			return true;
		}
		public bool IntoSelect() {
			if(Mode != EditMode.Normal) {
				return false;
			}

			Mode = EditMode.Select;
			return true;
		}
		public bool IntoInsert() {
			if(Mode != EditMode.Normal) {
				return false;
			}

			Mode = EditMode.Insert;
			return true;
		}
	}

	internal enum EditMode {
		Normal,
		Insert,
		Select,
	}
}
