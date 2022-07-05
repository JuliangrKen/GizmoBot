// Не переименовывать ничего! Иначе в процессе десериализации произойдёт ошибка.
namespace src.Modules.Profiles
{
    /// <summary>
    /// Класс для создания профиля игрока.
    /// </summary>
    [Serializable]
    public class Profile
    {
        /// <summary>
        /// Данные игрока.
        /// </summary>
        public ulong UserID { get; protected set; }
        /// <summary>
        /// Гильдия/сервер.
        /// </summary>
        public ulong Guild { get; protected set; }
        /// <summary>
        /// Имя персонажа.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Деньги
        /// </summary>
        public uint Money { get; set; }
        /// <summary>
        /// Уровень персонажа.
        /// </summary>
        public uint LVL { get; set; }
        /// <summary>
        /// Количество опыта персонажа.
        /// </summary>
        public uint XP { get; set; }
        /// <summary>
        /// Очки характеристик.
        /// </summary>
        public uint PerformancePoints { get; set; }

        /// <summary>
        /// Просто создаёт профиль.
        /// </summary>
        /// <param name="UserID">ID игрока.</param>
        /// <param name="Guild">Гильдия/сервер.</param>
        /// <param name="Name">Имя персонажа.</param>
        /// <param name="Money">Имя персонажа.</param>
        /// <param name="LVL">Уровень персонажа.</param>
        /// <param name="XP">Количество опыта персонажа.</param>
        /// <param name="PerformancePoints">Количество опыта персонажа.</param>
        public Profile(ulong UserID, ulong Guild, string Name, uint Money = 0, uint LVL = 0, uint XP = 0, uint PerformancePoints = 0)
        {
            this.UserID = UserID;
            this.Guild = Guild;
            this.Name = Name;
            this.Money = Money;
            this.LVL = LVL;
            this.XP = XP;
            this.PerformancePoints = PerformancePoints;
        }
    }
}
