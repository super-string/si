using System.Runtime.CompilerServices;

namespace kvi {
	public class ExternalIF {
		public event Action? OverEscapeHandler;
		public event Action? PressColonHandler;
		public event Action? PressEnterHandler;

		internal void OverEsc(){
			if(OverEscapeHandler != null){ 
				OverEscapeHandler();
			}
		}
			
		internal void PressColon(){
			if(PressColonHandler != null){
				PressColonHandler();
			}
		}
		internal void PressEnter(){
			if(PressEnterHandler != null){
				PressEnterHandler();
			}
		}
	}
}
