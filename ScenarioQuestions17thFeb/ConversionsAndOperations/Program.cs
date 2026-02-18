using System;

// Convert an integer Student ID 105 into a string and display it with the message:
// Student ID: ___
int StudentId = 105;
Console.WriteLine("Student ID: " + StudentId.ToString());

// Convert the string "45" into an integer and display:
// Available Seats: ___
string AvailableSeats = "45";
int availableSeats = int.Parse(AvailableSeats);
Console.WriteLine("Available Seats: " + availableSeats);

// Convert the string course fee "15000.50" into a decimal and display it.
string courseFee = "15000.50";
decimal CourseFee = decimal.Parse(courseFee);
Console.WriteLine(CourseFee);

// Convert an int discount 15 into a double and display it as:
// Discount Rate: ___
int discount = 15;
double Discount = (double)discount;
Console.WriteLine("Discount Rate: " + Discount);

// Convert a float attendance value 92.75f into a double and print it.
float attendance = 92.75f;
double Attendance = (double)attendance;
Console.WriteLine(Attendance);

// Convert the double duration 6.8 into an int and display the number of days.
double duration = 6.8;
int Duration = (int)duration;
Console.WriteLine(Duration);

// Convert the double temperature 37.45678 into a float and display the result.
double temperature = 37.45678;
float Temperature = (float)temperature;
Console.WriteLine(Temperature);

// Convert the decimal total amount 12345.6789m into a string formatted to 2 decimal places.
decimal totalAmount = 12345.6789m;
Console.WriteLine(totalAmount.ToString("F2"));

// Convert the character grade 'B' into its numeric (ASCII/Unicode) value.
char grade = 'B';
int numeric = (int)grade;
Console.WriteLine(numeric);

// Convert the boolean value false into a string and display:
bool value1 = false;
Console.WriteLine(value1.ToString());