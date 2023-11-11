namespace Oed {
	public  class ExternalIF {
		public event Action? OverEscapeHandler;
		public event Action<string>? FileCloseHandler;

		internal void OverEsc(){
			if(OverEscapeHandler != null){ 
				OverEscapeHandler();
			}
		}
			
		internal void FileClose(string _filePath){
			if(FileCloseHandler != null){
				FileCloseHandler(_filePath);
			}
		}
	}
}
