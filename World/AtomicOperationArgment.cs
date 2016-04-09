using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.TextProcessor;

public class LinkerParam
{
    public string action;
    public int wordIndex;
}
public class AtomicOperationArgment
{
    public List<Word> words;

    public StringBuilder outputString = new StringBuilder();

    private List<string> argments = new List<string>();


    public string GetParam()
    {
        string content = argments[0];
        argments.RemoveAt(0);
        return content;
    }
    public void AddParam(int index)
    {
        argments.Add(words[index].content);
    }
}
