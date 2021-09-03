using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeTask.Lib
{
    public class CsvReader
    {
        public IEnumerable<string> GetPropValues(string input)
        {
            if (!input.Contains('"'))
            {
                return input.Split(',');
            }
            else return GetPropValuesQuoted(input);
        }

        public IEnumerable<string> GetPropValuesQuoted(string input)
        {
            var headerLength = 8;
            var propsProcessed = 0;
            var curIdx = 0;
            while(propsProcessed < headerLength)
            {
                if (input[curIdx] == '"')
                {
                    var propVal = GetPropValueQuoted(input.Substring(curIdx));
                    curIdx += propVal.Length;
                    yield return propVal;
                }

                var propValue = GetPropValue(input.Substring(curIdx));

                curIdx += propValue.Length;
                    
                var isLastProp = curIdx == input.Length;
                if (isLastProp)
                {
                    yield break;
                }

                yield return propValue;

                curIdx++;
            }
        }

        private string GetPropValue(string input)
        {
            var commaIdx = input.IndexOf(',');
            var endsWithComma = commaIdx >= 0;

            return endsWithComma
                ? input.Substring(0, commaIdx)
                : input;
        }

        private string GetPropValueQuoted(string input)
        {
            var currIdx = 1;

            while (true)
            {
                currIdx = input.IndexOf('"', currIdx);

                var isNotQuoteBefore = input[currIdx - 1] != '"';
                var hasNextSymbol = currIdx + 1 != input.Length;
                var isNotQuoteAfter = !hasNextSymbol || input[currIdx + 1] != '"';

                if(isNotQuoteBefore && isNotQuoteAfter)
                {
                    break;
                }
            }

            return input.Substring(currIdx);
        }
    }
}
