namespace adventOfCode2022;

public class Day7 : Day
{
    private class FolderItem
    {
        public string Name;

        public FolderItem(string name)
        {
            Name = name;
        }
    }

    private class Folder : FolderItem
    {
        public List<FolderItem> Items;
        public Folder? ParentFolder;

        public Folder(string name, List<FolderItem>? items = null, Folder? parentFolder = null) : base(name)
        {
            Items = items ?? new List<FolderItem>();
            ParentFolder = parentFolder;
        }

        public static bool IsFolderStart(string row)
        {
            return row.StartsWith("dir ");
        } 
    }

    private class File : FolderItem
    {
        private int Size;

        public File(string name, int size) : base(name)
        {
            Size = size;
        }
    }


    private class Command
    {
        private string Action;
        private string Parameter;

        public Command(string action, string parameter)
        {
            Action = action;
            Parameter = parameter;
        }
    }
    
    private class ChangeDirectoryCommand : Command
    {
        public static bool Is(string row)
        {
            return row.StartsWith("$ cd");
        }

        public ChangeDirectoryCommand(string action, string parameter) : base(action, parameter)
        {
        }
    }
    
    private class ListDirectoryCommand : Command
    {
        public static bool Is(string row)
        {
            return row.StartsWith("$ ls");
        }

        public ListDirectoryCommand(string action, string parameter) : base(action, parameter)
        {
        }
    }

    private Folder BuildFilesystem(IEnumerable<string> puzzleInput)
    {
        var rootFolder = new Folder("/");
        var currentFolder = rootFolder;
        
        foreach (var row in puzzleInput.Skip(2))
        {
            var parts = row.Split(" ");
            if (parts[0] == "$")
            {
                if (ChangeDirectoryCommand.Is(row))
                {
                    // TODO change currentFolder
                }
                else if (ListDirectoryCommand.Is(row))
                {
                    // TODO start checking folder items
                }
                else if (Folder.IsFolderStart(row))
                {
                    var folderItem = new Folder(parts[1]);
                    currentFolder.Items.Append(folderItem);
                }
            }
          
        }

        return rootFolder;
    }

    public override object Part1(string[] puzzleInput)
    {
        var folder = BuildFilesystem(puzzleInput);
        throw new NotImplementedException();
    }

    public override object Part2(string[] puzzleInput)
    {
        throw new NotImplementedException();
    }
}