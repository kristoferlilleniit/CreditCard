using System;

namespace CreditCard
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your ID code: ");
            string usersID = Console.ReadLine();

            if(ValidateID(usersID))
            {
                Console.WriteLine("Your ID is correct. ");
                if (GetAge(usersID))
                {
                    Console.WriteLine("Enter your credit card number: ");
                    string usersCC = Console.ReadLine();
                    if (ValidateCreditCard(usersCC))
                    {
                        Console.WriteLine("Your card number is correct, please enter your CVV:");
                        string usersCVV = Console.ReadLine();
                        if (ValidateCVV(usersCVV)) ;
                        {
                            Console.WriteLine("CVV is correct, your card has been accepted!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Wrong format, try again.");
                }
            }
               // GetAge(usersID);


        }

        public static bool ValidateID(string idCode)
        {
            if(idCode.Length == 11)
            {
                try
                {
                    long.Parse(idCode);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Wrong format: {e}");
                    return false;
                }
            }else
            {
                return false;
            }
        }

        public static void UserGender(string idCode)
        {
            int firstNum = Int32.Parse(idCode[0].ToString());

            if (firstNum == 1 || firstNum == 3 || firstNum == 5)
            {
                Console.WriteLine("Hello, Sir!");
            }
            else if (firstNum == 2 || firstNum == 4 || firstNum == 6)
            {
                Console.WriteLine("Hello, Madam!");
            }
        }

        public static int GetYear(string idCode)
        {
            string yearfromcode = idCode.Substring(1, 2);
            string year;
            if(int.Parse(idCode[0].ToString()) > 4)
            {
                year = "20" + yearfromcode;
            }else
            {
                year = "19" + yearfromcode;
            }

            int yearParsed = Int32.Parse(year);
            return yearParsed;
        }

        public static bool GetAge(string idCode)
        {
            int yearOfBirth = GetYear(idCode);

            DateTime now = DateTime.Now;
            int yearnow = Int32.Parse(now.Year.ToString());
            int age = yearnow - yearOfBirth;

            if(age < 18)
            {
                Console.WriteLine("You're not authorized to use the credit card.");
                return false;
            }else
            {
                return true;
               // UserGender(idCode);
            }
        }

        public static bool ValidateCreditCard(string CCNumber)
        {
            if(CCNumber.Length == 16)
            {
                try
                {
                    long.Parse(CCNumber);
                    return true;
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Wrong format: {e}");
                    return false;
                }
            }else
            {
                return false;
            }
        }

        public static bool ValidateCVV(string cvvnumber)
        {
            if (cvvnumber.Length == 3)
            {
                try
                {
                    Int32.Parse(cvvnumber);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Wrong format: {e}");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
