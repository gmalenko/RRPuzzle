using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RR
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a string.  Click enter for default string");
            string input = Console.ReadLine();


            if (string.IsNullOrEmpty(input))
            {
                input = "(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)";
                Console.WriteLine(input);
            }            
            

            var resultList = ParseString(input);
            var result = resultList[0];


            Display(result);

            Console.WriteLine();
            Console.WriteLine();

            var alphabeticalOrder = result.Items.OrderBy(x => x.Name).ToList();
            DisplayList(alphabeticalOrder, 0, true);

            Console.WriteLine("Done");
            var end = Console.ReadLine();
        }

        public static Boolean ValidateParentheses(string input)
        {
            var result = false;
            if (!string.IsNullOrEmpty(input))
            {
                var leftP = input.Where(x => x == '(').Count();
                var rightP = input.Where(x => x == ')').Count();
                if (leftP == rightP)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }



        public static List<Item> ParseString(string input)
        {
            var subInput = Regex.Match(input, @"(?<=\().*(?=\))");
            var ItemList = new List<Item>();

            if (!subInput.Success)
            {
                foreach (var inputSplit in input.Split(','))
                {
                    var tempItem = new Item()
                    {
                        Name = inputSplit.Trim()
                    };
                    ItemList.Add(tempItem);
                }
                return ItemList;
            }
            else
            {
                var result = ParseString(subInput.Value);
                var tempInput = input.Replace(subInput.Value, "");
                foreach (var inputSplit in tempInput.Split(','))
                {
                    var newInputSplit = inputSplit.Trim();
                    var tempItem = new Item()
                    {
                        Name = inputSplit.Trim()
                    };
                    if (tempItem.Name.Contains("()"))
                    {
                        tempItem.Name = tempItem.Name.Replace("()", "");
                        tempItem.Items = result;
                    }
                    ItemList.Add(tempItem);
                }
                return ItemList;
            }
        }

        public static void Display(Item input, int level = 0)
        {
            DisplayList(input.Items);
        }

        public static void DisplayList(List<Item> itemList, int level = 0, Boolean alpha = false)
        {
            foreach (var tempInput in itemList)
            {
                Console.WriteLine(("-" + tempInput.Name).ToString().PadLeft(level + ("-" + tempInput.Name).Length, ' '));
                if (alpha)
                {
                    tempInput.Items = tempInput.Items.OrderBy(x => x.Name).ToList();
                }
                DisplayList(tempInput.Items, level + 1);
            }
        }
    }
}
