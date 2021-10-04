namespace Gameplay {
    // Добавлен интерфейс для регистрируемых игровых объектов.
    public interface IRegistrableGameObject {
        void Register (); // Зарегистрировать в менеджере.
        void Unregister (); // Отменить регистрацию в менеджере.
        void Restart (); // Перезапустить.
    }
}
