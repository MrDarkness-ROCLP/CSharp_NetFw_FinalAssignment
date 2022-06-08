using System;
using System.Threading;
using System.Data;

namespace FinalProject
{
    internal class Program
    {
        static void Main(String[] args)
        {
            Console.Clear();
            DatabaseConnection connection = new DatabaseConnection();
            for (int i = 0; i < 100; i++)
            {
                Console.Write("Loading.. ");
                Console.WriteLine(i + "%");
                Thread.Sleep(64);
                Console.Clear();
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t-- Hotel Booking Management System --");
                Console.WriteLine("\t\t\t\t-- Login System --");
                bool failed = false;
                Console.Write("Username -: ");
                string username = Console.ReadLine();
                Console.Write("Password -: ");
                string password = Console.ReadLine();
                // Execute SQL Data
                DataTable dt = connection.ExecuteDataQuery("select * from staff where staffName ='" + username + "' and staffPassword='" + password + "';");
                if (dt.Rows.Count > 0)
                {
                    failed = true;
                }

                if (failed)
                {
                    Console.Clear();
                    Console.WriteLine("Login Successful!!!");
                    Thread.Sleep(3000);
                    Console.Clear();
                    while (true)
                    {
                        Console.WriteLine("\t\t\t-- Hotel Booking Management System --");
                        Console.WriteLine("\t\t\t\t-- Booking Menu --");
                        Console.WriteLine("1) Add Staff account");
                        Console.WriteLine("2) Add Customer account");
                        Console.WriteLine("3) Create Booking");
                        Console.WriteLine("4) View All booking information and status");
                        Console.WriteLine("5) Cancel Booking");
                        Console.WriteLine("6) Update Booking Status");
                        Console.WriteLine("7) Logout");
                        Console.Write("Your Choice -: ");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (choice == 1)
                        {
                            Thread.Sleep(1000);
                            Console.Clear();
                            Console.WriteLine("\t\t\tAdd Staff account");
                            Console.WriteLine("");
                            Console.Write("Name: ");
                            string staffName = Console.ReadLine();
                            Console.Write("Password: ");
                            string staffpw = Console.ReadLine();
                            string query = "insert into staff values('" + staffName + "','" + staffpw + "');";
                            bool result = connection.ExecuteNonDataQuery(query);
                            if (result)
                            {
                                Console.Clear();
                                Console.WriteLine("Staff Registration Successful");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Staff Registration Failed");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                        }
                        else if (choice == 2)
                        {
                            Thread.Sleep(1000);
                            Console.Clear();
                            Console.WriteLine("\t\t\tCreate Customer");
                            Console.WriteLine("");
                            Console.WriteLine("Taking Customer Personal Information...");
                            Console.WriteLine("");
                            Console.Write("First name: ");
                            string customerFirstName = Console.ReadLine();
                            Console.Write("Last name: ");
                            string customerLastName = Console.ReadLine();
                            Console.Write("Gender: ");
                            string gender = Console.ReadLine();
                            Console.Write("Identification number: ");
                            string ic = Console.ReadLine();
                            Console.Write("E-mail: ");
                            string email = Console.ReadLine();
                            Console.Write("Phone number: ");
                            int phoneNum = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Emergency phone num: ");
                            int EphoneNum = Convert.ToInt32(Console.ReadLine());
                            string query = "insert into customerInfo values('" + customerFirstName + "','" + customerLastName + "' , '" + gender + "' , '" + ic + "' , '" + email + "' , '" + phoneNum + "' , '" + EphoneNum + "');";
                            bool result = connection.ExecuteNonDataQuery(query);
                            if (result)
                            {
                                Console.Clear();
                                Console.WriteLine("Customer Registration Successful");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Customer Registration Failed");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                        }
                        else if (choice == 3)
                        {
                            bool booked = false;
                            Thread.Sleep(1000);
                            Console.Clear();
                            Console.WriteLine("\t\t\tCreate Booking");
                            Console.WriteLine("");
                            Console.WriteLine("Taking Customer Booking Information...");
                            Console.WriteLine("");
                            Console.Write("Enter Customer First Name: ");
                            string customerFirstName = Console.ReadLine();
                            Console.Write("Enter Customer Last Name: ");
                            string customerLastName = Console.ReadLine();
                            DataTable getrs1 = connection.ExecuteDataQuery("select * from customerInfo where customerFirstName ='" + customerFirstName + "' and customerLastName ='" + customerLastName + "';");
                            if (getrs1.Rows.Count > 0)
                            {
                                booked = true;
                            }

                            if (booked)
                            {
                                Console.WriteLine("Room Type --");
                                Console.WriteLine("1. Standard Suite");
                                Console.WriteLine("2. Deluxe Suite");
                                Console.WriteLine("3. Presidential Suite");
                                Console.WriteLine("4. Honeymoon Suite");
                                Console.Write("Your Choice: ");
                                int selection = Convert.ToInt32(Console.ReadLine());
                                string roomType = "";
                                if (selection == 1)
                                {
                                    roomType = "Standard Suite";
                                }
                                else if (selection == 2)
                                {
                                    roomType = "Deluxe Suite";
                                }
                                else if (selection == 3)
                                {
                                    roomType = "Presidential Suite";
                                }
                                else if (selection == 4)
                                {
                                    roomType = "Honeymoon Suite";
                                }

                                Console.WriteLine("Reservation duration");
                                Console.Write("How many days: ");
                                int days = Convert.ToInt32(Console.ReadLine());
                                int night = days - 1;
                                string s = days.ToString();
                                string s2 = night.ToString();
                                string reservationDuration = s + "D" + s2 + "N";
                                Console.Write("Occupancy: ");
                                int occupancy = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Confirmation: 1) yes 2) no : ");
                                int a = Convert.ToInt32(Console.ReadLine());
                                if (a == 1)
                                {
                                    string query = "insert into bookingInfo values('" + customerFirstName + "','" + customerLastName + "','" + roomType + "','" + reservationDuration + "' , '" + occupancy + "', '" + "Pending" + "');";
                                    bool result = connection.ExecuteNonDataQuery(query);
                                    if (result)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Booking Successful");
                                        DataTable getresult = connection.ExecuteDataQuery("select bookingID from bookingInfo where customerFirstName ='" + customerFirstName + "' and customerLastName ='" + customerLastName + "'and bookingRoomType ='" + roomType + "' and bookingReservationDuration='" + reservationDuration + "' and bookingStatus='Pending'" + ";");
                                        Console.Write("Your Booking ID: ");
                                        Console.WriteLine(getresult.Rows[0][0].ToString());
                                        Thread.Sleep(3000);
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Booking Failed");
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                    }
                                }
                                else if (a == 2)
                                {
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid Customer");
                                Thread.Sleep(3000);
                                Console.Clear();
                            }
                        }
                        else if (choice == 4)
                        {
                            Console.Clear();
                            Console.WriteLine("\t\t\tAll Booking List");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine("Booking ID\tFirst Name\tLast Name\tRoom Type\t\tDays\t  Occupancy\tStatus");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                            DataTable getall = connection.ExecuteDataQuery("select * from bookingInfo;");
                            for (int i = 0; i < getall.Rows.Count; i++)
                            {
                                Console.Write(getall.Rows[i][0].ToString() + "\t\t" + getall.Rows[i][1].ToString());
                                Console.Write("\t\t" + getall.Rows[i][2].ToString() + "\t\t" + getall.Rows[i][3].ToString());
                                Console.Write("\t\t" + getall.Rows[i][4].ToString() + "\t\t" + getall.Rows[i][5].ToString());
                                Console.WriteLine("\t" + getall.Rows[i][6].ToString());
                            }

                            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                            Console.Write("Press any key to continue . . . ");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else if (choice == 5)
                        {
                            Console.Clear();
                            Console.WriteLine("\t\t\tDelete Booking");
                            Console.Write("Enter Booking ID: ");
                            int bookingID = Convert.ToInt32(Console.ReadLine());
                            DataTable check = connection.ExecuteDataQuery("select * from bookingInfo where bookingID ='" + bookingID + "';");
                            if (check.Rows.Count == 0)
                            {
                                Console.WriteLine("Booking ID not found...");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                            else
                            {
                                Console.Write("Confirmation: 1) yes 2) no : ");
                                int a = Convert.ToInt32(Console.ReadLine());
                                if (a == 1)
                                {
                                    DataTable getrs1 = connection.ExecuteDataQuery("delete from bookingInfo where bookingID ='" + bookingID + "';");
                                    Console.WriteLine("Delete Successful");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                }
                                else
                                {
                                }
                            }
                        }
                        else if (choice == 6)
                        {
                            Console.Clear();
                            Console.WriteLine("\t\t\tUpdate Booking Status");
                            Console.Write("Enter Booking ID: ");
                            int bookingID = Convert.ToInt32(Console.ReadLine());
                            DataTable check = connection.ExecuteDataQuery("select * from bookingInfo where bookingID ='" + bookingID + "';");
                            if (check.Rows.Count == 0)
                            {
                                Console.WriteLine("Booking ID not found...");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Booking Status Options -");
                                Console.WriteLine("1) Check-in");
                                Console.WriteLine("2) Check-out");
                                Console.WriteLine("3) Extend Stay");
                                Console.Write("Enter Desired Status Change: ");
                                int status = Convert.ToInt32(Console.ReadLine());
                                if (status == 1)
                                {
                                    string query = "UPDATE bookingInfo SET bookingStatus=" + "'Check-in' WHERE bookingID =" + bookingID + ";";
                                    bool result = connection.ExecuteNonDataQuery(query);
                                    Console.WriteLine("Booking ID: " + bookingID + " has checked in");
                                    Thread.Sleep(3000);
                                    Console.Clear();
                                }
                                else if (status == 2)
                                {
                                    string query = "UPDATE bookingInfo SET bookingStatus=" + "'Check-out' WHERE bookingID =" + bookingID + ";";
                                    bool result = connection.ExecuteNonDataQuery(query);
                                    Console.WriteLine("Booking ID: " + bookingID + " has checked out");
                                    Thread.Sleep(3000);
                                    Console.Clear();
                                }
                                else if (status == 3)
                                {
                                    Console.Write("Extend how many days: ");
                                    int days = Convert.ToInt32(Console.ReadLine());
                                    int night = days - 1;
                                    string s = days.ToString();
                                    string s2 = night.ToString();
                                    string reservationDuration = s + "D" + s2 + "N";
                                    string query = "UPDATE bookingInfo SET bookingReservationDuration='" + reservationDuration + "', bookingStatus= 'Extend' WHERE bookingID ='" + bookingID + "';";
                                    bool result = connection.ExecuteNonDataQuery(query);
                                    Console.WriteLine("Booking ID: " + bookingID + " has extended their stay.");
                                    Thread.Sleep(3000);
                                    Console.Clear();
                                }
                            }
                        }
                        else if (choice == 7)
                        {
                            Console.Clear();
                            Console.WriteLine("Logged Out");
                            Thread.Sleep(10000);
                            System.Environment.Exit(1);
                        }
                    }
                }
                else
                {
                }
            }
        }
    }
}