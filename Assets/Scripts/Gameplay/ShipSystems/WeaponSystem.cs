using Gameplay.Bonuses;
using System.Collections.Generic;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.ShipSystems
{
    public class WeaponSystem : MonoBehaviour, IBonusReceiver {
        [SerializeField]
        private List<Weapon> _weapons;
        public void Init(UnitBattleIdentity battleIdentity)
        {
            _weapons.ForEach(w => w.Init(battleIdentity));
        }
        public void TriggerFire()
        {
            _weapons.ForEach(w => w.TriggerFire());
        }
        // Реализация метода из интерфейса IBonusReceiver
        public void ApplyBonus (IBonusDealer bonusDealer) {
            _weapons.ForEach (w => w.ApplyBonus (bonusDealer));
        }
    }
}
