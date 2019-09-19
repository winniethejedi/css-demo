using System;

namespace academy_development_challenge
{
    class Program
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Hello World!");

                //Test arrays
                string[] nullTest = null;
                string[] oneStringTest = new string[] { "[1]" };
                string[] threeStringTest = new string[] { "[1]", "[2]", "[3]" };
                string[] nullStringsTest = new string[] { null, null };
                string[] noNumbersTest = new string[] { "[a, b, c]", "[d, e, f]" };
                string[] mixedNumbersLettersTest = new string[] { "[1, b, 3]", "[d, 5, f]" };
                string[] oneEmptyStringTest = new string[] { "", "[1, 2, 3,]" };
                string[] sampleTest1 = new string[] { "[1, 2, 5, 6]", "[5, 2, 8, 11]" };
                string[] sampleTest2 = new string[] { "[5, 2, 3]", "[2, 2, 3, 10, 6]" };
                string[] sampleTest3 = new string[] { "[1, 2, 1]", "[2, 1, 5, 2]" };

                //Tests
                var program = new Program();
                Console.WriteLine(program.TryArrayMatching(nullTest));
                Console.WriteLine(program.TryArrayMatching(oneStringTest));
                Console.WriteLine(program.TryArrayMatching(threeStringTest));
                Console.WriteLine(program.TryArrayMatching(nullStringsTest));
                Console.WriteLine(program.TryArrayMatching(noNumbersTest));
                Console.WriteLine(program.TryArrayMatching(mixedNumbersLettersTest));
                Console.WriteLine(program.TryArrayMatching(oneEmptyStringTest));
                Console.WriteLine(program.TryArrayMatching(sampleTest1));
                Console.WriteLine(program.TryArrayMatching(sampleTest2));
                Console.WriteLine(program.TryArrayMatching(sampleTest3));

                Console.WriteLine("Good-bye World!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public string TryArrayMatching(string[] strArr)
        {
            string result = "";

            try
            {
                result = ArrayMatching(strArr);
            }
            catch (ArgumentException ex)
            {
                result = ex.Message;
            }
            catch
            {
                throw;
            }

            return result;
        }

        public string ArrayMatching(string[] strArr)
        {
            if (strArr == null) throw new ArgumentException("strArr must not be null.");
            if (strArr.Length < 2 || strArr.Length > 2) throw new ArgumentException("strArr must have two elements.");
            if (strArr[0] == null || strArr[1] == null) throw new ArgumentException("Strings in strArr must not be null.");

            List<int> intList1 = CreateIntList(strArr[0]);
            List<int> intList2 = CreateIntList(strArr[1]);
            int maxCount = GetMaxCount(intList1, intList2);
            List<int> finalIntList = new List<int>();

            for (int i = 0; i < maxCount - 1; i++)
            {
                int int1 = GetInt(intList1, i);
                int int2 = GetInt(intList2, i);
                int finalInt = int1 + int2;
                finalIntList.Add(finalInt);
            }

            string result = FormatFinalIntList(finalIntList);
            return result;
        }

        public string FormatFinalIntList(List<int> finalIntList)
        {
            var resultStringBuilder = new StringBuilder();

            for (int i = 0; i < finalIntList.Count - 1; i++)
            {
                if (i == 0)
                {
                    resultStringBuilder.Append(finalIntList[i]);
                }
                else
                {
                    resultStringBuilder.Append("-" + finalIntList[i]);
                }
            }

            return resultStringBuilder.ToString();
        }

        public int GetInt(List<int> intList, int i)
        {
            int number = intList.Count > i ? intList[i] : 0;
            return number;
        }

        public int GetMaxCount(List<int> intList1, List<int> intList2)
        {
            return Math.Max(intList1.Count, intList2.Count);
        }

        public List<int> CreateIntList(string str)
        {
            string cleanStr = CleanString(str);
            var stringArr = str.Split(',');
            var intList = new List<int>();

            foreach (string intStr in stringArr)
            {
                int number = int.Parse(intStr);
                intList.Add(number);
            }

            return intList;
        }

        public string CleanString(string str)
        {
            str = Regex.Replace(str, @"[^0-9,]/g", "");
            return str;
        }
    }
}
