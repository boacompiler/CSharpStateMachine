using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using StateMachineTest.Classes;
using StateMachineTest.States;

namespace StateMachineTest
{
    class Program
    {
        public static Student bob;
        public static Student lou;
        public static Time time;

        static DateTime lastFrame;
        static TimeSpan delta;

        static void Main(string[] args)
        {
            bob = new Student("Robert");
            lou = new Student("Louis");

            EntityManager.Instance.RegisterEntity(bob);
            EntityManager.Instance.RegisterEntity(lou);

            time = new Time();

            lastFrame = DateTime.Now;
            
            for (int i = 0; i < 100; i++)
            {

                delta = DateTime.Now - lastFrame;
                lastFrame = DateTime.Now;

                Telegraph.MessageDispatcher.Instance.DispatchDelayedMessages();

                Console.ForegroundColor = ConsoleColor.Red;
                bob.Update();
                Console.ForegroundColor = ConsoleColor.Blue;
                //lou.Update();
                Console.ForegroundColor = ConsoleColor.Green;
                time.Update();
                Thread.Sleep(500);
            }

            Console.ReadKey();
        }
    }
}
