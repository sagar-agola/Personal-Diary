using AutoMapper;
using PersonalDiary.BusinessModels;
using PersonalDiary.Database.Models;

namespace PersonalDiary.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile ()
        {
            CreateMap<DailySummary, DailySummaryBM> ().ReverseMap ();
        }
    }
}
