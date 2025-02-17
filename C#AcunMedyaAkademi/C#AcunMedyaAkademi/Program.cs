using System;
class Program { 
    static void Main(string[] args) { 
        //ÖDEV 1
string name, surname, city, job;
int age;
Console.WriteLine("Enter your name:");
name = Console.ReadLine();
Console.WriteLine("Enter your lastname:");
surname = Console.ReadLine();
Console.WriteLine("Enter your city:");
city = Console.ReadLine();
Console.WriteLine("Enter your job:");
job = Console.ReadLine();
Console.WriteLine("Enter your age:");
age = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("\n--- User Information Card ---");
Console.WriteLine($"Name       : {name}");
Console.WriteLine($"Surname    : {surname}");
Console.WriteLine($"Age        : {age}");
Console.WriteLine($"City       : {city}");
Console.WriteLine($"Profession : {job}");
Console.WriteLine("-----------------------------");
        //ÖDEV 2
 Console.WriteLine("Welcome to calculation program\n Please enter two integer :)");
 int number1=Convert.ToInt32(Console.ReadLine());
 int number2=Convert.ToInt32(Console.ReadLine());
 if(number2==0) { Console.WriteLine("Error: Division by zero is not allowed.\r\n"); }
  
        Console.WriteLine($"Addition :{ number1+number2}");
        Console.WriteLine($"Subtraction :{number1 -number2}");
        Console.WriteLine($"Multiplication :{number1 * number2}");
        Console.WriteLine($"Division :{number1 / number2}");

        //ÖDEV 3
        Console.WriteLine("Please enter a/an sentence");
        string sentence= Console.ReadLine();

        Console.WriteLine($"Uppercase      : {sentence.ToUpper()}");
        Console.WriteLine($"Lowercase      : {sentence.ToLower()}");
        Console.WriteLine($"Lenght         : {sentence.Length}");
        Console.WriteLine($"First char     : {sentence[0]}");
        Console.WriteLine($"Last char      : {sentence[sentence.Length-1]}");
        Console.WriteLine($"Trimmed snt    : {sentence.Trim()}");
        //ÖDEV 4
        int birthYear;
        int currentYear=DateTime.Now.Year;
        Console.WriteLine("Please enter your birth year :");
        birthYear = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("You were born in "+birthYear+" and you are "+(currentYear-birthYear)+" years old.");
        //ÖDEV 5
        int randomInt;
        Random random= new Random();
        randomInt = random.Next(1, 100);
        Console.WriteLine("Random int :" + randomInt);
        //ÖDEV 6
        double avarage;
        Console.WriteLine("Enter first number :");
        int firstNumber=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter second number :");
        int secondNumber=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter third number :");
        int thirdNumber=Convert.ToInt32(Console.ReadLine());
        avarage=(firstNumber+secondNumber+thirdNumber)/3;
        Console.WriteLine("The average is :" + avarage);

    }
}