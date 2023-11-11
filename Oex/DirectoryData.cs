namespace Oex {
	internal class DirectoryData {
		protected string currentPath;
		protected List<string> fileList;
		protected List<string> directoryList;

		internal DirectoryData(){
			currentPath = Application.ExecutablePath;
			currentPath = Path.GetDirectoryName(currentPath) ?? @"c:\";
			fileList = new List<string>();
			directoryList = new List<string>();

		}
		internal DirectoryData(string _path){
			currentPath = "No directory";
			SetCurrentPathText(_path);
			fileList = new List<string>();
			directoryList = new List<string>();
		}

		//情報提供IF
		internal string GetCurrentPath(){
			return currentPath; 
		}
		internal int GetItemCount(){
			return directoryList.Count + fileList.Count;
		}
		internal string GetItemName(int _itemIdx){
			if(_itemIdx < directoryList.Count){
				return directoryList[_itemIdx];
			}

			int fileIdx = _itemIdx - directoryList.Count;
			if(fileIdx < fileList.Count){
				return fileList[fileIdx];
			}
			return "";
		}
		internal string GetFileItemName(int _fileIdx){
			if(_fileIdx < 0 || fileList.Count <= _fileIdx)
				return "";
			return fileList[_fileIdx];
		}
		internal string GetDirectoryItemName(int _directoryIdx){
			if(_directoryIdx < 0 || directoryList.Count <= _directoryIdx)
				return "";
			return directoryList[_directoryIdx];
		}
		//情報提供IF---

		//情報更新IF
		internal bool RefleshList(){
			fileList = Directory.GetFiles(currentPath).ToList();
			directoryList = Directory.GetDirectories(currentPath).ToList();
			for(int i = 0; i < fileList.Count; i++){
				fileList[i] = Path.GetFileName(fileList[i]);
			}
			for(int i = 0; i < directoryList.Count; i++){
				fileList[i] = Path.GetFileName(directoryList[i]);
			}
			return true;
		}

		internal bool SetCurrentPathText(string _path){
			if(Directory.Exists(_path)) {
				currentPath = _path;
				return true;
			}
			return false;
		}

		//情報更新IF---
	}
}
