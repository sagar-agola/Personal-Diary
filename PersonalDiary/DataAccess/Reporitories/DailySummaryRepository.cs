using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonalDiary.BusinessModels;
using PersonalDiary.DataAccess.Contracts;
using PersonalDiary.Database.Context;
using PersonalDiary.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonalDiary.DataAccess.Reporitories
{
    public class DailySummaryRepository : IDailySummaryReporitory
    {
        private readonly PersonalDiaryDbContext _context;
        private readonly IMapper _mapper;

        public DailySummaryRepository (PersonalDiaryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create (DailySummaryBM dailySummary)
        {
            DailySummary dailySummaryDM = _mapper.Map<DailySummary> (dailySummary);

            _context.DailySummaries.Add (dailySummaryDM);
            _context.SaveChanges ();
        }

        public bool Edit (DailySummaryBM dailySummary)
        {
            bool isEntityExists = _context.DailySummaries.Any (x => !x.DateDeleted.HasValue && x.Id == dailySummary.Id);

            if (isEntityExists)
            {
                DailySummary dailySummaryDM = _context.DailySummaries.AsNoTracking().First (x => x.Id == dailySummary.Id);

                dailySummaryDM.Desription = dailySummary.Desription;
                dailySummaryDM.DateModified = DateTime.Now;

                _context.DailySummaries.Update (dailySummaryDM);
                _context.SaveChanges ();
            }

            return isEntityExists;
        }

        public DailySummaryBM Get (int id)
        {
            DailySummary dailySummary = _context.DailySummaries
                .AsNoTracking()
                .FirstOrDefault (x => !x.DateDeleted.HasValue && x.Id == id);

            if (dailySummary == null)
            {
                return null;
            }

            return _mapper.Map<DailySummaryBM> (dailySummary);
        }

        public DailySummaryBM Get (DateTime CreatedDate)
        {
            DailySummary dailySummary = _context.DailySummaries
                .AsNoTracking()
                .FirstOrDefault (x => !x.DateDeleted.HasValue && x.DateCreated == CreatedDate);

            if (dailySummary == null)
            {
                return null;
            }

            return _mapper.Map<DailySummaryBM> (dailySummary);
        }

        public List<DailySummaryBM> GetAll ()
        {
            List<DailySummary> dailySummaries = _context.DailySummaries
                .AsNoTracking()
                .Where (x => !x.DateDeleted.HasValue)
                .ToList ();

            return _mapper.Map<List<DailySummaryBM>> (dailySummaries);
        }

        public bool Remove (int id)
        {
            bool isEntityExists = _context.DailySummaries.Any (x => !x.DateDeleted.HasValue && x.Id == id);

            if (isEntityExists)
            {
                DailySummary dailySummary = _context.DailySummaries.First (x => x.Id == id);

                _context.DailySummaries.Remove (dailySummary);
                _context.SaveChanges ();
            }

            return isEntityExists;
        }
    }
}
