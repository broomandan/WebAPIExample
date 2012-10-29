using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LakePuzzle.Business
{
    public class PuzzleSolutionStepFlat
    {
        public string SourceBucketOperation { get; set; }
        public uint SourceBucketState { get; set; }
        public string TargetBucketOperation { get; set; }
        public uint TargetBucketState { get; set; }
        public PuzzleSolutionStepFlat(string sourceBucketOperation, uint sourceBucketState, string targetBucketOperation, uint targetBucketState)
        {
            SourceBucketOperation = sourceBucketOperation;
            SourceBucketState = sourceBucketState;
            TargetBucketOperation = targetBucketOperation;
            TargetBucketState = targetBucketState;
        }
    }
}
