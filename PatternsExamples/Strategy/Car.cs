using System;


namespace PatternsExamples.Strategy
{
    public class Car
    {
       protected int passengers; // кол-во пассажиров
       protected string model; // модель автомобиля

       public Car(int num, string model, IMovable mov)
       {
          this.passengers = num;
          this.model = model;
          Movable = mov;
       }
       public IMovable Movable { private get; set; }
       public void Move()
       {
          Movable.Move();
       }
        
    }
    public interface IMovable
    {
        void Move();
    }

    public class PetrolMove : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Перемещение на бензине");
        }
    }

    public class ElectricMove : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Перемещение на электричестве");
        }
    }
}
