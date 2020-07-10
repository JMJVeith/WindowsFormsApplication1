using View;
using System.Windows.Forms;

namespace RealmWarsTestView
{
    class AttackButton : IAttackButton
    {
        Button attack_button;

        public AttackButton(Button button)
        {
            this.attack_button = button;
            attackButtonEntity.initialize(this);
        }

        public void button(bool enabled)
        {
            attack_button.Enabled = enabled;
        }
    }
}
