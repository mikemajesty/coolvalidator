using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CoolValidator
{
    public static class formValidator
    {
        public static List<TextBox> ValidateTextBox(this Form form, ValidateType type = ValidateType.NONE, MessageInfo message = null, Func<TextBox, bool> predicate = null)
        {
            var txtList = new List<TextBox>();

            var txtInPanel = GetTextBoxInContainer<Panel>(form);
            var txtInManyPanel = GetTextBoxInManyContainers<Panel>(form);

            var txtInGroupBox = GetTextBoxInContainer<GroupBox>(form);
            var txtInManyGroupBox = GetTextBoxInManyContainers<GroupBox>(form);

            var txtInSplitContainer = GetTextBoxInSpliContainer(form);

            var txtInTabControl = GetTextBoxInTabControl(form);
            var txtInManyTabControl = GetTextBoxInManyTabControl(form);

            var txtInForm = GetTextBoxInForm(form);

            txtList.AddRange(txtInGroupBox);
            txtList.AddRange(txtInManyGroupBox);

            txtList.AddRange(txtInPanel);
            txtList.AddRange(txtInManyPanel);

            txtList.AddRange(txtInTabControl);
            txtList.AddRange(txtInManyTabControl);

            txtList.AddRange(txtInSplitContainer);

            txtList.AddRange(txtInForm);

            if (txtList.Count > 0 && message != null)
            {
                MessageBox.Show(message.Text == null ? "This field is required" : message.Text, message.Caption == null ? "Warning" : message.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (type == ValidateType.IS_EMPTY)
            {
                txtList = txtList.Where(textBox => string.IsNullOrEmpty(textBox.Text.Trim())).ToList();
            }

            form.ActiveControl = txtList.OrderBy(t => t.TabIndex).FirstOrDefault();

            return predicate == null ? txtList.OrderBy(t => t.TabIndex).ToList() : txtList.Where(predicate).OrderBy(t => t.TabIndex).ToList();
        }

        private static List<TextBox> GetTextBoxInForm(Form form)
        {
            return form.Controls.OfType<TextBox>().ToList();
        }

        private static List<TextBox> GetTextBoxInContainer<T>(Form form) where T : Control
        {
            return form.Controls.OfType<T>().SelectMany(control => control.Controls.OfType<TextBox>()).ToList();
        }

        private static List<TextBox> GetTextBoxInManyContainers<T>(Form form) where T : Control
        {
            return form.Controls.OfType<T>().SelectMany(control => control.Controls.OfType<T>()).SelectMany(textBox => textBox.Controls.OfType<TextBox>()).ToList();
        }

        private static List<TextBox> GetTextBoxInManyTabControl(Form form)
        {
            return form.Controls.OfType<TabControl>().Select(tabPages => tabPages.TabPages).SelectMany(tabPage => tabPage.OfType<TabPage>()).SelectMany(control => control.Controls.OfType<TabControl>()).Select(tabPages => tabPages.TabPages).SelectMany(tabPage => tabPage.OfType<TabPage>()).SelectMany(textBox => textBox.Controls.OfType<TextBox>()).ToList();
        }
        private static List<TextBox> GetTextBoxInTabControl(Form form)
        {
            return form.Controls.OfType<TabControl>().Select(tabPages => tabPages.TabPages).SelectMany(tabPage => tabPage.OfType<TabPage>()).SelectMany(control => control.Controls.OfType<TextBox>()).ToList();
        }

        private static List<TextBox> GetTextBoxInSpliContainer(Form form)
        {
            var list = new List<TextBox>();
            var tab1 = form.Controls.OfType<SplitContainer>().Select(splitContainer => splitContainer.Panel1).SelectMany(control => control.Controls.OfType<TextBox>()).ToList();
            var tab2 = form.Controls.OfType<SplitContainer>().Select(splitContainer => splitContainer.Panel2).SelectMany(control => control.Controls.OfType<TextBox>()).ToList();

            list.AddRange(tab1);
            list.AddRange(tab2);
            return list;
        }
    }
}
