# CalculatorTask

CalculatorTask Project
This project is a calculator engine implemented in C# that supports various mathematical operations with different delimiters. It also includes comprehensive unit tests for all functionalities.

Features
The calculator performs the following operations:

Supports a maximum of 2 numbers using a comma delimiter. Throws an exception if more than 2 numbers are provided.
Remove the maximum constraint: Allows more than 2 numbers after calling RemoveNumberLimit().
Supports newline (\n) as a delimiter in addition to commas.
Ignores numbers greater than 1000.
Custom single-character delimiter support.
Custom multi-character delimiter support.
Multiple custom delimiters support.
Handles invalid numbers by treating them as 0.
Throws an exception for negative numbers, listing all negative numbers in the message.
Requirements
.NET Core SDK (v6.0 or later)
NUnit for testing
NUnit3TestAdapter
Microsoft.NET.Test.Sdk
Running the Application
1. Clone the Repository
git clone https://github.com/ericdotnet/CalculatorTask.git
cd calculatortask

2. Build the Project
dotnet build

3. Run the Unit Tests
The project uses NUnit for unit testing. Make sure the following NuGet packages are installed:

NUnit
NUnit3TestAdapter
Microsoft.NET.Test.Sdk
Running Tests via Command Line
To run the tests, execute the following command:
dotnet test

Running Tests in Visual Studio
Open the solution in Visual Studio.
Navigate to the Test Explorer (View -> Test Explorer).
Click on Run All to execute all tests.
Unit Test Cases
Below are the unit tests implemented for this project:

Empty String Returns Zero:

Input: ""
Expected Result: "0"
Single Number Returns the Same:

Input: "20"
Expected Result: "20"
More Than Two Numbers Throws Exception:

Input: "1,2,3"
Expected Result: Throws an exception with message "A maximum of 2 numbers is allowed."
Remove Number Limit Allows More Than Two Numbers:

Input: "1,2,3,4,5"
Expected Result: "15" (after calling RemoveNumberLimit())
Newline Delimiter Returns Sum:

Input: "1\n2,3"
Expected Result: "6"
Numbers Greater Than 1000 Are Ignored:

Input: "2,1001,6"
Expected Result: "8"
Custom Single-Character Delimiter Returns Sum:

Input: "//#\n2#5"
Expected Result: "7"
Custom Multi-Character Delimiter Returns Sum:

Input: "//[***]\n11***22***33"
Expected Result: "66"
Multiple Custom Delimiters Return Sum:

Input: "//[*][!!][r9r]\n11r9r22*33!!44"
Expected Result: "110"
Invalid Numbers Are Ignored:

Input: "5,tytyt"
Expected Result: "5"
Negative Numbers Throw Exception:

Input: "1,-2,3"
Expected Result: Throws an exception with message "Negative numbers not allowed: -2"
Multiple Negative Numbers Throw Exception with All Negatives Listed:

Input: "1,-2,-3,4"
Expected Result: Throws an exception with message "Negative numbers not allowed: -2, -3"

