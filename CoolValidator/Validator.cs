using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace CoolValidator
{
    public static class formValidator
    {
        public static List<TextBox> GetTextBoxInComponent<T>(this Form form, Func<TextBox, bool> predicate = null)
            where T : Control
        {
            var txtList = new List<TextBox>();
            var txtInPanel = form.Controls.OfType<T>().SelectMany(groupBox => groupBox.Controls.OfType<TextBox>()).OrderBy(t => t.TabIndex).Where(c => string.IsNullOrEmpty(c.Text.Trim())).ToList();
            var txtInManyPanel = form.Controls.OfType<T>().SelectMany(groupBox => groupBox.Controls.OfType<T>()).SelectMany(textBox => textBox.Controls.OfType<TextBox>()).OrderBy(t => t.TabIndex).Where(c => string.IsNullOrEmpty(c.Text.Trim())).ToList();
            var txtInForm = form.Controls.OfType<TextBox>().Where(c => string.IsNullOrEmpty(c.Text.Trim())).ToList();
            txtList.AddRange(txtInPanel);
            txtList.AddRange(txtInManyPanel);
            txtList.AddRange(txtInForm);
            return predicate == null ? txtList : txtList.Where(predicate).ToList();
        }
    }

}
