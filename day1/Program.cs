using System.Text.RegularExpressions;

String input = "";
String[] lines = input.Split("\r\n");
String asm_number = "";
int count = 0;

var numbers = new Dictionary<string, int>
        {{"zero",0},{"one",1},{"two",2},{"three",3},{"four",4},
        {"five",5},{"six",6},{"seven",7},{"eight",8},{"nine",9},
        {"0",0},{"1",1},{"2",2},{"3",3},{"4",4},
        {"5",5},{"6",6},{"7",7},{"8",8},{"9",9} };

var numbers_gen = new SortedDictionary<int, int> { };

foreach (String line in lines)
{
    asm_number = "";
    numbers_gen.Clear();
    foreach(KeyValuePair<string, int> x in numbers)
    {
        var rx = new Regex(x.Key, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        Match match = rx.Match(line);

        while (match.Success)
        {
            numbers_gen[match.Index] = numbers[match.Value];
            match = match.NextMatch();
        }
    }

    foreach (var y in numbers_gen)
    {
        asm_number = asm_number + y.Value;
    }

    if (asm_number != "")
    {
        string raw_value = $"{asm_number[0]}{asm_number[asm_number.Length - 1]}";

        //Console.WriteLine(raw_value);
        count += int.Parse(raw_value);
    }
}

Console.WriteLine(count.ToString());