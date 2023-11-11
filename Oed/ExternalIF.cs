namespace Oed {
	public  class ExternalIF {
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
