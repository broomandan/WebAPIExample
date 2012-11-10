using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LakePuzzle.Business;
namespace LakePuzzle.Business.test
{
    class Mother
    {
        internal static Bucket GetSourceBucket()
        {
            return Factory.CreateBucket(3);

        }
        internal static Bucket GetTargetBucket()
        {
            return Factory.CreateBucket(5);
        }
        internal static Bucket GetSourceBucketNotSolved()
        {
            return Factory.CreateBucket(6);

        }
        internal static Bucket GetTargetBucketUnsolved()
        {
            return Factory.CreateBucket(8);
        }

        internal static LakePuzzleManager GetPuzzleSolver()
        {
            return Factory.CreateLakePuzzleManager();
        }

        internal static Bucket GetEvenCapacitySourceBucket()
        {
            return Factory.CreateBucket(4);
        }

        internal static Bucket GetEvenCapacityTargetBucket()
        {
            return Factory.CreateBucket(6);
        }
    }
}
