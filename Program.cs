using NServiceBus.Unicast.Subscriptions.MessageDrivenSubscriptions;
using System.Security.Policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProjectReview1
{

    class Program
    {
        static void Main(string[] args)
        {
            FinalExam.Demo();
            Publisher pub1 = new Publisher("publisher1", 2000);
            Publisher pub2 = new Publisher("publisher2", 1000);

            //Create Instances of Subscribers
            Subscriber sub1 = new Subscriber("Chaoyi");
            Subscriber sub2 = new Subscriber("Peter");
            Subscriber sub3 = new Subscriber("Jane");

            //Pass the publisher obj to their Subscribe function
            sub1.Subscribe(pub2); //sub1 subscribes to publisher2
            sub3.Subscribe(pub2);

            sub1.Subscribe(pub1);
            sub2.Subscribe(pub1);



            // Concurrently running multiple publishers thread for mocking continious notification update firing.
            Task task1 = Task.Factory.StartNew(() => pub1.Publish());
            Task task2 = Task.Factory.StartNew(() => pub2.Publish());
            Task.WaitAll(task1, task2);
        }
    }


    //class Message
    //{
    //    public string Content { get; set; }
    //    public Message(string _content)
    //    {
    //        Content = _content;
    //    }
    //}

    //interface IPublisher
    //{
    //    event EventHandler<Message> Handler;
    //    void Publish(string cont);
    //}

    //class Publisher : IPublisher
    //{
    //    public event EventHandler<Message> Handler;

    //    public void OnPublish(Message msg)
    //    {
    //        Handler?.Invoke(this, msg);
    //    }

    //    public void Publish(string cont)
    //    {
    //        Message msg = (Message)Activator.CreateInstance(typeof(Message), cont);
    //        OnPublish(msg);
    //        Thread.Sleep(1000);
    //    }
    //}

    //class Subscriber
    //{
    //    public IPublisher Publisher { get; set; }
    //    public Subscriber(IPublisher publisher)
    //    {
    //        Publisher = publisher;
    //    }
    //}
}
