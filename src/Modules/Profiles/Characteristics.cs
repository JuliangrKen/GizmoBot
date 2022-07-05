using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using src.Modules;
using src.Modules.Data;

namespace src.Modules.Profiles
{
    public class Characteristics
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        /// <summary>
        /// Создание новой характеристики.
        /// </summary>
        /// <param name="Guild"></param>
        public void CreateNewChars(ulong Guild)
        {
            var dir = new DataStruct(Guild);
        }
    }
}
