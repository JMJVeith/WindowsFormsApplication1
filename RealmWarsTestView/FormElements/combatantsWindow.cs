using System.Collections.Generic;
using System.Windows.Forms;
using View;

namespace RealmWarsTestView
{
    class combatantsWindow : ICombatantsDisplay
    {
        ListBox combatant_display;

        public combatantsWindow(ListBox combatant_display)
        {
            this.combatant_display = combatant_display;
            combatantsEntity.initialize(this);
        }

        public void update(List<string> combatants)
        {
            clear();

            foreach (string combatant in combatants)
            {
                combatant_display.Items.Add(combatant);
            }
        }

        private void clear()
        {
            combatant_display.Items.Clear();
        }
    }
}
