using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalV1
{
    class Product
    {
        private int _id;
        private string _name;
        private double _quantity;
        private double _value;

        public Product(int id, string name, double quantity, double value)
        {
            _id = id;
            _name = name;
            _quantity = quantity;
            _value = value;
        }

        public double Price
        {
            get
            {
                return _value / _quantity;
            }
        }

        public double Value
        {
            get
            {
                return _value;
            }
        }

        public override string ToString()
        {
            return $"ID={_id}  Name={_name} Qty={_quantity} Price={Price} Value={_value}";
        }
    }
}
