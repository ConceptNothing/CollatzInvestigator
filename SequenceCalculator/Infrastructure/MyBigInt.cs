using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceCalculator.Infrastructure
{
    public class MyBigInt
    {
        public List<int> data;

        public MyBigInt(string s)
        {
            this.data = new List<int>();
            int n = s.Length;
            for (int i = n - 1; i >= 0; --i)
            {
                char c = s[i];
                this.data.Add(int.Parse(c.ToString()));
            }
        }
        public MyBigInt()
        {
            this.data = new List<int>();
        }
        public static MyBigInt Sub(MyBigInt x, MyBigInt y)
        {
            if (x < y)
            {
                throw new ArgumentException("x must be greater than or equal to y");
            }

            MyBigInt result = new MyBigInt();
            int n = x.data.Count;
            int borrow = 0;

            for (int i = 0; i < n; ++i)
            {
                int xx = (i > x.data.Count - 1) ? 0 : x.data[i];
                int yy = (i > y.data.Count - 1) ? 0 : y.data[i];

                int z = xx - yy - borrow;
                if (z < 0)
                {
                    result.data.Add(z + 10);
                    borrow = 1;
                }
                else
                {
                    result.data.Add(z);
                    borrow = 0;
                }
            }

            while (result.data.Count > 1 && result.data[result.data.Count - 1] == 0)
            {
                result.data.RemoveAt(result.data.Count - 1);
            }

            return result;
        }
        public static MyBigInt Sum(MyBigInt x, MyBigInt y)
        {
            int n = x.data.Count;
            if (y.data.Count > n)
            {
                n = y.data.Count;
            }

            MyBigInt result = new MyBigInt();
            int xx = 0;
            int yy = 0;
            int carry = 0;

            for (int i = 0; i < n; ++i)
            {
                xx = (i > x.data.Count - 1) ? 0 : x.data[i];
                yy = (i > y.data.Count - 1) ? 0 : y.data[i];

                int z = xx + yy + carry;
                if (z >= 10)
                {
                    result.data.Add(z - 10);
                    carry = 1;
                }
                else
                {
                    result.data.Add(z);
                    carry = 0;
                }
            }

            if (carry == 1)
            {
                result.data.Add(1);
            }

            return result;
        }
        public static MyBigInt Product(MyBigInt x, MyBigInt y)
        {
            MyBigInt tmp = null;
            MyBigInt result = new MyBigInt("0");

            for (int j = 0; j < y.data.Count; ++j)
            {
                int carry = 0;
                tmp = new MyBigInt();
                for (int i = 0; i < x.data.Count; ++i)
                {
                    int z = x.data[i] * y.data[j] + carry;
                    if (z >= 10)
                    {
                        tmp.data.Add(z % 10);
                        carry = z / 10;
                    }
                    else
                    {
                        tmp.data.Add(z);
                        carry = 0;
                    }
                }

                if (carry > 0)
                {
                    tmp.data.Add(carry);
                }

                for (int k = 0; k < j; ++k)
                {
                    tmp.data.Insert(0, 0);
                }

                result = MyBigInt.Sum(result, tmp);
            }

            return result;
        }
        public MyBigInt DivideByTwo()
        {
            MyBigInt result = new MyBigInt();

            int remainder = 0;
            for (int i = data.Count - 1; i >= 0; i--)
            {
                int dividend = remainder * 10 + data[i];
                int quotient = dividend / 2;
                remainder = dividend % 2;
                result.data.Insert(0, quotient);
            }

            while (result.data.Count > 1 && result.data[result.data.Count - 1] == 0)
            {
                result.data.RemoveAt(result.data.Count - 1);
            }

            return result;
        }
        public bool IsLastDigitEven()
        {
            if (data.Count == 0)
            {
                return false;
            }

            return data[0] % 2 == 0;
        }
        public static MyBigInt operator +(MyBigInt x, MyBigInt y)
        {
            return MyBigInt.Sum(x, y);
        }
        public static bool operator >(MyBigInt x, MyBigInt y)
        {
            if (x.data.Count != y.data.Count)
            {
                return x.data.Count > y.data.Count;
            }

            for (int i = x.data.Count - 1; i >= 0; i--)
            {
                if (x.data[i] != y.data[i])
                {
                    return x.data[i] > y.data[i];
                }
            }

            return false;
        }
        public static bool operator <(MyBigInt x, MyBigInt y)
        {
            if (x.data.Count != y.data.Count)
            {
                return x.data.Count < y.data.Count;
            }

            for (int i = x.data.Count - 1; i >= 0; i--)
            {
                if (x.data[i] != y.data[i])
                {
                    return x.data[i] < y.data[i];
                }
            }

            return false;
        }
        public override string ToString()
        {
            int n = this.data.Count;
            string s = "";

            for (int i = n - 1; i >= 0; --i)
            {
                s += this.data[i].ToString();
            }

            return s;
        }
        public static MyBigInt operator &(MyBigInt x, MyBigInt y)
        {
            int intX = Convert.ToInt32(string.Join("", x.data));
            int intY = Convert.ToInt32(string.Join("", y.data));
            int intResult = intX & intY;
            string strResult = intResult.ToString();
            return new MyBigInt(strResult);
        }
    } 
}
