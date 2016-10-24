using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace CoolValidator
{
    public static class formValidator
    {
        public static List<TextBox> GetTextBoxInComponent(this Form form, Func<TextBox, bool> predicate = null)
        {
            var txtList = new List<TextBox>();

            var txtInPanel = GetTextBoxInGroupBox(form);
            var txtInManyPanel = GetInHierarchicalPanel(form);

            var txtInGroupBox = GetTextBoxInGroupBox(form);
            var txtInManyGroupBox = GetInHierarchicalGroupBox(form);

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

        private static List<TextBox> GetInHierarchicalPanel(Form form)
        {
            return form.Controls.OfType<Panel>().SelectMany(panel => panel.Controls.OfType<Panel>()).SelectMany(textBox => textBox.Controls.OfType<TextBox>()).OrderBy(t => t.TabIndex).Where(c => string.IsNullOrEmpty(c.Text.Trim())).ToList();
        }

        private static List<TextBox> GetTextBoxInGroupBox(Form form)
        {
            return form.Controls.OfType<Panel>().SelectMany(panel => panel.Controls.OfType<TextBox>()).OrderBy(t => t.TabIndex).Where(c => string.IsNullOrEmpty(c.Text.Trim())).ToList();
        }

        private static List<TextBox> GetInHierarchicalGroupBox(Form form)
        {
            return form.Controls.OfType<GroupBox>().SelectMany(panel => panel.Controls.OfType<GroupBox>()).SelectMany(textBox => textBox.Controls.OfType<TextBox>()).OrderBy(t => t.TabIndex).Where(c => string.IsNullOrEmpty(c.Text.Trim())).ToList();
        }

        private static List<TextBox> dfdfd(Form form)
        {
            return form.Controls.OfType<GroupBox>().SelectMany(panel => panel.Controls.OfType<TextBox>()).OrderBy(t => t.TabIndex).Where(c => string.IsNullOrEmpty(c.Text.Trim())).ToList();
        }
    }

}
