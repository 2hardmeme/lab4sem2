using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Animal
    {
        private string _animalname;
        public string AnimalName
        {
            get
            {
                return _animalname;
            }
            set
            {
                _animalname = value;
            }
        }
        private string _country;
        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
            }
        }
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        private DateTime _birthday;
        public DateTime BirthDay
        {
            get
            {
                return _birthday;
            }
            set
            {
                _birthday = value;
            }
        }
        public Animal() { }
        public Animal(string AnimalName, string Country,string Name, DateTime BirthDay)
        {
            this.AnimalName = AnimalName;
            this.Country = Country;
            this.Name = Name;
            this.BirthDay = BirthDay;
        }
        public override string ToString()
        {
            return "Name: " + Name + " AnimalName: " + AnimalName + " Birthday: " + BirthDay.ToString();
        }
    }
}
