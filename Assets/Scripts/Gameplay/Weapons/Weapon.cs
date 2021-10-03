using Gameplay.Bonuses;
using System.Collections;
using Gameplay.Weapons.Projectiles;
using UnityEngine;

namespace Gameplay.Weapons
{
    public class Weapon : MonoBehaviour, IBonusReceiver
    {
        [SerializeField]
        private Projectile _projectile;
        [SerializeField]
        private Transform _barrel;
        [SerializeField]
        private float _cooldown;
        private float _cooldownBooster; // Добавлено поле для получения ускорения от собранных бонусов. Увеличивает скорость на определённый процент.
        private Coroutine _coroutineBonusDuration; // Ссылка на корутину длительности бонуса.
        private bool _readyToFire = true;
        private UnitBattleIdentity _battleIdentity;
        public void Init(UnitBattleIdentity battleIdentity)
        {
            _battleIdentity = battleIdentity;
        }
        public void TriggerFire()
        {
            if (!_readyToFire)
                return;
            
            var proj = Instantiate(_projectile, _barrel.position, _barrel.rotation);
            proj.Init(_battleIdentity);
            StartCoroutine(Reload(_cooldown * (1 - _cooldownBooster / 100)));
        }
        private IEnumerator Reload(float cooldown)
        {
            _readyToFire = false;
            yield return new WaitForSeconds(cooldown);
            _readyToFire = true;
        }
        // Реализация метода из интерфейса IBonusReceiver
        public void ApplyBonus (IBonusDealer bonusDealer) {
            switch (bonusDealer.BonusType) {
                case BonusType.Energy:
                    // Заменяем или продлеваем бонус только если он такойже или еффективней.
                    if (bonusDealer.Value >= _cooldownBooster) {
                        _cooldownBooster = bonusDealer.Value;

                        if (_coroutineBonusDuration != null)
                            StopCoroutine (_coroutineBonusDuration);

                        _coroutineBonusDuration = StartCoroutine (BonusDuration (bonusDealer.Duration));
                    }

                    break;
            }
        }
        // Корутина длительности бонуса.
        private IEnumerator BonusDuration (float duration) {
            yield return new WaitForSeconds (duration);
            _cooldownBooster = 0;
        }
    }
}
