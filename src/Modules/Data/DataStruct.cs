using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace src.Modules.Data
{
    /// <summary>
    /// Класс для создания структуры базы данных для конкретного сервера.
    /// </summary>
    public class DataStruct
    {
        /// <summary>
        /// Путь к общей базе данных.
        /// </summary>
        public const string Root = @"Database";
        /// <summary>
        /// Путь к папке с профилями для конкретных серверов.
        /// </summary>
        public string Profiles { get; }
        /// <summary>
        /// Путь к папке с инвентарями для конкретных серверов.
        /// </summary>
        public string Inventorys { get; }
        /// <summary>
        /// Путь к папке с характеристиками.
        /// </summary>
        public string Characteristics { get; }
        /// <summary>
        /// Путь к папке с инвентарями конкретных персонажей.
        /// </summary>
        public string Weapons { get; }
        /// <summary>
        /// Путь к папке с файлами с оружиями игроков.
        /// </summary>
        public string Items { get; }
        /// <summary>
        /// Путь к папке с файлами с вещами игроков.
        /// </summary>
        public string Buffs { get; }
        /// <summary>
        /// Путь к папке с дебаффами персонажа.
        /// </summary>
        public string Debuffs { get; }
        /// <summary>
        /// Путь к папке с .txt файлами, где заметки об игроках, которые пишут ГМы.
        /// </summary>
        public string GameMasterNotes { get; }
        /// <summary>
        /// Создаёт базу данных для конкретного сервера.
        /// </summary>
        /// <param name="GuildID">Сюда нужно добавлять Context.Guild</param
        /// <param name="doCreate">Если точно знаете, что база данных есть, то ради произв. можно не проверять, выбрав false</param>
        public DataStruct(ulong GuildID, bool doCreate = true)
        {
            Profiles = $@"{Root}\{GuildID}\Profiles";
            Characteristics = $@"{Root}\{GuildID}\Characteristics";
            Inventorys = $@"{Root}\{GuildID}\Inventorys";
            Weapons = $@"{Root}\{GuildID}\Inventorys\Weapons";
            Items = $@"{Root}\{GuildID}\Inventorys\Items";
            Buffs = $@"{Root}\{GuildID}\Buffs";
            Debuffs = $@"{Root}\{GuildID}\Debuffs";
            GameMasterNotes = $@"{Root}\{GuildID}\GameMasterNotes";

            if (doCreate)
                try
                {
                    if (!Directory.Exists(Profiles)) Directory.CreateDirectory(Profiles);
                    if (!Directory.Exists(Inventorys)) Directory.CreateDirectory(Inventorys);
                    if (!Directory.Exists(Weapons)) Directory.CreateDirectory(Weapons);
                    if (!Directory.Exists(Items)) Directory.CreateDirectory(Items);
                    if (!Directory.Exists(Buffs)) Directory.CreateDirectory(Buffs);
                    if (!Directory.Exists(Debuffs)) Directory.CreateDirectory(Debuffs);
                    if (!Directory.Exists(GameMasterNotes)) Directory.CreateDirectory(GameMasterNotes);
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[{DateTime.Now}] проблема с созданием папок в Database!");
                    Console.ResetColor();
                }
        }
    }
}