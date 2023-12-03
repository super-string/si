namespace Oex {
	public class OexPanel :Control {
		internal int displayNum;
		private OexControler controler;
		public  OexEvent ExpandEvent{ get; private set; }

		RichTextBox currentPath;
		List<FileDisplayTB> displayList;
		Size displayListAreaSize;

		public OexPanel(Size _size, Point _location){
			ExpandEvent = new OexEvent();
			currentPath = new RichTextBox();
			currentPath.BackColor = Color.Red;
			currentPath.Text = "dummy path";
			currentPath.Multiline = false;
			currentPath.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			this.Controls.Add(currentPath);

			displayList = new List<FileDisplayTB>();
			var hogehoge = new FileDisplayTB("", FileItemType.File);
			hogehoge.ktb.Anchor = AnchorStyles.Right | AnchorStyles.Left;
			displayList.Add(hogehoge);

			this.Controls.Add(displayList[0].ktb);

			this.SetSize(_size);
			this.SetLocation(_location);


			controler = new OexControler(this);
			PointCursor(0);
			SetStyle(ControlStyles.ResizeRedraw, true);
		}

		protected override void OnKeyDown(KeyEventArgs e){
			base.OnKeyDown(e);
			controler.RecieveKey(e.KeyData, this);
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
		/// OexPanelのサイズ情報から、内部に配置する各コントロールのサイズと個数を計算し、必要ならコントロールを追加する。
		/// </summary>
		/// <param name="_size"></param>
		/// <returns></returns>
		public bool SetSize(Size _size){
			Size = _size;
			refreshCurrentPathAreaSize();
			refreshDisplayListAreaSize();
			refreshFileItemSize();
			refreshFileItemDisplayNum();
			adjustDisplayListLength();
			return true;
		}

		//サイズ調整用メソッドたち
		private bool refreshCurrentPathAreaSize(){
			currentPath.Size = new Size(Size.Width, currentPath.Lines.Length * Font.Height + 2);
			return true;
		}
		private bool refreshDisplayListAreaSize(){
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

		//表示場所調整用メソッドたち
		private bool refreshCurrentPathAreaLocation(){
			currentPath.Location = this.Location;
			return true;
		}
		private bool refreshDisplayListItemLocation(){
			int locationHoriOffset = currentPath.Location.X;
			int locationVertOffset = currentPath.Location.Y + currentPath.Height;
			foreach(FileDisplayTB item in displayList){
				item.ktb.Location = new Point(locationHoriOffset, locationVertOffset);
				locationVertOffset += item.ktb.Size.Height;
			}
			return true;
		}
		//フォーム内表示調整ロジックーーー

		//カーソル操作IF
		internal bool PointCursor(int _idx){
			SelectionStart = _idx;
			SelectionLength = 1;
			refreshCursorDisplay(); 
			return true;
		}
		internal bool SelectRange(int _startIdx, int _endIdx){
			SelectionStart = _startIdx;
			SelectionLength = _endIdx - SelectionStart;
			refreshCursorDisplay(); 
			return true;
		}
		private int selectionStart;
		internal int SelectionStart{
			get{ return selectionStart; }
			private set{ 
				selectionStart = value; 
				refreshCursorDisplay(); 
			}
		}
		private int selectionLength;
		internal int SelectionLength{
			get{ return selectionLength; }
			private set{ 
				selectionLength = value; 
			}
		}
		private bool refreshCursorDisplay(){
			for(int i = 0; i < displayList.Count; i++){
				if(SelectionStart <= i && i < SelectionStart + SelectionLength){
					displayList[i].ktb.BackColor = Color.Aqua;
				}
				else{
					//displayList[i].ktb.BackColor = this.BackColor;
					displayList[i].ktb.BackColor = Color.Yellow;
				}
			}
			return true;
		}
		//カーソル操作IFーーー

		//描画更新IF
		internal bool refreshDirectoryPathDisplay(string _path){
			currentPath.Text = _path;
			return true;
		}
		internal bool refreshItemDisplay(List<string> _items){
			for(int i = 0; i < displayList.Count; i++){
				displayList[i].ktb.Update();
				if(_items.Count <= i){
					displayList[i].ktb.Text = "";
					break;
				}
				displayList[i].ktb.Text = _items[i];
			}
			return true;
		}
		//描画更新IFーーー
		
	}
}