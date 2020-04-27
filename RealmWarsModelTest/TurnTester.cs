using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealmWarsModel;

namespace RealmWarsModelTest
{
    [TestClass]
    public class TurnTester
    {
        [TestMethod]
        public void TestMethod1()
        {
            PCCombatant combatant = new PCCombatant("James",new Attributes(8,12));
            Turn turn = new PlayerTurn(combatant);
            Assert.AreEqual(1,1);
        }
    }
}
