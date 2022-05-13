namespace MergedStringChecker;

public class StringMerger
{
    public static bool isMerge(string complete, string s1, string s2)
    {
        List<StringPart> stringParts = new List<StringPart>(2);
        stringParts.Add(new StringPart(s1));
        stringParts.Add(new StringPart(s2));
        return isMerge(complete, stringParts);
    }

    private static bool isMerge(string complete, List<StringPart> stringParts)
    {
        for (var index = 0; index < complete.Length; index++)
        {
            var symbol = complete[index];
            List<StringPart> stringPartsMeetingCriterion = new List<StringPart>(stringParts.Count);
            foreach (StringPart stringPart in stringParts)
            {
                if (stringPart.Peek() == symbol)
                {
                    stringPartsMeetingCriterion.Add(stringPart);
                }
            }

            if (stringPartsMeetingCriterion.Count == 1)
            {
                stringPartsMeetingCriterion[0].MoveIndex();
                continue;
            }
             
            foreach (StringPart stringPartMeetingCriterion in stringPartsMeetingCriterion)
            {
                List<StringPart> newIterationStringParts = new List<StringPart>(stringParts.Count);
                foreach (StringPart stringPart in stringParts)
                {
                    StringPart newStringPart = stringPart.CreateFromRemaining();
                    if (stringPart == stringPartMeetingCriterion)
                    {
                        newStringPart.MoveIndex();
                    }
                    newIterationStringParts.Add(newStringPart);
                }

                if (isMerge(complete.Substring(index + 1), newIterationStringParts))
                {
                    return true;
                }
            }

            return false;
        }

        foreach (StringPart stringPart in stringParts)
        {
            if (!stringPart.DepletedLetters())
            {
                return false;
            }
        }

        return true;
    }
}