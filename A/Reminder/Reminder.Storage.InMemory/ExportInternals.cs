//кому мы разрешаем видеть свои internals члены за пределами сборки
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Reminder.Storage.InMemory.Tests")]