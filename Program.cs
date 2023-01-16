class Program
{
    public static void Main()
    {
        Console.Write("Für welche Liste möchtest du das Program ausführen?: ");
        string input = Console.ReadLine()!;
        string path = "\\Data\\Liste" + input + ".txt";
        List<string> containers = new List<string>();
        List<int> times = new List<int>();
        string[] content = File.ReadAllLines(Directory.GetCurrentDirectory() + path);
        for (int i = 0; i < content.Length; i++)
        {
            string[] arg = content[i].Split(' ');
            if (!containers.Contains(arg[0]))
            {
                containers.Add(arg[0]);
                times.Add(0);
            }
            if (!containers.Contains(arg[1]))
            {
                containers.Add(arg[1]);
                times.Add(1);
            }
            else
            {
                int index = containers.IndexOf(arg[1]);
                times[index] += 1;
            }
        }
        for (int i = 0; i < containers.Count; i++)
        {
            Console.WriteLine("Container: " + containers[i] + "; auf der rechten Seite: " + times[i]);
        }
        int zeros = 0;
        for (int i = 0; i < containers.Count; i++)
        {
            if (times[i] == 0)
            {
                zeros++;
            }
        }
        if (zeros == 0)
        {
            Console.WriteLine("Es lässt sich keine Aussage über den größten Container treffen");
        }
        else if (zeros == 1)
        {
            int index = times.IndexOf(0);
            Console.WriteLine("Der Container mit der Nummer: " + containers[index] + " ist der größte");
        }
        else
        {
            Console.WriteLine("Es lässt sich keine Aussage über den größten Container treffen");
        }
    }
}