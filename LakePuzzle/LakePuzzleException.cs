using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LakePuzzle.Business
{
    public class LakePuzzleException : Exception
    {
        public LakePuzzleException() : base() { }
        public LakePuzzleException(string message) : base(message) { }
    }
}
