using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ARandom
{
    private static System.Random mSeed = new Random();
    /// <summary>
    /// left closed,right open.[0,100)
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static int Range(int min, int max)
    {
        return mSeed.Next(min, max);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static int Get()
    {
        return mSeed.Next();
    }
}
