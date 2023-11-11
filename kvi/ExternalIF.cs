using System.Runtime.CompilerServices;

namespace kvi {
	public class ExternalIF {
		public event Action? OverEscapeHandler;
		public event Action? ExtCommandHandler;

		internal void OverEsc(){
			if(OverEscapeHandler != null){ 
				OverEscapeHandler();
			}
		}
			
		internal void ExtCommand(){
			if(ExtCommandHandler != null){
				ExtCommandHandler();
			}
		}
	}
}
