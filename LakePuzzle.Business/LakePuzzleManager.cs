using System;
namespace LakePuzzle.Business
{
    public class LakePuzzleManager
    {

        public PuzzleResult GetShortestSolution(Bucket sourceBucket, Bucket targetBucket, uint goal)
        {
            ValidateInput(sourceBucket, targetBucket, goal);

            var sourceSolution = Solve(sourceBucket, targetBucket, goal);
            var targetSolution = Solve(targetBucket, sourceBucket, goal);

            return FindShortestSolution(sourceSolution, targetSolution);

        }

        public PuzzleResult Solve(Bucket sourceBucket, Bucket targetBucket, uint goal)
        {
            ValidateInput(sourceBucket, targetBucket, goal);

            var result = Factory.CreatePuzzleResult();

            sourceBucket.Empty();

            targetBucket.Empty();

            result.AddStep(Factory.CreatePuzzleSolutionStep("E", sourceBucket.CurrentVolume, "E", targetBucket.CurrentVolume));

            do
            {
                if (sourceBucket.IsEmpty())
                {
                    sourceBucket.Fill();
                    result.AddStep(Factory.CreatePuzzleSolutionStep("F", sourceBucket.CurrentVolume, " ", targetBucket.CurrentVolume));
                }
                else if (targetBucket.IsFull())
                {
                    if (sourceBucket.IsFull())  // No solution!
                    {
                        result = Factory.CreatePuzzleResult(); // Indicate that there's no solution
                        break;
                    }
                    targetBucket.Empty();
                    result.AddStep(Factory.CreatePuzzleSolutionStep(" ", sourceBucket.CurrentVolume, "E", targetBucket.CurrentVolume));
                }
                else
                {
                    sourceBucket.TransferTo(targetBucket);

                    result.AddStep(Factory.CreatePuzzleSolutionStep("T", sourceBucket.CurrentVolume, "T", targetBucket.CurrentVolume));
                }
            }
            while (targetBucket.CurrentVolume != goal && sourceBucket.CurrentVolume != goal);
            return result;
        }

        private static PuzzleResult FindShortestSolution(PuzzleResult sourceSolution, PuzzleResult targetSolution)
        {
            PuzzleResult shortestSolution = sourceSolution;

            if (targetSolution.Length == sourceSolution.Length)
            {
                return shortestSolution;
            }

            if (targetSolution.Length > 0 && sourceSolution.Length > 0)
            {
                if (targetSolution.Length < sourceSolution.Length)
                {
                    shortestSolution = targetSolution;
                }
            }
            else if (targetSolution.Length > 0)
            {
                shortestSolution = targetSolution;
            }

            return shortestSolution;
        }

        private static void ValidateInput(Bucket sourceBucket, Bucket targetBucket, uint goal)
        {
            var largerBucketSize = sourceBucket.Capacity > targetBucket.Capacity ? sourceBucket.Capacity : targetBucket.Capacity;

            // Validation rule: goal amount (X) should be less than largest bucket size
            if (goal > largerBucketSize)
            {
                throw new LakePuzzleException(string.Format("goal({0}) cannot be greater than largest bucket size({1})", goal, largerBucketSize));
            }
            // Validation rule: source bucket and target bucket cannot have the same capacity 
            if (sourceBucket.Capacity == targetBucket.Capacity)
            {
                throw new LakePuzzleException("sourceBucket and targetBucket cannot have the same capacity)");
            }
        }

    }
}
