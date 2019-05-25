using System.Collections.Generic;

public class Progress : Singleton<Progress> 
{
    // public int[] test;
    public IDictionary<string, int> dict = new Dictionary<string, int>(){
        {"demo", 1}
    };
    // dict.Add();
    // int res;
    // dict.TryGetValue("demo", out res);
}
