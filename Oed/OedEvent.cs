namespace Oed {
	public  class OedEvent {
		public event Action? OverEscapeHandler;
		public event Action? FileCloseHandler;

		internal void OverEsc(){
			if(OverEscapeHandler != null){ 
				OverEscapeHandler();
			}
		}
			
		internal void FileClose(){
			if(FileCloseHandler != null){
				FileCloseHandler();
			}
		}
	}
}
