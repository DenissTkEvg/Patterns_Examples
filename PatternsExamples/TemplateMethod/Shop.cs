using System;


namespace PatternsExamples.TemplateMethod
{
    public abstract class Shop
    {
        public void Shopping()
        {
            Enter();
            Choose();
            Decide();
            Pay();
        }
        public abstract void Enter();
        public abstract void Choose();
      
        public abstract void Decide();
        public virtual void Pay()
        {
            Console.WriteLine("Оплата за товар");
        }

    }
    public class ClothingStore : Shop
    {
        public override void Enter()
        {
            Console.WriteLine("Едем в магазин одежды");
        }

        public override void Choose()
        {
            Console.WriteLine("Выбираем товар, примеряем");
        }

        public override void Decide()
        {
            Console.WriteLine("Принимаем решение о покупке: товар не подошел");
        }
    }

    class MobilePhoneStore : Shop
    {
        public override void Enter()
        {
            Console.WriteLine("Приезжаем в магазин мобильных телефонов");
        }

        public override void Choose()
        {
            Console.WriteLine("Выбираем модель");
            Console.WriteLine("Проверяем работоспособность");
        }

        public override void Decide()
        {
            Console.WriteLine("Принимаем решение о товаре. Телефон подошел");
        }

        public override void Pay()
        {
            Console.WriteLine("Оплата за товар. Оплата картой");
        }
    }
}
