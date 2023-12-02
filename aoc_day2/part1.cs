internal class Program
{
    static string input = "";
    static string[] colors = { "red", "green", "blue" };

    static Dictionary<string, int> limits = new Dictionary<string, int> { { "red",12 }, { "green",13 }, { "blue",14 } };
    private static int ParseInp(string instr)
    {
        string[] input_colonsplit = instr.Split(":");

        int GameID = int.Parse(input_colonsplit[0].Split(" ")[1]);

        string[] input_round_split = input_colonsplit[1].Split(";");

        foreach (string x in input_round_split)
        {
            string[] round_colors = x.Split(", ");

            foreach (string color in round_colors)
            {
                foreach (string color_match in colors)
                {
                    if (color.Contains(color_match))
                    {
                        int count = int.Parse(color.Where(x => Char.IsDigit(x)).ToArray());
                        if (count > limits[color_match])
                        {
                            return 0;
                        }
                    }
               }
            }

        }
        return GameID;
    }

    private static void Main(string[] args)
    {
        int game_id_count = 0;

        foreach (string x in input.Split("\r\n"))
        {
            game_id_count += ParseInp(x);
        }

        Console.WriteLine(game_id_count);
    }
}