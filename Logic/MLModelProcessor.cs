using Microsoft.Extensions.ML;
using Microsoft.ML;
using SudentGradesApp.Logic;
using SudentGradesApp.Models;
using static SchoolGradesModelLib.SchoolGradesModel;

namespace StudentGradesApp.Logic;

public class MLModelProcessor
{
    private readonly PredictionEnginePool<ModelInput, ModelOutput> _predictionEnginePool;

    public MLModelProcessor(PredictionEnginePool<ModelInput, ModelOutput> predictionEnginePool)
    {
        _predictionEnginePool = predictionEnginePool;
     
    }
    //Generates Prediction
    public ModelOutput MakePrediction(ModelInput student)
    {
        var engine = _predictionEnginePool.GetPredictionEngine();
        return engine.Predict(student);
    }

    
}
