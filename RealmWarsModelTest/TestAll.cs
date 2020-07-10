using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealmWarsModel;

namespace RealmWarsModelTest
{
    [TestClass]
    public class TestAll
    {
        private testBattleArena ba = new testBattleArena();

        [TestMethod]
        public void run_tests()
        {
            PCCombatant combatant = new PCCombatant("James",new Attributes(8,12));
            //Turn turn = new PlayerTurn(combatant);
            Assert.AreEqual(1,1);
        }

        [TestMethod]
        public void test_battle_arena()
        {

        }
    }
}
