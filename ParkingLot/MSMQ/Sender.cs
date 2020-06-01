using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingLot.MSMQ
{
    public class Sender
    {
        public void Message(string MessageToBeSend)
        {

            MessageQueue MyQueue;
            // If The MSMQ Path Is Avaliable On Not
            if (MessageQueue.Exists(@".\Private$\myqueue"))
            {
                // If It's Exists Store The Data
                MyQueue = new MessageQueue(@".\Private$\myqueue");
            }
            else
            {
                // Else Create The myqueue
                MyQueue = MessageQueue.Create(@".\Private$\myqueue");
            }

            Message MyMessage = new Message();
            // Message Format Is Binary
            MyMessage.Formatter = new BinaryMessageFormatter();
            // In Body Message Will Be Store
            MyMessage.Body = MessageToBeSend;
            // Lebel Name 
            MyMessage.Label = "Registration";
            // Message Pririty Normal Or High
            MyMessage.Priority = MessagePriority.Normal;
            // Send Message
            MyQueue.Send(MyMessage);
        }
    }
}

