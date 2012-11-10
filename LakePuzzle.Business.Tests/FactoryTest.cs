using LakePuzzle.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LakePuzzle.Business.test
{


    /// <summary>
    ///This is a test class for FactoryTest and is intended
    ///to contain all FactoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FactoryTest
    {

        ///A test for CreateBucket
        ///</summary>
        [TestMethod()]
        public void ShouldReturnAnInstanceOfBucketWhenCallingCreateBucket()
        {
            uint bucketCapacity = 3;

            var actual = Factory.CreateBucket(bucketCapacity);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual is Bucket);
        }
        ///A test for CreateBucket
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(LakePuzzleException))]
        public void ShouldThrowExceptionWhenCallingCreateBucketWithCapacityGreaterThan100()
        {
            uint bucketCapacity = 101;

            var actual = Factory.CreateBucket(bucketCapacity);
            //Assert.IsNotNull(actual);
            //Assert.IsTrue(actual is Bucket);
        }

        /// <summary>
        ///A test for CreateLakePuzzleManager
        ///</summary>
        [TestMethod()]
        public void ShouldReturnAnInstanceOfLakePuzzleManagerWhenCallingCreateLakePuzzleManager()
        {
            var actual = Factory.CreateLakePuzzleManager();

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual is LakePuzzleManager);
        }

        /// <summary>
        ///A test for CreatePuzzleResult
        ///</summary>
        [TestMethod()]
        public void ShouldReturnAnInstanceOfPuzzleResultWhenCallingCreatePuzzleResult()
        {

            var actual = Factory.CreatePuzzleResult();
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual is PuzzleResult);

        }

        /// <summary>
        ///A test for CreatePuzzleSolutionStep
        ///</summary>
        [TestMethod()]
        public void ShouldReturnAnInstanceOfPuzzleSolutionStepWhenCallingCreatePuzzleSolutionStep()
        {
            string sourceOperation = "sourceOp";
            uint sourceState = 0;
            string targetOperation = "targetOp";
            uint targetState = 0;
            var actual = Factory.CreatePuzzleSolutionStep(sourceOperation, sourceState, targetOperation, targetState);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual is PuzzleSolutionStep);
            Assert.AreEqual(sourceOperation, actual.SourceBucketStep.Operation);
            Assert.AreEqual(targetOperation, actual.TargetBucketStep.Operation);
        }
    }
}
