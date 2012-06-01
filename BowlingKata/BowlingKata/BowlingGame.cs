using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingKata
{
    public class BowlingGame
    {
        private readonly List<int> _throws;

        public BowlingGame()
        {
            _throws = new List<int>();
        }

        public int GetScore()
        {
            Console.Out.WriteLine("Call to GetScore received for game with theese scores: " + Print());
            int throwCount = _throws.Count;
            // We start by adding the values from the regular game
            int sum = _throws.Take(20).Sum();
            Console.Out.WriteLine("Plain sum of all throws : " + sum);
            // For all throws in the regular game (the ten frames) look for extra points to add for strikes (TODO: and spares)
            foreach (var index in Enumerable.Range(0, Math.Min(throwCount, 20)))
            {
                // For a spare we add the points of the next throw
                if (WasSpare(index) && index < (throwCount - 1))
                {
                    HandleExtraPointsForNextThrow(throwCount, ref sum, index, "spare");
                }
                // For a strike we add the points of the next two throws if possible
                // Make sure to omit dummy throws after strikes here
                if (WasStrike(index) && index < (throwCount - 1))
                {
                    int throwToAdd = HandleExtraPointsForNextThrow(throwCount, ref sum, index, "strike");
                    if (throwToAdd < throwCount)
                    {
                        Console.Out.WriteLine("Another throw followed");
                        int secondThrowToAdd = throwToAdd + 1;
                        if (WasStrike(_throws[throwToAdd]) && WasFirstThrowInFrameSpecial(throwToAdd))
                        {
                            Console.Out.WriteLine("And was a strike in first throw of frame again, moving on");
                            secondThrowToAdd++;
                        }
                        if (secondThrowToAdd < throwCount)
                        {
                            sum += _throws[secondThrowToAdd];
                            Console.Out.WriteLine("Adding throw number " + secondThrowToAdd + " to sum : " + sum);
                        }
                    }
                }
            }
            return sum;
        }

        private int HandleExtraPointsForNextThrow(int throwCount, ref int sum, int index, string searchElement)
        {
            Console.Out.WriteLine("Found a " + searchElement + " at throw " + index + " and at least one throw followed");
            int throwToAdd = index + 1;
            if (WasFirstThrowInFrameSpecial(index))
            {
                Console.Out.WriteLine("Moving on to avoid the dummy throw after Strike in first throw of frame");
                throwToAdd++;
            }
            if (throwToAdd < throwCount)
            {
                sum += _throws[throwToAdd];
                Console.Out.WriteLine("Adding throw number " + throwToAdd + " to sum : " + sum);
            }
            return throwToAdd;
        }

        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            int pos = 0;
            foreach(var singleThrow in _throws) {
                sb.Append(singleThrow.ToString());
                sb.Append(" ");
                pos++;
                if ((pos % 2) == 0)
                {
                    sb.Append("| ");
                }
            }
            Console.Out.WriteLine(sb.ToString());
            return sb.ToString();
        }

        public void Throw(int pins)
        {
            _throws.Add(pins);
            if(pins == 10 && WasFirstThrowInFrame()) {
                AddDummyThrow();
            }
        }

        public int GetCurrentFrame()
        {
            return (_throws.Count / 2) + 1;
        }

        private bool WasFirstThrowInFrame(int index = -1)
        {
            int throwToCheck = index < 0 ? _throws.Count : index;
            // This function is called AFTER the throw is added to the list of throws.
            // Therefore if the throw was the first then the count of throws is odd.
            return (throwToCheck % 2) > 0;
        }

        private bool WasFirstThrowInFrameSpecial(int index = -1)
        {
            int throwToCheck = index < 0 ? _throws.Count : index;
            // This function is called AFTER the throw is added to the list of throws.
            // Therefore if the throw was the first then the count of throws is odd.
            return (throwToCheck % 2) == 0;
        }

        private void AddDummyThrow()
        {
            _throws.Add(0);
        }

        private bool WasStrike(int index)
        {
            return _throws[index] == 10;
        }

        private bool WasSpare(int index)
        {
            // a Spare is only possible on the second throw of a frame
            if (index < 1 || WasFirstThrowInFrameSpecial(index))
            {
                return false;
            }

            // Watch out for the dummy rolls --> If the throw before was a strike this cannot be a spare
            if (WasStrike(index - 1))
            {
                return false;
            }

            // We call it a spare when both throws of a frame sum up to 10 pins
            return (_throws[index - 1] + _throws[index]) == 10;
        }
    }
}
