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
        [ExpectedException(typeof(LakePuzzleException))]
        public void ShouldThrowExceptionWhenCallingSolveWithSameSizeBuckets()
        {
            //Arrange
            var sourceBucket = Mother.GetTargetBucket();
            var targetBucket = Mother.GetTargetBucket();
            uint goal = 4;

            // Act
            var actual = sut.Solve(sourceBucket, targetBucket, goal);

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

        [TestMethod(),Ignore]
        public void Harness()
        {
            for (uint i = 1; i < 100; i++)
            {
                for (uint j = i + 1; j < 100; j++)
                {
                    for (uint goal = 1; goal < j; goal++)
                    {
                        var actual = sut.Solve(Factory.CreateBucket(i), Factory.CreateBucket(j), goal);
                        if (actual.Length > 0)
                        {
                            Debug.WriteLine(string.Format("Source {0}\t\ttarget {1}\t\tgoal {2}", i, j,goal));
                          //  actual.printLog();
                        }
                    }
                }
            }
            ////Arrange
            //var sourceBucket = Factory.CreateBucket(95);
            //var targetBucket = Factory.CreateBucket(57);
            //uint goal = 37;
            //var expectedLength = 2;

            //// Act
            //var actual = sut.Solve(sourceBucket, targetBucket, goal);

            ////Assert
            //Assert.AreEqual(expectedLength, actual.Length);
        }
    }
}
