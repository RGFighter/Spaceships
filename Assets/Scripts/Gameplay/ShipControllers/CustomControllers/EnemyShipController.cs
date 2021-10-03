using System.Collections;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using UnityEngine;

// Класс изменён.
public class EnemyShipController : ShipController {
    [SerializeField]
    private Vector2 _fireDelay;
    [SerializeField]
    private float _oneDirectionMoveTime; // Добавлено поле для назначения времени движения корабля в одном направлении.
    private float _lateralDirection = -1; // Добавлено поле для переключения направления бокового движения.
    private bool _fire = true;

    private void Awake () {
        // Запускаем постоянную смену направления бокового движения, если это необходимо.
        if (_oneDirectionMoveTime != 0)
            StartCoroutine (LateralDirectionDelay (_oneDirectionMoveTime));
    }
    // Добавлен метод для ожидания переключения направления бокового движения.
    private IEnumerator LateralDirectionDelay (float delay) {
        while (true) {
            yield return new WaitForSeconds (delay);
            _lateralDirection *= -1;
        }
    }
    protected override void ProcessHandling (MovementSystem movementSystem) {
        movementSystem.LongitudinalMovement (Time.deltaTime);

        // Боковое движение корабля.
        if (_oneDirectionMoveTime != 0)
            movementSystem.LateralMovement (_lateralDirection * Time.deltaTime);
    }
    protected override void ProcessFire (WeaponSystem fireSystem) {
        if (!_fire)
            return;

        fireSystem.TriggerFire ();
        StartCoroutine (FireDelay (Random.Range (_fireDelay.x, _fireDelay.y)));
    }
    private IEnumerator FireDelay (float delay) {
        _fire = false;
        yield return new WaitForSeconds (delay);
        _fire = true;
    }
}
