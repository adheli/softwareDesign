using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;


public interface CounterInterface
{
    void increment();
    void decrement();
    int read_value();
    void reset();
}

public class Test
{
    public static void Main()
    {
        int option = 0;
        TcpChannel tcpChannel = new TcpChannel();
        ChannelServices.RegisterChannel(tcpChannel);
        Type requiredType = typeof(CounterInterface);
        CounterInterface c =
           (CounterInterface)Activator.GetObject(requiredType,
             "tcp://localhost:9998/MyCounter");

        while (option != 5)
        {
            Console.WriteLine("Choose Option\n-------------\n1. Increment\n2. Decrement\n3. Read value\n4. Reset\n5. Quit");
            option = Convert.ToInt32(Console.ReadLine());
            if (option == 1)
            {
                c.increment();
            }
            else if (option == 2)
            {
                c.decrement();
            }
            else if (option == 3)
            {
                int val = c.read_value();
                Console.WriteLine("Value = {0}", val);
            }
            else if (option == 4)
            {
                c.reset();
            }
            else if (option != 5)
            {
                Console.WriteLine("Invalid Option");
            }
        }
    }
}