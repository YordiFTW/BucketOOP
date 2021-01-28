using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Timers;
using System.Linq;


namespace BucketOOP
{
    //abstract container

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

        // bruikbare classes

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

        // method berekent de hoeveelheid liters die overstroomt, geeft tevens een melding van het aantal liters.
        protected virtual void OnOverflowing(Bucket bucket)
        {
            int overflow;

            if (Content >= Capacity)
            {
                overflow = Content - Capacity;

                Console.WriteLine("Bucket is overflowing by" + overflow.ToString());
            }
        }

        // deze method doet niks
        protected virtual void OnOverflowed(Bucket bucket)
        {
            Capacity = Content;
            Full();
        }

        // method zorgt ervoor dat de content niet hoger kan zijn dan de maximale capaciteit, geeft tevens een melding hiervan.
        protected virtual void Full()
        {
            Capacity = Content;

            if (Content == Capacity)
            {
                Console.WriteLine("Bucket is Full");
            }

            
        }

        [TestMethod]

        // Zorg ervoor dat alleen een emmer ook gevuld kan worden met de inhoud van een andere emmer.

        public void Oefening2()
        {
            // 4 liter
            int amount = 4;

            Bucket bucket1 = new Bucket(12, 5);
            Bucket bucket2 = new Bucket(10, 0);
            Bucket bucket3 = new Bucket(16, 15);

            // 4 liter legen in bucket 1.
            bucket1.Empty(amount);

            // bucket 2 met 4 liter vullen.
            for (int i = 0; i < amount; i++)
            {
                bucket2.Fill(1);
            }

        }

        [TestMethod]

        //Er moeten ook olievaten gemaakt kunnen worden. Olievaten hebben een vaste afmeting van 159. Regentonnen bestaan in de volgende drie maten: klein 80, middel 120 en groot 160. Deze twee zijn vergelijkbaar met een emmer.

        public void Oefening3()
        {
            // lijst maken van alle containers.

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

            // deze containers sorteren op inhoud.
            containers.OrderBy(x => x.Content);
        }

        [TestMethod]

        //Wanneer de emmer overstroomd of gevuld wordt met een te grote hoeveelheid moet de emmer kenbaar kunnen maken hoeveel er naast de emmer is gevallen.

        public void Oefening4()
        {
            // bucket vullen met 15 liter?
            int amount = 15;

            Bucket bucket1 = new Bucket(12, 5);
            Bucket bucket2 = new Bucket(10, 0);
            Bucket bucket3 = new Bucket(16, 15);

            // per liter de emmer vullen en controleren of de aan het overstromen is.
            for (int i = 0; i < amount; i++)
            {
                bucket3.Fill(1);
                bucket3.OnOverflowing(bucket3);
            }
            //emmer na het vullen de maximale capaciteit geven.
            bucket3.Full();
        }




        //execute

        static void Main(string[] args)
        {

        }
    }
}
