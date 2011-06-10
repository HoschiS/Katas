using System;

namespace KataTennis {
    public class TennisGame {
        private static string GetPunkte(int count) {
            if (count == 0) {
                return "0";
            } else if (count == 1) {
                return "15";
            } else if (count == 2) {
                return "30";
            } else if (count == 3) {
                return "40";
            }
            throw new ArgumentOutOfRangeException();
        }

        private int _spieler1;
        private int _spieler2;

        public string Score() {
            if (IstZuEnde()) {
                return "Sieg Spieler " + (_spieler1 > _spieler2
                           ? "1"
                           : "2");
            }
            if (_spieler1 >= 3 && _spieler2 >= 3) {
                if (_spieler1 == _spieler2) {
                    return "Einstand";
                }
                if (_spieler1 > _spieler2) {
                    return "Vorteil Spieler 1";
                }
                if (_spieler1 < _spieler2) {
                    return "Vorteil Spieler 2";
                }
            }
            return GetPunkte(_spieler1) + ":" + GetPunkte(_spieler2);
        }

        public void Spieler1Punktet() {
            _spieler1++;
        }

        public void Spieler2Punktet() {
            _spieler2++;
        }

        public bool IstZuEnde() {
            if (_spieler1 >= 4 && _spieler1 >= (_spieler2 + 2)) {
                return true;
            }
            if (_spieler2 >= 4 && _spieler2 >= (_spieler1 + 2)) {
                return true;
            }
            return false;
        }
    }
}