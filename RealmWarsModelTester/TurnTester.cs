using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealmWarsModel;

namespace RealmWarsModelTester
{
    [TestClass]
    public class TurnTester
    {
        [TestMethod]
        public void PhaseTest()
        {
            PlayerCharacter player = new PlayerCharacter("James");
            PCCombatant playerCombatant = new PCCombatant(player);
            Turn turn = new PlayerTurn(playerCombatant);
            Assert.AreEqual(1,1);
            Assert.AreEqual(2, 1);
        }
    }
}
