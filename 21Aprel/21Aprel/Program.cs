using System;
using System.Data.SqlClient;
using ClassLibrary.Metod;
using ClassLibrary.Data;
namespace _21Aprel
{
    class Program
    {
        static void Main(string[] args)
        {
            
            bool check = true;
            while (check)
            {
                Console.WriteLine("1-Add stadium");
                Console.WriteLine("2-Show all the stadium");
                Console.WriteLine("3-Show stadium by id");
                Console.WriteLine("4-Delete stadium by id");
                Console.WriteLine("5-Add user");
                Console.WriteLine("6-Show user");
                Console.WriteLine("Select number:");
                int answer = Convert.ToInt32(Console.ReadLine());
                switch (answer)
                {
                    case 1:
                        getAdd();
                        break;
                    case 2:
                        getInfo();
                        break;
                    case 3:
                        getInfoById();
                        break;
                    case 4:
                        getDeleteById();
                        break;
                    case 5:
                        addUser();
                        break;
                    case 6:
                        getInfoUser();
                        break;
                    default:
                        Console.WriteLine("You have to select only 0,1,2,3,4");
                        break;
                }
            }

        }
        static void getAdd() 
        {
            string name;
            
            do
            {
                Console.WriteLine("Write Name");
                name = Console.ReadLine();

            } while (String.IsNullOrWhiteSpace(name));

            decimal hourlyPrice;
            string hourlyPriceTool;
            do
            {
                Console.WriteLine("Write Hourlyprice");

                hourlyPriceTool = Console.ReadLine();

            } while (!decimal.TryParse(hourlyPriceTool, out hourlyPrice));

            int capacity;
            string capacityTool;
            do
            {
                Console.WriteLine("Write Capacity");
                capacityTool = Console.ReadLine();

            } while (!int.TryParse(capacityTool, out capacity));

            Stadium stadium = new Stadium();
            stadium.Name = name;
            stadium.HourlyPrice = hourlyPrice;
            stadium.Capacity = capacity;
            StadiumData newData = new StadiumData();
            newData.Add(stadium);

        }
        static void getInfo()
        {
            StadiumData newData = new StadiumData();
            var stadiums = newData.ShowData();
            foreach (var item in stadiums)
            {
                Console.WriteLine(item.Id + " " + item._name);
            }

        }
        static void getInfoById() 
        {
            Console.WriteLine("Write your id:");
            int answer; 
            string answerTool;
            do
            {
                Console.WriteLine("Write Capacity");
                answerTool = Console.ReadLine();

            } while (!int.TryParse(answerTool, out answer));
            StadiumData newData = new StadiumData();
            var stadiums = newData.ShowDataById(answer);
            if (stadiums.Count>0)
            {
                foreach (var item in stadiums)
                {
                    Console.WriteLine(item.Id + " " + item._name);
                }
            }
            else
            {
                Console.WriteLine("There is no stadiums like at this id");
            }
        }

        static void getDeleteById()
        {
            Console.WriteLine("Write your id:");
            int answer;
            string answerTool;
            do
            {
                Console.WriteLine("Write Capacity");
                answerTool = Console.ReadLine();

            } while (!int.TryParse(answerTool, out answer));

            StadiumData newData = new StadiumData();
            newData.DeleteById(answer);
            Console.WriteLine("Stadium is deleted");
        }

        static void addUser() 
        {
            string FullName;
            do
            {
                Console.WriteLine("Write Name");
                FullName = Console.ReadLine();

            } while (String.IsNullOrWhiteSpace(FullName));

            string email;

            do
            {
                Console.WriteLine("Write Email");
                email = Console.ReadLine();

            } while (String.IsNullOrWhiteSpace(email));
            User newUser = new User();
            newUser.FullName = FullName;
            newUser.Email = email;
            UserData newData = new UserData();
            newData.Add(newUser);
        }
        static void getInfoUser() 
        {
            UserData newData = new UserData();
            var users = newData.ShowData();
            foreach (var item in users)
            {
                Console.WriteLine(item.Id + " " + item.FullName);
            }

        }
    }
}
