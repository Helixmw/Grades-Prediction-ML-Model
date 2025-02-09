using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SudentGradesApp.Logic;
using SudentGradesApp.Models;
using SchoolGradesModelLib;
using static SchoolGradesModelLib.SchoolGradesModel;
using StudentGradesApp.Logic;

namespace SudentGradesApp.Controllers;
public class HomeController : Controller
{
    private readonly MLModelProcessor _mLModelProcessor;

    public HomeController(MLModelProcessor mLModelProcessor)
    {
        _mLModelProcessor = mLModelProcessor;
    }

    public ActionResult Index()
    {
        return View();
    }

    public ActionResult Result()
    {
        return View();
    }



    [HttpPost]
    public ActionResult MakePrediction(IFormCollection collection)
    {
        float studyHours;
        float sleepHours;
        float attendance;
        float.TryParse(collection["studyHours"], out studyHours);
        float.TryParse(collection["sleepHours"], out sleepHours);
        float.TryParse(collection["attendance"], out attendance);
        var student = new ModelInput()
        {
            StudyHours = studyHours,
            SleepHours = sleepHours,
            Attendance = attendance
        };
        var prediction = _mLModelProcessor.MakePrediction(student);

        
        return RedirectToPage("/Result", prediction);
    }

}
