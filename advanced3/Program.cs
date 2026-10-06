namespace advanced3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exercise1();
            Exercise2();
            Exercise3();
            Exercise4();
            Exercise5();
            Exercise6();
        }
        #region Exercise 1: Student Grade Manager (List<int>)
        static void Exercise1()
        {
            Console.WriteLine("===== Exercise 1: Student Grade Manager =====");

            List<int> grades = new List<int> { 85, 92, 78, 95, 88, 70, 100, 65 };

            Console.WriteLine("Grades: " + string.Join(", ", grades));
            Console.WriteLine("Count: " + grades.Count);
            Console.WriteLine("First grade: " + grades[0]);
            Console.WriteLine("Last grade: " + grades[grades.Count - 1]);

            grades.Sort();
            Console.WriteLine("Sorted ascending: " + string.Join(", ", grades));

            int firstAbove90 = grades.Find(g => g > 90);
            Console.WriteLine("First grade above 90: " + firstAbove90);

            List<int> failing = grades.FindAll(g => g < 75);
            Console.WriteLine("Failing grades (<75): " + string.Join(", ", failing));

            int removed = grades.RemoveAll(g => g < 75);
            Console.WriteLine($"Removed {removed} failing grades. Remaining: " + string.Join(", ", grades));

            Console.WriteLine("Any grade equals 100? " + grades.Contains(100));

            List<string> gradeLabels = grades.Select(g => $"Grade: {g}").ToList();
            Console.WriteLine("Labels: " + string.Join(" | ", gradeLabels));
            Console.WriteLine();
        }

        #endregion

        #region Exercise 2: Leaderboard (SortedDictionary<int, string>)
        static void Exercise2()
        {
            Console.WriteLine("===== Exercise 2: Leaderboard =====");

            SortedDictionary<int, string> board = new SortedDictionary<int, string>
        {
            { 500, "Abdallah" },
            { 200, "atef" },
            { 800, "ahmed" },
            { 350, "ali" }
        };

            Console.WriteLine("Leaderboard (sorted by score):");
            foreach (var entry in board)
                Console.WriteLine($"  {entry.Key} => {entry.Value}");

            Console.WriteLine("First key: " + board.Keys.First());
            Console.WriteLine("First value: " + board.Values.First());

            Console.WriteLine("Score 500 exists? " + board.ContainsKey(500));

            if (board.TryGetValue(999, out string player))
                Console.WriteLine("Player with 999: " + player);
            else
                Console.WriteLine("No player with score 999.");

            board.Remove(200);
            Console.WriteLine("After removing score 200:");
            foreach (var entry in board)
                Console.WriteLine($"  {entry.Key} => {entry.Value}");
            Console.WriteLine();
        }


        #endregion

        #region Exercise 3: Phone Book (Dictionary<string, string>)
        static void Exercise3()
        {
            Console.WriteLine("===== Exercise 3: Phone Book =====");

            Dictionary<string, string> book = new Dictionary<string, string>
        {
            { "Abdallah", "0100-111-1111" },
            { "Atef",  "0111-222-2222" },
            { "Ali",   "0122-333-3333" },
            { "Ahmed",  "0155-444-4444" }
        };

            // [] syntax: adds if new, updates if it exists
            book["Omar"] = "0100-555-5555";
            book["Sara"] = "0111-999-9999";   // update
            Console.WriteLine("After [] add/update:");
            foreach (var c in book)
                Console.WriteLine($"  {c.Key}: {c.Value}");

            // .Add() with a duplicate key -> exception
            try
            {
                book.Add("Ahmed", "0100-000-0000");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Add() error: " + ex.Message);
            }

            // .TryAdd() with a duplicate key -> returns false
            bool added = book.TryAdd("Ahmed", "0100-000-0000");
            Console.WriteLine("TryAdd(\"Ahmed\") succeeded? " + added);

            // Search for a contact that doesn't exist
            if (book.TryGetValue("Khaled", out string phone))
                Console.WriteLine("Khaled: " + phone);
            else
                Console.WriteLine("Khaled was not found.");

            // Fallback value
            Console.WriteLine("Khaled (fallback): " + book.GetValueOrDefault("Khaled", "Not Found"));

            // Keys on one line, Values on another
            Console.WriteLine("Keys:   " + string.Join(", ", book.Keys));
            Console.WriteLine("Values: " + string.Join(", ", book.Values));
            Console.WriteLine();
        }


        #endregion

        #region Exercise 4: Unique Email Validator (HashSet<T>) 

        static void Exercise4()
        {
            Console.WriteLine("===== Exercise 4: Unique Email Validator =====");

            HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            string[] input = { "ahmed@test.com", "Ali@test.com", "Abdallah@test.com", "atef@Test.Com" };

            foreach (string e in input)
                Console.WriteLine($"  Add(\"{e}\") -> {emails.Add(e)}");

            Console.WriteLine("Count: " + emails.Count);
           
            int[] a = { 1, 2, 3, 4, 5 };
            int[] b = { 4, 5, 6, 7, 8 };

            // Each operation modifies the set, so use a fresh copy every time
            var union = new HashSet<int>(a);
            union.UnionWith(b);
            Console.WriteLine("UnionWith:     " + string.Join(", ", union));

            var intersect = new HashSet<int>(a);
            intersect.IntersectWith(b);
            Console.WriteLine("IntersectWith: " + string.Join(", ", intersect));

            var except = new HashSet<int>(a);
            except.ExceptWith(b);
            Console.WriteLine("ExceptWith:    " + string.Join(", ", except));

            var setA = new HashSet<int>(a);
            var small = new HashSet<int> { 1, 2 };
            Console.WriteLine("Is {1,2} a subset of Set A? " + small.IsSubsetOf(setA));
            Console.WriteLine();
        }

        #endregion

        #region  Exercise 5: Print Queue Simulator (Queue<string>)
        static void Exercise5()
        {
            Console.WriteLine("===== Exercise 5: Print Queue Simulator =====");

            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Report.pdf");
            queue.Enqueue("Invoice.pdf");
            queue.Enqueue("Letter.docx");
            queue.Enqueue("Resume.pdf");
            queue.Enqueue("Photo.jpg");

            Console.WriteLine("Queue: " + string.Join(", ", queue));
            Console.WriteLine("Count: " + queue.Count);
            Console.WriteLine("Next to print (Peek): " + queue.Peek());

            while (queue.Count > 0)
                Console.WriteLine("Printing: " + queue.Dequeue());

            bool success = queue.TryDequeue(out string doc);
            Console.WriteLine($"TryDequeue on empty queue -> returned {success}, item = {(doc ?? "null")} (no exception)");
            Console.WriteLine();
        }


        #endregion

        #region  Exercise 6: Browser History (Stack<string>)

        static void Exercise6()
        {
            Console.WriteLine("===== Exercise 6: Browser History =====");

            Stack<string> history = new Stack<string>();
            history.Push("google.com");
            history.Push("github.com");
            history.Push("stackoverflow.com");
            history.Push("youtube.com");
            history.Push("facebook.com");

            Console.WriteLine("Current page (Peek): " + history.Peek());

            for (int i = 1; i <= 3; i++)
                Console.WriteLine($"Back #{i}: leaving {history.Pop()}");

            Console.WriteLine("Current page after going back: " + history.Peek());

            // Empty the stack, then try TryPop
            while (history.Count > 0) history.Pop();

            bool success = history.TryPop(out string page);
            Console.WriteLine($"TryPop on empty stack -> returned {success}, page = {(page ?? "null")} (no exception)");
        }


        #endregion


    }
}
