using Gameplay.Data;
using UnityEngine;

namespace Gameplay.Spaceships.Custom {
    // Добавлен класс корабля врага.
    [AddComponentMenu ("Spaceships/EnemySpaceship")]
    public class EnemySpaceship : Spaceship, IScoreDealer {
        [SerializeField]
        private int _score; // Добавлено поле для хранения количества очков получаемых за уничтожение корабля.
        public int Score => _score; // Реализация свойства из интерфейса IScoreDealer.

        // Реализация абстрактного метода из класса Spaceship
        private protected override void DestroySelf () {
            Destroy (gameObject);
            Player.ApplyScore (this);
        }
    }
}
