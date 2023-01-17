using System.Collections.Generic;
class Program
{
    public static void Main()
    {
        Console.Write("Für welche Liste möchtest du das Program ausführen?: ");
        string input = Console.ReadLine()!;
        string path = "\\Data\\Liste" + input + ".txt";
        Dictionary<string, bool> containers = new Dictionary<string, bool>();
        string[] content = File.ReadAllLines(Directory.GetCurrentDirectory() + path);
        for (int i = 0; i < content.Length; i++)
        {
            string[] arg = content[i].Split(' ');
            if (!containers.ContainsKey(arg[0]))
            {
                containers.Add(arg[0], false);
            }
            containers[arg[1]] = true;
        }
        int zeros = 0;
        string heaviest = "";
        foreach (string container in containers.Keys)
        {
            if (!containers[container])
            {
                heaviest = container;
                zeros++;
                if (zeros > 1)
                {
                    Console.WriteLine("Es konnte keine Lösung gefunden werden");
                    break;
                }
            }
        }
        if (zeros == 0)
        {
            Console.WriteLine("Es lässt sich keine Aussage über den größten Container treffen");
        }
        else if (zeros == 1)
        {
            Console.WriteLine("Der schwerste Container ist: " + heaviest);
        }
    }
}