using System;
using System.IO;

namespace Civciv
{
    class Assignment
    {
        class Car //car class to car saling
        {
            private string 
                brand = "",
                model = "";
            private int 
                price = 0,
                year = 0, 
                kilometers = 0, 
                damageAmount = 0;
            private Person
                owner;

            // public functions to gets/sets car's informations
            public Person Owner
            {
                get;
                set;
            }
            public string Brand
            {
                get { return brand; }
                set { brand = value; }
            }
            public string Model
            {
                get { return model; } 
                set { model = value; } 
            }
            public int Price
            {
                get { return price; }
                set { price = value; }
            }
            public int Year
            {
                get { return year; }
                set { year = value; }
            }
            public int DamageAmount
            {
                get { return damageAmount; }
                set { damageAmount = value; }
            }
            public int Kilometers
            {
                get { return kilometers; }
                set { kilometers = value; }
            }

        }

        class Person //person class to user seller/buyer
        {
            private int
                age = 0,
                money = 0; 
            private string 
                name = "",
                username = "",
                identityNumber = "",
                phoneNum = "", 
                password = "";
            private Car 
                carArray = new Car() { };

            // public functions to gets/sets person's informations

            public int Age
            {
                get { return age; }
                set { age = value; }
            }
            public int Money
            {
                get { return money; }
                set { money = value; }
            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public string Username
            {
                get { return username; }
                set { username = value; }
            }
            public string IdentityNumber
            {
                get { return identityNumber; }
                set { identityNumber = value; }
            }
            public string PhoneNum
            {
                get { return phoneNum; }
                set { phoneNum = value; }
            }
            public string Password
            {
                get { return password; }
                set { password = value; }
            }
            public Car CarArray
            {
                get { return carArray; }
                set { carArray = value; }
            }

        }
        // Main Method
        public static void Main()
        {
            try
            {
                int 
                    personID = 0, 
                    carID = 0,
                    id = 0;

                string? 
                    statement, 
                    choice = "";

                Person[] 
                    users = new Person[5];

                Car[] 
                    onSaleCars = new Car[5];

                while (true)
                {
                    Welcome:
                    Console.WriteLine(
                        "Welcome to car sale!\n" +
                        "------------------------------------------\n" +
                        "*To continue please Sign in: (press 1).\n" +
                        "*Don't have an account? Sign up: (press 2).\n" +
                        "*Users info: (press 3).\n" +
                        "*To exit, please press 'q'."
                );
                    if (personID == users.Length) // not to any exception occurs because of array index out of range
                    {
                        Array.Resize(ref users, users.Length + 1);
                    }

                    statement = Console.ReadLine();
                    if (statement == "q") // want to leave statement
                    {
                        break;
                    }

                    else if (statement == "1") //signIn statement
                    {
                        Login:
                        Console.WriteLine("Enter your username or name: (to cancel please press q)");
                        var name = Console.ReadLine();

                        if (name == "q")
                        {
                            goto Welcome;
                        }

                        Console.WriteLine("Enter your password: ");
                        var password = Console.ReadLine();

                        for (int j = 0; j < personID; j++)
                        {
                            if ((users[j].Name == name || users[j].Username == name) && users[j].Password == password) //signin is successfull
                            {
                                Session:
                                Console.WriteLine(
                                    "Welcome!"               +
                                    "What do you want to do:\n"+
                                    "1- Buy a car:\n"          +
                                    "2- Sell a car:\n" +
                                    "3- Log out:"
                                    );
                                choice = Console.ReadLine();

                                if(choice == "1") // wants to buy
                                {
                                    if(carID == 0)
                                    {
                                        Console.WriteLine("There is no car on sale!");
                                        goto Session;
                                    }
                                    else 
                                    {

                                        Console.WriteLine(
                                            "Vehicles on sale:\n" +
                                            "----------------------------------------------------"
                                            );

                                        for (int k = 0; k < carID; k++)
                                        {
                                            Console.WriteLine(
                                        "\nCar ID: " + k +
                                        "\nOwner: " + onSaleCars[k].Owner.Name +
                                        "\nPrice: " + onSaleCars[k].Price + "TL" +
                                        "\nBrand: " + onSaleCars[k].Brand +
                                        "\nModel: " + onSaleCars[k].Model +
                                        "\nYear: " + onSaleCars[k].Year +
                                        "\nKilometers: " + onSaleCars[k].Kilometers +
                                        "\nDamage Amount: " + onSaleCars[k].DamageAmount
                                        );
                                        }
                                        Console.WriteLine(
                                            "----------------------------------------------------\n" +
                                            "Select car ID to buy:"
                                            );
                                        id = Convert.ToInt32(Console.ReadLine());

                                        if ((users[j].Username != onSaleCars[id].Owner.Name) &&(users[j].Money > onSaleCars[id].Price)) // purchase successfull
                                        {

                                            users[j].Money = users[j].Money - onSaleCars[id].Price;
                                            onSaleCars[id].Owner.Money = onSaleCars[id].Owner.Money + onSaleCars[id].Price;
                                            onSaleCars[id].Owner = users[j];


                                            Console.WriteLine("Car purchase successful!\n\n");

                                            goto Session;
                                        }
                                        else if ((users[j].Username == onSaleCars[id].Owner.Name))  //trying to buy his/her own car
                                        {
                                            Console.WriteLine("You can not buy your own car! \n");
                                            goto Session;

                                        }
                                        else if (!(users[j].Money > onSaleCars[id].Price)) // Insufficient money
                                        {
                                            Console.WriteLine("Insufficient money! \n");
                                            goto Session;
                                        }
                                        else // something happened
                                        {
                                            Console.WriteLine("Something went wrong :( \n");
                                        }



                                        //goto Session;
                                    }
                                }
                                else if (choice == "2") // wants to sell
                                {
                                    Car newCar = new Car();
                                    Console.WriteLine("Please enter the features of the car:");

                                    Console.WriteLine("Brand:");
                                    newCar.Brand = Console.ReadLine();

                                    Console.WriteLine("Model:");
                                    newCar.Model = Console.ReadLine();

                                    Console.WriteLine("Price: (Turkish Lira)");
                                    newCar.Price = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Year:");
                                    newCar.Year = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Kilometers:");
                                    newCar.Kilometers = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("DamageAmount:");
                                    newCar.DamageAmount = Convert.ToInt32(Console.ReadLine());

                                    newCar.Owner = users[j];

                                    onSaleCars[carID] = newCar;
                                    Console.WriteLine(
                                        "***********************************************" +
                                        "\nCar register is successful!" +
                                        "\nCar ID: " + carID +
                                        "\nOwner: " + newCar.Owner.Name +
                                        "\nPrice " + newCar.Price +
                                        "\nBrand: " + newCar.Brand +
                                        "\nModel " + newCar.Model +
                                        "\nYear: " + newCar.Year +
                                        "\nKilometers: " + newCar.Kilometers +
                                        "\nDamage Amount: " + newCar.DamageAmount + "\n\n" +
                                        "***********************************************\n\n"
                                        );
                                    carID++;
                                    goto Session;
                                }
                                else if (choice == "3") //logout
                                {
                                    goto Welcome;
                                }
                                else
                                {
                                    Console.WriteLine("Typed wrong!");
                                    goto Session;
                                }


                            }
                        }
                        Console.WriteLine("\nUsername or password is wrong, please try again!\n\n");
                        goto Login;
                    }

                    else if (statement == "2") //signUp statement
                    {
                        try
                        {
                            Person newUser = new Person();
                            Console.WriteLine("Enter your name: ");
                            newUser.Name = Console.ReadLine();

                            Console.WriteLine("Enter your username: ");
                            newUser.Username = Console.ReadLine();

                            Console.WriteLine("Enter your password: ");
                            newUser.Password = Console.ReadLine();

                            Console.WriteLine("Enter your age: ");
                            newUser.Age = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter your Identity Number: ");
                            newUser.IdentityNumber = Console.ReadLine();

                            Console.WriteLine("Money: ");
                            newUser.Money = Convert.ToInt32(Console.ReadLine());

                            users[personID] = newUser;
                            Console.WriteLine(
                                "\n\nSigning is successful!\n" +
                                "\nIndex: " + personID +
                                "\nUsername: " + newUser.Username +
                                "\nName: " + newUser.Name +
                                "\nAge: " + newUser.Age +
                                "\nIdentityNumber: " + newUser.IdentityNumber +
                                "\nMoney: " + newUser.Money
                                );

                            personID++;

                            Console.WriteLine("\n ***Directing to main page.***\n\n\n");

                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    else if (statement == "3") //info 
                    {
                        if(users[0].Name == null)
                        {
                            break;
                        }
                        Console.WriteLine("**********************************************\n");
                        for (int j = 0; j < personID; j++)
                        {
                            if (users[j].Name == null)
                            {
                                break;
                            }
                            Console.WriteLine("\nUser-" + j + ": " + users[j].Name);
                        }
                        Console.WriteLine("**********************************************\n");
                        Console.WriteLine("\n ***Directing to main page.***\n\n");
                    }
                    else //Wrong typed statement
                    {
                        Console.WriteLine("You have entered wrong, please try again: \n\n");
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
    }
}
