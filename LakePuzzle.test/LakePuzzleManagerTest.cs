using LakePuzzle.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace LakePuzzle.Business.test
{

    /// <summary>
    ///This is a test class for LakePuzzleManagerTest and is intended
    ///to contain all LakePuzzleManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LakePuzzleManagerTest
    {
        private LakePuzzleManager sut = Mother.GetPuzzleSolver();

        [TestMethod()]
        public void ShouldReturnShortestSolutionWhenCallingGetShortestSolution()
        {
            //Arrange
            var sourceBucket = Mother.GetSourceBucket();
            var targetBucket = Mother.GetTargetBucket();
            uint goal = 4;
            var expectedLength = 7;

            // Act
            var actualResult = sut.GetShortestSolution(sourceBucket, targetBucket, goal);

            //Assert
            Assert.AreEqual(expectedLength, actualResult.Length);
        }

        [TestMethod()]
        public void ShouldSolvePuzzleWhenCallingSolve()
        {
            //Arrange
            var sourceBucket = Mother.GetSourceBucket();
            var targetBucket = Mother.GetTargetBucket();
            uint goal = 4;
            var expectedLength = 9;

            // Act
            var actual = sut.Solve(sourceBucket, targetBucket, goal);

            //Assert
            Assert.AreEqual(expectedLength, actual.Length);
        }

        [TestMethod()]
        public void ShouldSolvePuzzleReverseWhenCallingSolve()
        {
            //Arrange
            var sourceBucket = Mother.GetSourceBucket();
            var targetBucket = Mother.GetTargetBucket();
            uint goal = 4;
            var expectedLength = 7;

            // Act
            var actual = sut.Solve(targetBucket, sourceBucket, goal);

            //Assert
            Assert.AreEqual(expectedLength, actual.Length);
        }

        [TestMethod()]
        [ExpectedException(typeof(LakePuzzleException))]
        public void ShouldThrowExceptionWhenCallingSolveWithGoalGreaterThanLargestBucket()
        {
            //Arrange
            var sourceBucket = Mother.GetSourceBucket();
            var targetBucket = Mother.GetTargetBucket();
            uint goal = 10;
            var expectedLength = 9;

            // Act
            var actual = sut.Solve(sourceBucket, targetBucket, goal);

            //Assert
            Assert.AreEqual(expectedLength, actual.Length);
        }

        [TestMethod()]
        public void ShouldReturnNoResultWhenCallingSolveWithEvenBucketSizesAndOddGoal()
        {
            //Arrange
            var sourceBucket = Mother.GetEvenCapacitySourceBucket();
            var targetBucket = Mother.GetEvenCapacityTargetBucket();
            uint goal = 5;

            // Act
            var actual = sut.Solve(sourceBucket, targetBucket, goal);
            Assert.AreEqual(actual.Length, 0);

        }

        [TestMethod()]
        public void ShouldReturnNoResult()
        {
            //Arrange
            var sourceBucket = Mother.GetSourceBucketNotSolved();
            var targetBucket = Mother.GetTargetBucketUnsolved();
            uint goal = 3;
            var expectedLength = 0;

            // Act
            var actual = sut.Solve(sourceBucket, targetBucket, goal);

            //Assert
            Assert.AreEqual(expectedLength, actual.Length);
        }
        [TestMethod()]

        public void ShouldReturnNoResultWhenCallingSolveWithSameSizeBuckets()
        {

            //Arrange

            var sourceBucket = Mother.GetTargetBucket();
            var targetBucket = Mother.GetTargetBucket();
            uint goal = 4;


            // Act

            var actual = sut.Solve(sourceBucket, targetBucket, goal);

            Assert.AreEqual(actual.Length, 0);

        }


        [TestMethod(), Ignore]
        public void Harness()
        {
            var resultCounter = 0;
            for (uint i = 1; i < 100; i++)
            {
                for (uint j = i + 1; j < 100; j++)
                {
                    for (uint goal = 1; goal < j; goal++)
                    {
                        var actual = sut.Solve(Factory.CreateBucket(i), Factory.CreateBucket(j), goal);
                        if (actual.Length > 0)
                        {
                            var sourceEven = i % 2 == 0;
                            var targetEven = j % 2 == 0;
                            var goalEven = goal % 2 == 0;

                            if (sourceEven && targetEven && !goalEven)
                                //Debug.WriteLine(string.Format("Source {0}\t\ttarget {1}\t\tgoal {2}", i, j, goal));
                                resultCounter++;
                        }
                    }
                }
            }
            Debug.WriteLine(string.Format("finished, resultCounter:{0}", resultCounter));
        }
    }
}
