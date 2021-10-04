using Gameplay.Spaceships.Custom;
using UnityEngine;
using System.Collections.Generic;

namespace Gameplay {
    // Добавлен класс менеджер игровых объектов.
    public static class GameObjectsManager {
        private static List<IRegistrableGameObject> _objects; // Объекты.

        static GameObjectsManager () {
            _objects = new List<IRegistrableGameObject> ();
        }
        public static void Add (IRegistrableGameObject registrableGameObject) {
            _objects.Add (registrableGameObject);
            Debug.Log ($"_objects - Add: {_objects.Count}");
        }
        public static void Remove (IRegistrableGameObject registrableGameObject) {
            _objects.Remove (registrableGameObject);
            Debug.Log ($"_objects - Remove: {_objects.Count}");
        }
        public static void Restart () {
            IRegistrableGameObject player = null;

            foreach (IRegistrableGameObject registrableGameObject in _objects) {
                if (registrableGameObject is PlayerSpaceship playerSpaceship)
                    player = playerSpaceship;

                registrableGameObject.Restart ();
            }

            Debug.Log ($"_objects - Restart - 1: {_objects.Count}");

            _objects.Clear ();

            Debug.Log ($"_objects - Restart - 2: {_objects.Count}");

            if (player != null)
                Add (player);

            Debug.Log ($"_objects - Restart - 3: {_objects.Count}");
        }
    }
}
