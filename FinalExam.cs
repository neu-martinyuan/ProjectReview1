using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProjectReview1
{
    /*
     * NOTE: 50% POINT DEDUCTION IF LATE OR INCORRECT SUBMISSION

     * Implement the FinalExam class by:
     *  
     * 1) 60 POINTS:
     * adding code to each method called by Demo() ;
     *  
     * 2) 15 Points:
     * adding the required MyBread, MyMilk and MyPJ inner classes derived from MyItem;
     *  
     * 3) 10 POINTS:
     * complete inner class MyItem by:
     *   3a) adding properties int Id, double Price and string Name:
     *   3b) implement IComparable
     *  
     * 4) 15 POINTS:
     * demonstrate the use of a Publisher/Subscriber event with Threads
     *       
     */
    public class FinalExam
    {
        private int majorObjectVersion = 1;
        private int minorObjectVersion = 1;
        public static int MajorVersion { get; set; } = 1;
        public static int MinorVersion { get; set; } = 0;
        public static string Version => $"{MajorVersion}.{MinorVersion}";

        /* inner class MyItem
         */
        private class MyItem : IComparable<MyItem>
        {
            // YOU implement properties for class MyItem
            public int Id { get; set; }
            public double Price { get; set; }
            public string Name { get; set; }
            public MyItem() // default MyItem constructor
            {
                Id = 1;
                Price = 0.99;
                Name = "some item";
            }
            public MyItem(int id, double price, string name)
            {
                this.Id = id;
                this.Price = price;
                this.Name = name;
            }
            /* ALL subclasses must override this method
             */
            public virtual string MyDescription()
            {
                return "I'm an item";
            }
            public override string ToString()
            {
                return $"#{Id} ${Price} {Name} '{MyDescription()}'";
            }

            public int CompareTo(MyItem other)
            {
                return Price.CompareTo(other.Price);
            }
        }

        /* YOU DESIGN inner class MyBread
         * derived from MyItem       
         */
        /* YOU DESIGN inner class MyOJ        
         * derived from MyItem       
         */
        /* YOU DESIGN inner class MyMilk
         * derived from MyItem       
         */
        private class MyBread : MyItem
        {
            public MyBread()
            {
                Id = 3;
                Price = 1.49;
                Name = "Bread";
            }
            public MyBread(int id, double price, string name)
            {
                this.Id = id;
                this.Price = price;
                this.Name = name;
            }
            public override string MyDescription()
            {
                return "Handmade Bread";
            }
        }

        private class MyOJ : MyItem
        {
            public MyOJ()
            {
                Id = 2;
                Price = 3.49;
                Name = "OJ";
            }
            public override string MyDescription()
            {
                return "OJ";
            }
        }

        private class MyMilk : MyItem
        {
            public MyMilk()
            {
                Id = 1;
                Price = 2.49;
                Name = "Milk";
            }
            public override string MyDescription()
            {
                return "Non-fat Milk";
            }
        }

        public FinalExam()
        {
            MajorVersion = majorObjectVersion;
            MinorVersion = minorObjectVersion;
        }
        /**
         * 
         * Method Name:     UseStrings
         * Parameters:      none
         * Return value:    none
         *         
         * Write to console: 
         *   1. interpolated string with expression 9 + 3
         *         
         * Example CONSOLE OUTPUT:
         * 
         * 9+3=9        
         */
        public void UseStrings()
        {
            int a = 9;
            int b = 3;
            Console.WriteLine($"9+3={a + b}");
        }
        /**
         * 
         * Method Name:     UseObjectInitializer
         * Parameters:      none
         * Return value:    none
         *         
         * Use Object Initializer
         * 
         * Instantiate the following objects:
         * 1. $1.49 Wheat Bread
         * 2. Dictionary of numbers: 1 is One, 2 is Two, 3 is Three        
         * 3. Dictionary of US States: NH is New Hampshire, NY is New York, NJ is New Jersey
         *         
         */
        public void UseObjectInitializer()
        {
            Console.WriteLine("\n\t FinalExam.UseObjectInitializer()...");
            MyBread bread = new MyBread(1, 1.49, "Wheat Bread");
            Dictionary<int, string> numbers = new Dictionary<int, string>();
            Dictionary<string, string> states = new Dictionary<string, string>();
            numbers.Add(1, "One");
            numbers.Add(2, "Two");
            numbers.Add(3, "Three");
            states.Add("NH", "New Hampshire");
            states.Add("NY", "New York");
            states.Add("NJ", "New Jersey");
            Console.WriteLine("\n\t FinalExam.UseObjectInitializer()...done!");
        }

        /**
         * 
         * Method Name:     ParseCSVString
         * Parameters:      none
         * Return value:    none
         *         
         * Demonstrate the parsing of a string containing 
         * three Comma Separated Value (CSV) tokens. 
         *  1. demonstrate parsing and conversion of an integer value;
         *  2. demonstrate parsing and conversion of a  string value;
         *  3. demonstrate parsing and conversion of a  double value;
         * 
         * NOTE: NO File I/O. Use a literall CSV string
         * parse tokens from Comma Separated Value (CSV) string
         * handle any thrown exceptions and write result to console
         *      e.g. 
         *  "17,Dan,4.0" Where Dan, age 17 having GPA of 4.0;
         * 
         */
        public void ParseCSVString()
        {
            string s = "18,Chaoyi,3.9";
            string[] vs = s.Split(",");
            int age = int.Parse(vs[0]);
            string name = vs[1];
            double gpa = double.Parse(vs[2]);
            Console.WriteLine($"Student {name}, age {age} having GPA of {gpa}");
        }
        /**
         * 
         * Method Name:     GenericShow<T>
         * Parameters:      list<T> list sequential container of elements of type T
         * Return value:    none
         *
         * Use generic programming to implement a method to show
         * the state of each element in a supplied list sequential container.        
         */
        public void GenericShow<T>(List<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        /**
         * 
         * Method Name:     GenericSort<T>
         * Parameters:      list<T> list sequential container of elements of type T
         *                  Comparison<T> comparer        
         * Return value:    list<T> list sequential container of elements of type T
         *         
         * Sort a list using the supplied Comparison and return
         */
        public List<T> GenericSort<T>(List<T> list, Comparison<T> comparer)
        {
            list.Sort(comparer);
            return list;
        }
        /**
         * 
         * Method Name:     GenericSort<T>
         * Parameters:      string title
         *                  list<T> list sequential container of elements of type T
         *                  Comparison<T> comparer        
         * Return value:    list<T> list sequential container of elements of type T
         *         
         * Sort a list using the supplied Comparison and return
         */
        public List<T> GenericSort<T>(string title, List<T> list, Comparison<T> comparer)
        {
            list.Sort(comparer);
            return list;
        }
        /**
         * 
         * Method Name:     SortIntegers
         * Parameters:      none
         * Return value:    none
         *         
         * Write to console: 3, 1, 5, 2, 4 
         *  1. sorted ascending and descending using sort() and reverse();
         *  2. sorted descending and descending using Lambda; 
         *  3. sorted descending and descending using LINQ;
         *  4. sorted descending and descending using GenericSort<T>(); 
         *  5. sorted descending and descending using Anonymous Comparison delegate; 
         *  e.g.
         * 1, 2, 3, 4, 5, 5, 4, 3, 2, 1, 1, 2, 3, 4, 5, 5, 4, 3, 2, 1, 1, 2, 3, 4, 5, 5, 4, 3, 2, 1, 1, 2, 3, 4, 5, 5, 4, 3, 2, 1, 1, 2, 3, 4, 5, 5, 4, 3, 2, 1,  ... done! 
         */
        public void SortIntegers()
        {
            Console.WriteLine($"\n\t FinalExam.SortIntegers()...");
            Console.WriteLine("SORTED ASCENDING AND DESCENDING:");
            List<int> vs = new List<int> { 3, 1, 5, 2, 4 };
            vs.Sort();
            Console.WriteLine(String.Join(", ", vs));
            vs.Reverse();
            Console.WriteLine(String.Join(", ", vs));
            vs.Sort((n1, n2) => n1.CompareTo(n2));
            Console.WriteLine(String.Join(", ", vs));
            vs.Sort((n1, n2) => n2.CompareTo(n1));
            Console.WriteLine(String.Join(", ", vs));
            IEnumerable<int> vs1 = vs.OrderBy(n => n);
            Console.WriteLine(String.Join(", ", vs1));
            IEnumerable<int> vs2 = vs.OrderByDescending(n => n);
            Console.WriteLine(String.Join(", ", vs2));

            GenericSort<int>(vs, delegate (int x, int y)
            {
                return x.CompareTo(y);
            });
            Console.WriteLine(String.Join(", ", vs));
            
            GenericSort<int>(vs, delegate (int x, int y)
            {
                return y.CompareTo(x);
            });
            Console.WriteLine(String.Join(", ", vs));

            vs.Sort(delegate (int x, int y)
            {
                return x.CompareTo(y);
            });
            Console.WriteLine(String.Join(", ", vs));
            vs.Sort(delegate (int x, int y)
            {
                return y.CompareTo(x);
            });
            Console.WriteLine(String.Join(", ", vs));

            Console.WriteLine($"\n\t FinalExam.SortIntegers()...done!");
        }
        /**
         * 
         * Method Name:     SortDoubles
         * Parameters:      none
         * Return value:    none
         *         
         * Write to console: 3.3, 1.1, 5.5, 2.2, 4.4 
         *  1. sorted ascending and descending using sort() and reverse();
         *  2. sorted descending and descending using Lambda; 
         *  3. sorted descending and descending using LINQ;
         *  4. sorted descending and descending using GenericSort<T>(); 
         *  5. sorted descending and descending using Anonymous Comparison delegate; 
         *  e.g.
         * 1.1, 2.2, 3.3, 4.4, 5.5, 5.5, 4.4, 3.3, 2.2, 1.1, 1.1, 2.2, 3.3, 4.4, 5.5, 5.5, 4.4, 3.3, 2.2, 1.1, 1.1, 2.2, 3.3, 4.4, 5.5, 5.5, 4.4, 3.3, 2.2, 1.1, 1.1, 2.2, 3.3, 4.4, 5.5, 5.5, 4.4, 3.3, 2.2, 1.1, 1.1, 2.2, 3.3, 4.4, 5.5, 5.5, 4.4, 3.3, 2.2, 1.1,  ... done! 
         */
        public void SortDoubles()
        {
            Console.WriteLine($"\n\t FinalExam.SortDoubles()...");
            Console.WriteLine("SORTED ASCENDING AND DESCENDING:");
            List<double> vs = new List<double> { 3.3, 1.1, 5.5, 2.2, 4.4 };
            vs.Sort();
            Console.WriteLine(String.Join(", ", vs));
            vs.Reverse();
            Console.WriteLine(String.Join(", ", vs));
            vs.Sort((n1, n2) => n1.CompareTo(n2));
            Console.WriteLine(String.Join(", ", vs));
            vs.Sort((n1, n2) => n2.CompareTo(n1));
            Console.WriteLine(String.Join(", ", vs));
            IEnumerable<double> vs1 = vs.OrderBy(n => n);
            Console.WriteLine(String.Join(", ", vs1));
            IEnumerable<double> vs2 = vs.OrderByDescending(n => n);
            Console.WriteLine(String.Join(", ", vs2));

            GenericSort<double>(vs, delegate (double x, double y)
            {
                return x.CompareTo(y);
            });
            Console.WriteLine(String.Join(", ", vs));

            GenericSort<double>(vs, delegate (double x, double y)
            {
                return y.CompareTo(x);
            });
            Console.WriteLine(String.Join(", ", vs));

            vs.Sort(delegate (double x, double y)
            {
                return x.CompareTo(y);
            });
            Console.WriteLine(String.Join(", ", vs));
            vs.Sort(delegate (double x, double y)
            {
                return y.CompareTo(x);
            });
            Console.WriteLine(String.Join(", ", vs));
            Console.WriteLine($"\n\t FinalExam.SortDoubles()...done!");
        }
        /**
         * 
         * Method Name:     SortStrings
         * Parameters:      none
         * Return value:    none
         *         
         * Write to console: Moe, Larry, Curley 
         *  1. sorted ascending and descending using sort() and reverse();
         *  2. sorted descending and descending using Lambda; 
         *  3. sorted descending and descending using LINQ;
         *  4. sorted descending and descending using GenericSort<T>(); 
         *  5. sorted descending and descending using Anonymous Comparison delegate; 
         *  e.g.
         * Curley, Larry, Moe, Moe, Larry, Curley, Curley, Larry, Moe, Moe, Larry, Curley, Curley, Larry, Moe, Moe, Larry, Curley, Curley, Larry, Moe, Moe, Larry, Curley, Curley, Larry, Moe, Moe, Larry, Curley,  ... done! 
         */
        public void SortStrings()
        {
            Console.WriteLine($"\n\t FinalExam.SortStrings()...");
            Console.WriteLine("SORTED ASCENDING AND DESCENDING:");
            List<string> vs = new List<string> { "Moe", "Larry", "Curley" };
            vs.Sort();
            Console.WriteLine(String.Join(", ", vs));
            vs.Reverse();
            Console.WriteLine(String.Join(", ", vs));
            vs.Sort((n1, n2) => n1.CompareTo(n2));
            Console.WriteLine(String.Join(", ", vs));
            vs.Sort((n1, n2) => n2.CompareTo(n1));
            Console.WriteLine(String.Join(", ", vs));
            IEnumerable<string> vs1 = vs.OrderBy(n => n);
            Console.WriteLine(String.Join(", ", vs1));
            IEnumerable<string> vs2 = vs.OrderByDescending(n => n);
            Console.WriteLine(String.Join(", ", vs2));

            GenericSort<string>(vs, delegate (string x, string y)
            {
                return x.CompareTo(y);
            });
            Console.WriteLine(String.Join(", ", vs));

            GenericSort<string>(vs, delegate (string x, string y)
            {
                return y.CompareTo(x);
            });
            Console.WriteLine(String.Join(", ", vs));

            vs.Sort(delegate (string x, string y)
            {
                return x.CompareTo(y);
            });
            Console.WriteLine(String.Join(", ", vs));
            vs.Sort(delegate (string x, string y)
            {
                return y.CompareTo(x);
            });
            Console.WriteLine(String.Join(", ", vs));
            Console.WriteLine($"\n\t FinalExam.SortStrings()...done!");
        }
        /**
         * 
         * Method Name:     SortItems
         * Parameters:      none
         * Return value:    none
         *         
         * Demonstrate Sort on MyItems objects:
         *  1. sort by ID using Lambda;
         *  2. sort by Price (using default order);
         *  3. sort by Name using Lambda;
         */
        public void SortItems()
        {
            Console.WriteLine($"\n\t FinalExam.SortItems()...");
            List<MyItem> list = new List<MyItem> { new MyItem(1, 5.99, "bowl"),
                    new MyItem(2, 20.99, "chair"), new MyItem(3, 100.99, "screen")};
            Console.WriteLine("SORTED BY ID ASCENDING AND DESCENDING:");
            list.Sort((n1, n2) => n1.Id.CompareTo(n2.Id));
            Console.WriteLine(String.Join(" | ", list));
            list.Sort((n1, n2) => n2.Id.CompareTo(n1.Id));
            Console.WriteLine(String.Join(" | ", list));
            Console.WriteLine("SORTED BY PRICE ASCENDING AND DESCENDING:");
            list.Sort();
            Console.WriteLine(String.Join(" | ", list));
            list.Reverse();
            Console.WriteLine(String.Join(" | ", list));
            Console.WriteLine("SORTED BY NAME ASCENDING AND DESCENDING:");
            list.Sort((n1, n2) => n1.Name.CompareTo(n2.Name));
            Console.WriteLine(String.Join(" | ", list));
            list.Sort((n1, n2) => n2.Name.CompareTo(n1.Name));
            Console.WriteLine(String.Join(" | ", list));
            Console.WriteLine($"\n\t FinalExam.SortItems()...done!");
        }
        /**
         * 
         * Method Name:     ProcessIntegers
         * Parameters:      none
         * Return value:    none
         *         
         * Demonstrate LINQ on int values, 3, 2, 1:
         *  1. sort in ascending order;
         *  2. scale each integer value by 100;
         * e.g.
         * 100, 200, 300,  ... done!
         */
        public void ProcessIntegers()
        {
            Console.WriteLine($"\n\t FinalExam.ProcessIntegers()...");
            List<int> list = new List<int> { 3, 2, 1 };
            IEnumerable<int> vs = 
                list
                .OrderBy(n => n)
                .Select(n => n * 100)
            ;
            Console.WriteLine(String.Join(", ", vs));
            Console.WriteLine($"\n\t FinalExam.ProcessIntegers()...done!");
        }
        /**
         * 
         * Method Name:     ProcessDoubles
         * Parameters:      none
         * Return value:    none
         *         
         * Demonstrate LINQ on double vlaues, 33.3, 22.2, 11.1:
         *  1. sort in ascending order;
         *  2. discount each double value by 20%;
         * e.g.
         * Original values => 33.3, 11.1, 22.2,  SORTED => 11.1, 22.2, 33.3,  and then discounted 20% => 8.88, 17.76, 26.64,  ... done!
         */
        public void ProcessDoubles()
        {
            Console.WriteLine($"\n\t FinalExam.ProcessDoubles()...");
            List<double> list = new List<double> { 33.3, 11.1, 22.2 };
            IEnumerable<double> vs =
                list
                .OrderBy(n => n)
                .Select(n => n * 0.8)
            ;
            Console.WriteLine(String.Join(", ", vs));
            Console.WriteLine($"\n\t FinalExam.ProcessDoubles()...done!");
        }
        /**
         * 
         * Method Name:     ProcessItems
         * Parameters:      none
         * Return value:    none
         *         
         * Demonstrate LINQ on MyItems objects:
         *  1. sort by ID ASCENDING AND DESCENDING using LINQ;
         *  2. sort by Price ASCENDING (use LINQ Query syntax) AND DESCENDING (use LINQ Fluent syntax);
         *  3. sort by Name ASCENDING AND DESCENDING using LINQ;
         *  4. Show a 10% price increase in each item
         */
        public void ProcessItems()
        {
            Console.WriteLine($"\n\t FinalExam.ProcessItems()...");
            List<MyItem> list = new List<MyItem> { new MyItem(1, 5.99, "bowl"),
                    new MyItem(2, 20.99, "chair"), new MyItem(3, 100.99, "screen")};
            Console.WriteLine("SORTED BY ID ASCENDING AND DESCENDING:");
            IEnumerable<MyItem> myItems1 =list.OrderBy(n => n.Id);
            Console.WriteLine(String.Join(", ", myItems1));
            IEnumerable<MyItem> myItems2 = list.OrderByDescending(n => n.Id);
            Console.WriteLine(String.Join(", ", myItems2));
            Console.WriteLine("SORTED LINQ Query BY PRICE ASCENDING:");
            IEnumerable<MyItem> myItems3 =
                from Item in list
                orderby Item
                select Item;
            Console.WriteLine(String.Join(", ", myItems3));

            Console.WriteLine("SORTED Fluent BY PRICE DESCENDING:");
            IEnumerable<MyItem> myItems4 = list.OrderByDescending(n => n).Select(n => n);
            Console.WriteLine(String.Join(", ", myItems4));

            Console.WriteLine("SORTED BY NAME ASCENDING AND DESCENDING:");
            IEnumerable<MyItem> myItems5 = list.OrderBy(n => n.Name);
            Console.WriteLine(String.Join(", ", myItems5));
            IEnumerable<MyItem> myItems6 = list.OrderByDescending(n => n.Name);
            Console.WriteLine(String.Join(", ", myItems6));

            Console.WriteLine("SORTED BY PRICE showing 20% price increase:");

            var result = from n in list
                         orderby n.Price
                         select new { n.Id, Price = n.Price * 1.2, n.Name};
            foreach(var temp in result)
            {
                Console.WriteLine($"#{temp.Id} ${temp.Price} {temp.Name}");
            }
           
            Console.WriteLine("Anonymous Type SORTED BY PRICE showing 20% price increase:");
            var anonymousList = new[]
            {
                new { Id = 1, Price = 5.99, Name = "bowl" },
                new { Id = 2, Price = 9.99, Name = "dish" },
                new { Id = 2, Price = 2.99, Name = "rice" }
            };
            var res2 = from n in anonymousList
                       orderby n.Price
                       select new { n.Id, Price = n.Price * 1.2, n.Name };
            foreach (var temp in res2)
            {
                Console.WriteLine($"#{temp.Id} ${temp.Price} {temp.Name}");
            }


            Console.WriteLine($"\n\t FinalExam.ProcessItems()...done!");
        }

        /**
         * 
         * Method Name:     UsePolymorphism
         * Parameters:      none
         * Return value:    none
         *         
         * Demonstrate polymorphism using MyItem objects:
         *  1. Derive MyBread, MyMilk and MyOJ classes from MyItem
         *  2. Instantiate objects, using object initializer:
         *      MyMilk  Id=1, Price=2.49, Name="Milk"
         *      MyOJ    Id=2, Price=3.49, Name="OJ"
         *      MyBread Id=3, Price=1.49, Name="Bread"
         *  1. sort by ID using LINQ;
         *  2. sort by Price using LINQ;
         *  3. sort by Name using LINQ (Query and Fluent syntax);
         */
        public void UsePolymorphism()
        {
            Console.WriteLine($"\n\t FinalExam.UsePolymorphism()...");
            List<MyItem> list = new List<MyItem> { new MyMilk(), new MyOJ(), new MyBread()};

            Console.WriteLine("SORTED BY ID ASCENDING AND DESCENDING:");
            IEnumerable<MyItem> myItems1 = list.OrderBy(n => n.Id);
            Console.WriteLine(String.Join(", ", myItems1));
            IEnumerable<MyItem> myItems2 = list.OrderByDescending(n => n.Id);
            Console.WriteLine(String.Join(", ", myItems2));

            Console.WriteLine("SORTED BY PRICE ASCENDING AND DESCENDING:");
            IEnumerable<MyItem> myItems3 = list.OrderBy(n => n);
            Console.WriteLine(String.Join(", ", myItems3));
            IEnumerable<MyItem> myItems4 = list.OrderByDescending(n => n);
            Console.WriteLine(String.Join(", ", myItems4));

            Console.WriteLine("SORTED LINQ Query & Fluent BY NAME ASCENDING AND DESCENDING:");
            IEnumerable<MyItem> myItems5 =
                from Item in list
                orderby Item.Name
                select Item;
            Console.WriteLine(String.Join(", ", myItems5));

            IEnumerable<MyItem> myItems6 = list.OrderByDescending(n => n.Name).Select(n => n);
            Console.WriteLine(String.Join(", ", myItems6));

            Console.WriteLine($"\n\t FinalExam.UsePolymorphism()...done!");
        }

        /*
         * 60 POINTS:       
         */
        public static void Demo()
        {
            Console.WriteLine($"\n\t FinalExam.Demo() version {Version} ...");

            FinalExam obj = new FinalExam();

            obj.UseStrings();           //  2 POINTS
            obj.UseObjectInitializer(); //  4 POINTS
            obj.ParseCSVString();       //  4 POINTS

            obj.SortIntegers();         //  2 POINTS
            obj.SortDoubles();          //  2 POINTS
            obj.SortStrings();          //  6 POINTS
            obj.SortItems();            // 10 POINTS

            obj.ProcessIntegers();      // 5 POINTS
            obj.ProcessDoubles();       // 5 POINTS
            obj.ProcessItems();         // 10 POINTS

            obj.UsePolymorphism();      // 10 POINTS

            Console.WriteLine("\n\t FinalExam.Demo()...done!");
        }


    }
}