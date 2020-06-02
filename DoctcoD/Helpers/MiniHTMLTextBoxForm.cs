#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System.Windows.Forms;

namespace DG.DoctcoD.Helpers
{
    /// <summary>
    /// MiniHTMLTextBox builder for C#
    /// </summary>
    public static class MiniHTMLTextBoxForm
    {
        /// <summary>
        /// Show an TextBoxForm
        /// </summary>
        /// <param name="title"></param>
        /// <param name="text"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DialogResult Show(string title, string text, ref string value)
        {
            return Show(title, text, null, ref value);
        }

        /// <summary>
        /// Show an TextBoxForm
        /// </summary>
        /// <param name="title"></param>
        /// <param name="text"></param>
        /// <param name="parent"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DialogResult Show(string title, string text, Form parent, ref string value)
        {
            Form form = new Form();
            MiniHTMLTextBox.MiniHTMLTextBox textBox = new MiniHTMLTextBox.MiniHTMLTextBox();
            Button buttonClose = new Button();
            Panel panelTop = new Panel();
            Panel panelBottom = new Panel();

            panelTop.Controls.Add(textBox);
            panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Size = new System.Drawing.Size(384, 161);
            panelTop.TabIndex = 0;

            panelBottom.Controls.Add(buttonClose);
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Location = new System.Drawing.Point(0, 126);
            panelBottom.Size = new System.Drawing.Size(384, 35);
            panelBottom.TabIndex = 1;

            buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            buttonClose.Location = new System.Drawing.Point(297, 6);
            buttonClose.Size = new System.Drawing.Size(75, 23);
            buttonClose.TabIndex = 1;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.DialogResult = DialogResult.OK;

            textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            textBox.Location = new System.Drawing.Point(0, 0);
            textBox.ViewMode = MiniHTMLTextBox.MiniHTMLTextBox.ViewModeType.HTML;
            textBox.Size = new System.Drawing.Size(384, 161);
            textBox.TabIndex = 0;
            textBox.Text = text;

            form.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            form.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            form.Controls.Add(panelBottom);
            form.Controls.Add(panelTop);
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            form.MinimumSize = new System.Drawing.Size(400, 200);
            form.StartPosition = FormStartPosition.CenterParent;
            if (parent != null)
                form.ClientSize = new System.Drawing.Size(parent.Width - 20, parent.Height - 20);
            else
                form.ClientSize = new System.Drawing.Size(400, 200);
            form.Text = title;
            form.MinimizeBox = true;
            form.MaximizeBox = true;
            form.AcceptButton = buttonClose;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
    }

}

