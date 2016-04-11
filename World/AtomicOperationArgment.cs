using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.TextProcessor;

public class LinkerParam
{
    public string Act;
    public int WordIndex;
}
public class AtomicOperationArgment
{
    public List<Word> Words;

    public StringBuilder OutputString = new StringBuilder();

    private List<string> Argments = new List<string>();

    private List<LinkerParam> mLinkParams = new List<LinkerParam>();

    public void AddLinkParam(LinkerParam param)
    {
        mLinkParams.Add(param);
    }
    public string GetNextParam()
    {
        string content = Argments[0];
        Argments.RemoveAt(0);
        return content;
    }
    public void AddParam(int index)
    {
        Argments.Add(Words[index].content);
    }

    public void Record(Expression exp)
    {
        if(exp.LinkParams.Count==0)
        {
            exp.LinkParams.AddRange(mLinkParams);
        }
    }
}
