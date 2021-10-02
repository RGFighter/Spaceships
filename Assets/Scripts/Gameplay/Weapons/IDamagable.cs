namespace Gameplay.Weapons
{
    public interface IDamagable
    {
        UnitBattleIdentity BattleIdentity { get; }
        float HP { get; } // Добавлено свойство. Количество очков прочности корабля.
        void ApplyDamage(IDamageDealer damageDealer);
    }
    public enum UnitBattleIdentity
    {
        Neutral,
        Ally,
        Enemy
    }
}
