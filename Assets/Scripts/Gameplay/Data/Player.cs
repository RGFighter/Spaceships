namespace Gameplay.Data {
    // Добавлен статический класс содержащий информацию об игроке.
    public static class Player {
        private static int _score; // Поле содержащее количество очков.
        public static int Score => _score;

        static Player () {
            _score = 0;
        }
        // Мотод изменяющий количество очков.
        public static void ApplyScore (IScoreDealer scoreDealer) {
            _score += scoreDealer.Score;
        }
        // Метод сбрасывающий набранные очки.
        public static void Reset () {
            _score = 0;
        }
    }
}
