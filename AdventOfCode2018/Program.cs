namespace AdventOfCode2018
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Day1();
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

    }
}