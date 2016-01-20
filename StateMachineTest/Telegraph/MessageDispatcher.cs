using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StateMachineTest.Classes;

namespace StateMachineTest.Telegraph
{

    public struct Telegram
    {
        public int Sender;
        public int Receiver;
        public int Message;
        public double DispatchTime;

        public Telegram(int sender, int receiver, int message, double dispatchTime)
        {
            Sender = sender;
            Receiver = receiver;
            Message = message;
            DispatchTime = dispatchTime;
        }
    };

    public enum MessageType
    {
        Hello,
        Goodbye,
        UniStart,
        UniEnd
    }

    class MessageDispatcher
    {
        private static readonly MessageDispatcher instance = new MessageDispatcher();
        private static List<Telegram> telegrams;

        internal static MessageDispatcher Instance
        {
            get
            {
                return instance;
            }
        }

        private MessageDispatcher()
        {
            telegrams = new List<Telegram>();
        }

        public void DispatchMessage(int sender, int receiver, int message, double dispatchTime)
        {
            Telegram telegram = new Telegram(sender,receiver,message,dispatchTime);
            telegrams.Add(telegram);
        }

        public void DispatchDelayedMessages()
        {
            for (int i = 0; i < telegrams.Count; i++)
            {
                BaseEntity recipient = EntityManager.Instance.GetEntityByID(telegrams[i].Receiver);
                recipient.HandleMessage(telegrams[i]);
            }
            telegrams.Clear();
        }

    }
}
