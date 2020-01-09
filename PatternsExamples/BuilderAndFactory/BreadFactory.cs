using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsExamples.BuilderAndFactory
{
    public abstract class BreadFactory
    {
        public string Name { get; set; }

        public BreadFactory(string n)
        {
            Name = n;
        }
        // фабричный метод
        abstract public BreadF Create();
    }

    // печет ржаной хлеб
    public class RyeBreadFactory : BreadFactory
    {
        public RyeBreadFactory(string n) : base(n)
        { }

        public override BreadF Create()
        {
            return new RyeBread();
        }
    }
    //печет пшеничный хлеб
    public class WheatBreadFactory : BreadFactory
    {
        public WheatBreadFactory(string n) : base(n)
        { }

        public override BreadF Create()
        {
            return new WheatBread();
        }
    }

    abstract public class BreadF
    {
        public abstract void SetFlour();

    }

    public class RyeBread : BreadF
    {
        public override void SetFlour() {
            Console.WriteLine("Ржаная мука 1 сорт");
        }
        public RyeBread()
        {
            SetFlour();
            Console.WriteLine("Ржаной хлеб испечен");
        }
    }
    public class WheatBread : BreadF
    {
        public override void SetFlour()
        {
            Console.WriteLine("Пшеничная мука высший сорт");
        }
        public WheatBread()
        {
            SetFlour();
            Console.WriteLine("пшеничный хлеб испечен");
        }
    }
}
