using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;




    class Program
    {
        public static void Main()
        {
            CounterServer();
        }

        static void CounterServer()
        {
            Console.WriteLine("Adheli's Server Started");

            TcpChannel tcpChannel = new TcpChannel(9998);
            ChannelServices.RegisterChannel(tcpChannel);
            Type commonInterfaceType = Type.GetType("Counter");

            RemotingConfiguration.RegisterWellKnownServiceType(commonInterfaceType,"MyCounter", WellKnownObjectMode.Singleton);
            System.Console.WriteLine("Press ENTER to quit");
            System.Console.ReadLine();
        }
    }


    public interface CounterInterface
    {
        void increment();
        void decrement();
        int read_value();
        void reset();
    }

    public class Counter : MarshalByRefObject, CounterInterface
    {
        private int value = 200;

        public void increment()
        {
            this.value++;
        }

        public void decrement()
        {
            this.value--;
        }

        public int read_value()
        {
            return this.value;
        }

        public void reset()
        {
            this.value = 0;
        }
    }


