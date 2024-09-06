# CalculatorTask

This project is a calculator engine implemented in C# that supports a variety of mathematical operations with flexible delimiters. It includes comprehensive unit tests to ensure all functionalities are thoroughly tested.

### Features
The calculator provides the following features:

- **Supports multiple numbers**: Initially, the calculator supports up to 2 numbers using a comma delimiter. However, this limit can be removed by invoking `RemoveNumberLimit()`, allowing the calculator to handle more than 2 numbers.
- **Supports newline (`\n`) as an additional delimiter**: Numbers can be separated by either a comma or newline character.
- **Ignores numbers greater than 1000**: Any number larger than 1000 is excluded from the sum.
- **Custom single-character delimiter support**: Allows users to define their own single-character delimiters.
- **Custom multi-character delimiter support**: Supports multi-character delimiters as well.
- **Multiple custom delimiters**: Enables the use of multiple custom delimiters simultaneously.
- **Handles invalid numbers gracefully**: Any invalid numbers are treated as `0` and do not break the operation.
- **Throws exception for negative numbers**: If negative numbers are included in the input, an exception is thrown, listing all negative numbers in the exception message.

### Requirements
- .NET Core SDK (v6.0 or later)
- NUnit for testing
- NUnit3TestAdapter
- Microsoft.NET.Test.Sdk

### Running the Application

#### Clone the Repository:
```bash
git clone https://github.com/ericdotnet/CalculatorTask.git
cd calculatortask
```

#### Build the Project:
```bash
dotnet build
```

### Running the Unit Tests
The project uses NUnit for unit testing. Ensure the following NuGet packages are installed:

- NUnit
- NUnit3TestAdapter
- Microsoft.NET.Test.Sdk

#### Running Tests via Command Line:
To execute the tests, run the following command:
```bash
dotnet test
```

#### Running Tests in Visual Studio:
1. Open the solution in Visual Studio.
2. Navigate to the Test Explorer (`View -> Test Explorer`).
3. Click on **Run All** to execute all tests.

### Unit Test Cases

**Empty String Returns Zero**:  
- **Input**: `""`  
- **Expected Result**: `"0"`

**Single Number Returns the Same**:  
- **Input**: `"20"`  
- **Expected Result**: `"20"`

**Remove Number Limit Allows More Than Two Numbers**:  
- **Input**: `"1,2,3,4,5"`  
- **Expected Result**: `"15"` (after calling `RemoveNumberLimit()`)

**Newline Delimiter Returns Sum**:  
- **Input**: `"1\n2,3"`  
- **Expected Result**: `"6"`

**Numbers Greater Than 1000 Are Ignored**:  
- **Input**: `"2,1001,6"`  
- **Expected Result**: `"8"`

**Custom Single-Character Delimiter Returns Sum**:  
- **Input**: `"//#\n2#5"`  
- **Expected Result**: `"7"`

**Custom Multi-Character Delimiter Returns Sum**:  
- **Input**: `"//[***]\n11***22***33"`  
- **Expected Result**: `"66"`

**Multiple Custom Delimiters Return Sum**:  
- **Input**: `"//[*][!!][r9r]\n11r9r22!!33*44"`  
- **Expected Result**: `"110"`

**Invalid Numbers Are Ignored**:  
- **Input**: `"5,tytyt"`  
- **Expected Result**: `"5"`

**Negative Numbers Throw Exception**:  
- **Input**: `"1,-2,3"`  
- **Expected Result**: Throws an exception with message `"Negative numbers not allowed: -2"`

**Multiple Negative Numbers Throw Exception with All Negatives Listed**:  
- **Input**: `"1,-2,-3,4"`  
- **Expected Result**: Throws an exception with message `"Negative numbers not allowed: -2, -3"`
