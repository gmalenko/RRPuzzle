using System;
using System.Collections.Generic;
using System.Text;

namespace RR
{
    public class Item
    {
        public string Name { get; set; }
        public List<Item> Items { get; set; }

        public Item()
        {
            this.Items = new List<Item>();
        }

    }
}
