using UnityEngine;

namespace Gameplay {
    // Добавлен базовый абстрактный класс для всех регистрируемых игровых объектов.
    public abstract class RegistrableGameObject : MonoBehaviour, IRegistrableGameObject {
        // Регистрация в менеджере объектов.
        public void Register () {
            GameObjectsManager.Add (this);
        }
        // Отмена регистрации в менеджере объектов.
        public void Unregister () {
            GameObjectsManager.Remove (this);
        }
        public abstract void Restart ();
    }
}
