 static Tuple<int, int> FindTuple(int[] arr, int target)
{
    int sum = arr[0];
    int i = 0, j = 0;

    while (i < arr.Length)
    {


        if (sum > target)
        {
            sum -= arr[j];
            j++;
        }
        else if (sum < target)
        {
            i++;
            sum += arr[i];

        }
        else
        {
            return Tuple.Create(j, i);
        }

    }
    return Tuple.Create(-1, -1);
}

int[] a= [1,2,3,4,5,6,7,8,9];
		  
Console.WriteLine(FindTuple(a, 18)); //(2, 5)

//* big-o : O(n) => could be O(2n) when the target is the last element in the array, so i and j will be traversed n times each so it will be 2n.