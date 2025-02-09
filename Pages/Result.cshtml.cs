using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static SchoolGradesModelLib.SchoolGradesModel;

namespace StudentGradesApp.Pages
{
    public class ResultModel : PageModel
    {
        public ModelOutput? _modelOutput
        {
            get; set;
        }

        public string Grade
        {
            get; set;
        }
        public void OnGet(ModelOutput modelOutput)
        {
            _modelOutput = modelOutput;
            Grade = Math.Round(_modelOutput.Score, 1).ToString();
        }
    }
}
