using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class AccountingUnit
    {
        private Animal _animal;
        public Animal Animal
        {
            get
            {
                return _animal;
            }
            set
            {
                _animal = value;
            }
        }
        private DateTime _recievedate;
        public DateTime RecieveDate
        {
            get
            {
                return _recievedate;
            }
            set
            {
                _recievedate = value;
            }
        }
        private decimal _price;
        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
        public AccountingUnit() { }
        public AccountingUnit(Animal Animal, DateTime RecieveDate, decimal Price)
        {
            this.Animal = Animal;
            this.RecieveDate = RecieveDate;
            this.Price = Price;
        }
        public override string ToString()
        { 
            return "Animal: " + Animal + " Recieve Date: " + RecieveDate + " Price: " + Price;
        }
    }
}
