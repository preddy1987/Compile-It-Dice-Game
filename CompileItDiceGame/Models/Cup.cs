using System;
using System.Collections.Generic;
using System.Text;

namespace CompileIt
{
    public class Cup
    {
        private List<Die> _dice = new List<Die>();
        private Random _rnd = new Random();

        public bool HasDice
        {
            get
            {
                return _dice.Count > 0;
            }
        }

        public Cup()
        {
            Reset();
        }

        public void Reset()
        {
            _dice.Clear();
            LoadDice(6, DieType.Green);
            LoadDice(4, DieType.Yellow);
            LoadDice(3, DieType.Red);
        }

        private void LoadDice(int numOfDice, DieType type)
        {
            for (int i = 0; i < numOfDice; i++)
            {
                if (type == DieType.Green)
                {
                    _dice.Add(new GreenDie());
                }
                else if(type == DieType.Yellow)
                {
                    _dice.Add(new YellowDie());
                }
                else if (type == DieType.Red)
                {
                    _dice.Add(new RedDie());
                }
            }
        }

        public Die PullDie()
        {
            Die result = null;
            int index = _rnd.Next(0, _dice.Count);
            result = _dice[index];
            _dice.RemoveAt(index);
            return result;
        }
    }
}
