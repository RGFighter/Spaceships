using UI;
using Gameplay.Bonuses;
using UnityEngine;

namespace Gameplay.Spaceships.Custom {
    // Добавлен класс корабля игрока.
    [AddComponentMenu ("Spaceships/PlayerSpaceship")]
    public class PlayerSpaceship : Spaceship, IBonusReceiver {
        [SerializeField]
        private HPRefreshing _hpRefreshing; // Добавлено поле со ссылкой на UI с очками прочности корабля.
        [SerializeField]
        private GameOver _gameOver; // Добавлено поле со ссылкой на UI с результатами игры.
        public HPRefreshing HPRefreshing => _hpRefreshing; // Добавлено свойство для поля _hpRefreshing
        public GameOver GameOver => _gameOver; // Добавлено свойство для поля _gameOver

        private protected override void Start () {
            base.Start ();
            _hpRefreshing.Init (this);
            _gameOver.Init ();
        }
        // Реализация метода из интерфейса IBonusReceiver
        public void ApplyBonus (IBonusDealer bonusDealer) {
            if (bonusDealer.BonusType == BonusType.HP)
                _hp += bonusDealer.Value;

            WeaponSystem.ApplyBonus (bonusDealer);
        }
        // Реализация абстрактного метода из класса Spaceship
        private protected override void DestroySelf () {
            _gameOver.Open ();
        }
        // Начать заново.
        public override void Restart () {
            transform.position = new Vector3 (0, -16.7f, 0); // Размещаем корабль в начальное положение.
            _hp = _hp_Default; // Выставляем начальное количество прочности.
		}
    }
}
