using PersonalDiary.BusinessModels;
using System;
using System.Collections.Generic;

namespace PersonalDiary.DataAccess.Contracts
{
    public interface IDailySummaryReporitory
    {
        List<DailySummaryBM> GetAll ();
        DailySummaryBM Get (int id);
        DailySummaryBM Get (DateTime CreatedDate);

        void Create (DailySummaryBM dailySummary);
        bool Edit (DailySummaryBM dailySummary);
        bool Remove (int id);
    }
}
