using System;

namespace PersonalDiary.Database.Models
{
    public class DailySummary
    {
        public int Id { get; set; }
        public string Desription { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
