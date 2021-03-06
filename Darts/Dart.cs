﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Darts
{
    public class Dart
    {
        public int Score { get; set; }
        public bool IsTriple { get; set; }
        public bool IsDouble { get; set; }
        public bool IsBullseyeInner { get; set; }


        private Random _random;

        public Dart(Random random)
        {
            _random = random;
        }

        public void Throw()
        {
            Score = _random.Next(0, 21);

            int multiplier = _random.Next(1, 101);
            if (multiplier >= 96) IsTriple = true;
            else if (multiplier >= 91) IsDouble = true;
            else if (multiplier >= 86) IsBullseyeInner = true;
        }

    }
}
