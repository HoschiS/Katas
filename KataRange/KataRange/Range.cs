using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace KataRange {
    public class Range {
        private readonly IEnumerable<int> _range;

        public Range(string input) {
            _range = ParseRange(input);
        }

        public static IEnumerable<int> ParseRange(string input) {
            if (input.Length < 5) {
                throw new ArgumentException("Ungültige Eingabe");
            }
            if (!new []{ '[', '('}.Contains(input.First())) {
                throw new ArgumentException("Ungültige Eingabe");                
            }
            if (!new []{ ']', ')'}.Contains(input.Last())) {
                throw new ArgumentException("Ungültige Eingabe");                
            }
            IEnumerable<int> parts;
            try {
                parts = ParseList(input);
            } catch (FormatException) {
                throw new ArgumentException("Ungültige Eingabe");
            }
            int firstNumber = parts.First();
            int secondNumber = parts.Last();
            if (input[0] == '(') {
                firstNumber++;
            }
            if (input.Last() == ']') {
                secondNumber++;
            }
            return Enumerable.Range(firstNumber, secondNumber - firstNumber);
        }

        private static IEnumerable<int> ParseList(string comparison) {
            return comparison.Substring(1, comparison.Length - 2).Split(',').Select(s => int.Parse(s));
        }

        public bool Contains(string comparison) {
            if (comparison.StartsWith("{") && comparison.EndsWith("}")) {
                return ParseList(comparison).All(value => _range.Contains(value));
            }
            return false;
        }

        public bool AllPoints(string comparison) {
            if (comparison.StartsWith("{") && comparison.EndsWith("}")) {
                return ParseList(comparison).SequenceEqual(_range);
            }
            return false;
        }

        public bool ContainsRange(string comparison) {
            return ParseRange(comparison).All(value => _range.Contains(value));
        }

        public bool OverlapsRange(string comparison) {
            return ParseRange(comparison).Any(value => _range.Contains(value));
        }

        public bool EqualsRange(string comparison) {
            return ParseRange(comparison).SequenceEqual(_range);
        }
    }
}