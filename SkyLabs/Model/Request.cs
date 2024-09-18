using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLabs.Model
{
    public class Request
    {
        public Request(int testId, string result, string comment)
        {
            TestId = testId;
            Result = result;
            Comment = comment;
        }

        public int TestId { get; set; }
        public string Result { get; set; }
        public string Comment { get; set; }
    }
}
