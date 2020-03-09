using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalDiary.BusinessModels;
using PersonalDiary.DataAccess.Contracts;

namespace PersonalDiary.Controllers
{
    public class DailySummaryController : Controller
    {
        private readonly IDailySummaryReporitory _dailySummaryReporitory;

        public DailySummaryController (IDailySummaryReporitory dailySummaryReporitory)
        {
            this._dailySummaryReporitory = dailySummaryReporitory;
        }

        public IActionResult Index()
        {
            List<DailySummaryBM> dailySummaries = _dailySummaryReporitory.GetAll ();

            return View(dailySummaries);
        }

        [HttpGet]
        public IActionResult CreateEdit (int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.Mode = "Create";
                return View ();
            }
            else
            {
                DailySummaryBM dailySummary = _dailySummaryReporitory.Get ((int) id);
                ViewBag.Mode = "Edit";

                return View (dailySummary);
            }
        }

        [HttpPost]
        public IActionResult CreateEdit (DailySummaryBM dailySummary)
        {
            if (!dailySummary.Id.HasValue)
            {
                dailySummary.DateCreated = DateTime.Now;

                _dailySummaryReporitory.Create (dailySummary);
            }
            else
            {
                dailySummary.DateModified = DateTime.Now;

                _dailySummaryReporitory.Edit (dailySummary);
            }

            return RedirectToAction ("Index");
        }

        [HttpGet]
        public IActionResult Details (int id)
        {
            DailySummaryBM dailySummary = _dailySummaryReporitory.Get (id);

            return View (dailySummary);
        }

        [HttpGet]
        [ActionName ("Remove")]
        public IActionResult RemoveGet (int id)
        {
            DailySummaryBM dailySummary = _dailySummaryReporitory.Get (id);

            return View (dailySummary);
        }

        [HttpPost]
        [ActionName ("Remove")]
        public IActionResult RemovePost (int id)
        {
            _dailySummaryReporitory.Remove (id);

            return RedirectToAction ("Index");
        }
    }
}