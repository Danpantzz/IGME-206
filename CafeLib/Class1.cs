using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Author: Daniel McErlean
namespace CafeLib
{
    //Class: HotDrink
    //Purpose: Used to create drinks to serve to customers
    //Restrictions: None
    public abstract class HotDrink
    {
        public bool instant;
        public bool milk;
        public string size;

        private byte sugar;

        public Customer customer;

        //Method: AddSugar
        //Purpose: add sugar to drink
        public virtual void AddSugar(byte amount)
        {

        }

        public abstract void Steam();

        public HotDrink()
        {

        }

        public HotDrink(string brand)
        {

        }
    }

    //Interface: IMood
    //Purpose: Tells the customer or waiters mood
    //Restrictions: None
    public interface IMood
    {
        string Mood
        {
            get;
        }
    }

    //Interface: ITakeOrder
    //Purpose: Method to receive order from customer
    //Restrictions: None
    public interface ITakeOrder
    {
        void TakeOrder();
    }

    //Class: Waiter
    //Purpose: Creates waiter and serves customer a drink
    //Restrictions: None
    public class Waiter : IMood
    {
        public string name;

        public string Mood
        {
            get;
        }

        //Method: ServeCustomer
        //Purpose: serves the customer a specific drink
        public void ServeCustomer(HotDrink cup)
        {

        }
    }

    //Class: Customer
    //Purpose: Creates customer
    public class Customer : IMood
    {
        public string name;
        public string creditCardNumber;

        public string Mood
        {
            get;
        }
    }

    //Class: CupOfCoffee
    //Purpose: Creates cup of coffee from HotDrink
    //Restrictions: None
    public class CupOfCoffee : HotDrink, ITakeOrder
    {
        public string beanType;

        public override void Steam() 
        {

        }

        public void TakeOrder()
        {

        }

        public CupOfCoffee(string brand) : base(brand)
        {

        }
    }

    //Class: CupOfTea
    //Purpose: Creates cup of tea from HotDrink
    //Restrictions: None
    public class CupOfTea : HotDrink, ITakeOrder
    {
        public string leafType;

        public override void Steam()
        {

        }

        public void TakeOrder()
        {

        }
        
        public CupOfTea(bool customerIsWealthy)
        {

        }
    }

    //Class: CupOfCocoa
    //Purpose: Creates cup of cocoa from HotDrink
    //Restrictions: None
    public class CupOfCocoa : HotDrink, ITakeOrder
    {
        public static int numCups;
        public bool marshmallows;
        private string source;

        public string Source
        {
            set
            {

            }
        }

        public override void Steam()
        {

        }

        public override void AddSugar(byte amount)
        {

        }

        public void TakeOrder()
        {

        }

        public CupOfCocoa() : this(false)
        {

        }

        public CupOfCocoa(bool marshmallows) : base("Expensive Organic Bread")
        {

        }
    }
}
