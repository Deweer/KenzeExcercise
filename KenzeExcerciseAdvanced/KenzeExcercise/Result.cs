using System;
using System.Collections.Generic;

namespace KenzeExcercise
{
    public class Result
    {
        public List<string> Components { get; }

        public string StitchedResult { get; }

        public Result(List<string> components, string result)
        {
            this.Components = components;
            this.StitchedResult = result;
        }

        public override string ToString()
        {
            var result = String.Join("+", Components);
            return $"{result}={StitchedResult}";
        }
    }
}
