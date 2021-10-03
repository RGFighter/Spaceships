using UI;
using Gameplay.Bonuses;
using UnityEngine;

namespace Gameplay.Spaceships.Custom {
    // Добавлен класс корабля игрока.
    [AddComponentMenu ("Spaceships/PlayerSpaceship")]
    public class PlayerSpaceship : Spaceship, IBonusReceiver {
        [SerializeField]
        private HPRefreshing _hpRefreshing; // Добавлено поле со ссылкой на UI с очками прочности корабля.
        public HPRefreshing HPRefreshing => _hpRefreshing; // Добавлено свойство для поля _hpRefreshing

        private protected override void Start () {
            base.Start ();
            _hpRefreshing.Init (this);
        }
        // Реализация метода из интерфейса IBonusReceiver
        public void ApplyBonus (IBonusDealer bonusDealer) {
            if (bonusDealer.BonusType == BonusType.HP)
                _hp += bonusDealer.Value;

            WeaponSystem.ApplyBonus (bonusDealer);
        }
        // Реализация абстрактного метода из класса Spaceship
        private protected override void DestroySelf () {
            Destroy (gameObject);
        }
	}
}
