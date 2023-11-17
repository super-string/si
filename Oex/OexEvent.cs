namespace Oex {
	public  class OexEvent {
		public event Action? OverEscapeHandler;
		public event Action<string>? FileOpenHandler;

		internal void OverEsc(){
			if(OverEscapeHandler != null){ 
				OverEscapeHandler();
			}
		}
			
		internal void FileOpen(string _filePath){
			if(FileOpenHandler != null){
				FileOpenHandler(_filePath);
			}
		}
	}
}
