using System;
using System.Collections.Generic;
using System.Text;

namespace JSONProject3
{
    public class MenuItem
    {
        public string Id { get; set; }
        public string Label { get; set; }
    }

    public class Menu
    {
        public string Header { get; set; }
        public MenuItem[] Items { get; set; }
    }
}
