using Gameplay.Data;
using Gameplay.ShipSystems;
using UnityEngine;

namespace Gameplay.Spaceships.Custom {
    // Добавлен класс корабля врага.
    [AddComponentMenu ("Spaceships/EnemySpaceship")]
    public class EnemySpaceship : Spaceship, IScoreDealer {
        [SerializeField]
        private BonusesSystem _bonusesSystem; // Поле для системы бонусов.
        [SerializeField]
        private int _score; // Добавлено поле для хранения количества очков получаемых за уничтожение корабля.
        public BonusesSystem BonusesSystem => _bonusesSystem;
        public int Score => _score; // Реализация свойства из интерфейса IScoreDealer.

        // Реализация абстрактного метода из класса Spaceship
        private protected override void DestroySelf () {
            Player.ApplyScore (this);
            _bonusesSystem.TriggerBonus ();
            Destroy (gameObject);
        }
    }
}
