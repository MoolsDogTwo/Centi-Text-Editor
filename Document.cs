using System.ComponentModel;

namespace Centi_Text_Editor;

public struct Position(int x, int y)
{
    public int X = x;
    public int Y = y;
}

public class Document
{
    private static Position _pos = new(0, 0);
    public static Position GetPos => _pos;
    public readonly Buffer Buffer;

    private enum MovementDirection
    {
        Left,
        Right,
        Up,
        Down
    }
    
    // Shorthands for external usage
    public static int RowX { get => _pos.X; set => _pos.X = value; }
    public static int RowY { get => _pos.Y; set => _pos.Y = value; }

    public Document()
    {
        Buffer = new Buffer();
    }

    // As in the name, used for debug purposes only DO NOT USE IN PRODUCTION!
    public void debug_PrettyPrint()
    {
        for (int i = 0; i < Buffer.Rows().Count; ++i)
        {
            char[] line = Buffer.GetRow(i).Replace('\t', ' ').ToCharArray();
            if (i != RowY)
            {
                Console.WriteLine(line);
                continue;
            }
            for (int j = 0; j < line.Length; ++j)
            {
                if (j == _pos.X)
                    Console.Write($"\x1b[91m{line[j]}\x1b[39m");
                else
                    Console.Write(line[j]);
            }
            Console.WriteLine();
        }
    }

    /* File position handling */
    public static void ResetFilePos()
    {
        _pos.X = 0;
        _pos.Y = 0;
    }

    private void MovePos(int amount, MovementDirection direction)
    {
        while (amount > 0)
        {
            // Wrap around lines automatically
            switch (direction)
            {
                case MovementDirection.Left:
                    throw new NotImplementedException();
                    break;
                case MovementDirection.Right:
                    if (RowX + 1 > Buffer.LineLength(RowY) && RowY < Buffer.Length - 1)
                    {
                        ++RowY;
                        RowX = 0;
                    }
                    if (RowX < Buffer.LineLength(RowY))
                        ++RowX;
                    
                    break;
                case MovementDirection.Up:
                    throw new NotImplementedException();
                    break;
                case MovementDirection.Down:
                    throw new NotImplementedException();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
            --amount;
        }
    }

    public void MoveLeft(int amount = 1)
    {
        MovePos(amount, MovementDirection.Left);
    }
    
    public void MoveRight(int amount = 1)
    {
        MovePos(amount, MovementDirection.Right);
    }
    
    public void MoveUp(int amount = 1)
    {
        MovePos(amount, MovementDirection.Up);
    }
    
    public void MoveDown(int amount = 1)
    {
        MovePos(amount, MovementDirection.Down);
    }
}