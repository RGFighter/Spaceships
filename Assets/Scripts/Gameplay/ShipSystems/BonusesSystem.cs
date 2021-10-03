using Gameplay.Bonuses;
using UnityEngine;

namespace Gameplay.ShipSystems {
    // Добавлен класс управляющий выпадением бонусов из уничтоженных вражеских кораблей (в соответствии с требованиями ТЗ).
    [AddComponentMenu ("Spaceships/ShipSystems/BonusesSystem")]
    public class BonusesSystem : MonoBehaviour {
        [SerializeField]
        private Bonus _bonus; // Префаб бонуса.
        [SerializeField]
        private Transform _place; // Место появления бонуса.
        [SerializeField]
        [Range (0, 100)]
        private float _chance; // Шанс на выпадение.
        public void TriggerBonus () {
            if (_chance > 0) {
                if (Random.Range (0f, 100f) <= _chance)
                    Instantiate (_bonus, _place.position, _place.rotation);
            }
        }
    }
}
