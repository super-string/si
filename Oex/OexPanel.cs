using kvi;
using System.Runtime.CompilerServices;

namespace Oex {
	public class OexPanel :Label {
		int displayNum;

		RichTextBox currentPath;
		List<FileDisplayTB> displayList;
		Size displayListAreaSize;

		public OexPanel(){
			currentPath = new RichTextBox();
			currentPath.BackColor = Color.Red;
			currentPath.Text = " ";
			this.Controls.Add(currentPath);

			displayList = new List<FileDisplayTB>();
			displayList.Add(new FileDisplayTB("", FileItemType.File));
			this.Controls.Add(displayList[0].ktb);
		}

		//フォーム内表示調整ロジック
			/// <summary>
			/// OexPanelの位置情報を更新し、内部の各コントロールの位置を計算する。
			/// 計算された情報は各コントロールの位置プロパティとして更新される。
			/// </summary>
			/// <param name="_location"></param>
			/// <returns></returns>
			public bool SetLocation(Point _location){
				Location = _location;
				refreshCurrentPathAreaLocation();
				refreshDisplayListItemLocation();
				return true;
			}

			/// <summary>
			/// OexPanelのサイズ情報から、内部に配置する各コントロールのサイズと個数を計算する。
			/// </summary>
			/// <param name="_size"></param>
			/// <returns></returns>
			public bool SetSize(Size _size){
				Size = _size;
				refreshCurrentPathAreaSize();
				refreshdisplayListAreaSize();
				refreshFileItemSize();
				refreshFileItemDisplayNum();
				adjustDisplayListLength();
				return true;
			}

			//サイズ調整用メソッドたち
			private bool refreshCurrentPathAreaSize(){
				currentPath.Size = new Size(Width, currentPath.Lines.Length * Font.Height + 2);
				return true;
			}
			private bool refreshdisplayListAreaSize(){
				int width = Size.Width;
				int height = Size.Height - currentPath.Size.Height;
				displayListAreaSize = new Size(width, height);
				return true;
			}
			private bool refreshFileItemSize(){
				foreach(FileDisplayTB item in displayList){
					item.SetSize(displayListAreaSize.Width - 2, Font.Height + 2);
				}
				return true;
			}
			private bool refreshFileItemDisplayNum(){
				displayNum = displayListAreaSize.Height / displayList[0].ktb.Height;
				return true;
			}
			private bool adjustDisplayListLength(){
				while(displayList.Count < displayNum) { 
					displayList.Add(new FileDisplayTB("",FileItemType.File));
					displayList[displayList.Count - 1].SetSize(displayList[0].ktb.Size);
					this.Controls.Add(displayList[displayList.Count - 1].ktb);
				}
				if(displayList.Count > displayNum){
					displayList.RemoveRange(displayNum, displayList.Count - displayNum);
				}
				return true;
			}

			//場所調整用メソッドたち
			private bool refreshCurrentPathAreaLocation(){
				currentPath.Location = this.Location;
				return true;
			}
			private bool refreshDisplayListItemLocation(){
				int locationHoriOffset = currentPath.Location.X;
				int locationVertOffset = currentPath.Location.Y + currentPath.Size.Height;
				foreach(FileDisplayTB item in displayList){
					item.ktb.Location = new Point(locationHoriOffset, locationVertOffset);
					locationVertOffset += item.ktb.Size.Height;
				}
				return true;
			}

		//フォーカス移動IF
			internal bool PointFocus(int _idx){
				for(int i = 0; i < displayList.Count; i++){
					if(i == _idx){ displayList[i].ktb.BackColor = Color.Aqua; }
					else{ displayList[i].ktb.BackColor = this.BackColor; }
				}
				return true;
			}
			internal bool SelectRange(int _startIdx, int _endIdx){
				for(int i = 0; i < displayList.Count; i++){
					if(_startIdx <= i && i <= _endIdx){ displayList[i].ktb.BackColor = Color.Aqua; }
					else{ displayList[i].ktb.BackColor = this.BackColor; }
				}
				return true;
			}

		//ディスプレイ項目編集IF
			/*
			internal bool DeleteDisplayItem(int _idx){
			}
			internal bool InsertDisplayItem(int _idx, string _name, FileItemType _type){

			}
			*/
		
	}
}