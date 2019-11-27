using System;

class Server
{
    private string ipnumber;
    private string name;
    private string location;
    private static Server instance;
    private static bool isCreated;

    private Server()
    {
        ipnumber = "172.16.254.3";
        name = "Gamma";
        location = "Athlone";

        isCreated = true;
        instance = this;
    }

    public static Server GetInstance()
    {
        return isCreated ? instance : new Server();
    }

    public void UpdateLocation(String loc) { location = loc; }

    public string ReadLocation() { return location; }

    public string ReadNumber() { return ipnumber; }

    public void PrintDetails()
    {
        Console.WriteLine("Name = " + name);
        Console.WriteLine("IP Number = " + ipnumber);
        Console.WriteLine("Location = " + location);
    }
}

public class Q7
{
    public static void Main(string[] args)
    {
        Server s1 = Server.GetInstance();
        Server s2 = Server.GetInstance();
        s1.PrintDetails();
        s1.UpdateLocation("Moate");
        s2.PrintDetails();
        Console.ReadLine();
    }
}
