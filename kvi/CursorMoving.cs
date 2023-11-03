
namespace kvi {
	internal static class CursorMoving {
		//カーソル移動計算
			/// <summary>
			/// step数分の横移動要求に対して、地形の制約に応じた正味の移動先idxを返す。
			/// </summary>
			/// <param name="_currentIdx"></param>
			/// <param name="_step"></param>
			/// <param name="_field"></param>
			/// <returns></returns>
			public static int MoveHolizontal(int _currentIdx, int _step, string _field){
				int theoreticDst;
				int headIdx, tailIdx;

				headIdx = searchCurrentHead(_currentIdx, _field);
				theoreticDst = _currentIdx + _step;

				if(theoreticDst < headIdx){
					return headIdx;
				}

				tailIdx = _field.IndexOf('\n', _currentIdx);
				if(tailIdx == -1){
					tailIdx = _field.Length;
				}

				if(tailIdx < theoreticDst){
					return tailIdx;
				}
				return theoreticDst;
			}

			/// <summary>
			/// step数分の縦移動要求に対して、地形の制約に応じた正味の移動先idxを返す。
			/// </summary>
			/// <param name="_current"></param>
			/// <param name="_step"></param>
			/// <param name="_field"></param>
			/// <returns></returns>
			public static int MoveVertical(int _current, int _step, string _field){
				int theoreticalHead, theoreticalDst;
				int theoreticalRowStep;

				if(_step < 0){
					theoreticalHead = calcTheoreticColHead_Neg(_current, _step, _field);
				}
				else if(0 < _step){
					theoreticalHead = calcTheoreticColHead_Pos(_current, _step, _field);
				}
				else{
					return _current;
				}

				if(theoreticalHead == -1){
					return _current;
				}

				theoreticalRowStep = _current - searchCurrentHead(_current, _field);
				theoreticalDst = MoveHolizontal(theoreticalHead, theoreticalRowStep, _field);
				return theoreticalDst;
			}

			private static int searchPreviousTail(int _currentIdx, string _field){
				int tailIdx;

				if(_currentIdx == _field.Length){
					return _field.LastIndexOf('\n', _currentIdx - 1);
				}

				tailIdx = _field.LastIndexOf('\n', _currentIdx);
				if(tailIdx == -1){
					return -1;
				}
				else if(tailIdx == _currentIdx){
					return _field.LastIndexOf('\n', _currentIdx - 1);
				}
				else{
					return tailIdx;
				}
			}
			private static int searchCurrentHead(int _currentIdx, string _field){
				int previousTail;

				previousTail = searchPreviousTail(_currentIdx, _field);
				if(previousTail == -1){
					return 0;
				}
				return previousTail + 1;
			}

			private static int searchCurrentTail(int _currentIdx, string _field){
				int tailIdx;

				if(_currentIdx == _field.Length - 1){
					return _currentIdx;
				}

				tailIdx = _field.IndexOf('\n', _currentIdx);
				if(tailIdx == -1){
					return _field.Length - 1;
				}
				else if(tailIdx == _currentIdx){
					return _currentIdx;
				}
				else{
					return tailIdx;
				}
			}
			private static int searchNextHead(int _currentIdx, string _field){
				int nextTail;
				nextTail = searchCurrentTail(_currentIdx, _field);
				if(nextTail == _field.Length - 1){
					return -1;
				}
				return nextTail + 1;
			}

			private static int calcTheoreticColHead_Neg(int _initialIdx, int _step, string _field){
				int step;
				int currentIdx = _initialIdx;
				int tmpCurrentIdx;
				int stepCount;

				stepCount = 1;
				step = _step * -1;

				while(stepCount <= step){
					tmpCurrentIdx = searchPreviousTail(currentIdx, _field);
					if(tmpCurrentIdx == -1){
						return -1;
					}
					currentIdx = tmpCurrentIdx;
					stepCount++;
				}

				return searchCurrentHead(currentIdx, _field);
			}
			private static int calcTheoreticColHead_Pos(int _initialIdx, int _step, string _field){
				int currentIdx = _initialIdx;
				int tmpCurrentIdx;
				int stepCount;

				stepCount = 1;
				while(stepCount <= _step){
					tmpCurrentIdx = searchNextHead(currentIdx, _field);
					if(tmpCurrentIdx == -1){
						return -1;
					}
					currentIdx = tmpCurrentIdx;
					stepCount++;
				}

				return currentIdx;
			}
		}
}
