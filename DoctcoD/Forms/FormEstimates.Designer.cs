﻿namespace DG.DoctcoD.Forms
{
    partial class FormEstimates
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEstimates));
            this.treatments_idLabel = new System.Windows.Forms.Label();
            this.estimates_deductiontaxrateLabel = new System.Windows.Forms.Label();
            this.estimates_footerLabel = new System.Windows.Forms.Label();
            this.estimates_paymentLabel = new System.Windows.Forms.Label();
            this.estimates_dateLabel = new System.Windows.Forms.Label();
            this.estimates_patientLabel = new System.Windows.Forms.Label();
            this.estimates_numberLabel = new System.Windows.Forms.Label();
            this.estimates_idLabel = new System.Windows.Forms.Label();
            this.estimateslines_unitpriceLabel = new System.Windows.Forms.Label();
            this.estimateslines_taxrateLabel = new System.Windows.Forms.Label();
            this.estimateslines_quantityLabel = new System.Windows.Forms.Label();
            this.estimateslines_descriptionLabel = new System.Windows.Forms.Label();
            this.estimateslines_codeLabel = new System.Windows.Forms.Label();
            this.estimateslines_idLabel = new System.Windows.Forms.Label();
            this.patientstreatments_idLabel = new System.Windows.Forms.Label();
            this.estimates_doctorLabel = new System.Windows.Forms.Label();
            this.treatments_idComboBox = new System.Windows.Forms.ComboBox();
            this.button_tabEstimatesLines_delete = new System.Windows.Forms.Button();
            this.button_tabEstimatesLines_edit = new System.Windows.Forms.Button();
            this.button_tabEstimatesLines_new = new System.Windows.Forms.Button();
            this.panel_tabEstimatesLines_actions = new System.Windows.Forms.Panel();
            this.button_tabEstimatesLines_cancel = new System.Windows.Forms.Button();
            this.button_tabEstimatesLines_save = new System.Windows.Forms.Button();
            this.panel_tabEstimatesLines_updates = new System.Windows.Forms.Panel();
            this.panel_tabEstimatesLines_list = new System.Windows.Forms.Panel();
            this.advancedDataGridView_tabEstimatesLines_list = new Zuby.ADGV.AdvancedDataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitpriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxrateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalpriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vEstimatesLinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox_tabEstimatesLines_filler = new System.Windows.Forms.GroupBox();
            this.computedlines_idComboBox = new System.Windows.Forms.ComboBox();
            this.computedlines_idLabel = new System.Windows.Forms.Label();
            this.estimateslines_unitpriceTextBox = new System.Windows.Forms.TextBox();
            this.estimateslinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.estimateslines_quantityTextBox = new System.Windows.Forms.TextBox();
            this.estimateslines_codeTextBox = new System.Windows.Forms.TextBox();
            this.estimateslines_idTextBox = new System.Windows.Forms.TextBox();
            this.estimateslines_taxrateComboBox = new System.Windows.Forms.ComboBox();
            this.patientstreatments_idComboBox = new System.Windows.Forms.ComboBox();
            this.button_tabEstimates_print = new System.Windows.Forms.Button();
            this.button_tabEstimates_delete = new System.Windows.Forms.Button();
            this.button_tabEstimates_edit = new System.Windows.Forms.Button();
            this.estimateslines_taxrateTextBox = new System.Windows.Forms.TextBox();
            this.estimateslines_descriptionTextBox = new System.Windows.Forms.TextBox();
            this.label_filterDoctors = new System.Windows.Forms.Label();
            this.panel_filters = new System.Windows.Forms.Panel();
            this.comboBox_filterYears = new System.Windows.Forms.ComboBox();
            this.label_filterYears = new System.Windows.Forms.Label();
            this.comboBox_filterDoctors = new System.Windows.Forms.ComboBox();
            this.totaldueinvoicedTextBox = new System.Windows.Forms.TextBox();
            this.totaldueinvoicedLabel = new System.Windows.Forms.Label();
            this.totaldueTextBox = new System.Windows.Forms.TextBox();
            this.totaldueLabel = new System.Windows.Forms.Label();
            this.panel_listtotal = new System.Windows.Forms.Panel();
            this.totalgrossTextBox = new System.Windows.Forms.TextBox();
            this.totalgrossLabel = new System.Windows.Forms.Label();
            this.totalnetTextBox = new System.Windows.Forms.TextBox();
            this.totalnetLabel = new System.Windows.Forms.Label();
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isinvoicedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.vEstimatesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel_list = new System.Windows.Forms.Panel();
            this.button_tabEstimates_new = new System.Windows.Forms.Button();
            this.panel_tabEstimates_data = new System.Windows.Forms.Panel();
            this.estimates_totaldueLabel = new System.Windows.Forms.Label();
            this.estimates_totaldueTextBox = new System.Windows.Forms.TextBox();
            this.estimatesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.estimates_totalgrossLabel = new System.Windows.Forms.Label();
            this.estimates_totalgrossTextBox = new System.Windows.Forms.TextBox();
            this.estimates_totalnetLabel = new System.Windows.Forms.Label();
            this.estimates_totalnetTextBox = new System.Windows.Forms.TextBox();
            this.estimates_invoiceTextBox = new System.Windows.Forms.TextBox();
            this.estimates_invoiceLabel = new System.Windows.Forms.Label();
            this.patients_idComboBox = new System.Windows.Forms.ComboBox();
            this.doctors_idComboBox = new System.Windows.Forms.ComboBox();
            this.estimates_deductiontaxrateComboBox = new System.Windows.Forms.ComboBox();
            this.estimates_deductiontaxrateTextBox = new System.Windows.Forms.TextBox();
            this.estimates_footerComboBox = new System.Windows.Forms.ComboBox();
            this.estimates_footerTextBox = new System.Windows.Forms.TextBox();
            this.estimates_paymentComboBox = new System.Windows.Forms.ComboBox();
            this.estimates_paymentTextBox = new System.Windows.Forms.TextBox();
            this.estimates_patientTextBox = new System.Windows.Forms.TextBox();
            this.estimates_doctorTextBox = new System.Windows.Forms.TextBox();
            this.estimates_dateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.estimates_numberTextBox = new System.Windows.Forms.TextBox();
            this.estimates_idTextBox = new System.Windows.Forms.TextBox();
            this.panel_data = new System.Windows.Forms.Panel();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_tabEstimates = new System.Windows.Forms.TabPage();
            this.panel_tabEstimates_updates = new System.Windows.Forms.Panel();
            this.button_tabEstimates_cancel = new System.Windows.Forms.Button();
            this.button_tabEstimates_save = new System.Windows.Forms.Button();
            this.panel_tabEstimates_actions = new System.Windows.Forms.Panel();
            this.button_tabEstimates_invoice = new System.Windows.Forms.Button();
            this.tabPage_tabEstimatesLines = new System.Windows.Forms.TabPage();
            this.panel_tabEstimatesLines_data = new System.Windows.Forms.Panel();
            this.estimateslines_istaxesdeductionsableCheckBox = new System.Windows.Forms.CheckBox();
            this.panel_tabEstimatesLines_actions.SuspendLayout();
            this.panel_tabEstimatesLines_updates.SuspendLayout();
            this.panel_tabEstimatesLines_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_tabEstimatesLines_list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEstimatesLinesBindingSource)).BeginInit();
            this.groupBox_tabEstimatesLines_filler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estimateslinesBindingSource)).BeginInit();
            this.panel_filters.SuspendLayout();
            this.panel_listtotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEstimatesBindingSource)).BeginInit();
            this.panel_list.SuspendLayout();
            this.panel_tabEstimates_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estimatesBindingSource)).BeginInit();
            this.panel_data.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.tabPage_tabEstimates.SuspendLayout();
            this.panel_tabEstimates_updates.SuspendLayout();
            this.panel_tabEstimates_actions.SuspendLayout();
            this.tabPage_tabEstimatesLines.SuspendLayout();
            this.panel_tabEstimatesLines_data.SuspendLayout();
            this.SuspendLayout();
            // 
            // treatments_idLabel
            // 
            this.treatments_idLabel.AutoSize = true;
            this.treatments_idLabel.Location = new System.Drawing.Point(6, 16);
            this.treatments_idLabel.Name = "treatments_idLabel";
            this.treatments_idLabel.Size = new System.Drawing.Size(58, 13);
            this.treatments_idLabel.TabIndex = 13;
            this.treatments_idLabel.Text = "Treatment:";
            // 
            // estimates_deductiontaxrateLabel
            // 
            this.estimates_deductiontaxrateLabel.AutoSize = true;
            this.estimates_deductiontaxrateLabel.Location = new System.Drawing.Point(9, 399);
            this.estimates_deductiontaxrateLabel.Name = "estimates_deductiontaxrateLabel";
            this.estimates_deductiontaxrateLabel.Size = new System.Drawing.Size(106, 13);
            this.estimates_deductiontaxrateLabel.TabIndex = 18;
            this.estimates_deductiontaxrateLabel.Text = "Deduction Tax Rate:";
            // 
            // estimates_footerLabel
            // 
            this.estimates_footerLabel.AutoSize = true;
            this.estimates_footerLabel.Location = new System.Drawing.Point(229, 304);
            this.estimates_footerLabel.Name = "estimates_footerLabel";
            this.estimates_footerLabel.Size = new System.Drawing.Size(40, 13);
            this.estimates_footerLabel.TabIndex = 15;
            this.estimates_footerLabel.Text = "Footer:";
            // 
            // estimates_paymentLabel
            // 
            this.estimates_paymentLabel.AutoSize = true;
            this.estimates_paymentLabel.Location = new System.Drawing.Point(9, 304);
            this.estimates_paymentLabel.Name = "estimates_paymentLabel";
            this.estimates_paymentLabel.Size = new System.Drawing.Size(51, 13);
            this.estimates_paymentLabel.TabIndex = 12;
            this.estimates_paymentLabel.Text = "Payment:";
            // 
            // estimates_dateLabel
            // 
            this.estimates_dateLabel.AutoSize = true;
            this.estimates_dateLabel.Location = new System.Drawing.Point(125, 48);
            this.estimates_dateLabel.Name = "estimates_dateLabel";
            this.estimates_dateLabel.Size = new System.Drawing.Size(33, 13);
            this.estimates_dateLabel.TabIndex = 8;
            this.estimates_dateLabel.Text = "Date:";
            // 
            // estimates_patientLabel
            // 
            this.estimates_patientLabel.AutoSize = true;
            this.estimates_patientLabel.Location = new System.Drawing.Point(9, 201);
            this.estimates_patientLabel.Name = "estimates_patientLabel";
            this.estimates_patientLabel.Size = new System.Drawing.Size(43, 13);
            this.estimates_patientLabel.TabIndex = 6;
            this.estimates_patientLabel.Text = "Patient:";
            // 
            // estimates_numberLabel
            // 
            this.estimates_numberLabel.AutoSize = true;
            this.estimates_numberLabel.Location = new System.Drawing.Point(9, 48);
            this.estimates_numberLabel.Name = "estimates_numberLabel";
            this.estimates_numberLabel.Size = new System.Drawing.Size(47, 13);
            this.estimates_numberLabel.TabIndex = 2;
            this.estimates_numberLabel.Text = "Number:";
            // 
            // estimates_idLabel
            // 
            this.estimates_idLabel.AutoSize = true;
            this.estimates_idLabel.Location = new System.Drawing.Point(9, 9);
            this.estimates_idLabel.Name = "estimates_idLabel";
            this.estimates_idLabel.Size = new System.Drawing.Size(19, 13);
            this.estimates_idLabel.TabIndex = 0;
            this.estimates_idLabel.Text = "Id:";
            // 
            // estimateslines_unitpriceLabel
            // 
            this.estimateslines_unitpriceLabel.AutoSize = true;
            this.estimateslines_unitpriceLabel.Location = new System.Drawing.Point(65, 217);
            this.estimateslines_unitpriceLabel.Name = "estimateslines_unitpriceLabel";
            this.estimateslines_unitpriceLabel.Size = new System.Drawing.Size(34, 13);
            this.estimateslines_unitpriceLabel.TabIndex = 10;
            this.estimateslines_unitpriceLabel.Text = "Price:";
            // 
            // estimateslines_taxrateLabel
            // 
            this.estimateslines_taxrateLabel.AutoSize = true;
            this.estimateslines_taxrateLabel.Location = new System.Drawing.Point(141, 217);
            this.estimateslines_taxrateLabel.Name = "estimateslines_taxrateLabel";
            this.estimateslines_taxrateLabel.Size = new System.Drawing.Size(54, 13);
            this.estimateslines_taxrateLabel.TabIndex = 8;
            this.estimateslines_taxrateLabel.Text = "Tax Rate:";
            // 
            // estimateslines_quantityLabel
            // 
            this.estimateslines_quantityLabel.AutoSize = true;
            this.estimateslines_quantityLabel.Location = new System.Drawing.Point(9, 217);
            this.estimateslines_quantityLabel.Name = "estimateslines_quantityLabel";
            this.estimateslines_quantityLabel.Size = new System.Drawing.Size(49, 13);
            this.estimateslines_quantityLabel.TabIndex = 6;
            this.estimateslines_quantityLabel.Text = "Quantity:";
            // 
            // estimateslines_descriptionLabel
            // 
            this.estimateslines_descriptionLabel.AutoSize = true;
            this.estimateslines_descriptionLabel.Location = new System.Drawing.Point(9, 128);
            this.estimateslines_descriptionLabel.Name = "estimateslines_descriptionLabel";
            this.estimateslines_descriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.estimateslines_descriptionLabel.TabIndex = 4;
            this.estimateslines_descriptionLabel.Text = "Description:";
            // 
            // estimateslines_codeLabel
            // 
            this.estimateslines_codeLabel.AutoSize = true;
            this.estimateslines_codeLabel.Location = new System.Drawing.Point(9, 89);
            this.estimateslines_codeLabel.Name = "estimateslines_codeLabel";
            this.estimateslines_codeLabel.Size = new System.Drawing.Size(35, 13);
            this.estimateslines_codeLabel.TabIndex = 2;
            this.estimateslines_codeLabel.Text = "Code:";
            // 
            // estimateslines_idLabel
            // 
            this.estimateslines_idLabel.AutoSize = true;
            this.estimateslines_idLabel.Location = new System.Drawing.Point(9, 9);
            this.estimateslines_idLabel.Name = "estimateslines_idLabel";
            this.estimateslines_idLabel.Size = new System.Drawing.Size(19, 13);
            this.estimateslines_idLabel.TabIndex = 0;
            this.estimateslines_idLabel.Text = "Id:";
            // 
            // patientstreatments_idLabel
            // 
            this.patientstreatments_idLabel.AutoSize = true;
            this.patientstreatments_idLabel.Location = new System.Drawing.Point(9, 49);
            this.patientstreatments_idLabel.Name = "patientstreatments_idLabel";
            this.patientstreatments_idLabel.Size = new System.Drawing.Size(94, 13);
            this.patientstreatments_idLabel.TabIndex = 15;
            this.patientstreatments_idLabel.Text = "Patient Treatment:";
            // 
            // estimates_doctorLabel
            // 
            this.estimates_doctorLabel.AutoSize = true;
            this.estimates_doctorLabel.Location = new System.Drawing.Point(9, 98);
            this.estimates_doctorLabel.Name = "estimates_doctorLabel";
            this.estimates_doctorLabel.Size = new System.Drawing.Size(42, 13);
            this.estimates_doctorLabel.TabIndex = 4;
            this.estimates_doctorLabel.Text = "Doctor:";
            // 
            // treatments_idComboBox
            // 
            this.treatments_idComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.treatments_idComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.treatments_idComboBox.FormattingEnabled = true;
            this.treatments_idComboBox.Location = new System.Drawing.Point(9, 32);
            this.treatments_idComboBox.Name = "treatments_idComboBox";
            this.treatments_idComboBox.Size = new System.Drawing.Size(150, 21);
            this.treatments_idComboBox.TabIndex = 14;
            this.treatments_idComboBox.SelectedIndexChanged += new System.EventHandler(this.treatments_idComboBox_SelectedIndexChanged);
            this.treatments_idComboBox.Leave += new System.EventHandler(this.treatments_idComboBox_Leave);
            // 
            // button_tabEstimatesLines_delete
            // 
            this.button_tabEstimatesLines_delete.Location = new System.Drawing.Point(165, 3);
            this.button_tabEstimatesLines_delete.Name = "button_tabEstimatesLines_delete";
            this.button_tabEstimatesLines_delete.Size = new System.Drawing.Size(75, 23);
            this.button_tabEstimatesLines_delete.TabIndex = 2;
            this.button_tabEstimatesLines_delete.Text = "Delete";
            this.button_tabEstimatesLines_delete.UseVisualStyleBackColor = true;
            // 
            // button_tabEstimatesLines_edit
            // 
            this.button_tabEstimatesLines_edit.Location = new System.Drawing.Point(84, 3);
            this.button_tabEstimatesLines_edit.Name = "button_tabEstimatesLines_edit";
            this.button_tabEstimatesLines_edit.Size = new System.Drawing.Size(75, 23);
            this.button_tabEstimatesLines_edit.TabIndex = 1;
            this.button_tabEstimatesLines_edit.Text = "Edit";
            this.button_tabEstimatesLines_edit.UseVisualStyleBackColor = true;
            this.button_tabEstimatesLines_edit.Click += new System.EventHandler(this.button_tabEstimatesLines_edit_Click);
            // 
            // button_tabEstimatesLines_new
            // 
            this.button_tabEstimatesLines_new.Location = new System.Drawing.Point(3, 3);
            this.button_tabEstimatesLines_new.Name = "button_tabEstimatesLines_new";
            this.button_tabEstimatesLines_new.Size = new System.Drawing.Size(75, 23);
            this.button_tabEstimatesLines_new.TabIndex = 0;
            this.button_tabEstimatesLines_new.Text = "New";
            this.button_tabEstimatesLines_new.UseVisualStyleBackColor = true;
            this.button_tabEstimatesLines_new.Click += new System.EventHandler(this.button_tabEstimatesLines_new_Click);
            // 
            // panel_tabEstimatesLines_actions
            // 
            this.panel_tabEstimatesLines_actions.Controls.Add(this.button_tabEstimatesLines_delete);
            this.panel_tabEstimatesLines_actions.Controls.Add(this.button_tabEstimatesLines_edit);
            this.panel_tabEstimatesLines_actions.Controls.Add(this.button_tabEstimatesLines_new);
            this.panel_tabEstimatesLines_actions.Location = new System.Drawing.Point(6, 192);
            this.panel_tabEstimatesLines_actions.Name = "panel_tabEstimatesLines_actions";
            this.panel_tabEstimatesLines_actions.Size = new System.Drawing.Size(480, 30);
            this.panel_tabEstimatesLines_actions.TabIndex = 7;
            // 
            // button_tabEstimatesLines_cancel
            // 
            this.button_tabEstimatesLines_cancel.Location = new System.Drawing.Point(402, 4);
            this.button_tabEstimatesLines_cancel.Name = "button_tabEstimatesLines_cancel";
            this.button_tabEstimatesLines_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_tabEstimatesLines_cancel.TabIndex = 2;
            this.button_tabEstimatesLines_cancel.Text = "Cancel";
            this.button_tabEstimatesLines_cancel.UseVisualStyleBackColor = true;
            // 
            // button_tabEstimatesLines_save
            // 
            this.button_tabEstimatesLines_save.Location = new System.Drawing.Point(321, 3);
            this.button_tabEstimatesLines_save.Name = "button_tabEstimatesLines_save";
            this.button_tabEstimatesLines_save.Size = new System.Drawing.Size(75, 23);
            this.button_tabEstimatesLines_save.TabIndex = 1;
            this.button_tabEstimatesLines_save.Text = "Save";
            this.button_tabEstimatesLines_save.UseVisualStyleBackColor = true;
            // 
            // panel_tabEstimatesLines_updates
            // 
            this.panel_tabEstimatesLines_updates.Controls.Add(this.button_tabEstimatesLines_cancel);
            this.panel_tabEstimatesLines_updates.Controls.Add(this.button_tabEstimatesLines_save);
            this.panel_tabEstimatesLines_updates.Location = new System.Drawing.Point(6, 493);
            this.panel_tabEstimatesLines_updates.Name = "panel_tabEstimatesLines_updates";
            this.panel_tabEstimatesLines_updates.Size = new System.Drawing.Size(480, 30);
            this.panel_tabEstimatesLines_updates.TabIndex = 8;
            // 
            // panel_tabEstimatesLines_list
            // 
            this.panel_tabEstimatesLines_list.Controls.Add(this.advancedDataGridView_tabEstimatesLines_list);
            this.panel_tabEstimatesLines_list.Location = new System.Drawing.Point(6, 6);
            this.panel_tabEstimatesLines_list.Name = "panel_tabEstimatesLines_list";
            this.panel_tabEstimatesLines_list.Size = new System.Drawing.Size(480, 180);
            this.panel_tabEstimatesLines_list.TabIndex = 6;
            // 
            // advancedDataGridView_tabEstimatesLines_list
            // 
            this.advancedDataGridView_tabEstimatesLines_list.AllowUserToAddRows = false;
            this.advancedDataGridView_tabEstimatesLines_list.AllowUserToDeleteRows = false;
            this.advancedDataGridView_tabEstimatesLines_list.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.advancedDataGridView_tabEstimatesLines_list.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.advancedDataGridView_tabEstimatesLines_list.AutoGenerateColumns = false;
            this.advancedDataGridView_tabEstimatesLines_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView_tabEstimatesLines_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.unitpriceDataGridViewTextBoxColumn,
            this.taxrateDataGridViewTextBoxColumn,
            this.totalpriceDataGridViewTextBoxColumn});
            this.advancedDataGridView_tabEstimatesLines_list.DataSource = this.vEstimatesLinesBindingSource;
            this.advancedDataGridView_tabEstimatesLines_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView_tabEstimatesLines_list.FilterAndSortEnabled = true;
            this.advancedDataGridView_tabEstimatesLines_list.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridView_tabEstimatesLines_list.MultiSelect = false;
            this.advancedDataGridView_tabEstimatesLines_list.Name = "advancedDataGridView_tabEstimatesLines_list";
            this.advancedDataGridView_tabEstimatesLines_list.ReadOnly = true;
            this.advancedDataGridView_tabEstimatesLines_list.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView_tabEstimatesLines_list.RowHeadersVisible = false;
            this.advancedDataGridView_tabEstimatesLines_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridView_tabEstimatesLines_list.Size = new System.Drawing.Size(480, 180);
            this.advancedDataGridView_tabEstimatesLines_list.TabIndex = 1;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.codeDataGridViewTextBoxColumn.Width = 60;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Qty";
            this.quantityDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.quantityDataGridViewTextBoxColumn.Width = 50;
            // 
            // unitpriceDataGridViewTextBoxColumn
            // 
            this.unitpriceDataGridViewTextBoxColumn.DataPropertyName = "unitprice";
            this.unitpriceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.unitpriceDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.unitpriceDataGridViewTextBoxColumn.Name = "unitpriceDataGridViewTextBoxColumn";
            this.unitpriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitpriceDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.unitpriceDataGridViewTextBoxColumn.Width = 70;
            // 
            // taxrateDataGridViewTextBoxColumn
            // 
            this.taxrateDataGridViewTextBoxColumn.DataPropertyName = "taxrate";
            this.taxrateDataGridViewTextBoxColumn.HeaderText = "Tax";
            this.taxrateDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.taxrateDataGridViewTextBoxColumn.Name = "taxrateDataGridViewTextBoxColumn";
            this.taxrateDataGridViewTextBoxColumn.ReadOnly = true;
            this.taxrateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.taxrateDataGridViewTextBoxColumn.Width = 60;
            // 
            // totalpriceDataGridViewTextBoxColumn
            // 
            this.totalpriceDataGridViewTextBoxColumn.DataPropertyName = "totalprice";
            dataGridViewCellStyle2.Format = "0.00";
            this.totalpriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.totalpriceDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalpriceDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.totalpriceDataGridViewTextBoxColumn.Name = "totalpriceDataGridViewTextBoxColumn";
            this.totalpriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalpriceDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.totalpriceDataGridViewTextBoxColumn.Width = 70;
            // 
            // vEstimatesLinesBindingSource
            // 
            this.vEstimatesLinesBindingSource.DataSource = typeof(DG.DoctcoD.Forms.Objects.VEstimatesLines);
            // 
            // groupBox_tabEstimatesLines_filler
            // 
            this.groupBox_tabEstimatesLines_filler.Controls.Add(this.computedlines_idComboBox);
            this.groupBox_tabEstimatesLines_filler.Controls.Add(this.computedlines_idLabel);
            this.groupBox_tabEstimatesLines_filler.Controls.Add(this.treatments_idLabel);
            this.groupBox_tabEstimatesLines_filler.Controls.Add(this.treatments_idComboBox);
            this.groupBox_tabEstimatesLines_filler.Location = new System.Drawing.Point(267, 33);
            this.groupBox_tabEstimatesLines_filler.Name = "groupBox_tabEstimatesLines_filler";
            this.groupBox_tabEstimatesLines_filler.Size = new System.Drawing.Size(172, 103);
            this.groupBox_tabEstimatesLines_filler.TabIndex = 18;
            this.groupBox_tabEstimatesLines_filler.TabStop = false;
            this.groupBox_tabEstimatesLines_filler.Text = "Autofill from";
            // 
            // computedlines_idComboBox
            // 
            this.computedlines_idComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.computedlines_idComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.computedlines_idComboBox.FormattingEnabled = true;
            this.computedlines_idComboBox.Location = new System.Drawing.Point(10, 72);
            this.computedlines_idComboBox.Name = "computedlines_idComboBox";
            this.computedlines_idComboBox.Size = new System.Drawing.Size(150, 21);
            this.computedlines_idComboBox.TabIndex = 16;
            this.computedlines_idComboBox.SelectedIndexChanged += new System.EventHandler(this.computedlines_idComboBox_SelectedIndexChanged);
            this.computedlines_idComboBox.Leave += new System.EventHandler(this.computedlines_idComboBox_Leave);
            // 
            // computedlines_idLabel
            // 
            this.computedlines_idLabel.AutoSize = true;
            this.computedlines_idLabel.Location = new System.Drawing.Point(6, 56);
            this.computedlines_idLabel.Name = "computedlines_idLabel";
            this.computedlines_idLabel.Size = new System.Drawing.Size(81, 13);
            this.computedlines_idLabel.TabIndex = 15;
            this.computedlines_idLabel.Text = "Computed Line:";
            // 
            // estimateslines_unitpriceTextBox
            // 
            this.estimateslines_unitpriceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estimateslinesBindingSource, "estimateslines_unitprice", true));
            this.estimateslines_unitpriceTextBox.Location = new System.Drawing.Point(68, 233);
            this.estimateslines_unitpriceTextBox.Name = "estimateslines_unitpriceTextBox";
            this.estimateslines_unitpriceTextBox.Size = new System.Drawing.Size(70, 20);
            this.estimateslines_unitpriceTextBox.TabIndex = 11;
            // 
            // estimateslinesBindingSource
            // 
            this.estimateslinesBindingSource.DataSource = typeof(DG.DoctcoD.Model.Entity.estimateslines);
            // 
            // estimateslines_quantityTextBox
            // 
            this.estimateslines_quantityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estimateslinesBindingSource, "estimateslines_quantity", true));
            this.estimateslines_quantityTextBox.Location = new System.Drawing.Point(12, 233);
            this.estimateslines_quantityTextBox.Name = "estimateslines_quantityTextBox";
            this.estimateslines_quantityTextBox.Size = new System.Drawing.Size(50, 20);
            this.estimateslines_quantityTextBox.TabIndex = 7;
            // 
            // estimateslines_codeTextBox
            // 
            this.estimateslines_codeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estimateslinesBindingSource, "estimateslines_code", true));
            this.estimateslines_codeTextBox.Location = new System.Drawing.Point(12, 105);
            this.estimateslines_codeTextBox.Name = "estimateslines_codeTextBox";
            this.estimateslines_codeTextBox.Size = new System.Drawing.Size(60, 20);
            this.estimateslines_codeTextBox.TabIndex = 3;
            // 
            // estimateslines_idTextBox
            // 
            this.estimateslines_idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estimateslinesBindingSource, "estimateslines_id", true));
            this.estimateslines_idTextBox.Enabled = false;
            this.estimateslines_idTextBox.Location = new System.Drawing.Point(12, 25);
            this.estimateslines_idTextBox.Name = "estimateslines_idTextBox";
            this.estimateslines_idTextBox.Size = new System.Drawing.Size(100, 20);
            this.estimateslines_idTextBox.TabIndex = 1;
            // 
            // estimateslines_taxrateComboBox
            // 
            this.estimateslines_taxrateComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.estimateslines_taxrateComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.estimateslines_taxrateComboBox.FormattingEnabled = true;
            this.estimateslines_taxrateComboBox.Location = new System.Drawing.Point(200, 233);
            this.estimateslines_taxrateComboBox.Name = "estimateslines_taxrateComboBox";
            this.estimateslines_taxrateComboBox.Size = new System.Drawing.Size(100, 21);
            this.estimateslines_taxrateComboBox.TabIndex = 12;
            this.estimateslines_taxrateComboBox.SelectedIndexChanged += new System.EventHandler(this.estimateslines_taxrateComboBox_SelectedIndexChanged);
            this.estimateslines_taxrateComboBox.Leave += new System.EventHandler(this.estimateslines_taxrateComboBox_Leave);
            // 
            // patientstreatments_idComboBox
            // 
            this.patientstreatments_idComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.patientstreatments_idComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.patientstreatments_idComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.estimateslinesBindingSource, "patientstreatments_id", true));
            this.patientstreatments_idComboBox.FormattingEnabled = true;
            this.patientstreatments_idComboBox.Location = new System.Drawing.Point(12, 65);
            this.patientstreatments_idComboBox.Name = "patientstreatments_idComboBox";
            this.patientstreatments_idComboBox.Size = new System.Drawing.Size(249, 21);
            this.patientstreatments_idComboBox.TabIndex = 16;
            this.patientstreatments_idComboBox.SelectedIndexChanged += new System.EventHandler(this.patientstreatments_idComboBox_SelectedIndexChanged);
            // 
            // button_tabEstimates_print
            // 
            this.button_tabEstimates_print.Location = new System.Drawing.Point(246, 3);
            this.button_tabEstimates_print.Name = "button_tabEstimates_print";
            this.button_tabEstimates_print.Size = new System.Drawing.Size(75, 23);
            this.button_tabEstimates_print.TabIndex = 4;
            this.button_tabEstimates_print.Text = "Print";
            this.button_tabEstimates_print.UseVisualStyleBackColor = true;
            this.button_tabEstimates_print.Click += new System.EventHandler(this.button_tabEstimates_print_Click);
            // 
            // button_tabEstimates_delete
            // 
            this.button_tabEstimates_delete.Location = new System.Drawing.Point(165, 3);
            this.button_tabEstimates_delete.Name = "button_tabEstimates_delete";
            this.button_tabEstimates_delete.Size = new System.Drawing.Size(75, 23);
            this.button_tabEstimates_delete.TabIndex = 2;
            this.button_tabEstimates_delete.Text = "Delete";
            this.button_tabEstimates_delete.UseVisualStyleBackColor = true;
            // 
            // button_tabEstimates_edit
            // 
            this.button_tabEstimates_edit.Location = new System.Drawing.Point(84, 3);
            this.button_tabEstimates_edit.Name = "button_tabEstimates_edit";
            this.button_tabEstimates_edit.Size = new System.Drawing.Size(75, 23);
            this.button_tabEstimates_edit.TabIndex = 1;
            this.button_tabEstimates_edit.Text = "Edit";
            this.button_tabEstimates_edit.UseVisualStyleBackColor = true;
            this.button_tabEstimates_edit.Click += new System.EventHandler(this.button_tabEstimates_edit_Click);
            // 
            // estimateslines_taxrateTextBox
            // 
            this.estimateslines_taxrateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estimateslinesBindingSource, "estimateslines_taxrate", true));
            this.estimateslines_taxrateTextBox.Location = new System.Drawing.Point(144, 233);
            this.estimateslines_taxrateTextBox.Name = "estimateslines_taxrateTextBox";
            this.estimateslines_taxrateTextBox.Size = new System.Drawing.Size(50, 20);
            this.estimateslines_taxrateTextBox.TabIndex = 9;
            // 
            // estimateslines_descriptionTextBox
            // 
            this.estimateslines_descriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estimateslinesBindingSource, "estimateslines_description", true));
            this.estimateslines_descriptionTextBox.Location = new System.Drawing.Point(12, 144);
            this.estimateslines_descriptionTextBox.Multiline = true;
            this.estimateslines_descriptionTextBox.Name = "estimateslines_descriptionTextBox";
            this.estimateslines_descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.estimateslines_descriptionTextBox.Size = new System.Drawing.Size(430, 70);
            this.estimateslines_descriptionTextBox.TabIndex = 5;
            // 
            // label_filterDoctors
            // 
            this.label_filterDoctors.AutoSize = true;
            this.label_filterDoctors.Location = new System.Drawing.Point(3, 9);
            this.label_filterDoctors.Name = "label_filterDoctors";
            this.label_filterDoctors.Size = new System.Drawing.Size(42, 13);
            this.label_filterDoctors.TabIndex = 4;
            this.label_filterDoctors.Text = "Doctor:";
            // 
            // panel_filters
            // 
            this.panel_filters.Controls.Add(this.comboBox_filterYears);
            this.panel_filters.Controls.Add(this.label_filterYears);
            this.panel_filters.Controls.Add(this.comboBox_filterDoctors);
            this.panel_filters.Controls.Add(this.label_filterDoctors);
            this.panel_filters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_filters.Location = new System.Drawing.Point(0, 0);
            this.panel_filters.Name = "panel_filters";
            this.panel_filters.Size = new System.Drawing.Size(284, 60);
            this.panel_filters.TabIndex = 13;
            // 
            // comboBox_filterYears
            // 
            this.comboBox_filterYears.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_filterYears.FormattingEnabled = true;
            this.comboBox_filterYears.Location = new System.Drawing.Point(173, 25);
            this.comboBox_filterYears.Name = "comboBox_filterYears";
            this.comboBox_filterYears.Size = new System.Drawing.Size(70, 21);
            this.comboBox_filterYears.TabIndex = 7;
            this.comboBox_filterYears.SelectedIndexChanged += new System.EventHandler(this.comboBox_filterYears_SelectedIndexChanged);
            // 
            // label_filterYears
            // 
            this.label_filterYears.AutoSize = true;
            this.label_filterYears.Location = new System.Drawing.Point(170, 9);
            this.label_filterYears.Name = "label_filterYears";
            this.label_filterYears.Size = new System.Drawing.Size(32, 13);
            this.label_filterYears.TabIndex = 6;
            this.label_filterYears.Text = "Year:";
            // 
            // comboBox_filterDoctors
            // 
            this.comboBox_filterDoctors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_filterDoctors.FormattingEnabled = true;
            this.comboBox_filterDoctors.Location = new System.Drawing.Point(6, 25);
            this.comboBox_filterDoctors.Name = "comboBox_filterDoctors";
            this.comboBox_filterDoctors.Size = new System.Drawing.Size(150, 21);
            this.comboBox_filterDoctors.TabIndex = 5;
            this.comboBox_filterDoctors.SelectedIndexChanged += new System.EventHandler(this.comboBox_filterDoctors_SelectedIndexChanged);
            // 
            // totaldueinvoicedTextBox
            // 
            this.totaldueinvoicedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totaldueinvoicedTextBox.Location = new System.Drawing.Point(188, 85);
            this.totaldueinvoicedTextBox.Name = "totaldueinvoicedTextBox";
            this.totaldueinvoicedTextBox.ReadOnly = true;
            this.totaldueinvoicedTextBox.Size = new System.Drawing.Size(90, 20);
            this.totaldueinvoicedTextBox.TabIndex = 3;
            this.totaldueinvoicedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // totaldueinvoicedLabel
            // 
            this.totaldueinvoicedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totaldueinvoicedLabel.Location = new System.Drawing.Point(32, 87);
            this.totaldueinvoicedLabel.Name = "totaldueinvoicedLabel";
            this.totaldueinvoicedLabel.Size = new System.Drawing.Size(150, 13);
            this.totaldueinvoicedLabel.TabIndex = 2;
            this.totaldueinvoicedLabel.Text = "Total Due Invoiced:";
            this.totaldueinvoicedLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // totaldueTextBox
            // 
            this.totaldueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totaldueTextBox.Location = new System.Drawing.Point(188, 58);
            this.totaldueTextBox.Name = "totaldueTextBox";
            this.totaldueTextBox.ReadOnly = true;
            this.totaldueTextBox.Size = new System.Drawing.Size(90, 20);
            this.totaldueTextBox.TabIndex = 1;
            this.totaldueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // totaldueLabel
            // 
            this.totaldueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totaldueLabel.Location = new System.Drawing.Point(32, 61);
            this.totaldueLabel.Name = "totaldueLabel";
            this.totaldueLabel.Size = new System.Drawing.Size(150, 13);
            this.totaldueLabel.TabIndex = 0;
            this.totaldueLabel.Text = "Total Due:";
            this.totaldueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel_listtotal
            // 
            this.panel_listtotal.Controls.Add(this.totalgrossTextBox);
            this.panel_listtotal.Controls.Add(this.totalgrossLabel);
            this.panel_listtotal.Controls.Add(this.totalnetTextBox);
            this.panel_listtotal.Controls.Add(this.totalnetLabel);
            this.panel_listtotal.Controls.Add(this.totaldueinvoicedTextBox);
            this.panel_listtotal.Controls.Add(this.totaldueinvoicedLabel);
            this.panel_listtotal.Controls.Add(this.totaldueTextBox);
            this.panel_listtotal.Controls.Add(this.totaldueLabel);
            this.panel_listtotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_listtotal.Location = new System.Drawing.Point(0, 390);
            this.panel_listtotal.Name = "panel_listtotal";
            this.panel_listtotal.Size = new System.Drawing.Size(284, 112);
            this.panel_listtotal.TabIndex = 2;
            // 
            // totalgrossTextBox
            // 
            this.totalgrossTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalgrossTextBox.Location = new System.Drawing.Point(188, 32);
            this.totalgrossTextBox.Name = "totalgrossTextBox";
            this.totalgrossTextBox.ReadOnly = true;
            this.totalgrossTextBox.Size = new System.Drawing.Size(90, 20);
            this.totalgrossTextBox.TabIndex = 7;
            this.totalgrossTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // totalgrossLabel
            // 
            this.totalgrossLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalgrossLabel.Location = new System.Drawing.Point(32, 35);
            this.totalgrossLabel.Name = "totalgrossLabel";
            this.totalgrossLabel.Size = new System.Drawing.Size(150, 13);
            this.totalgrossLabel.TabIndex = 6;
            this.totalgrossLabel.Text = "Total Gross:";
            this.totalgrossLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // totalnetTextBox
            // 
            this.totalnetTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalnetTextBox.Location = new System.Drawing.Point(188, 6);
            this.totalnetTextBox.Name = "totalnetTextBox";
            this.totalnetTextBox.ReadOnly = true;
            this.totalnetTextBox.Size = new System.Drawing.Size(90, 20);
            this.totalnetTextBox.TabIndex = 5;
            this.totalnetTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // totalnetLabel
            // 
            this.totalnetLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalnetLabel.Location = new System.Drawing.Point(32, 9);
            this.totalnetLabel.Name = "totalnetLabel";
            this.totalnetLabel.Size = new System.Drawing.Size(150, 13);
            this.totalnetLabel.TabIndex = 4;
            this.totalnetLabel.Text = "Total Net:";
            this.totalnetLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // advancedDataGridView_main
            // 
            this.advancedDataGridView_main.AllowUserToAddRows = false;
            this.advancedDataGridView_main.AllowUserToDeleteRows = false;
            this.advancedDataGridView_main.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.advancedDataGridView_main.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.advancedDataGridView_main.AutoGenerateColumns = false;
            this.advancedDataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView_main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numberDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.patientDataGridViewTextBoxColumn,
            this.isinvoicedDataGridViewCheckBoxColumn});
            this.advancedDataGridView_main.DataSource = this.vEstimatesBindingSource;
            this.advancedDataGridView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView_main.FilterAndSortEnabled = true;
            this.advancedDataGridView_main.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridView_main.MultiSelect = false;
            this.advancedDataGridView_main.Name = "advancedDataGridView_main";
            this.advancedDataGridView_main.ReadOnly = true;
            this.advancedDataGridView_main.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView_main.RowHeadersVisible = false;
            this.advancedDataGridView_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridView_main.Size = new System.Drawing.Size(284, 390);
            this.advancedDataGridView_main.TabIndex = 0;
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "Number";
            this.numberDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.numberDataGridViewTextBoxColumn.Width = 80;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "date";
            dataGridViewCellStyle4.Format = "d";
            this.dateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dateDataGridViewTextBoxColumn.Width = 80;
            // 
            // patientDataGridViewTextBoxColumn
            // 
            this.patientDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.patientDataGridViewTextBoxColumn.DataPropertyName = "patient";
            this.patientDataGridViewTextBoxColumn.HeaderText = "Patient";
            this.patientDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.patientDataGridViewTextBoxColumn.Name = "patientDataGridViewTextBoxColumn";
            this.patientDataGridViewTextBoxColumn.ReadOnly = true;
            this.patientDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // isinvoicedDataGridViewCheckBoxColumn
            // 
            this.isinvoicedDataGridViewCheckBoxColumn.DataPropertyName = "isinvoiced";
            this.isinvoicedDataGridViewCheckBoxColumn.HeaderText = "I";
            this.isinvoicedDataGridViewCheckBoxColumn.MinimumWidth = 22;
            this.isinvoicedDataGridViewCheckBoxColumn.Name = "isinvoicedDataGridViewCheckBoxColumn";
            this.isinvoicedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isinvoicedDataGridViewCheckBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.isinvoicedDataGridViewCheckBoxColumn.Width = 50;
            // 
            // vEstimatesBindingSource
            // 
            this.vEstimatesBindingSource.DataSource = typeof(DG.DoctcoD.Forms.Objects.VEstimates);
            this.vEstimatesBindingSource.CurrentChanged += new System.EventHandler(this.vEstimatesBindingSource_CurrentChanged);
            // 
            // panel_list
            // 
            this.panel_list.Controls.Add(this.advancedDataGridView_main);
            this.panel_list.Controls.Add(this.panel_listtotal);
            this.panel_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_list.Location = new System.Drawing.Point(0, 60);
            this.panel_list.Name = "panel_list";
            this.panel_list.Size = new System.Drawing.Size(284, 502);
            this.panel_list.TabIndex = 14;
            // 
            // button_tabEstimates_new
            // 
            this.button_tabEstimates_new.Location = new System.Drawing.Point(3, 3);
            this.button_tabEstimates_new.Name = "button_tabEstimates_new";
            this.button_tabEstimates_new.Size = new System.Drawing.Size(75, 23);
            this.button_tabEstimates_new.TabIndex = 0;
            this.button_tabEstimates_new.Text = "New";
            this.button_tabEstimates_new.UseVisualStyleBackColor = true;
            this.button_tabEstimates_new.Click += new System.EventHandler(this.button_tabEstimates_new_Click);
            // 
            // panel_tabEstimates_data
            // 
            this.panel_tabEstimates_data.Controls.Add(this.estimates_totaldueLabel);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_totaldueTextBox);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_totalgrossLabel);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_totalgrossTextBox);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_totalnetLabel);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_totalnetTextBox);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_invoiceTextBox);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_invoiceLabel);
            this.panel_tabEstimates_data.Controls.Add(this.patients_idComboBox);
            this.panel_tabEstimates_data.Controls.Add(this.doctors_idComboBox);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_deductiontaxrateComboBox);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_deductiontaxrateLabel);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_deductiontaxrateTextBox);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_footerComboBox);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_footerLabel);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_footerTextBox);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_paymentComboBox);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_paymentLabel);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_paymentTextBox);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_patientTextBox);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_doctorTextBox);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_dateLabel);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_dateDateTimePicker);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_patientLabel);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_doctorLabel);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_numberLabel);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_numberTextBox);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_idLabel);
            this.panel_tabEstimates_data.Controls.Add(this.estimates_idTextBox);
            this.panel_tabEstimates_data.Location = new System.Drawing.Point(6, 42);
            this.panel_tabEstimates_data.Name = "panel_tabEstimates_data";
            this.panel_tabEstimates_data.Size = new System.Drawing.Size(480, 442);
            this.panel_tabEstimates_data.TabIndex = 2;
            // 
            // estimates_totaldueLabel
            // 
            this.estimates_totaldueLabel.AutoSize = true;
            this.estimates_totaldueLabel.Location = new System.Drawing.Point(379, 48);
            this.estimates_totaldueLabel.Name = "estimates_totaldueLabel";
            this.estimates_totaldueLabel.Size = new System.Drawing.Size(30, 13);
            this.estimates_totaldueLabel.TabIndex = 29;
            this.estimates_totaldueLabel.Text = "Due:";
            // 
            // estimates_totaldueTextBox
            // 
            this.estimates_totaldueTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estimatesBindingSource, "estimates_totaldue", true));
            this.estimates_totaldueTextBox.Enabled = false;
            this.estimates_totaldueTextBox.Location = new System.Drawing.Point(382, 64);
            this.estimates_totaldueTextBox.Name = "estimates_totaldueTextBox";
            this.estimates_totaldueTextBox.Size = new System.Drawing.Size(60, 20);
            this.estimates_totaldueTextBox.TabIndex = 30;
            // 
            // estimatesBindingSource
            // 
            this.estimatesBindingSource.DataSource = typeof(DG.DoctcoD.Model.Entity.estimates);
            // 
            // estimates_totalgrossLabel
            // 
            this.estimates_totalgrossLabel.AutoSize = true;
            this.estimates_totalgrossLabel.Location = new System.Drawing.Point(313, 48);
            this.estimates_totalgrossLabel.Name = "estimates_totalgrossLabel";
            this.estimates_totalgrossLabel.Size = new System.Drawing.Size(37, 13);
            this.estimates_totalgrossLabel.TabIndex = 28;
            this.estimates_totalgrossLabel.Text = "Gross:";
            // 
            // estimates_totalgrossTextBox
            // 
            this.estimates_totalgrossTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estimatesBindingSource, "estimates_totalgross", true));
            this.estimates_totalgrossTextBox.Enabled = false;
            this.estimates_totalgrossTextBox.Location = new System.Drawing.Point(316, 64);
            this.estimates_totalgrossTextBox.Name = "estimates_totalgrossTextBox";
            this.estimates_totalgrossTextBox.Size = new System.Drawing.Size(60, 20);
            this.estimates_totalgrossTextBox.TabIndex = 29;
            // 
            // estimates_totalnetLabel
            // 
            this.estimates_totalnetLabel.AutoSize = true;
            this.estimates_totalnetLabel.Location = new System.Drawing.Point(247, 48);
            this.estimates_totalnetLabel.Name = "estimates_totalnetLabel";
            this.estimates_totalnetLabel.Size = new System.Drawing.Size(27, 13);
            this.estimates_totalnetLabel.TabIndex = 27;
            this.estimates_totalnetLabel.Text = "Net:";
            // 
            // estimates_totalnetTextBox
            // 
            this.estimates_totalnetTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estimatesBindingSource, "estimates_totalnet", true));
            this.estimates_totalnetTextBox.Enabled = false;
            this.estimates_totalnetTextBox.Location = new System.Drawing.Point(250, 64);
            this.estimates_totalnetTextBox.Name = "estimates_totalnetTextBox";
            this.estimates_totalnetTextBox.Size = new System.Drawing.Size(60, 20);
            this.estimates_totalnetTextBox.TabIndex = 28;
            // 
            // estimates_invoiceTextBox
            // 
            this.estimates_invoiceTextBox.Enabled = false;
            this.estimates_invoiceTextBox.Location = new System.Drawing.Point(250, 25);
            this.estimates_invoiceTextBox.Name = "estimates_invoiceTextBox";
            this.estimates_invoiceTextBox.Size = new System.Drawing.Size(150, 20);
            this.estimates_invoiceTextBox.TabIndex = 27;
            // 
            // estimates_invoiceLabel
            // 
            this.estimates_invoiceLabel.AutoSize = true;
            this.estimates_invoiceLabel.Location = new System.Drawing.Point(247, 9);
            this.estimates_invoiceLabel.Name = "estimates_invoiceLabel";
            this.estimates_invoiceLabel.Size = new System.Drawing.Size(42, 13);
            this.estimates_invoiceLabel.TabIndex = 26;
            this.estimates_invoiceLabel.Text = "Invoice";
            // 
            // patients_idComboBox
            // 
            this.patients_idComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.patients_idComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.patients_idComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.estimatesBindingSource, "patients_id", true));
            this.patients_idComboBox.FormattingEnabled = true;
            this.patients_idComboBox.Location = new System.Drawing.Point(67, 193);
            this.patients_idComboBox.Name = "patients_idComboBox";
            this.patients_idComboBox.Size = new System.Drawing.Size(121, 21);
            this.patients_idComboBox.TabIndex = 24;
            this.patients_idComboBox.SelectedIndexChanged += new System.EventHandler(this.patients_idComboBox_SelectedIndexChanged);
            // 
            // doctors_idComboBox
            // 
            this.doctors_idComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.doctors_idComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.doctors_idComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.estimatesBindingSource, "doctors_id", true));
            this.doctors_idComboBox.FormattingEnabled = true;
            this.doctors_idComboBox.Location = new System.Drawing.Point(68, 90);
            this.doctors_idComboBox.Name = "doctors_idComboBox";
            this.doctors_idComboBox.Size = new System.Drawing.Size(121, 21);
            this.doctors_idComboBox.TabIndex = 23;
            this.doctors_idComboBox.SelectedIndexChanged += new System.EventHandler(this.doctors_idComboBox_SelectedIndexChanged);
            // 
            // estimates_deductiontaxrateComboBox
            // 
            this.estimates_deductiontaxrateComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.estimates_deductiontaxrateComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.estimates_deductiontaxrateComboBox.FormattingEnabled = true;
            this.estimates_deductiontaxrateComboBox.Location = new System.Drawing.Point(88, 414);
            this.estimates_deductiontaxrateComboBox.Name = "estimates_deductiontaxrateComboBox";
            this.estimates_deductiontaxrateComboBox.Size = new System.Drawing.Size(100, 21);
            this.estimates_deductiontaxrateComboBox.TabIndex = 22;
            this.estimates_deductiontaxrateComboBox.SelectedIndexChanged += new System.EventHandler(this.estimates_deductiontaxrateComboBox_SelectedIndexChanged);
            this.estimates_deductiontaxrateComboBox.Leave += new System.EventHandler(this.estimates_deductiontaxrateComboBox_Leave);
            // 
            // estimates_deductiontaxrateTextBox
            // 
            this.estimates_deductiontaxrateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estimatesBindingSource, "estimates_deductiontaxrate", true));
            this.estimates_deductiontaxrateTextBox.Location = new System.Drawing.Point(12, 415);
            this.estimates_deductiontaxrateTextBox.Name = "estimates_deductiontaxrateTextBox";
            this.estimates_deductiontaxrateTextBox.Size = new System.Drawing.Size(70, 20);
            this.estimates_deductiontaxrateTextBox.TabIndex = 19;
            // 
            // estimates_footerComboBox
            // 
            this.estimates_footerComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.estimates_footerComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.estimates_footerComboBox.FormattingEnabled = true;
            this.estimates_footerComboBox.Location = new System.Drawing.Point(286, 296);
            this.estimates_footerComboBox.Name = "estimates_footerComboBox";
            this.estimates_footerComboBox.Size = new System.Drawing.Size(121, 21);
            this.estimates_footerComboBox.TabIndex = 17;
            this.estimates_footerComboBox.SelectedIndexChanged += new System.EventHandler(this.estimates_footerComboBox_SelectedIndexChanged);
            this.estimates_footerComboBox.Leave += new System.EventHandler(this.estimates_footerComboBox_Leave);
            // 
            // estimates_footerTextBox
            // 
            this.estimates_footerTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estimatesBindingSource, "estimates_footer", true));
            this.estimates_footerTextBox.Location = new System.Drawing.Point(232, 323);
            this.estimates_footerTextBox.Multiline = true;
            this.estimates_footerTextBox.Name = "estimates_footerTextBox";
            this.estimates_footerTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.estimates_footerTextBox.Size = new System.Drawing.Size(210, 70);
            this.estimates_footerTextBox.TabIndex = 16;
            this.estimates_footerTextBox.WordWrap = false;
            // 
            // estimates_paymentComboBox
            // 
            this.estimates_paymentComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.estimates_paymentComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.estimates_paymentComboBox.FormattingEnabled = true;
            this.estimates_paymentComboBox.Location = new System.Drawing.Point(68, 296);
            this.estimates_paymentComboBox.Name = "estimates_paymentComboBox";
            this.estimates_paymentComboBox.Size = new System.Drawing.Size(121, 21);
            this.estimates_paymentComboBox.TabIndex = 14;
            this.estimates_paymentComboBox.SelectedIndexChanged += new System.EventHandler(this.estimates_paymentComboBox_SelectedIndexChanged);
            this.estimates_paymentComboBox.Leave += new System.EventHandler(this.estimates_paymentComboBox_Leave);
            // 
            // estimates_paymentTextBox
            // 
            this.estimates_paymentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estimatesBindingSource, "estimates_payment", true));
            this.estimates_paymentTextBox.Location = new System.Drawing.Point(12, 323);
            this.estimates_paymentTextBox.Multiline = true;
            this.estimates_paymentTextBox.Name = "estimates_paymentTextBox";
            this.estimates_paymentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.estimates_paymentTextBox.Size = new System.Drawing.Size(210, 70);
            this.estimates_paymentTextBox.TabIndex = 13;
            this.estimates_paymentTextBox.WordWrap = false;
            // 
            // estimates_patientTextBox
            // 
            this.estimates_patientTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estimatesBindingSource, "estimates_patient", true));
            this.estimates_patientTextBox.Location = new System.Drawing.Point(12, 220);
            this.estimates_patientTextBox.Multiline = true;
            this.estimates_patientTextBox.Name = "estimates_patientTextBox";
            this.estimates_patientTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.estimates_patientTextBox.Size = new System.Drawing.Size(430, 70);
            this.estimates_patientTextBox.TabIndex = 12;
            this.estimates_patientTextBox.WordWrap = false;
            // 
            // estimates_doctorTextBox
            // 
            this.estimates_doctorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estimatesBindingSource, "estimates_doctor", true));
            this.estimates_doctorTextBox.Location = new System.Drawing.Point(12, 117);
            this.estimates_doctorTextBox.Multiline = true;
            this.estimates_doctorTextBox.Name = "estimates_doctorTextBox";
            this.estimates_doctorTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.estimates_doctorTextBox.Size = new System.Drawing.Size(430, 70);
            this.estimates_doctorTextBox.TabIndex = 11;
            this.estimates_doctorTextBox.WordWrap = false;
            // 
            // estimates_dateDateTimePicker
            // 
            this.estimates_dateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.estimatesBindingSource, "estimates_date", true));
            this.estimates_dateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.estimates_dateDateTimePicker.Location = new System.Drawing.Point(128, 64);
            this.estimates_dateDateTimePicker.Name = "estimates_dateDateTimePicker";
            this.estimates_dateDateTimePicker.Size = new System.Drawing.Size(100, 20);
            this.estimates_dateDateTimePicker.TabIndex = 9;
            // 
            // estimates_numberTextBox
            // 
            this.estimates_numberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estimatesBindingSource, "estimates_number", true));
            this.estimates_numberTextBox.Location = new System.Drawing.Point(12, 64);
            this.estimates_numberTextBox.Name = "estimates_numberTextBox";
            this.estimates_numberTextBox.Size = new System.Drawing.Size(100, 20);
            this.estimates_numberTextBox.TabIndex = 3;
            // 
            // estimates_idTextBox
            // 
            this.estimates_idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estimatesBindingSource, "estimates_id", true));
            this.estimates_idTextBox.Enabled = false;
            this.estimates_idTextBox.Location = new System.Drawing.Point(12, 25);
            this.estimates_idTextBox.Name = "estimates_idTextBox";
            this.estimates_idTextBox.Size = new System.Drawing.Size(100, 20);
            this.estimates_idTextBox.TabIndex = 1;
            // 
            // panel_data
            // 
            this.panel_data.Controls.Add(this.tabControl_main);
            this.panel_data.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_data.Location = new System.Drawing.Point(284, 0);
            this.panel_data.Name = "panel_data";
            this.panel_data.Size = new System.Drawing.Size(500, 562);
            this.panel_data.TabIndex = 12;
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage_tabEstimates);
            this.tabControl_main.Controls.Add(this.tabPage_tabEstimatesLines);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(500, 562);
            this.tabControl_main.TabIndex = 0;
            // 
            // tabPage_tabEstimates
            // 
            this.tabPage_tabEstimates.AutoScroll = true;
            this.tabPage_tabEstimates.Controls.Add(this.panel_tabEstimates_data);
            this.tabPage_tabEstimates.Controls.Add(this.panel_tabEstimates_updates);
            this.tabPage_tabEstimates.Controls.Add(this.panel_tabEstimates_actions);
            this.tabPage_tabEstimates.Location = new System.Drawing.Point(4, 22);
            this.tabPage_tabEstimates.Name = "tabPage_tabEstimates";
            this.tabPage_tabEstimates.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_tabEstimates.Size = new System.Drawing.Size(492, 536);
            this.tabPage_tabEstimates.TabIndex = 0;
            this.tabPage_tabEstimates.Text = "Estimates";
            this.tabPage_tabEstimates.UseVisualStyleBackColor = true;
            // 
            // panel_tabEstimates_updates
            // 
            this.panel_tabEstimates_updates.Controls.Add(this.button_tabEstimates_cancel);
            this.panel_tabEstimates_updates.Controls.Add(this.button_tabEstimates_save);
            this.panel_tabEstimates_updates.Location = new System.Drawing.Point(6, 492);
            this.panel_tabEstimates_updates.Name = "panel_tabEstimates_updates";
            this.panel_tabEstimates_updates.Size = new System.Drawing.Size(480, 30);
            this.panel_tabEstimates_updates.TabIndex = 1;
            // 
            // button_tabEstimates_cancel
            // 
            this.button_tabEstimates_cancel.Location = new System.Drawing.Point(402, 3);
            this.button_tabEstimates_cancel.Name = "button_tabEstimates_cancel";
            this.button_tabEstimates_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_tabEstimates_cancel.TabIndex = 2;
            this.button_tabEstimates_cancel.Text = "Cancel";
            this.button_tabEstimates_cancel.UseVisualStyleBackColor = true;
            // 
            // button_tabEstimates_save
            // 
            this.button_tabEstimates_save.Location = new System.Drawing.Point(321, 3);
            this.button_tabEstimates_save.Name = "button_tabEstimates_save";
            this.button_tabEstimates_save.Size = new System.Drawing.Size(75, 23);
            this.button_tabEstimates_save.TabIndex = 1;
            this.button_tabEstimates_save.Text = "Save";
            this.button_tabEstimates_save.UseVisualStyleBackColor = true;
            this.button_tabEstimates_save.Click += new System.EventHandler(this.button_tabEstimates_save_Click);
            // 
            // panel_tabEstimates_actions
            // 
            this.panel_tabEstimates_actions.Controls.Add(this.button_tabEstimates_invoice);
            this.panel_tabEstimates_actions.Controls.Add(this.button_tabEstimates_print);
            this.panel_tabEstimates_actions.Controls.Add(this.button_tabEstimates_delete);
            this.panel_tabEstimates_actions.Controls.Add(this.button_tabEstimates_edit);
            this.panel_tabEstimates_actions.Controls.Add(this.button_tabEstimates_new);
            this.panel_tabEstimates_actions.Location = new System.Drawing.Point(6, 6);
            this.panel_tabEstimates_actions.Name = "panel_tabEstimates_actions";
            this.panel_tabEstimates_actions.Size = new System.Drawing.Size(480, 30);
            this.panel_tabEstimates_actions.TabIndex = 0;
            // 
            // button_tabEstimates_invoice
            // 
            this.button_tabEstimates_invoice.Location = new System.Drawing.Point(402, 3);
            this.button_tabEstimates_invoice.Name = "button_tabEstimates_invoice";
            this.button_tabEstimates_invoice.Size = new System.Drawing.Size(75, 23);
            this.button_tabEstimates_invoice.TabIndex = 5;
            this.button_tabEstimates_invoice.Text = "Invoice";
            this.button_tabEstimates_invoice.UseVisualStyleBackColor = true;
            this.button_tabEstimates_invoice.Click += new System.EventHandler(this.button_tabEstimates_invoiced_Click);
            // 
            // tabPage_tabEstimatesLines
            // 
            this.tabPage_tabEstimatesLines.AutoScroll = true;
            this.tabPage_tabEstimatesLines.Controls.Add(this.panel_tabEstimatesLines_data);
            this.tabPage_tabEstimatesLines.Controls.Add(this.panel_tabEstimatesLines_updates);
            this.tabPage_tabEstimatesLines.Controls.Add(this.panel_tabEstimatesLines_actions);
            this.tabPage_tabEstimatesLines.Controls.Add(this.panel_tabEstimatesLines_list);
            this.tabPage_tabEstimatesLines.Location = new System.Drawing.Point(4, 22);
            this.tabPage_tabEstimatesLines.Name = "tabPage_tabEstimatesLines";
            this.tabPage_tabEstimatesLines.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_tabEstimatesLines.Size = new System.Drawing.Size(492, 536);
            this.tabPage_tabEstimatesLines.TabIndex = 1;
            this.tabPage_tabEstimatesLines.Text = "Lines";
            this.tabPage_tabEstimatesLines.UseVisualStyleBackColor = true;
            // 
            // panel_tabEstimatesLines_data
            // 
            this.panel_tabEstimatesLines_data.Controls.Add(this.estimateslines_istaxesdeductionsableCheckBox);
            this.panel_tabEstimatesLines_data.Controls.Add(this.groupBox_tabEstimatesLines_filler);
            this.panel_tabEstimatesLines_data.Controls.Add(this.estimateslines_taxrateComboBox);
            this.panel_tabEstimatesLines_data.Controls.Add(this.patientstreatments_idLabel);
            this.panel_tabEstimatesLines_data.Controls.Add(this.patientstreatments_idComboBox);
            this.panel_tabEstimatesLines_data.Controls.Add(this.estimateslines_unitpriceLabel);
            this.panel_tabEstimatesLines_data.Controls.Add(this.estimateslines_unitpriceTextBox);
            this.panel_tabEstimatesLines_data.Controls.Add(this.estimateslines_taxrateLabel);
            this.panel_tabEstimatesLines_data.Controls.Add(this.estimateslines_taxrateTextBox);
            this.panel_tabEstimatesLines_data.Controls.Add(this.estimateslines_quantityLabel);
            this.panel_tabEstimatesLines_data.Controls.Add(this.estimateslines_quantityTextBox);
            this.panel_tabEstimatesLines_data.Controls.Add(this.estimateslines_descriptionLabel);
            this.panel_tabEstimatesLines_data.Controls.Add(this.estimateslines_descriptionTextBox);
            this.panel_tabEstimatesLines_data.Controls.Add(this.estimateslines_codeLabel);
            this.panel_tabEstimatesLines_data.Controls.Add(this.estimateslines_codeTextBox);
            this.panel_tabEstimatesLines_data.Controls.Add(this.estimateslines_idLabel);
            this.panel_tabEstimatesLines_data.Controls.Add(this.estimateslines_idTextBox);
            this.panel_tabEstimatesLines_data.Location = new System.Drawing.Point(6, 228);
            this.panel_tabEstimatesLines_data.Name = "panel_tabEstimatesLines_data";
            this.panel_tabEstimatesLines_data.Size = new System.Drawing.Size(480, 259);
            this.panel_tabEstimatesLines_data.TabIndex = 9;
            // 
            // estimateslines_istaxesdeductionsableCheckBox
            // 
            this.estimateslines_istaxesdeductionsableCheckBox.AutoSize = true;
            this.estimateslines_istaxesdeductionsableCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.estimateslinesBindingSource, "estimateslines_istaxesdeductionsable", true));
            this.estimateslines_istaxesdeductionsableCheckBox.Location = new System.Drawing.Point(312, 234);
            this.estimateslines_istaxesdeductionsableCheckBox.Name = "estimateslines_istaxesdeductionsableCheckBox";
            this.estimateslines_istaxesdeductionsableCheckBox.Size = new System.Drawing.Size(130, 17);
            this.estimateslines_istaxesdeductionsableCheckBox.TabIndex = 19;
            this.estimateslines_istaxesdeductionsableCheckBox.Text = "Is deduction tax abled";
            this.estimateslines_istaxesdeductionsableCheckBox.UseVisualStyleBackColor = true;
            // 
            // FormEstimates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel_list);
            this.Controls.Add(this.panel_filters);
            this.Controls.Add(this.panel_data);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormEstimates";
            this.Text = "Estimates";
            this.Load += new System.EventHandler(this.FormEstimates_Load);
            this.panel_tabEstimatesLines_actions.ResumeLayout(false);
            this.panel_tabEstimatesLines_updates.ResumeLayout(false);
            this.panel_tabEstimatesLines_list.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_tabEstimatesLines_list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEstimatesLinesBindingSource)).EndInit();
            this.groupBox_tabEstimatesLines_filler.ResumeLayout(false);
            this.groupBox_tabEstimatesLines_filler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estimateslinesBindingSource)).EndInit();
            this.panel_filters.ResumeLayout(false);
            this.panel_filters.PerformLayout();
            this.panel_listtotal.ResumeLayout(false);
            this.panel_listtotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEstimatesBindingSource)).EndInit();
            this.panel_list.ResumeLayout(false);
            this.panel_tabEstimates_data.ResumeLayout(false);
            this.panel_tabEstimates_data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estimatesBindingSource)).EndInit();
            this.panel_data.ResumeLayout(false);
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_tabEstimates.ResumeLayout(false);
            this.panel_tabEstimates_updates.ResumeLayout(false);
            this.panel_tabEstimates_actions.ResumeLayout(false);
            this.tabPage_tabEstimatesLines.ResumeLayout(false);
            this.panel_tabEstimatesLines_data.ResumeLayout(false);
            this.panel_tabEstimatesLines_data.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox treatments_idComboBox;
        private System.Windows.Forms.Button button_tabEstimatesLines_delete;
        private System.Windows.Forms.Button button_tabEstimatesLines_edit;
        private System.Windows.Forms.Button button_tabEstimatesLines_new;
        private System.Windows.Forms.Panel panel_tabEstimatesLines_actions;
        private System.Windows.Forms.Button button_tabEstimatesLines_cancel;
        private System.Windows.Forms.Button button_tabEstimatesLines_save;
        private System.Windows.Forms.Panel panel_tabEstimatesLines_updates;
        private System.Windows.Forms.Panel panel_tabEstimatesLines_list;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_tabEstimatesLines_list;
        private System.Windows.Forms.GroupBox groupBox_tabEstimatesLines_filler;
        private System.Windows.Forms.TextBox estimateslines_unitpriceTextBox;
        private System.Windows.Forms.BindingSource estimateslinesBindingSource;
        private System.Windows.Forms.TextBox estimateslines_quantityTextBox;
        private System.Windows.Forms.TextBox estimateslines_codeTextBox;
        private System.Windows.Forms.TextBox estimateslines_idTextBox;
        private System.Windows.Forms.ComboBox estimateslines_taxrateComboBox;
        private System.Windows.Forms.ComboBox patientstreatments_idComboBox;
        private System.Windows.Forms.Button button_tabEstimates_print;
        private System.Windows.Forms.Button button_tabEstimates_delete;
        private System.Windows.Forms.Button button_tabEstimates_edit;
        private System.Windows.Forms.TextBox estimateslines_taxrateTextBox;
        private System.Windows.Forms.TextBox estimateslines_descriptionTextBox;
        private System.Windows.Forms.Label label_filterDoctors;
        private System.Windows.Forms.Panel panel_filters;
        private System.Windows.Forms.ComboBox comboBox_filterDoctors;
        private System.Windows.Forms.TextBox totaldueinvoicedTextBox;
        private System.Windows.Forms.Label totaldueinvoicedLabel;
        private System.Windows.Forms.TextBox totaldueTextBox;
        private System.Windows.Forms.Label totaldueLabel;
        private System.Windows.Forms.Panel panel_listtotal;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_main;
        private System.Windows.Forms.Panel panel_list;
        private System.Windows.Forms.Button button_tabEstimates_new;
        private System.Windows.Forms.Panel panel_tabEstimates_data;
        private System.Windows.Forms.BindingSource estimatesBindingSource;
        private System.Windows.Forms.ComboBox patients_idComboBox;
        private System.Windows.Forms.ComboBox doctors_idComboBox;
        private System.Windows.Forms.ComboBox estimates_deductiontaxrateComboBox;
        private System.Windows.Forms.TextBox estimates_deductiontaxrateTextBox;
        private System.Windows.Forms.ComboBox estimates_footerComboBox;
        private System.Windows.Forms.TextBox estimates_footerTextBox;
        private System.Windows.Forms.ComboBox estimates_paymentComboBox;
        private System.Windows.Forms.TextBox estimates_paymentTextBox;
        private System.Windows.Forms.TextBox estimates_patientTextBox;
        private System.Windows.Forms.TextBox estimates_doctorTextBox;
        private System.Windows.Forms.DateTimePicker estimates_dateDateTimePicker;
        private System.Windows.Forms.TextBox estimates_numberTextBox;
        private System.Windows.Forms.TextBox estimates_idTextBox;
        private System.Windows.Forms.Panel panel_data;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_tabEstimates;
        private System.Windows.Forms.Panel panel_tabEstimates_updates;
        private System.Windows.Forms.Button button_tabEstimates_cancel;
        private System.Windows.Forms.Button button_tabEstimates_save;
        private System.Windows.Forms.Panel panel_tabEstimates_actions;
        private System.Windows.Forms.TabPage tabPage_tabEstimatesLines;
        private System.Windows.Forms.Panel panel_tabEstimatesLines_data;
        private System.Windows.Forms.BindingSource vEstimatesLinesBindingSource;
        private System.Windows.Forms.BindingSource vEstimatesBindingSource;
        private System.Windows.Forms.Label estimates_doctorLabel;
        private System.Windows.Forms.Button button_tabEstimates_invoice;
        private System.Windows.Forms.TextBox estimates_invoiceTextBox;
        private System.Windows.Forms.Label estimates_invoiceLabel;
        private System.Windows.Forms.ComboBox comboBox_filterYears;
        private System.Windows.Forms.Label label_filterYears;
        private System.Windows.Forms.Label estimates_deductiontaxrateLabel;
        private System.Windows.Forms.Label estimates_footerLabel;
        private System.Windows.Forms.Label estimates_paymentLabel;
        private System.Windows.Forms.Label estimates_dateLabel;
        private System.Windows.Forms.Label estimates_patientLabel;
        private System.Windows.Forms.Label estimates_numberLabel;
        private System.Windows.Forms.Label estimates_idLabel;
        private System.Windows.Forms.Label treatments_idLabel;
        private System.Windows.Forms.Label estimateslines_unitpriceLabel;
        private System.Windows.Forms.Label estimateslines_taxrateLabel;
        private System.Windows.Forms.Label estimateslines_quantityLabel;
        private System.Windows.Forms.Label estimateslines_descriptionLabel;
        private System.Windows.Forms.Label estimateslines_codeLabel;
        private System.Windows.Forms.Label estimateslines_idLabel;
        private System.Windows.Forms.Label patientstreatments_idLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isinvoicedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitpriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxrateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalpriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label estimates_totaldueLabel;
        private System.Windows.Forms.TextBox estimates_totaldueTextBox;
        private System.Windows.Forms.Label estimates_totalgrossLabel;
        private System.Windows.Forms.TextBox estimates_totalgrossTextBox;
        private System.Windows.Forms.Label estimates_totalnetLabel;
        private System.Windows.Forms.TextBox estimates_totalnetTextBox;
        private System.Windows.Forms.CheckBox estimateslines_istaxesdeductionsableCheckBox;
        private System.Windows.Forms.ComboBox computedlines_idComboBox;
        private System.Windows.Forms.Label computedlines_idLabel;
        private System.Windows.Forms.TextBox totalgrossTextBox;
        private System.Windows.Forms.Label totalgrossLabel;
        private System.Windows.Forms.TextBox totalnetTextBox;
        private System.Windows.Forms.Label totalnetLabel;
    }
}