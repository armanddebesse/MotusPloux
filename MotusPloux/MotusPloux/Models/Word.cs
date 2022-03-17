using System;
using SQLite;

namespace MotusPloux.Models
{
    public class Word
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
