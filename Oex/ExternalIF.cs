namespace Oex {
	public delegate void NoArgEventHandler();
	public  class ExternalIF {
		public event NoArgEventHandler? OverEscapeHandler;

		internal void OverEsc(){
			if(OverEscapeHandler != null){ 
				OverEscapeHandler();
			}
		}
			
	}
}
