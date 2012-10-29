using System.Collections.Generic;
using System.Diagnostics;

namespace LakePuzzle.Business
{
    public class PuzzleResult
    {
        private List<PuzzleSolutionStep> _solutionsSteps;

        public void AddStep(PuzzleSolutionStep step)
        {
            _solutionsSteps.Add(step);
        }

        public int Length
        {
            get
            {
                return _solutionsSteps.Count;
            }
        }

        public PuzzleResult()
        {
            _solutionsSteps = new List<PuzzleSolutionStep>();
        }
        public IList<PuzzleSolutionStepFlat> GetResultSteps()
        {
            var result = new List<PuzzleSolutionStepFlat>();
             _solutionsSteps.ForEach(step =>result.Add( new PuzzleSolutionStepFlat(step.SourceBucketStep.Operation,step.SourceBucketStep.State,step.TargetBucketStep.Operation,step.TargetBucketStep.State )));
            return result;  
        }
        public void printLog()
        {
            Debug.WriteLine("---------------------------");
            _solutionsSteps.ForEach(step => PrintStep(step));
            Debug.WriteLine("---------------------------");
        }

        private static void PrintStep(PuzzleSolutionStep step)
        {
            Debug.WriteLine("{0}{1}\t\t\t{2}{3}", step.SourceBucketStep.Operation, step.SourceBucketStep.State, step.TargetBucketStep.Operation, step.TargetBucketStep.State);
        }
    }
}
