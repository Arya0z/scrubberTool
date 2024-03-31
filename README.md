Scrober Tool
Overview
Scrober Tool is a .NET MVC application designed to sequence and format text data from Excel files based on user-defined letter lengths. This tool provides a convenient way to convert Excel data into a text file while customizing the sequence of letters according to specific requirements.

Features
Sequence Editing: Allows users to define the sequence of letters based on the desired length.
Excel to Text Conversion: Converts data from Excel files into formatted text files.
Customization: Users can specify the length and sequence of letters according to their needs.
Output Options: Provides options for saving the formatted text file locally.
Requirements
.NET Framework 4.8
Microsoft Excel (for Excel file processing)
Installation
Clone the repository to your local machine.
Open the solution in Visual Studio.
Build the solution to ensure all dependencies are resolved.
Usage
Launch the Scrober Tool application.
Upload an Excel file containing the data you want to convert.
Specify the desired letter length and sequence.
Click the "Convert" button to generate the formatted text file.
Save the output text file to your desired location.
Example
Let's say you have an Excel file containing the following data:

Copy code
Name    Age
John    30
Alice   25
Bob     35
And you want to convert this data into a text file with a sequence length of 3:

Copy code
Njo
Age
hn 
Ali
Bob
ce 
You can achieve this using the Scrober Tool by setting the letter length to 3 and defining the sequence accordingly.
