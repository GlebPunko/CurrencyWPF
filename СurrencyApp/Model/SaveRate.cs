using System;

namespace СurrencyApp.Model
{
    public class SaveRate
    {
        public int Cur_ID { get; set; }
        public DateTime Date { get; set; }
        public string Cur_Abbreviation { get; set; }
        public decimal? Cur_OfficialRate { get; set; }
    }
}
