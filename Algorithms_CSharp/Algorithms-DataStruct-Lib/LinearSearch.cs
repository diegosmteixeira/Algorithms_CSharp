namespace Algorithms_CSharp
{
    internal class LinearSearch
    {
        /*
         *      [All the methods represents a Linear Search]
         * ----------------------------------------------------------
         * * they all work for linear time in the wrost case - O(N) *
         * ----------------------------------------------------------
        */

        class Customer
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public DateTime BirthDate { get; set; }
        }
        private static bool Exists(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                    return true;
            }
            return false;
        }

        //Linear Search - Time Complexity O(N)
        private static int IndexOf(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                    return i;
            }
            return -1;
        }

        public class CustomersComparer : IEqualityComparer<Customer>
        {
            bool IEqualityComparer<Customer>.Equals(Customer? x, Customer? y) => x.Age == y.Age && x.Name == y.Name;

            //Delegate GetHashCode to built-in mechanism
            int IEqualityComparer<Customer>.GetHashCode(Customer obj) => obj.GetHashCode();
        }

        static void ProgramMain()
        {
            var customersList = new List<Customer>()
            {
                new Customer { Age = 3, Name = "Ann"},
                new Customer { Age = 16, Name = "Bill"},
                new Customer { Age = 20, Name = "Rose"},
                new Customer { Age = 14, Name = "Rob"},
                new Customer { Age = 28, Name = "Bill"},
                new Customer { Age = 14, Name = "John"},
            };

            var intList = new List<int>() { 1, 4, 2, 7, 5, 9, 12, 3, 2, 1 };

            //linear search method (list)
            bool contains = intList.Contains(3);

            //if pass contains on a List of custom type, then you may want to pass a second argument
            //which should be an object which implements the equality compare
            bool contains2 = customersList.Contains(new Customer { Age = 14, Name = "Rob" }, new CustomersComparer());

            bool exists = customersList.Exists(customer => customer.Age == 28);

            int min = intList.Min();
            int max = intList.Max();

            int youngestCustomerAge = customersList.Min(customer => customer.Age);

            Customer bill = customersList.Find(customer => customer.Name == "Bill");
            Customer lastBill = customersList.FindLast(customer => customer.Name == "Bill");
            Customer lastBill2 = customersList.Last(customer => customer.Name == "Bill");

            List<Customer> customers = customersList.FindAll(customer => customer.Age > 18);
            IEnumerable<Customer> whereAge = customersList.Where(customer => customer.Age > 18);

            int index1 = customersList.FindIndex(customer => customer.Age == 14);
            int lastIndex = customersList.FindIndex(customer => customer.Age > 18);

            int indexOf = intList.IndexOf(2);
            int lastindexOf = intList.LastIndexOf(2);

            //from list
            bool isTrueForAll = customersList.TrueForAll(customer => customer.Age > 10);

            //from linq
            bool all = customersList.All(customer => customer.Age > 18);
            bool allThereAny = customersList.Any(customer => customer.Age == 3);
            int count = customersList.Count(customer => customer.Age > 18);

            Customer firstBill = customersList.First(customer => customer.Name == "Bill");
            Customer singleAnn = customersList.Single(customer => customer.Name == "Ann");
        }
    }
}
