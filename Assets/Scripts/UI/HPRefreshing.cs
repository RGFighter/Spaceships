using Gameplay.Weapons;
using UnityEngine;

namespace UI {
	// Добавлен класс отображающий количество очков прочности корабля в UI (в соответствии с требованиями ТЗ).
	[AddComponentMenu ("Spaceships/UI/HPRefreshing")]
    public class HPRefreshing : Refreshing<float> {
		private IDamagable _damagable;

		public void Init (IDamagable damagable) {
			_damagable = damagable;
		}
		private protected override void Refresh () {
			// Для экономии ресурсов обновляем текст только при необходимости.
			if (_damagable.HP != _previous) {
				_text.text = $"{_damagable.HP}";
				_previous = _damagable.HP;
			}
		}
	}
}
