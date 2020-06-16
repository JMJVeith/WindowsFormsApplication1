using RealmWarsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealmWarsTestView
{
    class combatantsWindow : View<List<ICombatant>>
    {
        ListBox combatant_display;

        public combatantsWindow(ListBox combatant_display)
        {
            this.combatant_display = combatant_display;
        }

        public void print(List<ICombatant> combatants)
        {
            clear();

            foreach (ICombatant combatant in combatants)
            {
                combatant_display.Items.Add(format_combatant(combatant));
            }
        }

        private string format_combatant(ICombatant combatant)
        {
            return $"{combatant.name,-7} HP: {combatant.get_health()}";
        }

        private void clear()
        {
            combatant_display.Items.Clear();
        }
    }
}
