using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Zoo
{
    public class AnimalRooms
    {
        private RoomType _roomType;
        public RoomType RoomType
        {
            get
            {
                return _roomType;
            }
            set
            {
                _roomType = value;
            }
        }
        public int Number { get; set; }
        public int Size { get; set; }
        public int ClearPrice { get; set; }
        public List<AccountingUnit> AccUnits = new List<AccountingUnit>();
        public void AddAccountingUnit(AccountingUnit unit)
        {
            AccUnits.Add(unit);
        }
        public void EditAccountingUnit(int index, AccountingUnit unit)
        {
            
            AccUnits[index+1] = unit;
        }
        public AnimalRooms() { }

        public AnimalRooms(RoomType RoomType,int Number, int Size, int ClearPrice)
        {
            this.RoomType = RoomType;
            this.Number = Number;
            this.Size = Size;
            this.ClearPrice = ClearPrice;

        }
        public override string ToString()
        {
            return "Room Number: " + Number.ToString() + " Price for service of animals " + ClearPrice.ToString();
        }
        public string ListToString()
        {
            string str = "";
            if (AccUnits != null)
            {
                foreach (var unit in AccUnits)
                {
                    str += unit.ToString() + Environment.NewLine;
                }
            }
            return str;

        }
        
    }
}
