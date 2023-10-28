using System.Runtime.CompilerServices;

namespace kvi {
	public delegate void NoArgEventHandler();
	internal class ExternalIF {
		public event NoArgEventHandler? OverEscapeHandler;

		internal void OverEsc(){
			if(OverEscapeHandler != null){ 
				OverEscapeHandler();
			}
		}
			
	}
}
