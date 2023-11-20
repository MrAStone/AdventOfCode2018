using System.Collections.Concurrent;
using System.ComponentModel;

namespace AdventOfCode2018
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Day3();
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
        static void Day3()
        {
           StreamReader sr = new StreamReader("day3input.txt");
           
           // StreamReader sr = new StreamReader("test.txt");
            Dictionary<(int x, int y), int> grid = new Dictionary<(int x, int y), int>();

            Dictionary<(int x, int y), List<int>> claims = new Dictionary<(int x, int y), List<int>>();
            List<int> ClaimNumbers = new List<int>();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                line = line.Replace(":", "");
                line = line.Replace("#", "");
                string[] lSplit = line.Split(' ');
                int claim = Convert.ToInt32(lSplit[0]);
                ClaimNumbers.Add(claim);
                string[] coords = lSplit[2].Split(",");
                int x = int.Parse(coords[0]);
                int y = int.Parse(coords[1]);
                var cord = (x, y);
                string[] size = lSplit[3].Split("x");
               
                int w = int.Parse(size[0]);
                int h = int.Parse(size[1]);

                for(int i = x;i< x + w; i++){
                    for (int j = y;j< y + h; j++)
                    {
                        
                        //Console.WriteLine($"{i}x{j}");
                        //Console.ReadLine();
                        cord = (i, j);
                        if (claims.ContainsKey(cord))
                        {
                            claims[cord].Add(claim);
                            ClaimNumbers.Remove(claim);
                            for(int c = 0; c < claims[cord].Count; c++)
                            {
                                ClaimNumbers.Remove(claims[cord][c]);
                            }

                        }
                        else
                        {
                            claims.Add(cord, new List<int>());
                            claims[cord].Add(claim);
                        }
                        if (grid.ContainsKey(cord))
                        {
                            grid[cord]++;
                      
                        }
                        else
                        {
                            grid.Add(cord, 1);
                        }
                    }
                }
               

            }
            int overlaps = 0;
     for (int i = 0; i<ClaimNumbers.Count; i++)
            {
                Console.WriteLine(ClaimNumbers[i]);
            }
           
        }


    }
}