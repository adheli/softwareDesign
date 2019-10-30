using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Sterling
{
    private int pound;
    private int pence;

    public Sterling(int po, int pe)
    {
        pound = po;
        pence = pe;
    }

    public void Print()
    {
        Console.WriteLine("£ {0}.{1}", pound, pence);
    }

    public static Sterling operator +(Sterling s1, Sterling s2)
    {
        int pound = s1.pound + s2.pound;
        int pence = s1.pence + s2.pence;

        if (pence >= 100)
        {
            pound++;
            pence -= 100;
        }
        return new Sterling(pound, pence);
    }

    public static bool operator <(Sterling s1, Sterling s2)
    {
        return ((s1.pound * 100) + s1.pence) < ((s2.pound * 100) + s2.pence);
    }

    public static bool operator >(Sterling s1, Sterling s2)
    {
        return ((s1.pound * 100) + s1.pence) > ((s2.pound * 100) + s2.pence);
    }

    public static explicit operator string(Sterling s)
    {
        return String.Format("£ {0}.{1}", s.pound, s.pence);
    }

    public static Sterling operator ++(Sterling s1)
    {
        s1.pence++;

        if (s1.pence >= 100)
        {
            s1.pound++;
            s1.pence -= 100;
        }

        return s1;
    }

    public static Sterling operator --(Sterling s1)
    {
        s1.pence--;

        if (s1.pence < 0)
        {
            s1.pound--;
            s1.pence += 100;
        }

        return s1;
    }

}

public class Test
{
    public static void Main()
    {
        Sterling s = new Sterling(52, 36);
        s.Print();

        Sterling s2 = new Sterling(15, 99);
        s2.Print();
        s2++;
        s2.Print();
        s2--;
        s2.Print();

        Sterling res = s + s2;
        res.Print();
        res++;
        res.Print();
        res--;
        res.Print();


        if (s > s2)
        {
            Console.WriteLine("First Bigger");
        }
        else
        {
            Console.WriteLine("Second Bigger");
        }
        Console.WriteLine("s2 = {0}", (String)s2);
    }
}



