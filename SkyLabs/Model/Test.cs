using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLabs.Model
{
    public class Test
    {
        public Test(int testId, string mnemonic, string description, bool isActive)
        {
            TestId = testId;
            Mnemonic = mnemonic;
            Description = description;
            this.isActive = isActive;
        }

        public int TestId { get; set; }
        public string Mnemonic { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; }
    }
}
