using System;
class ThreeDim
{
    private int x, y, z;
    public ThreeDim()
    {
        x = y = z = 0;
    }
    public ThreeDim(int i, int j, int k)
    {
        x = i; y = j; z = k;
    }
    public int GetX()
    {
        return x;
    }
    public int GetY()
    {
        return y;
    }
    public int GetZ()
    {
        return z;
    }
    public static ThreeDim operator + (ThreeDim par1, ThreeDim par2)
    {
        ThreeDim res = new ThreeDim();
        res.x = par1.x + par2.x;
        res.y = par1.y + par2.y;
        res.z = par1.z + par2.z;
        return res;
    }
    public static ThreeDim operator + (ThreeDim par, int i)
    {
        ThreeDim temp = new ThreeDim();
        temp.x = par.x + i;
        temp.y = par.y + i;
        temp.z = par.z + i;
        return temp;
    }
    public static ThreeDim operator +(int i, ThreeDim par)
    {
        ThreeDim temp = new ThreeDim();
        temp.x = par.x + i;
        temp.y = par.y + i;
        temp.z = par.z + i;
        return temp;
    }

    public static ThreeDim operator - (ThreeDim par1, ThreeDim par2)
    {
        ThreeDim res = new ThreeDim();
        res.x = par1.x - par2.x;
        res.y = par1.y - par2.y;
        res.z = par1.z - par2.z;
        return res;
    }
    public static ThreeDim operator - (ThreeDim par)
    {
        ThreeDim res = new ThreeDim();
        res.x = -par.x;
        res.y = -par.y;
        res.z = -par.z;
        return res;
    }
    public static ThreeDim operator ++ (ThreeDim par)
    {
        ThreeDim res = new ThreeDim();
        res.x = par.x + 1;
        res.y = par.y + 1;
        res.z = par.z + 1;
        return res;
    }
}

class Start
{
    static void Main()
    {
        ThreeDim t1 = new ThreeDim(1, 1, 1);
        ThreeDim t2 = new ThreeDim(10, 10, 10);
        ThreeDim t3 = t1 + t2;
        ThreeDim t4 = t1 - t2;
        ThreeDim t5 = -t1;
        Console.WriteLine("          t1:   x = {0}, y = {1}, z = {2}", t1.GetX(), t1.GetY(), t1.GetZ());
        t1++;
        Console.WriteLine("          t2:   x = {0}, y = {1}, z = {2}", t2.GetX(), t2.GetY(), t2.GetZ());
        Console.WriteLine("t3 = t1 + t2:   x = {0}, y = {1}, z = {2}", t3.GetX(), t3.GetY(), t3.GetZ());
        Console.WriteLine("t4 = t1 - t2:   x = {0}, y = {1}, z = {2}", t4.GetX(), t4.GetY(), t4.GetZ());
        Console.WriteLine("    t5 = -t1:   x = {0}, y = {1}, z = {2}", t5.GetX(), t5.GetY(), t5.GetZ());
        Console.WriteLine("        t1++:   x = {0}, y = {1}, z = {2}", t1.GetX(), t1.GetY(), t1.GetZ());
        ThreeDim t6 = t1++;
        Console.WriteLine("   t6 = t1++:   x = {0}, y = {1}, z = {2}", t6.GetX(), t6.GetY(), t6.GetZ());
        ThreeDim t7 = ++t1;
        Console.WriteLine("   t7 = ++t1:   x = {0}, y = {1}, z = {2}", t7.GetX(), t7.GetY(), t7.GetZ());

        t7 = t1 + 4;
        Console.WriteLine(" t7 = t1 + 4:   x = {0}, y = {1}, z = {2}", t7.GetX(), t7.GetY(), t7.GetZ());
        ThreeDim t8 = 4 + t7;
        Console.WriteLine(" t8 = 4 + t7:   x = {0}, y = {1}, z = {2}", t8.GetX(), t8.GetY(), t8.GetZ());
    }
}