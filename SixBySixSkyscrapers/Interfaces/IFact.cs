namespace SixBySixSkyscrapers.Interfaces;

public interface IFact
{
    /// <summary>
    /// Checks whether fact is valid. If yes, returns indexes of modified buildings. 
    /// </summary>
    /// <param name="street">Street to check fact against</param>
    /// <returns>Indexes of modified buildings</returns>
    public bool Check(Street street);
}