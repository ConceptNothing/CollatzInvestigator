using SequenceCalculator.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceCalculator.Infrastructure
{
    public class CollatzCalculator : ICollatzInvestigator
    {
        private int oddCount;
        private int evenCount;
        private string maxMember;
        private static readonly MyBigInt ONE = new MyBigInt("1");
        private static readonly MyBigInt THREE = new MyBigInt("3");
        public string ShowResult(string number)
        {
            try
            {
                if (!string.IsNullOrEmpty(number))
                {
                    return BuildResultString(number);
                }
                else
                {
                    // Handle empty or null input
                    throw new ArgumentException("Input string is null or empty.");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception and return an error message
                string errorMessage = $"Error occurred while processing input: {ex.Message}";
                return errorMessage;
            }
        }
        private string BuildResultString(string number)
        {
            oddCount = 0;
            evenCount = 0;
            var sb = new StringBuilder();
            CalculateSequence(number);
            sb.AppendLine($"Number of 3k+1 operations: {oddCount}");
            sb.AppendLine($"Number of 2k operations: {evenCount}");
            sb.AppendLine($"Maximum member: {maxMember}");

            return sb.ToString();
        }
        private void CalculateSequence(string input)
        {
            var number = new MyBigInt(input);
            var max=new MyBigInt("0");
            while (number.ToString() != "1")
            {
                if (number.IsLastDigitEven())
                {
                    number = number.DivideByTwo();
                    evenCount++;
                    if (number > max)
                    {
                        max = number;
                    }
                }
                else
                {
                    number = MultiplyByThreePlusOne(number, THREE, ONE);
                    oddCount++;
                    if (number > max)
                    {
                        max = number;
                    }
                }
            }
            maxMember = max.ToString();
        }
        private MyBigInt MultiplyByThreePlusOne(MyBigInt n,MyBigInt multiplier,MyBigInt bigIntOne)
        {
            return MyBigInt.Product(n,multiplier) + bigIntOne;
        }

        public string CalculateMultiplyByThreePlusOne(string number)
        {
            MyBigInt bigNum=new MyBigInt(number);
            MyBigInt result = MultiplyByThreePlusOne(bigNum,THREE,ONE);
            return result.ToString();
        }
        public string DivideByTwo(string number)
        {
            MyBigInt bigNum = new MyBigInt(number);
            MyBigInt result = bigNum.DivideByTwo();
            return result.ToString();
        }
    }
}
