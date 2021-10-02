using UnityEngine;
using TMPro;

namespace UI {
	// Добавлен класс отображающий количество очков игрока в UI (в соответствии с требованиями ТЗ).
	[AddComponentMenu ("Spaceships/UI/ScoreRefreshing")]
	[RequireComponent (typeof (TMP_Text))]
    public class ScoreRefreshing : MonoBehaviour {
		private int _previous; // Поле с предыдущими отображёнными очками.
		private TMP_Text _text; // Поле со ссылкой на компонент TMP_Text
		[SerializeField]
		private string _prefix; // Поле с текстом отображаемым перед количеством очков.

		private void Awake () {
			_previous = 0;
			_text = GetComponent<TMP_Text> ();
		}
		private void Update () {
			// Для экономии ресурсов обновляем текст только при необходимости.
			if (Gameplay.Data.Player.Score != _previous) {
				_text.text = $"{_prefix}{Gameplay.Data.Player.Score}";
				_previous = Gameplay.Data.Player.Score;
			}
		}
	}
}
