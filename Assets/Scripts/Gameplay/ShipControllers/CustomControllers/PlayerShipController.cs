using Gameplay.ShipSystems;
using Gameplay.Helpers;
using UnityEngine;

namespace Gameplay.ShipControllers.CustomControllers
{
    public class PlayerShipController : ShipController
    {
        [SerializeField]
        private SpriteRenderer _representation; // Добавлено поле для хранения ссылки на спрайт корабля.

        // Метод изменён для ограничения передвижения корабля игрока (в соответствии с требованиями ТЗ).
        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            var axis = Input.GetAxis ("Horizontal");

            if (axis > 0) {
                if (GameAreaHelper.IsInGameplayAreaRight (transform, _representation.bounds))
                    movementSystem.LateralMovement (axis * Time.deltaTime);
            } else {
                if (GameAreaHelper.IsInGameplayAreaLeft (transform, _representation.bounds))
                    movementSystem.LateralMovement (axis * Time.deltaTime);
            }
        }
        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                fireSystem.TriggerFire();
            }
        }
    }
}
