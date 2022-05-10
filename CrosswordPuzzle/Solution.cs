namespace CrosswordPuzzle;

public static class Solution
{
    public static string[] Words = new string[128]
    {
        "AA", "AB", "AD", "AE", "AG", "AH", "AI", "AL",
        "AM", "AN", "AR", "AS", "AT", "AW", "AX", "AY",
        "BA", "BE", "BI", "BO", "BY", "CH", "DA", "DE",
        "DI", "DO", "EA", "ED", "EE", "EF", "EH", "EL",
        "EM", "EN", "ER", "ES", "ET", "EW", "EX", "FA",
        "FE", "FY", "GI", "GO", "GU", "HA", "HE", "HI",
        "HM", "HO", "ID", "IF", "IN", "IO", "IS", "IT",
        "JA", "JO", "KA", "KI", "KO", "KY", "LA", "LI",
        "LO", "MA", "ME", "MI", "MM", "MO", "MU", "MY",
        "NA", "NE", "NI", "NO", "NU", "NY", "OB", "OD",
        "OE", "OF", "OH", "OI", "OK", "OM", "ON", "OO",
        "OP", "OR", "OS", "OU", "OW", "OX", "OY", "PA",
        "PE", "PI", "PO", "QI", "RE", "SH", "SI", "SO",
        "ST", "TA", "TE", "TI", "TO", "UG", "UH", "UM",
        "UN", "UP", "UR", "US", "UT", "WE", "WO", "XI",
        "XU", "YA", "YE", "YO", "YU", "ZA", "ZE", "ZO"
    };

    public static Dictionary<char, int> Values = new Dictionary<char, int>
    {
        { 'A', 1 }, { 'B', 3 }, { 'C', 3 }, { 'D', 2 }, { 'E', 1 }, { 'F', 4 }, { 'G', 2 },
        { 'H', 4 }, { 'I', 1 }, { 'J', 8 }, { 'K', 5 }, { 'L', 1 }, { 'M', 3 }, { 'N', 1 },
        { 'O', 1 }, { 'P', 3 }, { 'Q', 10 }, { 'R', 1 }, { 'S', 1 }, { 'T', 1 }, { 'U', 1 },
        { 'V', 4 }, { 'W', 4 }, { 'X', 8 }, { 'Y', 4 }, { 'Z', 10 }
    };

    public static List<object[]> Crossword2x2(string[] puzzle)
    {
        //  <----  hajime!
        throw new NotImplementedException();
    }
}