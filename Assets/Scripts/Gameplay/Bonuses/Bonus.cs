using UnityEngine;

namespace Gameplay.Bonuses {
    // Добавлен класс бонуса выпадающего из уничтоженного вражеского корабля (в соответствии с требованиями ТЗ).
    [AddComponentMenu ("Spaceships/Bonuses/Bonus")]
    public class Bonus : MonoBehaviour, IBonusDealer {
        [SerializeField]
        private BonusType _bonusType; // Тип.
        [SerializeField]
        private float _value; // Эффективность.
        [SerializeField]
        private float _duration; // Длительность.
        [SerializeField]
        private float _speed; // Скорость движения.

        public BonusType BonusType => _bonusType;
        public float Value => _value;
        public float Duration => _duration;

        private void Update () {
            Move (_speed);
        }
        private void OnCollisionEnter2D (Collision2D other) {
            var bonusReceiver = other.gameObject.GetComponent<IBonusReceiver> ();

            if (bonusReceiver != null) {
                bonusReceiver.ApplyBonus (this);
                Destroy (gameObject);
            }
        }
        private protected void Move (float speed) {
            transform.Translate (speed * Time.deltaTime * Vector3.up);
        }
    }
}
