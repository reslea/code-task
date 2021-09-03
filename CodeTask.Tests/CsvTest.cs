using CodeTask.Lib;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTask.Tests
{
    public class CsvTest
    {
        const string simpleData = "101,b603c59e-34a1-4754-aef8-baeed09466c4,Melanie,Yate,Melanie.Yate@yopmail.com,doctor,BJ,\"YHAoOEc\"\"YQIFIcOeNoqTqynlmEOgQXpLiiDW aZnj\"";
        const string dataWithComma = "107,f3328b96-a0ea-4231-ac22-4a5b3b99a0f0,Fanny,Burch,Fanny.Burch@yopmail.com,worker,BJ,\"YwrqUZTxatTcErR ZA\"\"XkIYT ,lKJchmxn s\"";


        [Theory]
        [InlineData(simpleData, new string[] { 
            "101",
            "b603c59e-34a1-4754-aef8-baeed09466c4",
            "Melanie",
            "Yate",
            "Melanie.Yate@yopmail.com",
            "doctor",
            "BJ",
            "\"YHAoOEc\"\"YQIFIcOeNoqTqynlmEOgQXpLiiDW aZnj\""
        })]
        [InlineData(dataWithComma, new string[] {
            "107",
            "f3328b96-a0ea-4231-ac22-4a5b3b99a0f0",
            "Fanny",
            "Burch",
            "Fanny.Burch@yopmail.com",
            "worker",
            "BJ",
            "\"YwrqUZTxatTcErR ZA\"\"XkIYT ,lKJchmxn s\""
        })]
        public void EnsureData(string input, string[] output)
        {
            var reader = new CsvReader();
            Assert.Equal(output, reader.GetPropValuesQuoted(input));
        }
    }
}
