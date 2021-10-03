namespace Gameplay.Bonuses {
    // Добавлено перечисление для типов бонусов.
    public enum BonusType {
        HP,
        Energy
    }
    // Добавлен интерфейс для получателя бонусов.
    public interface IBonusReceiver {
        void ApplyBonus (IBonusDealer bonusDealer); // Применить бонус.
    }
}
