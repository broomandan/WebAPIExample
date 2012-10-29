using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using LakePuzzle.Business;

namespace LakePuzzle.API.Controllers
{
    [UnhandledExceptionFilter]
    public class LakePuzzleResultController : ApiController
    {

        // GET api/lakepuzzleresult/3/5/4
        public IEnumerable<PuzzleSolutionStepFlat> GetLakePuzzleResult(uint sourceBucket, uint targetBucket, uint goal)
        {
            var puzzleManager = Factory.CreateLakePuzzleManager();

            var pussleResult = puzzleManager.GetShortestSolution(Factory.CreateBucket(sourceBucket), Factory.CreateBucket(targetBucket), goal);
            return pussleResult.GetResultSteps();

        }
    }
}