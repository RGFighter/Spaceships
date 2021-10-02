using Gameplay.Data;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public class Spaceship : MonoBehaviour, ISpaceship, IDamagable, IScoreDealer
    {
        [SerializeField]
        private ShipController _shipController;
        [SerializeField]
        private MovementSystem _movementSystem;
        [SerializeField]
        private WeaponSystem _weaponSystem;
        [SerializeField]
        private UnitBattleIdentity _battleIdentity;
        [SerializeField]
        private float _hp; // Добавлено поле для хранения количества очков прочности корабля.
        [SerializeField]
        private int _score; // Добавлено поле для хранения количества очков получаемых за уничтожение корабля.

        public MovementSystem MovementSystem => _movementSystem;
        public WeaponSystem WeaponSystem => _weaponSystem;
        public UnitBattleIdentity BattleIdentity => _battleIdentity;
        public float HP => _hp; // Реализация свойства из интерфейса IDamagable.
        public int Score => _score; // Реализация свойства из интерфейса IScoreDealer.

        private void Start()
        {
            _shipController.Init(this);
            _weaponSystem.Init(_battleIdentity);
        }
        // Метод изменён. Корабль получает урон и тратит очки прочности (в соответствии с требованиями ТЗ).
        public void ApplyDamage(IDamageDealer damageDealer)
        {
            _hp -= damageDealer.Damage;

            if (_hp <= 0) {
                Destroy (gameObject);

                if (damageDealer.BattleIdentity == UnitBattleIdentity.Ally) {
                    Player.ApplyScore (this);
                }
            }
        }
    }
}
