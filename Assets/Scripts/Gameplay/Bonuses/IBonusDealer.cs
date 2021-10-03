namespace Gameplay.Bonuses {
    // Добавлен интерфейс для бонусов.
    public interface IBonusDealer {
        BonusType BonusType { get; } // Тип бонуса.
        float Value { get; } // Эффективность бонуса.
        float Duration { get; } // Длительность бонуса.
    }
}
