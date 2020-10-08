namespace Comparable
{
    public interface IComparable
    {
        // Returnerar ett heltal som är:
        // - mindre än 0 om det här objektet är mindre än det andra
        // - exakt 0 om objekten är likvärdiga
        // - större än 0 om det här objektet är större än det andra
        int CompareTo(object other);
    }
}