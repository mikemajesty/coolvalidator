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

            var txtInPanel = GetTextBoxInContainer<Panel>(form);
            var txtInManyPanel = GetTextBoxInManyContainers<Panel>(form);

            var txtInGroupBox = GetTextBoxInContainer<GroupBox>(form);
            var txtInManyGroupBox = GetTextBoxInManyContainers<GroupBox>(form);

            var txtInTabControl = GetTextBoxInContainer<TabControl>(form);
            var txtInManyTabControl = GetTextBoxInManyContainers<TabControl>(form);

            var txtInSplitContainer = GetTextBoxInContainer<SplitContainer>(form);
            var txtInManySplitContainer = GetTextBoxInManyContainers<SplitContainer>(form);

            var txtInTableLayoutPanel = GetTextBoxInContainer<TableLayoutPanel>(form);
            var txtInManyTableLayoutPanel = GetTextBoxInManyContainers<TableLayoutPanel>(form);

            var txtInFlowLayoutPanel = GetTextBoxInContainer<FlowLayoutPanel>(form);

            var txtInForm = GetTextBoxInForm(form);

            txtList.AddRange(txtInGroupBox);
            txtList.AddRange(txtInManyGroupBox);

            txtList.AddRange(txtInPanel);
            txtList.AddRange(txtInManyPanel);

            txtList.AddRange(txtInTabControl);
            txtList.AddRange(txtInManyTabControl);

            txtList.AddRange(txtInSplitContainer);
            txtList.AddRange(txtInManySplitContainer);

            txtList.AddRange(txtInTableLayoutPanel);
            txtList.AddRange(txtInManyTableLayoutPanel);

            txtList.AddRange(txtInFlowLayoutPanel);

            txtList.AddRange(txtInForm);

            form.ActiveControl = txtList.OrderBy(t => t.TabIndex).FirstOrDefault();


            return predicate == null ? txtList.OrderBy(t => t.TabIndex).ToList() : txtList.Where(predicate).OrderBy(t => t.TabIndex).ToList();
        }

        private static List<TextBox> GetTextBoxInForm(Form form)
        {
            return form.Controls.OfType<TextBox>().Where(c => string.IsNullOrEmpty(c.Text.Trim())).ToList();
        }

        private static List<TextBox> GetTextBoxInContainer<T>(Form form) where T : Control
        {
            return form.Controls.OfType<T>().SelectMany(panel => panel.Controls.OfType<TextBox>()).Where(c => string.IsNullOrEmpty(c.Text.Trim())).ToList();
        }

        private static List<TextBox> GetTextBoxInManyContainers<T>(Form form) where T : Control
        {
            return form.Controls.OfType<T>().SelectMany(panel => panel.Controls.OfType<T>()).SelectMany(textBox => textBox.Controls.OfType<TextBox>()).Where(c => string.IsNullOrEmpty(c.Text.Trim())).ToList();
        }
    }
}
