using SkyLabs.Model;
using System;
using System.Collections.Generic;
using System.IO;
namespace SkyLabs.Views
{
    public class TestsAvailable
    {
        public List<Test> populateList()
        {
            List<Test> test = new List<Test>();
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string relativePath = @"PopulateTests\TestData.txt";
            string fullPath = Path.Combine(projectDirectory, relativePath);
            string[] tests = File.ReadAllLines(fullPath);
            foreach (string testLine in tests)
            {
                var values = testLine.Split(',');
                var testss = new Test(
                   Int32.Parse(values[0].TrimEnd()),
                    values[1].TrimEnd(),
                    values[2].TrimEnd(),
                    bool.Parse(values[3].TrimEnd())
                    );
                test.Add(testss);
            }
            return test;    
        }
    }
}
