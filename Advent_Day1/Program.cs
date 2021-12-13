// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

try
{
    Console.WriteLine("Input from file");
    int counter = 0;
    int lineNumber = 0;
    int previousLine = 0;
    var parsedList = new List<int>();
    var lineArray = System.IO.File.ReadAllLines("Input.txt");
    var intArray = new List<int>();
    foreach (var line in lineArray)
    {
        var currentLine = int.Parse(line);
        intArray.Add(currentLine);
        if(lineNumber == 0)
        {
            Console.WriteLine($"{currentLine} (N/A - no previous measurement");
            previousLine = currentLine;
            lineNumber++;
        }
        else
        {
            if(currentLine > previousLine)
            {
                Console.WriteLine($"{currentLine} increased");
                counter++;
            }
            else if (currentLine == previousLine)
            {
                Console.WriteLine($"{currentLine} unchanged");
            }
            else
            {
                Console.WriteLine($"{currentLine} decreased");
            }
            previousLine = currentLine;
            lineNumber++;
        }
    }
    Console.WriteLine($"====== {counter} ======");
    Console.WriteLine($"Count total = {intArray.Count}");
    Console.ReadKey();



    // Windowed implementation
    intArray.ToArray<int>();
    var whatAboutSecondCounter = 0;
    for(int i=0; i<=intArray.Count-3; i++)
    {
        // Stop when no room for three measurement sum!
        var currentLine = intArray[i]+intArray[i+1]+intArray[i+2];
        if(i == 0)
        {
            previousLine = currentLine;
            Console.WriteLine($"{currentLine} (N/A - no previous measurement");
        }
        else
        {
            if(currentLine > previousLine)
            {
                Console.WriteLine($"{currentLine} increased");
                whatAboutSecondCounter++;
            }
            else if (currentLine == previousLine)
            {
                Console.WriteLine($"{currentLine} unchanged");
            }
            else
            {
                Console.WriteLine($"{currentLine} decreased");
            }
            previousLine = currentLine;
        }
    }

    Console.WriteLine($"====== {whatAboutSecondCounter} ======");
}
catch (IOException e)
{
    Console.WriteLine("The file could not be processed:");
    Console.WriteLine(e.Message);
}