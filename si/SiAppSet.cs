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

			oex.ExpandEvent.FileOpenHandler += StartOed;
			oed.ExpandEvent.FileCloseHandler += EndOed;
			oex.Dock = DockStyle.Fill;
			this.Controls.Add(oex);

			GotFocus += gotFocusHandler;
			//Resize += resizeHandler;

			//SetStyle(ControlStyles.ResizeRedraw, true);
		}

		public void SetLocation(Point value) {
			Location = value;
			oex.SetLocation(value);
			oed.SetLocation(value);
		}

		public void SetSize(Size value) {
			Size = value;
		//	oex.SetSize(value);
		//	oed.SetSize(value);
		}

		//アプリ開始・終了
		private void StartOed(string _path){
			oed.ReloadOed(_path);
			this.Controls.Remove(oex);
			this.Controls.Add(oed);
			oed.Select();
		}
		private void EndOed(){
			this.Controls.Remove(oed);
			this.Controls.Add(oex);
			oex.Select();
		}
		//アプリ開始・終了ーーー

		//イベントハンドラ
		private void gotFocusHandler(object? sender, EventArgs e){
			if(this.Controls.Count == 0)
				return;

			this.Controls[0].Select();
		}
		private void resizeHandler(object? sender, EventArgs e){
			SetSize(this.Size);
			SetLocation(this.Location);
			//this.Refresh();
		}
		//イベントハンドラーーー
	}
}
