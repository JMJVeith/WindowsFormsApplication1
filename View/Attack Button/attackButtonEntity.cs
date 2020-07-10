namespace View
{
    public class attackButtonEntity
    {
        private static attackButtonEntity button_entity;
        private static IAttackButton attack_button;

        private attackButtonEntity(IAttackButton new_button)
        {
            attack_button = new_button;
        }

        public static attackButtonEntity initialize(IAttackButton new_button)
        {
            if(button_entity == null)
            {
                button_entity = new attackButtonEntity(new_button);
            }
            return button_entity;
        }

        public static void button(bool enabled)
        {
            if (attack_button == null) return;
            attack_button.button(enabled);
        }
    }
}
