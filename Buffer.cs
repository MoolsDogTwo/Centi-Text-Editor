using System.IO;
using System.Runtime.InteropServices.JavaScript;

namespace Centi_Text_Editor;

public class Buffer
{
    private string _filePath = Environment.CurrentDirectory;
    public string FilePath => _filePath;
    private List<string> _rows = [""];
    public int Length => _rows.Count;
    
    public Buffer()
    {
    }

    public Buffer(string filePath)
    {
        LoadFile(filePath);
    }
    
    /* Attribute retrieve functions */
    public bool Empty => _rows is [""];
    public string GetRow(int index) => _rows[index];
    public int LineLength(int index) => _rows[index].Length;
    public List<string> Rows() => _rows;

    /* File operations */
    /// <summary>
    /// Loads a file from disk
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="clear">Don't read the file's contents to memory</param>
    public void LoadFile(string path)
    {
        // Clear any previous data if any
        if (_rows.Count > 0)
        {
            _rows.Clear();
            _rows = [];
        }
        
        if (File.Exists(path))
        {
            
            int lineCount = 0;
            foreach (string line in File.ReadAllLines(path))
            {
                _rows.Add(line);
                ++lineCount;
            }
            // Remove placeholder line if not an empty file
            if (lineCount == 0)
                _rows.Add("");
        }
        
        _filePath = path;
    }

    public void SaveToFile(string filePath = "")
    {
        filePath = filePath == "" ? _filePath : filePath;
            
        StreamWriter save = new(filePath);
        for (int i = 0; i < _rows.Count; ++i)
        {
            string line = _rows[i] + (i < _rows.Count - 1 ? '\n' : null);
            save.Write(line);
        }
        save.Close();
    }
    
    /* Line operations */
    public void Insert(string contents)
    {
        Console.WriteLine(_filePath);
        _rows[Document.RowY] = _rows[Document.RowY].Insert(Document.RowX, contents);
        Document.RowX += contents.Length;
    }

    public void InsertLine(string contents = "")
    {
        _rows.Insert(Document.RowY  + 1, contents);
        ++Document.RowY;
        Document.RowX = 0;
    }
    
//     public void Append(Cursor cursor)
//     {
//         _buffer.Insert(cursor.Y + 1, new Line(GetLine(cursor.Y)[cursor.X..]));
//         _buffer[cursor.Y].Contents = GetLine(cursor.Y)[..cursor.X];
//         cursor.Down();
//         
//         BufferState = BufferState.Modified;
//     }
//     
//     public void InsertLine(string str, Cursor cursor)
//     {
//         Append(cursor);
//         _buffer[cursor.Y].Contents = str;
//         cursor.End();
//
//         BufferState = BufferState.Modified;
//     }
//     
//     /* Editing: Deletion operations */
//     
//     public void Delete(Cursor cursor)
//     {
//         if (GetLine(cursor.Y).Length > 0 && cursor.X > 0)
//         {
//             DeleteChar(cursor);
//         }
//         else if (cursor is { Y: > 0, X: 0 } && GetLine(cursor.Y).Length > 0)
//         {
//             JoinLine(cursor);
//         }
//         else if (cursor.Y > 0 && GetLine(cursor.Y).Length == 0)
//             DeleteLine(cursor);
//         
//         // We don't need to set the buffer's current state here!
//     }
//
//     private void DeleteChar(Cursor cursor)
//     {
//         _buffer[cursor.Y].Contents = GetLine(cursor.Y).Remove(cursor.X - 1, 1);
//         cursor.Left();
//         
//         BufferState = BufferState.Modified;
//     }
//
//     private void JoinLine(Cursor cursor)
//     {
//         int lineJoinPos = GetLine(cursor.Y).Length;
//         string line = GetLine(cursor.Y - 1);
//         _buffer[cursor.Y - 1].Contents = line + GetLine(cursor.Y);
//         DeleteLine(cursor);
//         cursor.X -= lineJoinPos;
//
//         BufferState = BufferState.Modified;
//     }
//
//     public void DeleteLine(Cursor cursor)
//     {
//         if (_buffer.Count > 1 && cursor.Y > 0)
//         {
//             _buffer.RemoveAt(cursor.Y);
//                 
//             cursor.Up();
//             cursor.End();
//         }
//         else
//         {
//             _buffer[cursor.Y].Contents = "";
//             cursor.Home();
//         }
//         
//         BufferState = BufferState.Modified;
//     }
// }
//
// /* TODO: Rewrite ts in screen.cs and maybe move a bunch of other stuff there too.
// This file should only be dedicated to just the file buffer */
// public static class ScrBuf
// {
//     private static readonly StringBuilder Buffer = new();
//
//     public static void Append(string str)
//     {
//         Buffer.Append(str);
//     }
//     
//     public static void Append(char c)
//     {
//         Buffer.Append(c);
//     }
//
//     public static void EmptyAppend()
//     {
//         Buffer.Append('\n');
//     }
//
//     public static void Flush()
//     {
//         Console.Write(Buffer.ToString());
//         Buffer.Clear();
//     }
}