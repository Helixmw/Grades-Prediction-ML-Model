using SudentGradesApp.Interfaces;
using SudentGradesApp.Models;
using static SchoolGradesModelLib.SchoolGradesModel;

namespace SudentGradesApp.Logic;

public interface IMLModelProcessor
{
     ModelOutput MakePrediction(ModelInput TModelInput);
}
