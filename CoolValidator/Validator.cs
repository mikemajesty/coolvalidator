using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CoolValidator
{
    public static class formValidator
    {
        public static List<TextBox> GetTextBoxInComponent(this Form form, Func<TextBox, bool> predicate)
        {
            var txtList = new List<TextBox>();
            var txtInPanel = form.Controls.OfType<Panel>().SelectMany(groupBox => groupBox.Controls.OfType<TextBox>()).OrderBy(t => t.TabIndex).Where(c => string.IsNullOrEmpty(c.Text)).Where(predicate).ToList();
            var txtInManyPanel = form.Controls.OfType<Panel>().SelectMany(groupBox => groupBox.Controls.OfType<Panel>()).SelectMany(textBox => textBox.Controls.OfType<TextBox>()).OrderBy(t => t.TabIndex).Where(c => string.IsNullOrEmpty(c.Text)).Where(predicate).ToList();
            var txtInForm = form.Controls.OfType<TextBox>().Where(c => string.IsNullOrEmpty(c.Text)).Where(predicate).ToList();
            txtList.AddRange(txtInPanel);
            txtList.AddRange(txtInManyPanel);
            txtList.AddRange(txtInForm);
            return txtList;
        }
    }

}
