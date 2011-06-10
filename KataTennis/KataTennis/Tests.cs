using System.Linq;
using NUnit.Framework;

namespace KataTennis {
    [TestFixture]
    public class Tests {
        private TennisGame _tennisGame;

        [SetUp]
        public void SetupTennisGame() {
            _tennisGame = new TennisGame();
        }

        [Test]
        public void Teste_Keine_Punkte_Ergibt_0_Zu_0 () {
            Assert.That(_tennisGame.Score(), Is.EqualTo("0:0"));
        }

        [Test]
        public void Teste_Einer_Punktet_Einmal_Ergibt_15_Zu_0() {
            _tennisGame.Spieler1Punktet();
            Assert.That(_tennisGame.Score(), Is.EqualTo("15:0"));
        }

        [Test]
        public void Teste_Beide_Punkten_Einmal_Ergibt_15_Zu_15() {
            _tennisGame.Spieler1Punktet();
            _tennisGame.Spieler2Punktet();
            Assert.That(_tennisGame.Score(), Is.EqualTo("15:15"));
        }

        [Test]
        public void Teste_Einer_Punktet_Zweimal_Ergibt_30_Zu_0() {
            _tennisGame.Spieler1Punktet();
            _tennisGame.Spieler1Punktet();
            Assert.That(_tennisGame.Score(), Is.EqualTo("30:0"));
        }

        [Test]
        public void Teste_Einer_Punktet_Dreimal_Ergibt_40_Zu_0() {
            _tennisGame.Spieler1Punktet();
            _tennisGame.Spieler1Punktet();
            _tennisGame.Spieler1Punktet();
            Assert.That(_tennisGame.Score(), Is.EqualTo("40:0"));
        }

        [Test]
        public void Teste_Spiel_Nicht_Zu_Ende() {
            Assert.That(_tennisGame.IstZuEnde(), Is.False);
        }

        [Test]
        public void Teste_Spiel_Zu_Ende_Wenn_Einer_Viermal_Punktet() {
            _tennisGame.Spieler1Punktet();
            _tennisGame.Spieler1Punktet();
            _tennisGame.Spieler1Punktet();
            _tennisGame.Spieler1Punktet();
            Assert.That(_tennisGame.IstZuEnde(), Is.True);
        }

        [Test]
        public void Teste_Spiel_Zu_Ende_Wenn_Andere_Viermal_Punktet() {
            _tennisGame.Spieler2Punktet();
            _tennisGame.Spieler2Punktet();
            _tennisGame.Spieler2Punktet();
            _tennisGame.Spieler2Punktet();
            Assert.That(_tennisGame.IstZuEnde(), Is.True);
        }

        [Test]
        public void Teste_Spiel_Nicht_Zu_Ende_Wenn_Beide_Viermal_Abwechselnd_Punkten() {
            _tennisGame.Spieler1Punktet();
            _tennisGame.Spieler2Punktet();
            _tennisGame.Spieler1Punktet();
            _tennisGame.Spieler2Punktet();
            _tennisGame.Spieler1Punktet();
            _tennisGame.Spieler2Punktet();
            _tennisGame.Spieler1Punktet();
            _tennisGame.Spieler2Punktet();
            Assert.That(_tennisGame.IstZuEnde(), Is.False);
        }

        [Test]
        public void Teste_Spiel_Nicht_Zu_Ende_Wenn_Einer_Viermal_Punktet_Und_Der_Andere_Dreimal() {
            _tennisGame.Spieler1Punktet();
            _tennisGame.Spieler2Punktet();
            _tennisGame.Spieler1Punktet();
            _tennisGame.Spieler2Punktet();
            _tennisGame.Spieler1Punktet();
            _tennisGame.Spieler2Punktet();
            _tennisGame.Spieler1Punktet();
            Assert.That(_tennisGame.IstZuEnde(), Is.False);
        }

        [Test]
        public void Teste_Ergebnis_Ist_Einstand_Wenn_Beide_Dreimal_Punkten() {
            _tennisGame.Spieler1Punktet();
            _tennisGame.Spieler1Punktet();
            _tennisGame.Spieler1Punktet();
            _tennisGame.Spieler2Punktet();
            _tennisGame.Spieler2Punktet();
            _tennisGame.Spieler2Punktet();
            Assert.That(_tennisGame.Score(), Is.EqualTo("Einstand"));
        }

        [Test]
        public void Teste_Ergebnis_Ist_Vorteil_Spieler_1_Wenn_Beide_Dreimal_Punkten_Und_Spieler1_Punktet() {
            _tennisGame.Spieler1Punktet();
            _tennisGame.Spieler1Punktet();
            _tennisGame.Spieler1Punktet();
            _tennisGame.Spieler2Punktet();
            _tennisGame.Spieler2Punktet();
            _tennisGame.Spieler2Punktet();
            _tennisGame.Spieler1Punktet();
            Assert.That(_tennisGame.Score(), Is.EqualTo("Vorteil Spieler 1"));
        }

        [Test]
        public void Teste_Ergebnis_Ist_Vorteil_Spieler_2_Wenn_Beide_Dreimal_Punkten_Und_Spieler2_Punktet() {
            Spielstand(3, 4);
            Assert.That(_tennisGame.Score(), Is.EqualTo("Vorteil Spieler 2"));
        }

        [Test]
        public void Teste_Ergebnis_Ist_Sieg_Spieler_1_Wenn_Beide_Dreimal_Punkten_Und_Spieler1_Zweimal_Punktet() {
            Spielstand(5, 3);
            Assert.That(_tennisGame.Score(), Is.EqualTo("Sieg Spieler 1"));
        }

        [Test]
        public void Teste_Ergebnis_Ist_Sieg_Spieler_2_Wenn_Beide_Dreimal_Punkten_Und_Spieler2_Zweimal_Punktet() {
            Spielstand(3, 5);
            Assert.That(_tennisGame.Score(), Is.EqualTo("Sieg Spieler 2"));
        }

        private void Spielstand(int spieler1, int spieler2) {
            PunkteSpieler1(spieler1);
            PunkteSpieler2(spieler2);
        }


        private void PunkteSpieler1(int count) {
            Enumerable.Repeat(1, count).Select(n => {
                _tennisGame.Spieler1Punktet();
                return n;
            }).ToArray();
        }

        private void PunkteSpieler2(int count) {
            Enumerable.Repeat(1, count).Select(n => {
                _tennisGame.Spieler2Punktet();
                return n;
            }).ToArray();
        }
    }
}
