namespace Comparable
{
    static class Algorithms
    {
        static public void Sort(IComparable[] objs)
        {
            for (int i = objs.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (objs[j].CompareTo(objs[j + 1]) > 0)
                    {
                        IComparable tmp = objs[j];
                        objs[j] = objs[j + 1];
                        objs[j + 1] = tmp; 
                    }
                }
            }
        }
    }

}