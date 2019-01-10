using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string[] values =
            {
                "可，一XXX15.5核發",
                "可，萬一XXX15.5a核發",
                "可，一XXX15.5a萬核發",
                "可，萬一XXX15.5a萬核發",
                "可，一XXX15.5萬核發",
                "可，萬一XXX15.5萬核發",
                "可，萬一XXX15萬核發",
                "可，萬一XXX15.3萬或34萬核發",
            };
            Regex rx = new Regex(@"\d萬");

            foreach (string value in values)
            {
                var rs = rx.IsMatch(value);
                if (rs)
                {
                    MatchCollection matches = rx.Matches(value); 
                    Console.Write("{0} matches found in:\t   {1}\t", matches.Count, value); 
                    foreach (Match match in matches)
                    {
                        GroupCollection groups = match.Groups;
                        Console.Write(", at positions {0}",  groups[0].Index);
                    }
                    Console.WriteLine("");
                }
            }
        }
    }
}
