using UnityEngine;

namespace UI {
	// Добавлен класс отображающий количество очков игрока в UI (в соответствии с требованиями ТЗ).
	[AddComponentMenu ("Spaceships/UI/ScoreRefreshing")]
    public class ScoreRefreshing : Refreshing<int> {
		[SerializeField]
		private string _prefix; // Поле с текстом отображаемым перед количеством очков.

		private protected override void Refresh () {
			// Для экономии ресурсов обновляем текст только при необходимости.
			if (Gameplay.Data.Player.Score != _previous) {
				_text.text = $"{_prefix}{Gameplay.Data.Player.Score}";
				_previous = Gameplay.Data.Player.Score;
			}
		}
	}
}
