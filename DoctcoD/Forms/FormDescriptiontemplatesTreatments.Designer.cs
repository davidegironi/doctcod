namespace DG.DoctcoD.Forms
{
    partial class FormDescriptiontemplatesTreatments
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDescriptiontemplatesTreatments));
            this.panel_filters = new System.Windows.Forms.Panel();
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            this.descriptiontemplatestreatmentsidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vDescriptiontemplatesTreatmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel_list = new System.Windows.Forms.Panel();
            this.button_tabDescriptiontemplatesTreatments_delete = new System.Windows.Forms.Button();
            this.button_tabDescriptiontemplatesTreatments_edit = new System.Windows.Forms.Button();
            this.button_tabDescriptiontemplatesTreatments_new = new System.Windows.Forms.Button();
            this.panel_tabDescriptiontemplatesTreatments_actions = new System.Windows.Forms.Panel();
            this.button_tabDescriptiontemplatesTreatments_cancel = new System.Windows.Forms.Button();
            this.button_tabDescriptiontemplatesTreatments_save = new System.Windows.Forms.Button();
            this.descriptiontemplatestreatments_idTextBox = new System.Windows.Forms.TextBox();
            this.descriptiontemplatestreatmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.descriptiontemplatestreatments_nameTextBox = new System.Windows.Forms.TextBox();
            this.panel_tabDescriptiontemplatesTreatments_data = new System.Windows.Forms.Panel();
            this.descriptiontemplatestreatments_templateLabel = new System.Windows.Forms.Label();
            this.descriptiontemplatestreatments_nameLabel = new System.Windows.Forms.Label();
            this.descriptiontemplatestreatments_idLabel = new System.Windows.Forms.Label();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_tabDescriptiontemplatesTreatments = new System.Windows.Forms.TabPage();
            this.panel_tabDescriptiontemplatesTreatments_updates = new System.Windows.Forms.Panel();
            this.panel_data = new System.Windows.Forms.Panel();
            this.descriptiontemplatestreatments_templateTextBox = new DG.MiniHTMLTextBox.MiniHTMLTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vDescriptiontemplatesTreatmentsBindingSource)).BeginInit();
            this.panel_list.SuspendLayout();
            this.panel_tabDescriptiontemplatesTreatments_actions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descriptiontemplatestreatmentsBindingSource)).BeginInit();
            this.panel_tabDescriptiontemplatesTreatments_data.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.tabPage_tabDescriptiontemplatesTreatments.SuspendLayout();
            this.panel_tabDescriptiontemplatesTreatments_updates.SuspendLayout();
            this.panel_data.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_filters
            // 
            this.panel_filters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_filters.Location = new System.Drawing.Point(0, 0);
            this.panel_filters.Name = "panel_filters";
            this.panel_filters.Size = new System.Drawing.Size(284, 60);
            this.panel_filters.TabIndex = 13;
            // 
            // advancedDataGridView_main
            // 
            this.advancedDataGridView_main.AllowUserToAddRows = false;
            this.advancedDataGridView_main.AllowUserToDeleteRows = false;
            this.advancedDataGridView_main.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.advancedDataGridView_main.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.advancedDataGridView_main.AutoGenerateColumns = false;
            this.advancedDataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView_main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descriptiontemplatestreatmentsidDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.advancedDataGridView_main.DataSource = this.vDescriptiontemplatesTreatmentsBindingSource;
            this.advancedDataGridView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView_main.FilterAndSortEnabled = true;
            this.advancedDataGridView_main.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridView_main.MultiSelect = false;
            this.advancedDataGridView_main.Name = "advancedDataGridView_main";
            this.advancedDataGridView_main.ReadOnly = true;
            this.advancedDataGridView_main.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView_main.RowHeadersVisible = false;
            this.advancedDataGridView_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridView_main.Size = new System.Drawing.Size(284, 501);
            this.advancedDataGridView_main.TabIndex = 0;
            // 
            // descriptiontemplatestreatmentsidDataGridViewTextBoxColumn
            // 
            this.descriptiontemplatestreatmentsidDataGridViewTextBoxColumn.DataPropertyName = "descriptiontemplatestreatments_id";
            this.descriptiontemplatestreatmentsidDataGridViewTextBoxColumn.HeaderText = "Id";
            this.descriptiontemplatestreatmentsidDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.descriptiontemplatestreatmentsidDataGridViewTextBoxColumn.Name = "descriptiontemplatestreatmentsidDataGridViewTextBoxColumn";
            this.descriptiontemplatestreatmentsidDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptiontemplatestreatmentsidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.descriptiontemplatestreatmentsidDataGridViewTextBoxColumn.Width = 80;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // vDescriptiontemplatesTreatmentsBindingSource
            // 
            this.vDescriptiontemplatesTreatmentsBindingSource.DataSource = typeof(DG.DoctcoD.Forms.Objects.VDescriptiontemplatesTreatments);
            // 
            // panel_list
            // 
            this.panel_list.Controls.Add(this.advancedDataGridView_main);
            this.panel_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_list.Location = new System.Drawing.Point(0, 60);
            this.panel_list.Name = "panel_list";
            this.panel_list.Size = new System.Drawing.Size(284, 501);
            this.panel_list.TabIndex = 14;
            // 
            // button_tabDescriptiontemplatesTreatments_delete
            // 
            this.button_tabDescriptiontemplatesTreatments_delete.Location = new System.Drawing.Point(165, 3);
            this.button_tabDescriptiontemplatesTreatments_delete.Name = "button_tabDescriptiontemplatesTreatments_delete";
            this.button_tabDescriptiontemplatesTreatments_delete.Size = new System.Drawing.Size(75, 23);
            this.button_tabDescriptiontemplatesTreatments_delete.TabIndex = 2;
            this.button_tabDescriptiontemplatesTreatments_delete.Text = "Delete";
            this.button_tabDescriptiontemplatesTreatments_delete.UseVisualStyleBackColor = true;
            // 
            // button_tabDescriptiontemplatesTreatments_edit
            // 
            this.button_tabDescriptiontemplatesTreatments_edit.Location = new System.Drawing.Point(84, 3);
            this.button_tabDescriptiontemplatesTreatments_edit.Name = "button_tabDescriptiontemplatesTreatments_edit";
            this.button_tabDescriptiontemplatesTreatments_edit.Size = new System.Drawing.Size(75, 23);
            this.button_tabDescriptiontemplatesTreatments_edit.TabIndex = 1;
            this.button_tabDescriptiontemplatesTreatments_edit.Text = "Edit";
            this.button_tabDescriptiontemplatesTreatments_edit.UseVisualStyleBackColor = true;
            // 
            // button_tabDescriptiontemplatesTreatments_new
            // 
            this.button_tabDescriptiontemplatesTreatments_new.Location = new System.Drawing.Point(3, 3);
            this.button_tabDescriptiontemplatesTreatments_new.Name = "button_tabDescriptiontemplatesTreatments_new";
            this.button_tabDescriptiontemplatesTreatments_new.Size = new System.Drawing.Size(75, 23);
            this.button_tabDescriptiontemplatesTreatments_new.TabIndex = 0;
            this.button_tabDescriptiontemplatesTreatments_new.Text = "New";
            this.button_tabDescriptiontemplatesTreatments_new.UseVisualStyleBackColor = true;
            // 
            // panel_tabDescriptiontemplatesTreatments_actions
            // 
            this.panel_tabDescriptiontemplatesTreatments_actions.Controls.Add(this.button_tabDescriptiontemplatesTreatments_delete);
            this.panel_tabDescriptiontemplatesTreatments_actions.Controls.Add(this.button_tabDescriptiontemplatesTreatments_edit);
            this.panel_tabDescriptiontemplatesTreatments_actions.Controls.Add(this.button_tabDescriptiontemplatesTreatments_new);
            this.panel_tabDescriptiontemplatesTreatments_actions.Location = new System.Drawing.Point(6, 6);
            this.panel_tabDescriptiontemplatesTreatments_actions.Name = "panel_tabDescriptiontemplatesTreatments_actions";
            this.panel_tabDescriptiontemplatesTreatments_actions.Size = new System.Drawing.Size(480, 30);
            this.panel_tabDescriptiontemplatesTreatments_actions.TabIndex = 0;
            // 
            // button_tabDescriptiontemplatesTreatments_cancel
            // 
            this.button_tabDescriptiontemplatesTreatments_cancel.Location = new System.Drawing.Point(402, 3);
            this.button_tabDescriptiontemplatesTreatments_cancel.Name = "button_tabDescriptiontemplatesTreatments_cancel";
            this.button_tabDescriptiontemplatesTreatments_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_tabDescriptiontemplatesTreatments_cancel.TabIndex = 2;
            this.button_tabDescriptiontemplatesTreatments_cancel.Text = "Cancel";
            this.button_tabDescriptiontemplatesTreatments_cancel.UseVisualStyleBackColor = true;
            // 
            // button_tabDescriptiontemplatesTreatments_save
            // 
            this.button_tabDescriptiontemplatesTreatments_save.Location = new System.Drawing.Point(321, 3);
            this.button_tabDescriptiontemplatesTreatments_save.Name = "button_tabDescriptiontemplatesTreatments_save";
            this.button_tabDescriptiontemplatesTreatments_save.Size = new System.Drawing.Size(75, 23);
            this.button_tabDescriptiontemplatesTreatments_save.TabIndex = 1;
            this.button_tabDescriptiontemplatesTreatments_save.Text = "Save";
            this.button_tabDescriptiontemplatesTreatments_save.UseVisualStyleBackColor = true;
            // 
            // descriptiontemplatestreatments_idTextBox
            // 
            this.descriptiontemplatestreatments_idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.descriptiontemplatestreatmentsBindingSource, "descriptiontemplatestreatments_id", true));
            this.descriptiontemplatestreatments_idTextBox.Enabled = false;
            this.descriptiontemplatestreatments_idTextBox.Location = new System.Drawing.Point(12, 25);
            this.descriptiontemplatestreatments_idTextBox.Name = "descriptiontemplatestreatments_idTextBox";
            this.descriptiontemplatestreatments_idTextBox.Size = new System.Drawing.Size(100, 20);
            this.descriptiontemplatestreatments_idTextBox.TabIndex = 1;
            // 
            // descriptiontemplatestreatmentsBindingSource
            // 
            this.descriptiontemplatestreatmentsBindingSource.DataSource = typeof(DG.DoctcoD.Model.Entity.descriptiontemplatestreatments);
            // 
            // descriptiontemplatestreatments_nameTextBox
            // 
            this.descriptiontemplatestreatments_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.descriptiontemplatestreatmentsBindingSource, "descriptiontemplatestreatments_name", true));
            this.descriptiontemplatestreatments_nameTextBox.Location = new System.Drawing.Point(12, 64);
            this.descriptiontemplatestreatments_nameTextBox.Name = "descriptiontemplatestreatments_nameTextBox";
            this.descriptiontemplatestreatments_nameTextBox.Size = new System.Drawing.Size(250, 20);
            this.descriptiontemplatestreatments_nameTextBox.TabIndex = 3;
            // 
            // panel_tabDescriptiontemplatesTreatments_data
            // 
            this.panel_tabDescriptiontemplatesTreatments_data.Controls.Add(this.descriptiontemplatestreatments_templateTextBox);
            this.panel_tabDescriptiontemplatesTreatments_data.Controls.Add(this.descriptiontemplatestreatments_templateLabel);
            this.panel_tabDescriptiontemplatesTreatments_data.Controls.Add(this.descriptiontemplatestreatments_nameLabel);
            this.panel_tabDescriptiontemplatesTreatments_data.Controls.Add(this.descriptiontemplatestreatments_nameTextBox);
            this.panel_tabDescriptiontemplatesTreatments_data.Controls.Add(this.descriptiontemplatestreatments_idLabel);
            this.panel_tabDescriptiontemplatesTreatments_data.Controls.Add(this.descriptiontemplatestreatments_idTextBox);
            this.panel_tabDescriptiontemplatesTreatments_data.Location = new System.Drawing.Point(6, 42);
            this.panel_tabDescriptiontemplatesTreatments_data.Name = "panel_tabDescriptiontemplatesTreatments_data";
            this.panel_tabDescriptiontemplatesTreatments_data.Size = new System.Drawing.Size(480, 311);
            this.panel_tabDescriptiontemplatesTreatments_data.TabIndex = 2;
            // 
            // descriptiontemplatestreatments_templateLabel
            // 
            this.descriptiontemplatestreatments_templateLabel.AutoSize = true;
            this.descriptiontemplatestreatments_templateLabel.Location = new System.Drawing.Point(9, 87);
            this.descriptiontemplatestreatments_templateLabel.Name = "descriptiontemplatestreatments_templateLabel";
            this.descriptiontemplatestreatments_templateLabel.Size = new System.Drawing.Size(54, 13);
            this.descriptiontemplatestreatments_templateLabel.TabIndex = 4;
            this.descriptiontemplatestreatments_templateLabel.Text = "Template:";
            // 
            // descriptiontemplatestreatments_nameLabel
            // 
            this.descriptiontemplatestreatments_nameLabel.AutoSize = true;
            this.descriptiontemplatestreatments_nameLabel.Location = new System.Drawing.Point(9, 48);
            this.descriptiontemplatestreatments_nameLabel.Name = "descriptiontemplatestreatments_nameLabel";
            this.descriptiontemplatestreatments_nameLabel.Size = new System.Drawing.Size(38, 13);
            this.descriptiontemplatestreatments_nameLabel.TabIndex = 2;
            this.descriptiontemplatestreatments_nameLabel.Text = "Name:";
            // 
            // descriptiontemplatestreatments_idLabel
            // 
            this.descriptiontemplatestreatments_idLabel.AutoSize = true;
            this.descriptiontemplatestreatments_idLabel.Location = new System.Drawing.Point(9, 9);
            this.descriptiontemplatestreatments_idLabel.Name = "descriptiontemplatestreatments_idLabel";
            this.descriptiontemplatestreatments_idLabel.Size = new System.Drawing.Size(19, 13);
            this.descriptiontemplatestreatments_idLabel.TabIndex = 0;
            this.descriptiontemplatestreatments_idLabel.Text = "Id:";
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage_tabDescriptiontemplatesTreatments);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(500, 561);
            this.tabControl_main.TabIndex = 0;
            // 
            // tabPage_tabDescriptiontemplatesTreatments
            // 
            this.tabPage_tabDescriptiontemplatesTreatments.Controls.Add(this.panel_tabDescriptiontemplatesTreatments_data);
            this.tabPage_tabDescriptiontemplatesTreatments.Controls.Add(this.panel_tabDescriptiontemplatesTreatments_updates);
            this.tabPage_tabDescriptiontemplatesTreatments.Controls.Add(this.panel_tabDescriptiontemplatesTreatments_actions);
            this.tabPage_tabDescriptiontemplatesTreatments.Location = new System.Drawing.Point(4, 22);
            this.tabPage_tabDescriptiontemplatesTreatments.Name = "tabPage_tabDescriptiontemplatesTreatments";
            this.tabPage_tabDescriptiontemplatesTreatments.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_tabDescriptiontemplatesTreatments.Size = new System.Drawing.Size(492, 535);
            this.tabPage_tabDescriptiontemplatesTreatments.TabIndex = 0;
            this.tabPage_tabDescriptiontemplatesTreatments.Text = "Description Template Treatments";
            this.tabPage_tabDescriptiontemplatesTreatments.UseVisualStyleBackColor = true;
            // 
            // panel_tabDescriptiontemplatesTreatments_updates
            // 
            this.panel_tabDescriptiontemplatesTreatments_updates.Controls.Add(this.button_tabDescriptiontemplatesTreatments_cancel);
            this.panel_tabDescriptiontemplatesTreatments_updates.Controls.Add(this.button_tabDescriptiontemplatesTreatments_save);
            this.panel_tabDescriptiontemplatesTreatments_updates.Location = new System.Drawing.Point(6, 359);
            this.panel_tabDescriptiontemplatesTreatments_updates.Name = "panel_tabDescriptiontemplatesTreatments_updates";
            this.panel_tabDescriptiontemplatesTreatments_updates.Size = new System.Drawing.Size(480, 30);
            this.panel_tabDescriptiontemplatesTreatments_updates.TabIndex = 1;
            // 
            // panel_data
            // 
            this.panel_data.Controls.Add(this.tabControl_main);
            this.panel_data.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_data.Location = new System.Drawing.Point(284, 0);
            this.panel_data.Name = "panel_data";
            this.panel_data.Size = new System.Drawing.Size(500, 561);
            this.panel_data.TabIndex = 12;
            // 
            // descriptiontemplatestreatments_templateTextBox
            // 
            this.descriptiontemplatestreatments_templateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.descriptiontemplatestreatmentsBindingSource, "descriptiontemplatestreatments_template", true));
            this.descriptiontemplatestreatments_templateTextBox.Location = new System.Drawing.Point(12, 103);
            this.descriptiontemplatestreatments_templateTextBox.Name = "descriptiontemplatestreatments_templateTextBox";
            this.descriptiontemplatestreatments_templateTextBox.Padding = new System.Windows.Forms.Padding(1);
            this.descriptiontemplatestreatments_templateTextBox.Size = new System.Drawing.Size(450, 200);
            this.descriptiontemplatestreatments_templateTextBox.TabIndex = 6;
            this.descriptiontemplatestreatments_templateTextBox.Text = null;
            // 
            // FormDescriptiontemplatesTreatments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panel_list);
            this.Controls.Add(this.panel_filters);
            this.Controls.Add(this.panel_data);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormDescriptiontemplatesTreatments";
            this.Text = "Description Templates Treatments";
            this.Load += new System.EventHandler(this.FormDescriptiontemplatesTreatments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vDescriptiontemplatesTreatmentsBindingSource)).EndInit();
            this.panel_list.ResumeLayout(false);
            this.panel_tabDescriptiontemplatesTreatments_actions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.descriptiontemplatestreatmentsBindingSource)).EndInit();
            this.panel_tabDescriptiontemplatesTreatments_data.ResumeLayout(false);
            this.panel_tabDescriptiontemplatesTreatments_data.PerformLayout();
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_tabDescriptiontemplatesTreatments.ResumeLayout(false);
            this.panel_tabDescriptiontemplatesTreatments_updates.ResumeLayout(false);
            this.panel_data.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_filters;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptiontemplatestreatmentsidDataGridViewTextBoxColumn;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_main;
        private System.Windows.Forms.BindingSource vDescriptiontemplatesTreatmentsBindingSource;
        private System.Windows.Forms.Panel panel_list;
        private System.Windows.Forms.Button button_tabDescriptiontemplatesTreatments_delete;
        private System.Windows.Forms.Button button_tabDescriptiontemplatesTreatments_edit;
        private System.Windows.Forms.Button button_tabDescriptiontemplatesTreatments_new;
        private System.Windows.Forms.Panel panel_tabDescriptiontemplatesTreatments_actions;
        private System.Windows.Forms.Button button_tabDescriptiontemplatesTreatments_cancel;
        private System.Windows.Forms.Button button_tabDescriptiontemplatesTreatments_save;
        private System.Windows.Forms.TextBox descriptiontemplatestreatments_idTextBox;
        private System.Windows.Forms.BindingSource descriptiontemplatestreatmentsBindingSource;
        private System.Windows.Forms.TextBox descriptiontemplatestreatments_nameTextBox;
        private System.Windows.Forms.Panel panel_tabDescriptiontemplatesTreatments_data;
        private System.Windows.Forms.Label descriptiontemplatestreatments_nameLabel;
        private System.Windows.Forms.Label descriptiontemplatestreatments_idLabel;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_tabDescriptiontemplatesTreatments;
        private System.Windows.Forms.Panel panel_tabDescriptiontemplatesTreatments_updates;
        private System.Windows.Forms.Panel panel_data;
        private System.Windows.Forms.Label descriptiontemplatestreatments_templateLabel;
        private MiniHTMLTextBox.MiniHTMLTextBox descriptiontemplatestreatments_templateTextBox;
    }
}