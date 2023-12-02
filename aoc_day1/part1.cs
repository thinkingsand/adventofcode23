using System;
using System.Linq;

String input = "";
String[] lines = input.Split("\r\n");

int calibrations = 0;

foreach (String line in lines)
{
    string line_numbers = new String(line.
        Where(x => Char.IsDigit(x)).ToArray());
    string raw_value = $"{line_numbers[0]}{line_numbers[line_numbers.Length - 1]}";
    calibrations += int.Parse(raw_value);

}

Console.WriteLine(calibrations.ToString());