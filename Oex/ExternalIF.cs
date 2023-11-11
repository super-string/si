namespace Oex {
	public  class ExternalIF {
		public event Action? OverEscapeHandler;

		internal void OverEsc(){
			if(OverEscapeHandler != null){ 
				OverEscapeHandler();
			}
		}
			
	}
}
