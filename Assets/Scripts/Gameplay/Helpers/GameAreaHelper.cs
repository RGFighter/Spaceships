using UnityEngine;

namespace Gameplay.Helpers
{
    public static class GameAreaHelper
    {
        private static Camera _camera;

        private static float _topBound; // Вынесено в приватное поле.
        private static float _bottomBound; // Вынесено в приватное поле.
        private static float _leftBound; // Вынесено в приватное поле.
        private static float _rightBound; // Вынесено в приватное поле.

        static GameAreaHelper()
        {
            _camera = Camera.main;
            CalculateGameplayArea (); // Вычисление рамок игрового поля при инициализации.
        }
        // Позволяет вычислить рамки игрового поля. Вынесено в отдельный метод для экономии ресурсов.
        // Вызывать при наличии фактической необходимости (изменение положения камеры, изменение соотношения сторон и т.д.)
        public static void CalculateGameplayArea () {
            var camHalfHeight = _camera.orthographicSize;
            var camHalfWidth = camHalfHeight * _camera.aspect;
            var camPos = _camera.transform.position;
            _topBound = camPos.y + camHalfHeight;
            _bottomBound = camPos.y - camHalfHeight;
            _leftBound = camPos.x - camHalfWidth;
            _rightBound = camPos.x + camHalfWidth;
        }
        public static bool IsInGameplayArea(Transform objectTransform, Bounds objectBounds)
        {
            var objectPos = objectTransform.position;

            return (objectPos.x - objectBounds.extents.x < _rightBound)
                && (objectPos.x + objectBounds.extents.x > _leftBound)
                && (objectPos.y - objectBounds.extents.y < _topBound)
                && (objectPos.y + objectBounds.extents.y > _bottomBound);
        }
        // Позволяет определить являетсяли пространство слева от корабля игровым полем.
        public static bool IsInGameplayAreaLeft (Transform objectTransform, Bounds objectBounds) {
            var objectPos = objectTransform.position;

            return objectPos.x - objectBounds.extents.x > _leftBound;
        }
        // Позволяет определить являетсяли пространство справа от корабля игровым полем.
        public static bool IsInGameplayAreaRight (Transform objectTransform, Bounds objectBounds) {
            var objectPos = objectTransform.position;

            return objectPos.x + objectBounds.extents.x < _rightBound;
        }
    }
}
