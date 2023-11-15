using System.Collections.Concurrent;

namespace AdventOfCode2018
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Day2P2();
        }
        static void Day1()
        {
            StreamReader sr = new StreamReader("day1input.txt");
            List<int> frequencies = new List<int>();
            List<int> lof = new List<int>();
            while (!sr.EndOfStream)
            {
                int n = Convert.ToInt32(sr.ReadLine());
                lof.Add(n);

            }
            sr.Close();
            int frequency = 0;
            frequencies.Add(frequency);
            int index = 0;
            int d1p1 = 0;
            bool foundD1P1 = false;
            do
            {
                frequency += lof[index];
                frequencies.Add(frequency);
                index++;
                if (index == lof.Count)
                {
                    if (!foundD1P1)
                    {
                        d1p1 = frequency;
                        foundD1P1 = true;
                    }

                    index = 0;
                }
            } while (!frequencies.Contains(frequency + lof[index]));
            Console.WriteLine($"Day1 p1 = {d1p1}");
            Console.WriteLine($"Day1 p2 = {frequency + lof[index]}");


        }
        static void Day2()
        {
            StreamReader sr = new StreamReader("day2input.txt");

            int numTwoCount = 0;
            int numThreeCount = 0;
            while (!sr.EndOfStream)
            {
                Dictionary<char, int> letters = new Dictionary<char, int>();

                string line = sr.ReadLine();
                int twocount = 0;
                int threecount = 0;


                for (int i = 0; i < line.Length; i++)
                {
                    if (letters.ContainsKey(line[i]))
                    {
                        letters[line[i]]++;

                    }
                    else
                    {
                        letters.Add(line[i], 1);
                    }
                }
                foreach (KeyValuePair<char, int> pair in letters)

                {
                    if (pair.Value == 2)
                    {
                        twocount = 1;

                    }
                    if (pair.Value == 3)
                    {
                        threecount = 1;

                    }
                }

                numThreeCount += threecount;
                numTwoCount += twocount;
            }
            Console.WriteLine($"{numTwoCount} * {numThreeCount} = {numTwoCount * numThreeCount}");
        }
        static void Day2P2()
        {
            StreamReader sr = new StreamReader("day2input.txt");
            List<string> letters = new List<string>();
            while (!sr.EndOfStream)
            {
                letters.Add(sr.ReadLine());
            }
            sr.Close();

            Console.Write("ANSWER = ");
            for (int first = 0; first < letters.Count; first++)
            {

                string a = letters[first];

                for (int second = first + 1; second < letters.Count; second++)
                {
                    string output = "";
                    string b = letters[second];
                    int diffCount = 0;
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (a[i] != b[i])
                        {
                            diffCount++;

                        }
                        else
                        {
                            output += a[i];
                        }

                    }
                    if (diffCount == 1)
                    {
                        Console.WriteLine(output);
                    }
                }
            }


        }



    }
}