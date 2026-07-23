using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    // ==========================================
    // Address Class
    // ==========================================
    public class Address
    {
        private string _streetAddress;
        private string _city;
        private string _stateOrProvince;
        private string _country;

        public Address(string streetAddress, string city, string stateOrProvince, string country)
        {
            _streetAddress = streetAddress;
            _city = city;
            _stateOrProvince = stateOrProvince;
            _country = country;
        }

        // I Returns true if the address is in the USA
        public bool IsInUsa()
        {
            return _country.Trim().Equals("USA", StringComparison.OrdinalIgnoreCase) ||
                   _country.Trim().Equals("United States", StringComparison.OrdinalIgnoreCase);
        }

        // I Returns a multi-line string of the complete address
        public string GetFullAddress()
        {
            return $"{_streetAddress}\n{_city}, {_stateOrProvince}\n{_country}";
        }
    }

    // ==========================================
    // Customer Class
    // ==========================================
    public class Customer
    {
        private string _name;
        private Address _address;

        public Customer(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        public string GetName()
        {
            return _name;
        }

        public Address GetAddress()
        {
            return _address;
        }

        // I Calls the method on the Address class to check if customer lives in the USA
        public bool IsInUsa()
        {
            return _address.IsInUsa();
        }
    }

    // ==========================================
    // Product Class
    // ==========================================
    public class Product
    {
        private string _name;
        private string _productId;
        private double _price;
        private int _quantity;

        public Product(string name, string productId, double price, int quantity)
        {
            _name = name;
            _productId = productId;
            _price = price;
            _quantity = quantity;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetProductId()
        {
            return _productId;
        }

        // I Calculates total cost for this specific product (price * quantity)
        public double GetTotalCost()
        {
            return _price * _quantity;
        }
    }

    // ==========================================
    // Order Class
    // ==========================================
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        // I Computes final price: sum of products + one-time shipping ($5 USA, $35 International)
        public double CalculateTotalCost()
        {
            double productTotal = 0;
            foreach (Product product in _products)
            {
                productTotal += product.GetTotalCost();
            }

            double shippingCost = _customer.IsInUsa() ? 5.00 : 35.00;

            return productTotal + shippingCost;
        }

        // I Formats packing label with Name and Product ID for each product
        public string GetPackingLabel()
        {
            string label = "--- PACKING LABEL ---\n";
            foreach (Product product in _products)
            {
                label += $"• {product.GetName()} (ID: {product.GetProductId()})\n";
            }
            return label;
        }

        // I Formats shipping label with Customer Name and Full Address
        public string GetShippingLabel()
        {
            return $"--- SHIPPING LABEL ---\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
        }
    }

    // ==========================================
    // Main Program Execution
    // ==========================================
    class Program
    {
        static void Main(string[] args)
        {
            // --------------------------------------------------
            // ORDER 1: USA Resident (3 Products)
            // --------------------------------------------------
            Address address1 = new Address("123 Main Street", "Rexburg", "ID", "USA");
            Customer customer1 = new Customer("John Doe", address1);
            Order order1 = new Order(customer1);

            order1.AddProduct(new Product("Wireless Mouse", "M101", 25.99, 2));
            order1.AddProduct(new Product("Mechanical Keyboard", "K202", 79.50, 1));
            order1.AddProduct(new Product("Desk Mat", "D303", 15.00, 1));

            // Output Order 1
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"\nTotal Order Price: ${order1.CalculateTotalCost():F2}");
            Console.WriteLine("\n==================================================\n");

            // --------------------------------------------------
            // ORDER 2: International Resident (2 Products)
            // --------------------------------------------------
            Address address2 = new Address("456 Queen St W", "Toronto", "ON", "Canada");
            Customer customer2 = new Customer("Jane Smith", address2);
            Order order2 = new Order(customer2);

            order2.AddProduct(new Product("27-inch Monitor", "MON77", 249.99, 1));
            order2.AddProduct(new Product("HDMI Cable 6ft", "CAB09", 8.49, 3));

            // Output Order 2
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"\nTotal Order Price: ${order2.CalculateTotalCost():F2}");
            Console.WriteLine("\n==================================================");
        }
    }
}