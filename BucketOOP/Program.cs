using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Timers;
using System.Linq;


namespace BucketOOP
{
    //abstract

    public abstract class Container
    {

        protected int Capacity;
        protected int Content;

        public void Fill(int amount)
        {
            Content += amount;
            
        }
        public void Fill(Container container)
        {
            container.Content += container.Capacity;
        }

        public void Empty()
        {
            this.Content = 0;
        }

        public void Empty(int amount)
        {
            this.Content -= amount;
        }



        public class Bucket : Container
        {

            public Bucket()
            {

            }

            public Bucket(int content)
            {
                this.Content = content;
            }

            public Bucket(int capacity, int content)
            {
                this.Capacity = capacity;
                this.Content = content;
            }

        }

        public class OlieVat : Container
        {
            public OlieVat()
            {

            }

            public OlieVat(int content)
            {
                this.Content = content;
            }

            public OlieVat(int capacity, int content)
            {
                this.Capacity = capacity;
                this.Content = content;
            }
        }

        public class RegenTon : Container
        {
            public RegenTon()
            {

            }

            public RegenTon(int content)
            {
                this.Content = content;
            }

            public RegenTon(int capacity, int content)
            {
                this.Capacity = capacity;
                this.Content = content;
            }
        }
        



        //event


        protected virtual void OnOverflowing(Bucket bucket)
        {
            if (Content >= Capacity)
            {
                Console.WriteLine("Bucket is OverFlowing");
            }
        }

        protected virtual void OnOverflowed(Bucket bucket)
        {
            Capacity = Content;
        }

        protected virtual void Full()
        {
            if (Content == Capacity)
            {
                Console.WriteLine("Bucket is Full");
            }

            
        }

        [TestMethod]
        public void Oefening2()
        {
            int amount = 4;

            //List<Bucket> buckets = new List<Bucket>();

            Bucket bucket1 = new Bucket(12, 5);
            Bucket bucket2 = new Bucket(10, 0);
            Bucket bucket3 = new Bucket(16, 15);

            //buckets.Add(bucket1);
            //buckets.Add(bucket2);
            //buckets.Add(bucket3);

            bucket1.Empty(amount);

            for (int i = 0; i < amount; i++)
            {
                bucket2.Fill(1);
            }

        }

        [TestMethod]
        public void Oefening3()
        {
            OlieVat olievat1 = new OlieVat(159, 0);
            OlieVat olievat2 = new OlieVat(159, 0);
            OlieVat olievat3 = new OlieVat(159, 0);

            RegenTon regenton1 = new RegenTon(80, 0);
            RegenTon regenton2 = new RegenTon(120, 0);
            RegenTon regenton3 = new RegenTon(160, 0);

            Bucket bucket1 = new Bucket(12, 5);
            Bucket bucket2 = new Bucket(10, 0);
            Bucket bucket3 = new Bucket(16, 15);

            List<Container> containers = new List<Container>();

            containers.Add(olievat1);
            containers.Add(olievat2);
            containers.Add(olievat3);
            containers.Add(regenton1);
            containers.Add(regenton2);
            containers.Add(regenton3);
            containers.Add(bucket1);
            containers.Add(bucket2);
            containers.Add(bucket3);

            containers.OrderBy(x => x.Content);
        }

        [TestMethod]
        public void Oefening4()
        {
            int amount = 15;

            Bucket bucket1 = new Bucket(12, 5);
            Bucket bucket2 = new Bucket(10, 0);
            Bucket bucket3 = new Bucket(16, 15);

            for (int i = 0; i < amount; i++)
            {
                bucket3.Fill(1);
            }
        }




        //execute

        static void Main(string[] args)
        {
 
        }
    }
}
