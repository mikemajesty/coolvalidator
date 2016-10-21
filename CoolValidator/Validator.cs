using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CoolValidator
{
    public static class Validator
    {

        public static IEnumerable<TextBox> GetTextBoxInComponent(this Form form, ComponentType type)
        {
            return form.Controls.OfType<Panel>().SelectMany(groupBox => groupBox.Controls.OfType<TextBox>()).OrderBy(t => t.TabIndex);
        }

    }

}
