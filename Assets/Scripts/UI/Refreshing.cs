using UnityEngine;
using TMPro;

namespace UI {
	// Добавлен абстрактный класс отображающий информацию в UI.
	[RequireComponent (typeof (TMP_Text))]
    public abstract class Refreshing<T> : MonoBehaviour {
		private protected T _previous; // Поле с предыдущим отображённым значением.
		private protected TMP_Text _text; // Поле со ссылкой на компонент TMP_Text

		private void Awake () {
			_previous = default;
			_text = GetComponent<TMP_Text> ();
		}
		private protected abstract void Refresh ();
		private void Update () {
			Refresh ();
		}
	}
}
