using System;
using System.Collections.Generic;
using System.Globalization;

namespace offerBook
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Offer> offerBook = new List<Offer>();
            Console.WriteLine("Quantas notificações serão?");
            int numberOfNotification = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < numberOfNotification; i++)
            {
                try
                {
                    Console.WriteLine("Insira A notificação");
                    var notificationConsole = Console.ReadLine();
                    var notificationArray = notificationConsole.Split(",");
                    Notification notification = new Notification() { position=Convert.ToInt32(notificationArray[0]), action= Convert.ToInt32(notificationArray[1]), value= double.Parse(notificationArray[2], CultureInfo.InvariantCulture),quantity = Convert.ToInt32(notificationArray[3]) };
                    switch (notification.action)
                    {
                        case 0:
                            if (ValideObject(notification))
                            {

                            if (offerBook.Count > 0)
                            {
                                offerBook.Insert(notification.position-1, new Offer(notification.position, notification.value, notification.quantity));
                            }
                            else
                            {
                                offerBook.Add(new Offer(notification.position, notification.value, notification.quantity));
                            }
                            }
                            continue;
                        case 1:
                            if (ValideObject(notification))
                            {
                                offerBook[notification.position - 1].value = notification.value;
                                offerBook[notification.position - 1].quantity = notification.quantity;
                            }
                            continue;
                        case 2:
                            offerBook.RemoveAt(notification.position - 1);
                            continue;
                        default:
                            continue;
                    }
                }
                catch (Exception e)
                {
                    continue;
                }

            }


            Console.WriteLine("--------Resultado--------");
            foreach(var offer in offerBook)
            {
                Console.WriteLine(@$"{offer.position},{ offer.value.ToString("N2", CultureInfo.CreateSpecificCulture("en-US"))},{offer.quantity}");
            }
            
        }

        static bool ValideObject(Notification notification)
        {
            return notification.position >= 0 && notification.value >= 0 && notification.quantity >= 0;
        }


    }

    sealed class Offer
    {

        public int position { get;   set; }
        public double value { get;   set; }
        public int quantity { get; set; }


        public Offer(int position,  double value, int quantity)
        {
           
            this.position = position;
            this.value = value;
            this.quantity = quantity;
        }




    }

    sealed class Notification
    {
        public int position { get;  set; }
        public int action { get;  set; }
        public double value { get;  set; }
        public int quantity { get;  set; }
    }
   
}
