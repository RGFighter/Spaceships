using UnityEngine;

namespace Gameplay.Helpers
{
    public static class GameAreaHelper
    {
        private static Camera _camera;

        private static float topBound; // Вынесено в приватное поле.
        private static float bottomBound; // Вынесено в приватное поле.
        private static float leftBound; // Вынесено в приватное поле.
        private static float rightBound; // Вынесено в приватное поле.

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
            topBound = camPos.y + camHalfHeight;
            bottomBound = camPos.y - camHalfHeight;
            leftBound = camPos.x - camHalfWidth;
            rightBound = camPos.x + camHalfWidth;
        }
        public static bool IsInGameplayArea(Transform objectTransform, Bounds objectBounds)
        {
            var objectPos = objectTransform.position;

            return (objectPos.x - objectBounds.extents.x < rightBound)
                && (objectPos.x + objectBounds.extents.x > leftBound)
                && (objectPos.y - objectBounds.extents.y < topBound)
                && (objectPos.y + objectBounds.extents.y > bottomBound);
        }
        // Позволяет определить являетсяли пространство слева от корабля игровым полем.
        public static bool IsInGameplayAreaLeft (Transform objectTransform, Bounds objectBounds) {
            var objectPos = objectTransform.position;

            return objectPos.x - objectBounds.extents.x > leftBound;
        }
        // Позволяет определить являетсяли пространство справа от корабля игровым полем.
        public static bool IsInGameplayAreaRight (Transform objectTransform, Bounds objectBounds) {
            var objectPos = objectTransform.position;

            return objectPos.x + objectBounds.extents.x < rightBound;
        }
    }
}
