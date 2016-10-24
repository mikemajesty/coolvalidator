using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CoolValidator
{
    public static class formValidator
    {
        public static List<TextBox> ValidateTextBox(this Form form, Func<TextBox, bool> predicate = null)
        {
            var txtList = new List<TextBox>();

            var txtInPanel = GetTextBoxInGroupBox<Panel>(form);
            var txtInManyPanel = GetInHierarchicalGroupBox<Panel>(form);

            var txtInGroupBox = GetTextBoxInGroupBox<GroupBox>(form);
            var txtInManyGroupBox = GetInHierarchicalGroupBox<GroupBox>(form);

            var txtInForm = GetTextBoxInForm(form);

            txtList.AddRange(txtInGroupBox);
            txtList.AddRange(txtInManyGroupBox);

            txtList.AddRange(txtInPanel);
            txtList.AddRange(txtInManyPanel);

            txtList.AddRange(txtInForm);
            return predicate == null ? txtList.OrderBy(t => t.TabIndex).ToList() : txtList.Where(predicate).OrderBy(t => t.TabIndex).ToList();
        }

        private static List<TextBox> GetTextBoxInForm(Form form)
        {
            return form.Controls.OfType<TextBox>().Where(c => string.IsNullOrEmpty(c.Text.Trim())).ToList();
        }

        private static List<TextBox> GetTextBoxInGroupBox<T>(Form form) where T : Control
        {
            return form.Controls.OfType<GroupBox>().SelectMany(panel => panel.Controls.OfType<TextBox>()).Where(c => string.IsNullOrEmpty(c.Text.Trim())).ToList();
        }

        private static List<TextBox> GetInHierarchicalGroupBox<T>(Form form) where T : Control
        {
            return form.Controls.OfType<GroupBox>().SelectMany(panel => panel.Controls.OfType<GroupBox>()).SelectMany(textBox => textBox.Controls.OfType<TextBox>()).Where(c => string.IsNullOrEmpty(c.Text.Trim())).ToList();
        }
    }
}
