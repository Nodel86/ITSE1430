using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile
{
    /// <summary>Provides information about a product.</summary>
    public class Product
    {
        internal decimal DiscountPercantage = 0.10M;

        /// <summary>Get the product name.</summary>
        /// <returns>The name.</returns>
        
        public string GetName()
        {
            return _name ?? "";
        }


        /// <summary>Validates the product.</summary>
        /// <returns>Error message, if any.</returns>
        public string Validate()
        {
            //Name is required
            if (string.IsNullOrEmpty(_name))
                return "Name cannot be empty";

            //Price >=0
            if (_price < 0)
                return "Price must be >= 0";

            return "";
        }



        /// <summary>Sets the product name.</summary>
        /// <param name="value">The name.</param>
        public void SetName ( string value)
        {
            _name = value ?? "";
        }

        private string _name = "";
        private string _description;
        private decimal _price;
        private bool _isDiscontinued;
    }
}
