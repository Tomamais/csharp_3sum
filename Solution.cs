public class Solution 
{
    private readonly int max = 3000;
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var result = new List<IList<int>>();
        if (nums.Count() >= max) return result;

        var triplet = new List<int>();

        for (int i = 0; i < nums.Count(); i++)
        {
            triplet.Add(nums[i]);
            for (int j = 0; j < nums.Count(); j++)
            {
                if (i != j)
                {
                    triplet.Add(nums[j]);
                    for (int k = 0; k < nums.Count(); k++)
                    {
                        if (j != k && k != i)
                        {
                            triplet.Add(nums[k]);
                            // System.Console.WriteLine("DEBUG: " + string.Join(",", triplet));
                            if (triplet.Sum() == 0)
                            {
                                TryAddingTriplet(result, triplet);
                                triplet = new List<int>(triplet.ToList());
                            }
                            triplet.RemoveAt(triplet.Count - 1);
                        }
                    }
                    triplet.RemoveAt(triplet.Count - 1);
                }
            }
            triplet.RemoveAt(triplet.Count - 1);
        }

        return result;
    }

    private static List<int> TryAddingTriplet(List<IList<int>> result, List<int> triplet)
    {
        // check if triplet is not a repetition
        if (result.Count > 0)
        {
            bool isRepeated = false;
            foreach (IList<int> j in result)
            {
                isRepeated = j.OrderBy(x => x).SequenceEqual(triplet.OrderBy(x => x));
                if (isRepeated) break;
            }

            if (!isRepeated)
            {
                AddTripletIfValid(result, triplet);
            }
        }
        else
        {
            AddTripletIfValid(result, triplet);
        }
        triplet = new List<int>();
        return triplet;
    }

    private static void AddTripletIfValid(List<IList<int>> result, List<int> triplet)
    {
        if (triplet.Sum() == 0)
            result.Add(triplet);
    }
}