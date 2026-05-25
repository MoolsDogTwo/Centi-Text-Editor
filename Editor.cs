namespace Centi_Text_Editor;


public class Editor
{
    public const string VersionNumber = "1.1";
    public readonly Document Doc = new();

    public void Run()
    {
        Doc.Buffer.LoadFile("helloworld.c");
    }
}