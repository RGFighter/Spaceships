using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.Spaceships
{
    // Класс изменён на абстрактный.
    public abstract class Spaceship : MonoBehaviour, ISpaceship, IDamagable
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

        public MovementSystem MovementSystem => _movementSystem;
        public WeaponSystem WeaponSystem => _weaponSystem;
        public UnitBattleIdentity BattleIdentity => _battleIdentity;
        public float HP => _hp; // Реализация свойства из интерфейса IDamagable.

        private protected virtual void Start()
        {
            _shipController.Init(this);
            _weaponSystem.Init(_battleIdentity);
        }
        // Метод изменён. Корабль получает урон и тратит очки прочности (в соответствии с требованиями ТЗ).
        public void ApplyDamage(IDamageDealer damageDealer)
        {
            _hp -= damageDealer.Damage;

            if (_hp <= 0)
                DestroySelf ();
        }
        // Добавлен абстрактный метод отвечающий за уничтожение корабля.
        private protected abstract void DestroySelf ();
    }
}
