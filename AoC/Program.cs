using AoC;
const string path = @"data/Day{0}.txt";
const string start = "----Day-{0}----------------";
const string end = "-------------------------";
static void StartLine(int day) => Console.WriteLine(string.Format(start, day), Console.ForegroundColor = ConsoleColor.DarkGreen);
static void EndLine() => Console.WriteLine(end, Console.ForegroundColor = ConsoleColor.Red);


StartLine(1);
Day1.Solve(File.ReadAllLines(string.Format(path, 1)).ToList());
EndLine();

StartLine(2);
Day2.Solve(File.ReadAllLines(string.Format(path, 2)).ToList());
Day2.Solve2(File.ReadAllLines(string.Format(path, 2)).ToList());
EndLine();

StartLine(3);
Day3.Solve(File.ReadAllLines(string.Format(path, 3)).ToList());
Day3.Solve2(File.ReadAllLines(string.Format(path, 3)).ToList());
EndLine();

StartLine(4);
Day4.Solve(File.ReadAllLines(string.Format(path, 4)).ToList());
EndLine();

StartLine(5);
Day5.Solve(File.ReadAllLines(string.Format(path, 5)).ToList());
EndLine();

Console.WriteLine("Press enter to exit");
Console.ReadLine();
