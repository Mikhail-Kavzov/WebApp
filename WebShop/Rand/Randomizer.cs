namespace WebShop.Rand
{
    public static class Randomizer
    {
        public static int[] GenerateRange(int first, int second, int diff=4)
        {
            if (diff < 0)
                throw new ArgumentException("Incorrect parameter diff. Must be positive");
            if (second - first < diff)
                throw new ArgumentException("2nd parameter is less than diff");
            int localFirst = new Random().Next(first, second - diff);
            return new int[] { localFirst, localFirst + diff };
            
        }
    }
}
