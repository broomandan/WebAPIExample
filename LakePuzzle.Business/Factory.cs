using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LakePuzzle.Business
{
    public class Factory
    {
        public static Bucket CreateBucket(uint bucketCapacity)
        {
            if (bucketCapacity > 100)
            {
                throw new LakePuzzleException(string.Format("bucketCapacity({0}) cannot be greater than 100!", bucketCapacity));
            }
            return new Bucket(bucketCapacity);
        }

        public static LakePuzzleManager CreateLakePuzzleManager()
        {
            return new LakePuzzleManager();
        }

        public static PuzzleSolutionStep CreatePuzzleSolutionStep(string sourceOperation, uint sourceState, string targetOperation, uint targetState)
        {
            return new PuzzleSolutionStep(sourceOperation, sourceState, targetOperation, targetState);
        }

        public static PuzzleResult CreatePuzzleResult()
        {
            return new PuzzleResult();
        }

        internal static BucketAudit CreateBucketAudit(string operation, uint state)
        {
            return new BucketAudit() { Operation = operation, State = state };
        }
    }
}
