using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabir_CafeLib
{
    //Interface:IMood
    //Property: public string Mood {get}
    public interface IMood
    {
        string Mood { get; }
    }

    //Interface: ITakeOrder
    //Method: public void TakeOrder()
    public interface ITakeOrder
    {
        void TakeOrder();
    }

    //Public class: Waiter : IMood
    //Fields: public string name
    //Property: public string Mood {get}
    //Method: public void ServeCustomer(HotDrink cup)
    public class Waiter : IMood
    {
        public string name;
        
        public string Mood { get; }

        public void ServeCustomer(HotDrink cup)
        {

        }

    }

    //Public class: Customer : IMood
    //Fields: public string name, public string creditCardNumber
    //Property: public string Mood {get}
    public class Customer : IMood
    {
        public string name;
        public string creditCardNumber;

        public string Mood { get; }
    }
    

    //Public abstract class: HotDrink
    //Fields: public bool instant, public bool milk, private byte sugar, public string size, public Customer customer
    //Methods: public virtual void AddSugar(byte amount), public abstract void Steam()
    //Constructors: public HotDrink(), public HotDrink(string brand)
    public abstract class HotDrink
    {
        public bool instant;
        public bool milk;
        private byte sugar;
        public string size;
        public Customer customer;

        public HotDrink()
        {

        }

        public HotDrink(string brand)
        {

        }

        public virtual void AddSugar(byte amount)
        {

        }
        public abstract void Steam();
    }

    //Public class: CupOfCoffee: HotDrink, ITakeOrder
    //Fields: public string beanType
    //Methods: public override void Steam(), public void TakeOrder()
    //Constructors: public CupOfCoffee(string brand) : base(brand)
    public class CupOfCoffee : HotDrink, ITakeOrder
    {
        public string beanType;

        public CupOfCoffee(string brand) : base(brand)
        {

        }

        public override void Steam()
        {

        }
        public void TakeOrder()
        {

        }
    }
        

    //Public class: CupOfTea: HotDrink, ITakeOrder
    //Fields: public string leafType
    //Methods: public override void Steam(), public void TakeOrder()
    //Constructors: public CupOfTea(bool customerIsWealthy)
    public class CupOfTea : HotDrink, ITakeOrder
    {
        public string leafType;

        public CupOfTea(bool customerIsWealthy)
        {

        }

        public override void Steam()
        {
            
        }
        
        public void TakeOrder()
        {

        }
    }

    //Public class: CupOfCocoa: HotDrink, ITakeOrder
    //Fields: public static int numCups, public bool marshmallows, private string source
    //Methods: public override void Steam(), public override void AddSugar(byte amount), public void TakeOrder()
    //Protperties: public string Source {set}
    //Constructors: public CupOfCocoa(): this(false), public CupOfCoca(bool marshmallows) : base("Expensive Organic Brand")
    public class CupOfCocoa : HotDrink, ITakeOrder
    {
        public static int numCups;
        public bool marshmallows;
        private string source;

        public CupOfCocoa() : this(false)
        {

        }

        public CupOfCocoa(bool marshmallows) : base("Expensive Organic Brand")
        {

        }


        public override void Steam()
        {
           
        }

        public override void AddSugar(byte amount)
        {
            base.AddSugar(amount);
        }

        public void TakeOrder()
        {

        }

        public string Source
        {
            set
            {
                source = value;
            }
        }
    }


}
