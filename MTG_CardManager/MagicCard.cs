﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MTG_CardManager
{

    enum Color { Colorless, White, Blue, Black, Red, Green }
    enum Rarity { BasicLand, Common, Uncommon, Rare, MythicRare, Special }

    class MagicCard
    {
        public String name { get; set; }
        public String ruleText { get; set; }
        public String flavorText { get; set; }
        public List<String> types { get; set; }
        public Color[] color { get; set; }
        public String manaCost { get; set; }
        public String power { get; set; }
        public String toughness { get; set; }
        public int convertedManaCost { get { return ConvertManaCost(manaCost); } }
        public List<String> subTypes { get; set; }
        public string editions { get; set; }
        public Bitmap image { get; set; }

        public int ConvertManaCost(String mana)
        {
            String pattern = "(\\d+|W|U|B|R|G|{...})";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            Match match = regex.Match(mana);
            int manaCost = 0;
            while (match.Success)
            {
                String value = match.Value;
                if (value.Contains("/"))
                    value = value.Substring(1, value.IndexOf("/") - 1);

                try
                {
                    manaCost += Convert.ToInt32(value);
                }
                catch (FormatException error)
                {
                    if (!"WUBRG".Contains(value))
                        throw error;
                    manaCost++;
                }

                match = match.NextMatch();
            }
            return manaCost;
        }
    }

}
