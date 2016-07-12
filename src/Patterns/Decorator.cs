using System.Collections.Generic;
using System.Linq;

namespace Patterns
{
    public interface IPizza
    {
        string Description { get; }

        double Cost { get; }

        IEnumerable<PizzaType> Types { get; }
    }

    public class PlainPizza : IPizza
    {
        public double Cost { get { return 2; } }

        public string Description { get { return "Standart"; } }

        public IEnumerable<PizzaType> Types {
            get { return new List<PizzaType> { PizzaType.Plain }; }
        }
    }

    public abstract class ToppingDecorator : IPizza
    {
        protected readonly IPizza pizza;

        public ToppingDecorator(IPizza pizza) {
            this.pizza = pizza;
        }

        protected abstract PizzaType PizzaType { get; }

        public virtual double Cost { get { return pizza.Cost; } }

        public virtual string Description { get { return $"{pizza.Description}, {PizzaType}"; } }

        public virtual IEnumerable<PizzaType> Types {
            get {
                var result = pizza.Types.ToList();
                result.Add(PizzaType);
                return result;
            }
        }
    }

    public class Mozzeralla : ToppingDecorator
    {
        public Mozzeralla(IPizza pizza)
            : base(pizza) {
        }

        public override double Cost { get { return base.Cost + 0.5; } }

        protected override PizzaType PizzaType { get { return PizzaType.Mozzarella; } }
    }

    public class Ham : ToppingDecorator
    {
        public Ham(IPizza pizza)
            : base(pizza) {
        }

        public override double Cost {
            get {
                var extraCost = Types.Contains(PizzaType.Mozzarella) ? 1 : 2;
                return base.Cost + extraCost;
            }
        }

        protected override PizzaType PizzaType { get { return PizzaType.Ham; } }
    }

    public enum PizzaType
    {
        Plain,
        Mozzarella,
        Ham
    }
}
