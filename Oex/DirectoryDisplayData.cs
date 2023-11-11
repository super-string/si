
namespace Oex {
	internal class DirectoryDisplayData {
		private int selectStart;
		private int selectLength;
		private int displayStart;

		internal DirectoryData DirectoryData { get; set; }
		internal int SelectStart{ 
			get { return selectStart; }
			set { selectStart = (-1 < value) ? value : 0; }
		}
		internal int SelectLength{ 
			get { return selectLength; }
			set { selectLength = (0 < value) ? value : 1; }
		}
		internal int DisplayStart{ 
			get { return displayStart; }
			set { displayStart = (-1 < value) ? value : 0; }
		}

		internal DirectoryDisplayData(){
			DirectoryData = new DirectoryData();
			SelectStart = 0;
			SelectLength = 1;
			DisplayStart = 0;
		}

		//ディスプレイ情報提供めそっど
		internal string GetDisplayDirectoryPath(){
			return DirectoryData.GetCurrentPath();
		}
		internal List<string> GetDisplayFileNameList(int _displayNum){
			List<string> ret = new List<string>();
			for(int i = displayStart; i < displayStart + _displayNum; i++){
				ret.Add(DirectoryData.GetItemName(i));
			}
			return ret;
		}
		//ディスプレイ情報提供めそっどーーー
	}
}
