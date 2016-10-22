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
            var txtInPanel = GetTextBoxInContainer<T>(form);
            var txtInManyPanel = GetTextBoxHierarchicalContainer<T>(form);
            var txtInForm = GetTextBoxInForm(form);
            txtList.AddRange(txtInPanel);
            txtList.AddRange(txtInManyPanel);
            txtList.AddRange(txtInForm);
            return predicate == null ? txtList : txtList.Where(predicate).ToList();
        }

        private static List<TextBox> GetTextBoxInForm(Form form)
        {
            return form.Controls.OfType<TextBox>().Where(c => string.IsNullOrEmpty(c.Text.Trim())).ToList();
        }

        private static List<TextBox> GetTextBoxHierarchicalContainer<T>(Form form) where T : Control
        {
            return form.Controls.OfType<T>().SelectMany(groupBox => groupBox.Controls.OfType<T>()).SelectMany(textBox => textBox.Controls.OfType<TextBox>()).OrderBy(t => t.TabIndex).Where(c => string.IsNullOrEmpty(c.Text.Trim())).ToList();
        }

        private static List<TextBox> GetTextBoxInContainer<T>(Form form) where T : Control
        {
            return form.Controls.OfType<T>().SelectMany(groupBox => groupBox.Controls.OfType<TextBox>()).OrderBy(t => t.TabIndex).Where(c => string.IsNullOrEmpty(c.Text.Trim())).ToList();
        }
    }

}
