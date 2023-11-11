using Oex;
using Oed;

namespace si {
	internal class SiAppSet :Control {
		internal OexPanel oex;
		internal OedPanel oed;

		public SiAppSet(Size _size, Point _location){
			oex = new OexPanel(_size, _location);
			oed = new OedPanel(_size, _location);
			SetSize(_size);
			SetLocation(_location);

			oex.ExtIF.FileOpenHandler += StartOed;
			this.Controls.Add(oex);

			GotFocus += gotFocusHandler;
		}

		public Point GetLocation() { return Location; }
		public void SetLocation(Point value) {
			Location = value;
			oex.SetLocation(value);
			oed.SetLocation(value);
		}

		public Size GetSize() { return Size; }
		public void SetSize(Size value) {
			Size = value;
			oex.SetSize(value);
			oex.SetLocation(GetLocation());
			oed.SetSize(value);
			oed.SetLocation(GetLocation());
		}

		//アプリ開始・終了
		private void StartOed(string _path){
			oed.ReadFile(_path);
			this.Controls.Remove(oex);
			this.Controls.Add(oed);
		}
		private void EndOed(){
			this.Controls.Remove(oed);
			this.Controls.Add(oex);
		}
		//アプリ開始・終了ーーー

		//フォーカス操作
		private void gotFocusHandler(object? sender, EventArgs e){
			if(this.Controls.Count == 0)
				return;

			this.Controls[0].Select();
		}
		//フォーカス操作ーーー
	}
}
