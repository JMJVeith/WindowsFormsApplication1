using System.Collections.Generic;

namespace View
{
    public class combatantsEntity
    {
        private static combatantsEntity combatants_entity;
        private static ICombatantsDisplay combatants;

        private combatantsEntity(ICombatantsDisplay new_combatants)
        {
            combatants = new_combatants;
        }

        public static combatantsEntity initialize(ICombatantsDisplay new_combatants)
        {
            if (combatants == null)
            {
                combatants_entity = new combatantsEntity(new_combatants);
            }
            return combatants_entity;
        }

        public static void update(List<string> new_combatants)
        {
            combatants.update(new_combatants);
        }
    }
}
