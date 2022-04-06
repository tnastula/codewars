namespace DescendingOrder;

public class DescendingOrder
{
    public int Calculate(int num)
    {
        Dictionary<int, int> digitCount = new()
        {
            { 9, 0 },
            { 8, 0 },
            { 7, 0 },
            { 6, 0 },
            { 5, 0 },
            { 4, 0 },
            { 3, 0 },
            { 2, 0 },
            { 1, 0 },
            { 0, 0 },
        };

        int integralPart = num;
        do
        {
            integralPart = Math.DivRem(integralPart, 10, out int remainder);
            ++digitCount[remainder];
        } while (integralPart > 0);

        int result = 0;
        int currentPrecision = 1;
        for (int digit = 0; digit < 10; digit++)
        {
            for (int currentDigitCount = 0; currentDigitCount < digitCount[digit]; currentDigitCount++)
            {
                result += currentPrecision * digit;
                currentPrecision *= 10;
            }
        }

        return result;
    }
}