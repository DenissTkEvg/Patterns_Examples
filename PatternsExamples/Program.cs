using PatternsExamples.BuilderAndFactory;
using PatternsExamples.ChainOfResponsibility;
using PatternsExamples.Iterator;
using PatternsExamples.Strategy;
using PatternsExamples.TemplateMethod;
using System;
using System.Collections.Generic;

namespace PatternsExamples
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //// Template Method
            ClothingStore clothingStore = new ClothingStore();
            MobilePhoneStore mobilePhoneStore = new MobilePhoneStore();

            clothingStore.Shopping();
            mobilePhoneStore.Shopping();

            //// Strategy
            Car auto = new Car(5, "Chevrolet", new PetrolMove());
            auto.Move();
            auto.Movable = new ElectricMove();
            auto.Move();

            //// Iterator
            var replies1 = new List<int>() { 1, 4, 7 };
            var replies2 = new List<int>() { 2, 5, 8 };
            var replies3 = new List<int>() { 3, 6, 9 };
            var mas = new List<List<int>>() { replies1, replies2, replies3 };
            var res = mas.Cartesian((x, y) => 10 * x + y);
            Console.WriteLine(string.Join("\n", res));

            //// Builder
            // содаем объект пекаря
            Baker baker = new Baker();
            // создаем билдер для ржаного хлеба
            BreadBuilder builder = new RyeBreadBuilder();
            // выпекаем
            Bread ryeBread = baker.Bake(builder);
            Console.WriteLine(ryeBread.ToString());
            // создаем билдер для пшеничного хлеба
            builder = new WheatBreadBuilder();
            Bread wheatBread = baker.Bake(builder);
            Console.WriteLine(wheatBread.ToString());


            //// Factory
            BreadFactory breadFactory = new RyeBreadFactory("ООО Хлебовал");
            BreadF ryeBreadF = breadFactory.Create();

            breadFactory = new WheatBreadFactory("Хлеб от Палыча");
            BreadF wheatBreadF = breadFactory.Create();

            ////ChainOfResponsibility
            Receiver receiver = new Receiver(false, true, true);

            PaymentHandler bankPaymentHandler = new BankPaymentHandler();
            PaymentHandler moneyPaymentHnadler = new MoneyPaymentHandler();
            PaymentHandler paypalPaymentHandler = new PayPalPaymentHandler();
            bankPaymentHandler.Successor = paypalPaymentHandler;
            paypalPaymentHandler.Successor = moneyPaymentHnadler;

            ////ChainOfResponsibility with Delegate
            DelegateReceiver delegateReceiver = new DelegateReceiver(false, true, true);
            Pay pay = new Pay();
            pay.Notify += Display;
            pay.BankPaymentHandler(delegateReceiver);
            Console.ReadLine();
        }
        public static void Display(string message)
        {
            Console.WriteLine(message);
        }
    }
}
