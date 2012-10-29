using System;

namespace LakePuzzle.Business
{
    public class PuzzleSolutionStep
    {
        public BucketAudit SourceBucketStep;
        public BucketAudit TargetBucketStep;
        public PuzzleSolutionStep(string sourceBucketOperation, uint sourceBucketState, string targetBucketOperation, uint targetBucketState)
        {
            SourceBucketStep = Factory.CreateBucketAudit(sourceBucketOperation, sourceBucketState);
            TargetBucketStep = Factory.CreateBucketAudit(targetBucketOperation, targetBucketState);
        }
    }   
}
