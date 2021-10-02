namespace Gameplay.Data {
    // Добавлен интерфейс для объектов за которые можно получать очки.
    public interface IScoreDealer {
        int Score { get; }
    }
}
