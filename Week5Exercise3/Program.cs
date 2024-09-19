using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5Exercise3
{
    internal class Program
    {
        class Product //Product class to create new product objects
        {
            public string ProductID { get; set; } //declares an enstatiated ProductID string
            public string ProductName { get; set; } //declares an enstatiated ProductName string
            public double Price { get; set; } //declares an enstatiated Price double

            public Product(string productID, string productName, double price) //Product method to set variables to input
            {
                ProductID = productID; //sets ProductID to productID input
                ProductName = productName; //sets ProductName to productName input
                Price = price; //sets Price to price input
            }
        }

        class ShoppingCart //shopping cart class to create shopping carts
        {
            List<Product> cartItems = new List<Product>(); //declares shopping cart list

            public void AddProduct(Product product) //method to add product object to list
            {
                cartItems.Add(product); //adds product object to list
            }

            public void RemoveProduct(string productID) //method to remove product object from list
            {
                for (int i = 0; i < cartItems.Count; i++) //for loop to loop through objects in list
                {
                    if (cartItems[i].ProductID == productID) //if condition to check if object in index equals input
                    {
                        cartItems.RemoveAt(i); //removes object from list
                        return; //returns from method
                    }
                }
                Console.WriteLine("Product was not found in the cart"); //result if object was not found
            }

            public double CalculateTotalPrice() //method to calculate the total price
            {
                double totalPrice = 0; //declares and initializes total price double
                for (int i = 0; i < cartItems.Count; i++) //for loop to loop through each object in list
                {
                    totalPrice += cartItems[i].Price; //price calculation
                }

                return totalPrice; //returns calculated price
            }

            public void ViewShoppingCart() //method to view objects in list
            {
                Console.WriteLine("Shopping Cart Contents: "); //displays text
                foreach (var product in cartItems) //foreach loop to display each object
                {
                    Console.WriteLine($"ID: {product.ProductID} - {product.ProductName} - ${product.Price}"); //displays object
                }
            }
        }
        static void Main(string[] args) //main method
        {
            ShoppingCart cart = new ShoppingCart(); //creates new shopping cart

            while (true) //while loop that loops the program
            {
                Console.WriteLine(); //displays blank line
                Console.WriteLine("Please choose a option:"); //asks for user input
                Console.WriteLine("1. View carts contents"); //displays text
                Console.WriteLine("2. Add product to cart"); //displays text
                Console.WriteLine("3. Remove product from cart"); //displays text
                Console.WriteLine("4. Display total price"); //displays text
                Console.WriteLine("0. Exit"); //displays text
                Console.WriteLine(); //displays blank line

                string input = Console.ReadLine(); //sets user input to string

                if (input == "0") //if condition for user input
                {
                    break; //breaks from loop
                }
                else if (input == "1") //else if condition for user input
                {
                    cart.ViewShoppingCart(); //calls ViewShoppingCart method
                }
                else if (input == "2") //else if condition for user input
                {
                    Console.WriteLine("Please enter the product ID: "); //asks for user input
                    string PID = Console.ReadLine(); //sets user input to string
                    Console.WriteLine("Please enter the product name: "); //asks for user input
                    string PName = Console.ReadLine(); //sets user input to string
                    int PPrice = 0; //declares and initializes int
                    while (true) //while loop to loop input
                    {
                        Console.WriteLine("Please enter the product price: "); //asks for user input
                        try //try and catch to check for errors
                        {
                            PPrice = Convert.ToInt32(Console.ReadLine()); //sets user input to int
                            if (PPrice < 0) //if condition to see if input is less than 0
                            {
                                throw new ArgumentOutOfRangeException("Invalid price value"); //throws error message
                            }
                            break; //breaks from while loop
                        }
                        catch (Exception) //catch if error was detected
                        {
                            Console.WriteLine("Please enter a valid numeric value");
                        }
                    }
                    Product product = new Product(PID, PName, PPrice); //creates new product object
                    cart.AddProduct(product); //adds object to shopping cart
                }
                else if (input == "3") //else if condition for user input
                {
                    Console.WriteLine("Please enter the ID of the product you want to remove: "); //asks for input
                    string PID = Console.ReadLine(); //sets input to string
                    cart.RemoveProduct(PID); //removes object from shopping cart
                }
                else if (input == "4") //else if condition for user input
                {
                    Console.WriteLine($"The total price is ${cart.CalculateTotalPrice()}"); //displays price
                }
                else //else condition if invalid input
                {
                    Console.WriteLine("Please enter a valid option"); //displays text
                }
            }
            Console.Read(); //lets user read program
        }
    }
}
