using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    internal class Day7
    {
        public static void Solve(List<string> input)
        {
            var directory = ParseToDirectory(input);
            int sum = 0;
            int totalSize = directory.First().CalcSize();

            foreach (var dir in directory)
            {
                int size = dir.CalcSize();
                if (size <= 100000)
                {
                    sum += size;
                }
            }
            Console.WriteLine($"Solution one {sum}");
            int totalCapacity = 70000000;
            int spaceRemaining = totalCapacity - totalSize;
            int spaceRequired = 30000000 - spaceRemaining;
            Console.WriteLine($"Solution two {directory.Where(x => x.CalcSize() >= spaceRequired).Select(x => x.CalcSize()).ToList().Min()}");
        }



        private static List<Directory> ParseToDirectory(List<string> input)
        {
            var root = new Directory("root", null);
            var currentDir = root;
            var directories = new List<Directory> { root };
            int rowsToSkip = 0;
            for (var i = 0; i < input.Count; i++)
            {
                var row = input[i].Split(' ');
                switch (row[1])
                {
                    case "cd":
                        if (row[2] == "/")
                        {
                            currentDir = root;
                            break;
                        }
                        if (row[2] == "..")
                        {
                            if (currentDir?.Parent is null)
                                currentDir = currentDir;
                            else
                                currentDir = currentDir.Parent;
                            break;
                        }
                        currentDir = currentDir.Child.FirstOrDefault(d => d.Name == row[2]);
                        break;
                    case "ls":

                        input.Skip(i + 1).TakeWhile(s => !s.StartsWith("$")).ToList().ForEach(r =>
                        {
                            var split = r.Split(" ");
                            if (split[0] == "dir")
                            {
                                var dirName = split[1];
                                var parent = currentDir;
                                var directory = new Directory(dirName, parent);
                                currentDir.Child.Add(directory);
                                directories.Add(directory);
                            }
                            else
                            {
                                var fileSize = int.Parse(split[0]);
                                currentDir.Files.Add(new File(fileSize));
                            }
                            rowsToSkip++;

                        });

                        i += rowsToSkip;
                        rowsToSkip = 0;
                        break;
                }
            }

            return directories;
        }

        private class Directory
        {
            public Directory(string name, Directory? parent)
            {
                Name = name;
                Parent = parent;
            }

            public string Name { get; set; }
            public Directory? Parent { get; set; }
            public List<Directory> Child { get; set; } = new List<Directory>();
            public List<File> Files { get; set; } = new List<File>();


            public int CalcSize()
            {
                int size = 0;
                foreach (var file in this.Files)
                {
                    size += file.Size;
                }

                foreach (var child in this.Child)
                {
                    size += child.CalcSize();
                }

                return size;
            }
        }
        private class File
        {
            public File(int size)
            {
                Size = size;
            }
            public int Size { get; set; }
        }
    }


}