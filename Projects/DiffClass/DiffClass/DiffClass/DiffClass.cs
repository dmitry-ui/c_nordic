using System;
class DiffClass
{
    public int alfa;
    private int beta;
    public void SetBeta(int i)
    {
        beta = i;
    }
    public int GetBeta()
    {
        return beta;
    }
        
}

class Start
{
   static  void Main()
    {
        DiffClass a = new DiffClass();
        a.SetBeta(5);
        a.alfa = 1;
        Console.WriteLine("beta=" + a.GetBeta());
        Console.WriteLine("alfa=" + a.alfa);


    }
}