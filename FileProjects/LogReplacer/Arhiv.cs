using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LogReplacer
{
    public class Arhiv
    {
        public string TimeStart;       //дата-время начала запуска процедуры
        public int TimeIntervalHours;  //период запуска переноса в архив
        public string FromDirectory;   //откуда копировать
        public string ToDirectory;     //куда  копировать
        public int QuantityDaysToMove; //количество дней старше кот перемещаем в архив
    }
}
