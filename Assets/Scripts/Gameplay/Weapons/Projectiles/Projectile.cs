using Gameplay;
using UnityEngine;

namespace Gameplay.Weapons.Projectiles
{
    public abstract class Projectile : RegistrableGameObject, IDamageDealer
    {
        [SerializeField]
        private float _speed;
        [SerializeField] 
        private float _damage;
        
        private UnitBattleIdentity _battleIdentity;
        public UnitBattleIdentity BattleIdentity => _battleIdentity;
        public float Damage => _damage;

        private void Start () {
            Register (); // Регистрация в менеджере.
        }
        public void Init(UnitBattleIdentity battleIdentity)
        {
            _battleIdentity = battleIdentity;
        }
        private void Update()
        {
            Move(_speed);
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            var damagableObject = other.gameObject.GetComponent<IDamagable>();
            
            if (damagableObject != null 
                && damagableObject.BattleIdentity != BattleIdentity)
            {
                damagableObject.ApplyDamage(this);
                Unregister (); // Отмена регистрации в менеджере.
                Destroy (gameObject);
            }
        }
        // Начать заново.
        public override void Restart () {
            Destroy (gameObject);
        }
        protected abstract void Move(float speed);
    }
}
