﻿#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.Data.Model.Helpers;
using DG.DoctcoD.Forms.Objects;
using DG.DoctcoD.Helpers;
using DG.DoctcoD.Model;
using DG.DoctcoD.Model.Entity;
using DG.UI.GHF;
using DG.UI.Helpers;
using SMcMaster;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Zuby.ADGV;

namespace DG.DoctcoD.Forms
{
    public partial class FormEstimates : DGUIGHFForm
    {
        private DoctcoDModel _doctcodModel = null;

        private TabElement tabElement_tabEstimates = new TabElement();
        private TabElement tabElement_tabEstimatesLines = new TabElement();

        private readonly BoxLoader _boxLoader = null;

        private const int MaxRowValueLength = 60;

        private readonly bool _autoincrementInvoicesEstimatesNumber = false;

        /// <summary>
        /// Constructor
        /// </summary>
        public FormEstimates()
        {
            InitializeComponent();
            (new TabOrderManager(this)).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);

            Initialize(Program.uighfApplication);

            _doctcodModel = new DoctcoDModel();
            _doctcodModel.LanguageHelper.LoadFromFile(Program.uighfApplication.LanguageFilename);

            _boxLoader = new BoxLoader(_doctcodModel);

            panel_listtotal.Visible = Convert.ToBoolean(ConfigurationManager.AppSettings["showInvoicesEstimatesTotal"]);
            _autoincrementInvoicesEstimatesNumber = Convert.ToBoolean(ConfigurationManager.AppSettings["autoincrementInvoicesEstimatesNumber"]);
        }

        /// <summary>
        /// Add components language
        /// </summary>
        public override void AddLanguageComponents()
        {
            //main
            LanguageHelper.AddComponent(this);
            LanguageHelper.AddComponent(label_filterDoctors);
            LanguageHelper.AddComponent(label_filterYears);
            LanguageHelper.AddComponent(totalnetLabel);
            LanguageHelper.AddComponent(totalgrossLabel);
            LanguageHelper.AddComponent(totaldueLabel);
            LanguageHelper.AddComponent(totaldueinvoicedLabel);
            LanguageHelper.AddComponent(numberDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(dateDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(patientDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(isinvoicedDataGridViewCheckBoxColumn, this.GetType().Name, "HeaderText");
            //tabEstimates
            LanguageHelper.AddComponent(tabPage_tabEstimates);
            LanguageHelper.AddComponent(button_tabEstimates_new);
            LanguageHelper.AddComponent(button_tabEstimates_edit);
            LanguageHelper.AddComponent(button_tabEstimates_delete);
            LanguageHelper.AddComponent(button_tabEstimates_save);
            LanguageHelper.AddComponent(button_tabEstimates_cancel);
            LanguageHelper.AddComponent(button_tabEstimates_print);
            LanguageHelper.AddComponent(button_tabEstimates_invoice);
            LanguageHelper.AddComponent(estimates_idLabel);
            LanguageHelper.AddComponent(estimates_numberLabel);
            LanguageHelper.AddComponent(estimates_invoiceLabel);
            LanguageHelper.AddComponent(estimates_totalnetLabel);
            LanguageHelper.AddComponent(estimates_totalgrossLabel);
            LanguageHelper.AddComponent(estimates_totaldueLabel);
            LanguageHelper.AddComponent(estimates_dateLabel);
            LanguageHelper.AddComponent(estimates_doctorLabel);
            LanguageHelper.AddComponent(estimates_patientLabel);
            LanguageHelper.AddComponent(estimates_paymentLabel);
            LanguageHelper.AddComponent(estimates_footerLabel);
            LanguageHelper.AddComponent(estimates_deductiontaxrateLabel);
            //tabEstimatesLines
            LanguageHelper.AddComponent(tabPage_tabEstimatesLines);
            LanguageHelper.AddComponent(codeDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(descriptionDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(quantityDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(unitpriceDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(taxrateDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(totalpriceDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(button_tabEstimatesLines_new);
            LanguageHelper.AddComponent(button_tabEstimatesLines_edit);
            LanguageHelper.AddComponent(button_tabEstimatesLines_delete);
            LanguageHelper.AddComponent(button_tabEstimatesLines_save);
            LanguageHelper.AddComponent(button_tabEstimatesLines_cancel);
            LanguageHelper.AddComponent(estimateslines_idLabel);
            LanguageHelper.AddComponent(patientstreatments_idLabel);
            LanguageHelper.AddComponent(estimateslines_codeLabel);
            LanguageHelper.AddComponent(estimateslines_quantityLabel);
            LanguageHelper.AddComponent(estimateslines_unitpriceLabel);
            LanguageHelper.AddComponent(estimateslines_taxrateLabel);
            LanguageHelper.AddComponent(estimateslines_descriptionLabel);
            LanguageHelper.AddComponent(treatments_idLabel);
            LanguageHelper.AddComponent(computedlines_idLabel);
            LanguageHelper.AddComponent(estimateslines_istaxesdeductionsableCheckBox);
            LanguageHelper.AddComponent(groupBox_tabEstimatesLines_filler);
        }

        /// <summary>
        /// Form language dictionary
        /// </summary>
        public class FormLanguage : IDGUIGHFLanguage
        {
            public string doctorselectMessage = "Please select a Doctor.";
            public string doctorselectTitle = "Warning";
            public string invoicerequestMessage = "Invoice this item?";
            public string invoicerequestTitle = "Invoice";
            public string invoicerequestsuccessfulMessage = "Successfully invoiced to invoice number {0} of date {1}.";
            public string invoicerequestsuccessfulTitle = "Info";
            public string invoicerequestalreadyexistsMessage = "Already invoiced. Invoice number {0} of date {1}.";
            public string invoicerequestalreadyexistsTitle = "Info";
            public string printmodelerrorMessage = "Can not instantiate the print model.";
            public string printmodelerrorTitle = "Error";
            public string printmodelerrorNone = "No print model available";
            public string printmodelselectMessage = "Select a print template:";
            public string printmodelselectTitle = "Print template";
            public string printcreatefoldererrorMessage = "Can not create destination folder '{0}'.";
            public string printcreatefoldererrorTitle = "Error";
            public string printvalidfilenameerrorMessage = "Can not found a valid filename.";
            public string printvalidfilenameerrorTitle = "Error";
            public string printoverwritefilenamewarningMessage = "The file '{0}' already exists, press 'Yes' to overwrite it, 'No' to open that file, 'Cancel' to exit.";
            public string printoverwritefilenamewarningTitle = "Warning";
            public string printbuildpdferrorMessage = "Can not build the PDF file '{0}'.";
            public string printbuildpdferrorTitle = "Error";
            public string printopenfilenameMessage = "File '{0}' built successful.";
            public string printopenfilenameTitle = "Info";
            public string savewarningnumberMessage = "The selected number is not consistent with the one proposed. Do you want to continue?";
            public string savewarningnumberTitle = "Warning";
        }

        /// <summary>
        /// Form language
        /// </summary>
        public FormLanguage language = new FormLanguage();

        /// <summary>
        /// Initialize TabElements
        /// </summary>
        protected override void InitializeTabElements()
        {
            //set Readonly OnSetEditingMode for Controls
            DisableReadonlyCheckOnSetEditingModeControlCollection.Add(typeof(DataGridView));
            DisableReadonlyCheckOnSetEditingModeControlCollection.Add(typeof(AdvancedDataGridView));

            //set Main BindingSource
            BindingSourceMain = vEstimatesBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = panel_filters;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabEstimates
            tabElement_tabEstimates = new TabElement()
            {
                TabPageElement = tabPage_tabEstimates,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabEstimates_data,
                    PanelActions = panel_tabEstimates_actions,
                    PanelUpdates = panel_tabEstimates_updates,

                    ParentBindingSourceList = vEstimatesBindingSource,
                    GetParentDataSourceList = GetDataSource_main,

                    BindingSourceEdit = estimatesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabEstimates,
                    AfterSaveAction = AfterSaveAction_tabEstimates,

                    AddButton = button_tabEstimates_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabEstimates_edit,
                    IsUpdateButtonDefaultClickEventAttached = false,
                    RemoveButton = button_tabEstimates_delete,
                    SaveButton = button_tabEstimates_save,
                    IsSaveButtonDefaultClickEventAttached = false,
                    CancelButton = button_tabEstimates_cancel,

                    Add = Add_tabEstimates,
                    Update = Update_tabEstimates,
                    Remove = Remove_tabEstimates
                }
            };

            //set tabEstimatesLines
            tabElement_tabEstimatesLines = new TabElement()
            {
                TabPageElement = tabPage_tabEstimatesLines,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = null,
                    PanelList = panel_tabEstimatesLines_list,

                    PanelData = panel_tabEstimatesLines_data,
                    PanelActions = panel_tabEstimatesLines_actions,
                    PanelUpdates = panel_tabEstimatesLines_updates,

                    BindingSourceList = vEstimatesLinesBindingSource,
                    GetDataSourceList = GetDataSourceList_tabEstimatesLines,

                    BindingSourceEdit = estimateslinesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabEstimatesLines,
                    AfterSaveAction = AfterSaveAction_tabEstimatesLines,

                    AddButton = button_tabEstimatesLines_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabEstimatesLines_edit,
                    IsUpdateButtonDefaultClickEventAttached = false,
                    RemoveButton = button_tabEstimatesLines_delete,
                    SaveButton = button_tabEstimatesLines_save,
                    CancelButton = button_tabEstimatesLines_cancel,

                    Add = Add_tabEstimatesLines,
                    Update = Update_tabEstimatesLines,
                    Remove = Remove_tabEstimatesLines
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabEstimates);
            TabElements.Add(tabElement_tabEstimatesLines);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormEstimates_Load(object sender, EventArgs e)
        {
            IsBindingSourceLoading = true;
            advancedDataGridView_main.SortDESC(advancedDataGridView_main.Columns[1]);
            advancedDataGridView_main.SortDESC(advancedDataGridView_main.Columns[0]);
            IsBindingSourceLoading = false;

            PreloadView();

            //select an estimate on load estimate
            int estimates_id = -1;
            estimates estimate = null;
            foreach (Form form in this.MdiParent.MdiChildren)
            {
                if (form.GetType() == typeof(FormPatients))
                {
                    estimates_id = ((FormPatients)form).estimates_id_toload;
                    ((FormPatients)form).estimates_id_toload = -1;
                }

                if (estimates_id != -1)
                {
                    IsBindingSourceLoading = true;
                    estimate = _doctcodModel.Estimates.Find(estimates_id);
                    if (estimate != null)
                    {
                        if (estimate.doctors_id != null)
                            comboBox_filterDoctors.SelectedValue = estimate.doctors_id;
                        else
                            comboBox_filterDoctors.SelectedIndex = -1;
                    }
                    comboBox_filterYears.SelectedValue = estimate.estimates_date.Year;
                    IsBindingSourceLoading = false;
                    break;
                }
            }

            ReloadView();

            //select an estimate on load estimate
            if (estimate != null)
            {
                DGUIGHFData.SetBindingSourcePosition<estimates, DoctcoDModel>(_doctcodModel.Estimates, estimate, vEstimatesBindingSource);
                tabControl_main.SelectedTab = tabPage_tabEstimates;
            }
        }

        /// <summary>
        /// Preload View
        /// </summary>
        private void PreloadView()
        {
            IsBindingSourceLoading = true;

            _boxLoader.LoadComboBoxDoctors(doctors_idComboBox);
            _boxLoader.LoadComboBoxPatients(patients_idComboBox);
            _boxLoader.LoadComboBoxPaymentsTypes(estimates_paymentComboBox);
            _boxLoader.LoadComboBoxEstimatesFooters(estimates_footerComboBox);
            _boxLoader.LoadComboBoxTaxesDeductions(estimates_deductiontaxrateComboBox);
            _boxLoader.LoadComboBoxTaxes(estimateslines_taxrateComboBox);
            _boxLoader.LoadComboBoxTreatments(treatments_idComboBox);
            _boxLoader.LoadComboBoxComputedLines(computedlines_idComboBox);

            _boxLoader.LoadComboBoxFilterDoctors(comboBox_filterDoctors);
            if (comboBox_filterDoctors.Items.Count == 2)
                comboBox_filterDoctors.SelectedIndex = 1;

            IsBindingSourceLoading = false;

            //load filter years
            ReloadFilterYears();
        }

        /// <summary>
        /// Reset all the tab datagrid
        /// </summary>
        private void ResetTabsDataGrid()
        {
            IsBindingSourceLoading = true;
            advancedDataGridView_tabEstimatesLines_list.CleanFilterAndSort();
            advancedDataGridView_tabEstimatesLines_list.SortASC(advancedDataGridView_tabEstimatesLines_list.Columns[1]);
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Reload Years filter
        /// </summary>
        private void ReloadFilterYears()
        {
            IsBindingSourceLoading = true;
            int currentSelectedIndex = comboBox_filterYears.SelectedIndex;
            List<int> years = new List<int>();
            foreach (estimates a in _doctcodModel.Estimates.List().OrderBy(r => r.estimates_date))
            {
                if (!years.Contains(a.estimates_date.Year))
                    years.Add(a.estimates_date.Year);
            }
            EnhancedComboBoxHelper.AttachComboBox(
                comboBox_filterYears,
                new string[] { "Year" },
                years.OrderBy(r => r).Select(
                r => new EnhancedComboBoxHelper.Items()
                {
                    _id = r,
                    _value = r.ToString(),
                    _values = new string[]
                    {
                        r.ToString()
                    }
                }).ToArray());

            if (currentSelectedIndex == -1)
                comboBox_filterYears.SelectedIndex = comboBox_filterYears.Items.Count - 1;
            else
            {
                if (currentSelectedIndex > comboBox_filterYears.Items.Count - 1)
                    comboBox_filterYears.SelectedIndex = comboBox_filterYears.Items.Count - 1;
                else
                    comboBox_filterYears.SelectedIndex = currentSelectedIndex;
            }
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Get main list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSource_main()
        {
            ResetTabsDataGrid();

            int doctors_id = -1;
            if (comboBox_filterDoctors.SelectedIndex != -1)
            {
                doctors_id = Convert.ToInt32(comboBox_filterDoctors.SelectedValue);
            }
            int year = -1;
            if (comboBox_filterYears.SelectedIndex != -1)
            {
                year = Convert.ToInt32(comboBox_filterYears.SelectedValue);
            }

            totalnetTextBox.Text = "0";
            totalgrossTextBox.Text = "0";
            totaldueTextBox.Text = "0";
            totaldueinvoicedTextBox.Text = "0";

            //reset list total
            SetListTotal(year);

            Hashtable patientsnames = new Hashtable();
            foreach (patients patient in _doctcodModel.Patients.List())
            {
                patientsnames[patient.patients_id] = patient.patients_surname + " " + patient.patients_name;
            }
            IEnumerable<VEstimates> vEstimates = _doctcodModel.Estimates.List(r => r.estimates_date.Year == year && r.doctors_id == (doctors_id == -1 ? null : (Nullable<int>)doctors_id)).Select(
                r => new VEstimates
                {
                    estimates_id = r.estimates_id,
                    date = r.estimates_date,
                    isinvoiced = (r.invoices_id != null ? true : false),
                    number = r.estimates_number,
                    patient = (r.patients_id != null ? (patientsnames.ContainsKey(r.patients_id) ? patientsnames[r.patients_id].ToString() : "") : "")
                }).ToList();

            return DGDataTableUtils.ToDataTable<VEstimates>(vEstimates);
        }

        /// <summary>
        /// Doctor filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_filterDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            ReloadView();
        }

        /// <summary>
        /// Years filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_filterYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            ReloadView();
        }

        /// <summary>
        /// Set the main list total
        /// </summary>
        /// <param name="year"></param>
        private void SetListTotal(int year)
        {
            int doctors_id = -1;
            if (comboBox_filterDoctors.SelectedIndex != -1)
            {
                doctors_id = Convert.ToInt32(comboBox_filterDoctors.SelectedValue);
            }

            totalnetTextBox.Text = Math.Round(_doctcodModel.Estimates.List(r => r.doctors_id == doctors_id && r.estimates_date.Year == year).Sum(r => r.estimates_totalnet), 2).ToString();
            totalgrossTextBox.Text = Math.Round(_doctcodModel.Estimates.List(r => r.doctors_id == doctors_id && r.estimates_date.Year == year).Sum(r => r.estimates_totalgross), 2).ToString();
            totaldueTextBox.Text = Math.Round(_doctcodModel.Estimates.List(r => r.doctors_id == doctors_id && r.estimates_date.Year == year).Sum(r => r.estimates_totaldue), 2).ToString();
            totaldueinvoicedTextBox.Text = Math.Round(_doctcodModel.Estimates.List(r => r.doctors_id == doctors_id && r.estimates_date.Year == year && r.invoices_id != null).Sum(r => r.estimates_totaldue), 2).ToString();
        }

        /// <summary>
        /// Main BindingSource changed handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vEstimatesBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            int estimates_id = -1;
            if (vEstimatesBindingSource.Current != null)
            {
                estimates_id = (((DataRowView)vEstimatesBindingSource.Current).Row).Field<int>("estimates_id");
            }

            estimates_invoiceTextBox.Text = "";
            if (estimates_id != -1)
            {
                estimates estimate = _doctcodModel.Estimates.Find(estimates_id);
                if (estimate.invoices_id != null)
                {
                    invoices invoice = _doctcodModel.Invoices.Find(estimate.invoices_id);
                    doctors doctor = null;
                    if (invoice.doctors_id != null)
                    {
                        doctor = _doctcodModel.Doctors.Find(invoice.doctors_id);
                    }

                    estimates_invoiceTextBox.Text = invoice.invoices_number + " / " + invoice.invoices_date.ToShortDateString() + " " + (doctor != null ? "- " + doctor.doctors_surname + " " + doctor.doctors_name + " " : "") + "(" + invoice.invoices_id + ")";
                }
            }

        }


        #region tabEstimates

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabEstimates()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<estimates, DoctcoDModel>(_doctcodModel.Estimates, vEstimatesBindingSource, new string[] { "estimates_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabEstimates(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<estimates, DoctcoDModel>(_doctcodModel.Estimates, item, vEstimatesBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabEstimates(object item)
        {
            DGUIGHFData.Add<estimates, DoctcoDModel>(_doctcodModel.Estimates, item);

            //load filter years
            ReloadFilterYears();

            if (comboBox_filterYears.SelectedIndex != -1)
            {
                if (((estimates)item).estimates_date.Year != Convert.ToInt32(comboBox_filterYears.SelectedValue))
                {
                    ReloadView();
                    comboBox_filterYears.SelectedIndex = comboBox_filterYears.Items.Count - 1;
                }
            }
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabEstimates(object item)
        {
            DGUIGHFData.Update<estimates, DoctcoDModel>(_doctcodModel.Estimates, item);

            //load filter years
            ReloadFilterYears();

            if (comboBox_filterYears.SelectedIndex != -1)
            {
                if (((estimates)item).estimates_date.Year != Convert.ToInt32(comboBox_filterYears.SelectedValue))
                {
                    ReloadView();
                    comboBox_filterYears.SelectedIndex = comboBox_filterYears.Items.Count - 1;
                }
            }
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabEstimates(object item)
        {
            DGUIGHFData.Remove<estimates, DoctcoDModel>(_doctcodModel.Estimates, item);

            //load filter years
            ReloadFilterYears();
        }

        /// <summary>
        /// New button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabEstimates_new_Click(object sender, EventArgs e)
        {
            if (comboBox_filterDoctors.SelectedIndex == -1 || comboBox_filterDoctors.SelectedIndex == 0)
            {
                MessageBox.Show(language.doctorselectMessage, language.doctorselectTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            IsBindingSourceLoading = true;
            if (AddClick(tabElement_tabEstimates))
            {
                //set default values
                int doctors_id = Convert.ToInt32(comboBox_filterDoctors.SelectedValue);
                int year = DateTime.Now.Year;
                if (comboBox_filterYears.SelectedIndex != -1)
                {
                    if (Convert.ToInt32(comboBox_filterYears.SelectedValue) == year - 1)
                    {
                        if (_doctcodModel.Estimates.Any(r => r.doctors_id == doctors_id && r.estimates_date.Year == year))
                            year = Convert.ToInt32(comboBox_filterYears.SelectedValue);
                    }
                    else
                        year = Convert.ToInt32(comboBox_filterYears.SelectedValue);
                }
                Nullable<int> maxnumber = null;
                if (_autoincrementInvoicesEstimatesNumber)
                    maxnumber = GetMaxNumber(doctors_id, year);
                ((estimates)estimatesBindingSource.Current).doctors_id = doctors_id;
                ((estimates)estimatesBindingSource.Current).patients_id = null;
                if (_doctcodModel.PaymentsTypes.Any(r => r.paymentstypes_isdefault))
                    ((estimates)estimatesBindingSource.Current).estimates_payment = _doctcodModel.PaymentsTypes.FirstOrDefault(r => r.paymentstypes_isdefault).paymentstypes_doctext;
                if (_doctcodModel.EstimatesFooters.Any(r => r.estimatesfooters_isdefault))
                    ((estimates)estimatesBindingSource.Current).estimates_footer = _doctcodModel.EstimatesFooters.FirstOrDefault(r => r.estimatesfooters_isdefault).estimatesfooters_doctext;
                if (_doctcodModel.TaxesDeductions.Any(r => r.taxesdeductions_isdefault))
                    ((estimates)estimatesBindingSource.Current).estimates_deductiontaxrate = _doctcodModel.TaxesDeductions.FirstOrDefault(r => r.taxesdeductions_isdefault).taxesdeductions_rate;
                ((estimates)estimatesBindingSource.Current).estimates_date = new DateTime(year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
                if (maxnumber != null)
                    ((estimates)estimatesBindingSource.Current).estimates_number = maxnumber.ToString();
                //reset BindingSource
                estimatesBindingSource.ResetBindings(true);
                //raise changed indexes
                IsBindingSourceLoading = false;
                doctors_idComboBox_SelectedIndexChanged(null, null);
                estimates_paymentComboBox_SelectedIndexChanged(null, null);
                estimates_footerComboBox_SelectedIndexChanged(null, null);
                estimates_deductiontaxrateComboBox_SelectedIndexChanged(null, null);
            }
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Edit button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabEstimates_edit_Click(object sender, EventArgs e)
        {
            if (UpdateClick(tabElement_tabEstimates))
            {
                doctors_idComboBox.Enabled = false;
                patients_idComboBox.Enabled = false;
            }
        }

        /// <summary>
        /// Invoiced button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabEstimates_invoiced_Click(object sender, EventArgs e)
        {
            if (vEstimatesBindingSource.Current != null)
            {
                int estimates_id = -1;
                if (vEstimatesBindingSource.Current != null)
                {
                    estimates_id = (((DataRowView)vEstimatesBindingSource.Current).Row).Field<int>("estimates_id");
                }

                if (estimates_id != -1)
                {
                    estimates estimate = _doctcodModel.Estimates.Find(estimates_id);
                    if (estimate.invoices_id == null)
                    {
                        if (MessageBox.Show(language.invoicerequestMessage, language.invoicerequestTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            //add the new invoice
                            int maxnumber = 1;
                            int year = DateTime.Now.Year;
                            if (comboBox_filterYears.SelectedIndex != -1)
                            {
                                year = Convert.ToInt32(comboBox_filterYears.SelectedValue);
                            }
                            string[] numbers = _doctcodModel.Invoices.List(r => r.doctors_id == estimate.doctors_id && r.invoices_date.Year == DateTime.Now.Year).Select(r => r.invoices_number).ToArray();
                            try
                            {
                                foreach (string number in numbers)
                                {
                                    int n = Convert.ToInt32(number);
                                    if (n > maxnumber)
                                        maxnumber = n;
                                }
                                if (maxnumber != 1)
                                    maxnumber++;
                            }
                            catch { }
                            invoices invoice = new invoices()
                            {
                                doctors_id = estimate.doctors_id,
                                patients_id = estimate.patients_id,
                                invoices_number = maxnumber.ToString(),
                                invoices_date = DateTime.Now,
                                invoices_doctor = estimate.estimates_doctor,
                                invoices_footer = estimate.estimates_footer,
                                invoices_deductiontaxrate = estimate.estimates_deductiontaxrate,
                                invoices_patient = estimate.estimates_patient,
                                invoices_payment = estimate.estimates_payment,
                                invoices_ispaid = false,
                                invoices_totalnet = estimate.estimates_totalnet,
                                invoices_totalgross = estimate.estimates_totalgross,
                                invoices_totaldue = estimate.estimates_totaldue
                            };
                            _doctcodModel.Invoices.Add(invoice);
                            //add invoices lines
                            foreach (estimateslines estimatesline in _doctcodModel.EstimatesLines.List(r => r.estimates_id == estimate.estimates_id))
                            {
                                invoiceslines invoicesline = new invoiceslines()
                                {
                                    invoices_id = invoice.invoices_id,
                                    invoiceslines_code = estimatesline.estimateslines_code,
                                    invoiceslines_description = estimatesline.estimateslines_description,
                                    invoiceslines_quantity = estimatesline.estimateslines_quantity,
                                    invoiceslines_taxrate = estimatesline.estimateslines_taxrate,
                                    invoiceslines_unitprice = estimatesline.estimateslines_unitprice,
                                    patientstreatments_id = estimatesline.patientstreatments_id,
                                    invoiceslines_istaxesdeductionsable = estimatesline.estimateslines_istaxesdeductionsable
                                };
                                _doctcodModel.InvoicesLines.Add(invoicesline);
                            }

                            //set the invoice number
                            estimate.invoices_id = invoice.invoices_id;
                            _doctcodModel.Estimates.Update(estimate);

                            MessageBox.Show(String.Format(language.invoicerequestsuccessfulMessage, invoice.invoices_number, invoice.invoices_date.ToString()), language.invoicerequestsuccessfulTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ReloadAfterSave(tabElement_tabEstimates, estimate);
                        }
                    }
                    else
                    {
                        invoices invoice = _doctcodModel.Invoices.Find(estimate.invoices_id);

                        MessageBox.Show(String.Format(language.invoicerequestalreadyexistsMessage, invoice.invoices_number, invoice.invoices_date.ToString()), language.invoicerequestalreadyexistsTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }

        }

        /// <summary>
        /// Print button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabEstimates_print_Click(object sender, EventArgs e)
        {
            if (vEstimatesBindingSource.Current != null)
            {
                int estimates_id = -1;
                if (vEstimatesBindingSource.Current != null)
                {
                    estimates_id = (((DataRowView)vEstimatesBindingSource.Current).Row).Field<int>("estimates_id");
                }

                if (estimates_id != -1)
                {
                    PrintEstimates(estimates_id);
                }
            }
        }

        /// <summary>
        /// Save click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabEstimates_save_Click(object sender, EventArgs e)
        {
            if (tabElement_tabEstimates.CurrentEditingMode == EditingMode.C)
            {
                //check max number for new insertion
                if (_autoincrementInvoicesEstimatesNumber && ((estimates)estimatesBindingSource.Current).doctors_id != null)
                {
                    int doctors_id = (int)((estimates)estimatesBindingSource.Current).doctors_id;
                    int year = ((estimates)estimatesBindingSource.Current).estimates_date.Year;
                    int maxnumber = GetMaxNumber(doctors_id, year);
                    GetMaxNumber(doctors_id, year);
                    if (maxnumber.ToString() != ((estimates)estimatesBindingSource.Current).estimates_number)
                    {
                        if (MessageBox.Show(language.savewarningnumberMessage, language.savewarningnumberTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            return;
                        }
                    }
                }
            }

            SaveClick(tabElement_tabEstimates);
        }

        /// <summary>
        /// Print an estimate
        /// </summary>
        /// <param name="estimates_id"></param>
        private void PrintEstimates(int estimates_id)
        {
            estimates estimate = _doctcodModel.Estimates.Find(estimates_id);
            if (estimate == null)
                return;

            //load print templates
            string[] templates = new string[] { };
            Dictionary<string, IDoctcoDPrintModel> templatesModels = new Dictionary<string, IDoctcoDPrintModel>();
            foreach (string assemblyPath in ConfigurationManager.AppSettings["printModels"].Split(','))
            {
                IDoctcoDPrintModel printModelt = DoctcoDPrintModelHelper.DoctcoDPrintModelInstance(assemblyPath);
                if (printModelt != null)
                {
                    if (printModelt.IsBuildEstimateEnabled())
                    {
                        string modelname = printModelt.BuildEstimateTemplateName(ConfigurationManager.AppSettings["language"]);
                        if (!templatesModels.ContainsKey(modelname))
                        {
                            templatesModels.Add(modelname, printModelt);
                            templates = templates.Concat(new string[] { modelname }).ToArray();
                        }
                    }
                }
            }
            if (templates.Count() == 0)
            {
                MessageBox.Show(language.printmodelerrorMessage, language.printmodelerrorNone, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //select printmodel from print template
            IDoctcoDPrintModel printModel = null;
            if (templates.Count() == 1)
                printModel = templatesModels.FirstOrDefault().Value;
            else
            {
                string template = null;
                if (SelectorBox.Show(language.printmodelselectMessage, language.printmodelselectTitle, templates, ref template) == DialogResult.OK)
                {
                    if (templatesModels.Any(r => r.Key == template))
                        printModel = templatesModels.FirstOrDefault(r => r.Key == template).Value;
                }
                else
                    return;
            }
            if (printModel == null)
            {
                MessageBox.Show(language.printmodelerrorMessage, language.printmodelerrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //prepare folders
            string destfolder = ConfigurationManager.AppSettings["tmpdir"];
            if (!FileHelper.CreateFolder(destfolder))
            {
                MessageBox.Show(String.Format(language.printcreatefoldererrorMessage, destfolder), language.printcreatefoldererrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //make new filename
            bool buildfile = true;
            string filename = printModel.BuildEstimateGetFilename(_doctcodModel, estimates_id, destfolder);
            if (String.IsNullOrEmpty(filename))
            {
                MessageBox.Show(language.printvalidfilenameerrorMessage, language.printvalidfilenameerrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (File.Exists(filename))
            {
                DialogResult dialogResult = MessageBox.Show(String.Format(language.printoverwritefilenamewarningMessage, filename), language.printoverwritefilenamewarningTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                { }
                else if (dialogResult == DialogResult.No)
                    buildfile = false;
                else
                    return;
            }

            //build estimate
            if (buildfile)
            {
                string[] errors = new string[] { };
                if (!printModel.BuildEstimate(_doctcodModel, estimates_id, ConfigurationManager.AppSettings["language"], filename, ref errors))
                {
                    MessageBox.Show(String.Format(language.printbuildpdferrorMessage, filename) + (errors.Length > 0 ? " " + String.Join("\n", errors) : null), language.printbuildpdferrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //try to start the process
            if (!String.IsNullOrEmpty(filename))
            {
                try
                {
                    Process.Start(filename);
                }
                catch
                {
                    MessageBox.Show(String.Format(language.printopenfilenameMessage, filename), language.printopenfilenameTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Get the max available number of estimate
        /// </summary>
        /// <param name="doctors_id"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        private int GetMaxNumber(int doctors_id, int year)
        {
            int maxnumber = 0;
            string[] numbers = _doctcodModel.Estimates.List(r => r.doctors_id == doctors_id && r.estimates_date.Year == year).Select(r => r.estimates_number).ToArray();
            try
            {
                foreach (string number in numbers)
                {
                    int n = Convert.ToInt32(number);
                    if (n > maxnumber)
                        maxnumber = n;
                }
                maxnumber++;
            }
            catch { }
            if (maxnumber == 0)
                maxnumber++;
            return maxnumber;
        }

        /// <summary>
        /// Doctors changed handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void doctors_idComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (doctors_idComboBox.SelectedValue != null && (tabElement_tabEstimates.CurrentEditingMode == EditingMode.C || tabElement_tabEstimates.CurrentEditingMode == EditingMode.U))
            {
                ((estimates)estimatesBindingSource.Current).estimates_doctor = "";
                doctors doctor = _doctcodModel.Doctors.Find((int)doctors_idComboBox.SelectedValue);
                if (doctor != null)
                    ((estimates)estimatesBindingSource.Current).estimates_doctor = doctor.doctors_doctext;
                ((estimates)estimatesBindingSource.Current).doctors_id = (int)doctors_idComboBox.SelectedValue;
                estimatesBindingSource.ResetBindings(true);
            }
        }

        /// <summary>
        /// Patients changed handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patients_idComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (patients_idComboBox.SelectedValue != null && (tabElement_tabEstimates.CurrentEditingMode == EditingMode.C || tabElement_tabEstimates.CurrentEditingMode == EditingMode.U))
            {
                ((estimates)estimatesBindingSource.Current).estimates_patient = "";
                patients patient = _doctcodModel.Patients.Find((int)patients_idComboBox.SelectedValue);
                if (patient != null)
                    ((estimates)estimatesBindingSource.Current).estimates_patient = patient.patients_doctext;
                ((estimates)estimatesBindingSource.Current).patients_id = (int)patients_idComboBox.SelectedValue;
                estimatesBindingSource.ResetBindings(true);
            }
        }

        /// <summary>
        /// Payment Type changed handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void estimates_paymentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (estimates_paymentComboBox.SelectedIndex != -1 && (tabElement_tabEstimates.CurrentEditingMode == EditingMode.C || tabElement_tabEstimates.CurrentEditingMode == EditingMode.U))
            {
                int paymentstypes_id = -1;
                try
                {
                    paymentstypes_id = Convert.ToInt32(estimates_paymentComboBox.SelectedValue);
                }
                catch { }
                if (paymentstypes_id != -1)
                {
                    paymentstypes paymentstype = _doctcodModel.PaymentsTypes.Find(paymentstypes_id);
                    ((estimates)estimatesBindingSource.Current).estimates_payment = paymentstype.paymentstypes_doctext;
                }
                estimatesBindingSource.ResetBindings(true);
            }
        }

        /// <summary>
        /// Footer changed handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void estimates_footerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (estimates_footerComboBox.SelectedIndex != -1 && (tabElement_tabEstimates.CurrentEditingMode == EditingMode.C || tabElement_tabEstimates.CurrentEditingMode == EditingMode.U))
            {
                int estimatesfooters_id = -1;
                try
                {
                    estimatesfooters_id = Convert.ToInt32(estimates_footerComboBox.SelectedValue);
                }
                catch { }
                if (estimatesfooters_id != -1)
                {
                    estimatesfooters estimatesfooter = _doctcodModel.EstimatesFooters.Find(estimatesfooters_id);
                    ((estimates)estimatesBindingSource.Current).estimates_footer = estimatesfooter.estimatesfooters_doctext;
                }
                estimatesBindingSource.ResetBindings(true);
            }
        }

        /// <summary>
        /// Deduction tax changed handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void estimates_deductiontaxrateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (estimates_deductiontaxrateComboBox.SelectedIndex != -1 && (tabElement_tabEstimates.CurrentEditingMode == EditingMode.C || tabElement_tabEstimates.CurrentEditingMode == EditingMode.U))
            {
                int taxesdeductions_id = -1;
                try
                {
                    taxesdeductions_id = Convert.ToInt32(estimates_deductiontaxrateComboBox.SelectedValue);
                }
                catch { }
                if (taxesdeductions_id != -1)
                {
                    taxesdeductions taxesdeduction = _doctcodModel.TaxesDeductions.Find(taxesdeductions_id);
                    ((estimates)estimatesBindingSource.Current).estimates_deductiontaxrate = taxesdeduction.taxesdeductions_rate;
                }
                estimatesBindingSource.ResetBindings(true);
            }
        }

        /// <summary>
        /// Payment Type leaved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void estimates_paymentComboBox_Leave(object sender, EventArgs e)
        {
            IsBindingSourceLoading = true;
            estimates_paymentComboBox.SelectedIndex = -1;
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Footer leaved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void estimates_footerComboBox_Leave(object sender, EventArgs e)
        {
            IsBindingSourceLoading = true;
            estimates_footerComboBox.SelectedIndex = -1;
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Deduction tax leaved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void estimates_deductiontaxrateComboBox_Leave(object sender, EventArgs e)
        {
            IsBindingSourceLoading = true;
            estimates_deductiontaxrateComboBox.SelectedIndex = -1;
            IsBindingSourceLoading = false;
        }

        #endregion

        #region tabEstimatesLines

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabEstimatesLines()
        {
            object ret = null;

            int estimates_id = -1;
            if (vEstimatesBindingSource.Current != null)
            {
                estimates_id = (((DataRowView)vEstimatesBindingSource.Current).Row).Field<int>("estimates_id");
            }

            if (estimates_id != -1)
            {
                //reload patientstreatments tab
                estimates estimate = _doctcodModel.Estimates.Find(estimates_id);
                ReloadPatientsTreatments(estimate.patients_id, true);

                //reset list total
                SetListTotal(estimate.estimates_date.Year);
            }
            else
                ReloadPatientsTreatments(null, true);

            IEnumerable<VEstimatesLines> vEstimatesLines =
            _doctcodModel.EstimatesLines.List(r => r.estimates_id == estimates_id).Select(
            r => new VEstimatesLines
            {
                estimateslines_id = r.estimateslines_id,
                code = r.estimateslines_code,
                quantity = r.estimateslines_quantity,
                taxrate = (double)r.estimateslines_taxrate,
                unitprice = (double)r.estimateslines_unitprice,
                description = ((r.estimateslines_description).Length > MaxRowValueLength ? (r.estimateslines_description).Substring(0, MaxRowValueLength) + "..." : (r.estimateslines_description)),
                totalprice = (double)Math.Round((r.estimateslines_quantity * r.estimateslines_unitprice) + (r.estimateslines_quantity * r.estimateslines_unitprice) * (r.estimateslines_taxrate / 100), 2)
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VEstimatesLines>(vEstimatesLines);

            return ret;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabEstimatesLines()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<estimateslines, DoctcoDModel>(_doctcodModel.EstimatesLines, vEstimatesLinesBindingSource, new string[] { "estimateslines_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabEstimatesLines(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<estimateslines, DoctcoDModel>(_doctcodModel.EstimatesLines, item, vEstimatesLinesBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabEstimatesLines(object item)
        {
            //unset lazy load for estimate tab, to reload total
            tabElement_tabEstimates.IsLazyLoaded = false;

            DGUIGHFData.Add<estimateslines, DoctcoDModel>(_doctcodModel.EstimatesLines, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabEstimatesLines(object item)
        {
            //unset lazy load for estimate tab, to reload total
            tabElement_tabEstimates.IsLazyLoaded = false;

            DGUIGHFData.Update<estimateslines, DoctcoDModel>(_doctcodModel.EstimatesLines, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabEstimatesLines(object item)
        {
            //unset lazy load for estimate tab, to reload total
            tabElement_tabEstimates.IsLazyLoaded = false;

            DGUIGHFData.Remove<estimateslines, DoctcoDModel>(_doctcodModel.EstimatesLines, item);
        }

        /// <summary>
        /// New tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabEstimatesLines_new_Click(object sender, EventArgs e)
        {
            if (vEstimatesBindingSource.Current != null)
            {
                if (AddClick(tabElement_tabEstimatesLines))
                {
                    int estimates_id = (((DataRowView)vEstimatesBindingSource.Current).Row).Field<int>("estimates_id");
                    estimates estimate = _doctcodModel.Estimates.Find(estimates_id);
                    ReloadPatientsTreatments(estimate.patients_id, false);

                    ((estimateslines)estimateslinesBindingSource.Current).estimates_id = estimates_id;
                    ((estimateslines)estimateslinesBindingSource.Current).estimateslines_code = "";
                    ((estimateslines)estimateslinesBindingSource.Current).estimateslines_description = "";
                    ((estimateslines)estimateslinesBindingSource.Current).estimateslines_quantity = 1;
                    ((estimateslines)estimateslinesBindingSource.Current).estimateslines_unitprice = 0;
                    if (_doctcodModel.Taxes.Any(r => r.taxes_isdefault))
                        ((estimateslines)estimateslinesBindingSource.Current).estimateslines_taxrate = _doctcodModel.Taxes.FirstOrDefault(r => r.taxes_isdefault).taxes_rate;
                    ((estimateslines)estimateslinesBindingSource.Current).estimateslines_istaxesdeductionsable = true;
                    estimateslinesBindingSource.ResetBindings(true);
                }
            }
        }

        /// <summary>
        /// Edit tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabEstimatesLines_edit_Click(object sender, EventArgs e)
        {
            if (vEstimatesBindingSource.Current != null)
            {
                if (UpdateClick(tabElement_tabEstimatesLines))
                {
                    ((estimateslines)estimateslinesBindingSource.Current).estimateslines_istaxesdeductionsable = true;
                    estimateslinesBindingSource.ResetBindings(true);

                    groupBox_tabEstimatesLines_filler.Enabled = false;
                    patientstreatments_idComboBox.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Reload patients treatments combobox
        /// </summary>
        /// <param name="patients_id"></param>
        /// <param name="loadall"></param>
        private void ReloadPatientsTreatments(Nullable<int> patients_id, bool loadall)
        {
            //get only treatments not yet estimated
            List<patientstreatments> patientstreatmentsl = new List<patientstreatments>();
            if (patients_id != null)
            {
                if (!loadall)
                {
                    //do not load already inserted treatments and yet paid or invoices
                    patientstreatmentsl = _doctcodModel.PatientsTreatments.List(r => r.patients_id == patients_id && !r.patientstreatments_ispaid).ToList();
                    int[] patientstreatmentsids = patientstreatmentsl.Select(r => r.patientstreatments_id).ToArray();
                    estimateslines[] estimateslinel = new estimateslines[] { };
                    using (var context = (doctcodEntities)Activator.CreateInstance(_doctcodModel.ContextType, _doctcodModel.ContextParameters))
                    {
                        estimateslinel = (from estimatesline in context.estimateslines
                                          join estimate in context.estimates on estimatesline.estimates_id equals estimate.estimates_id
                                          where estimate.patients_id == patients_id
                                          select estimatesline).ToArray();
                    }
                    foreach (estimateslines estimatesline in estimateslinel)
                    {
                        patientstreatments patientstreatment = patientstreatmentsl.FirstOrDefault(r => r.patientstreatments_id == estimatesline.patientstreatments_id);
                        if (patientstreatment != null)
                            patientstreatmentsl.Remove(patientstreatment);
                    }
                    invoiceslines[] invoiceslinel = new invoiceslines[] { };
                    using (var context = (doctcodEntities)Activator.CreateInstance(_doctcodModel.ContextType, _doctcodModel.ContextParameters))
                    {
                        invoiceslinel = (from invoicesline in context.invoiceslines
                                         join invoice in context.invoices on invoicesline.invoices_id equals invoice.invoices_id
                                         where invoicesline.patientstreatments_id != null && patientstreatmentsids.Contains((int)invoicesline.patientstreatments_id)
                                         select invoicesline).ToArray();
                    }
                    foreach (invoiceslines invoicesline in invoiceslinel)
                    {
                        patientstreatments patientstreatment = patientstreatmentsl.FirstOrDefault(r => r.patientstreatments_id == invoicesline.patientstreatments_id);
                        if (patientstreatment != null)
                            patientstreatmentsl.Remove(patientstreatment);
                    }
                }
                else
                {
                    patientstreatmentsl = _doctcodModel.PatientsTreatments.List(r => r.patients_id == patients_id).ToList();
                }
            }

            //load patients treatments
            IsBindingSourceLoading = true;
            EnhancedComboBoxHelper.Items[] patientstreatmentsitems = new EnhancedComboBoxHelper.Items[] { };
            foreach (patientstreatments patientstreatment in patientstreatmentsl)
            {
                treatments treatment = _doctcodModel.Treatments.Find(patientstreatment.treatments_id);
                patientstreatmentsitems = patientstreatmentsitems.Concat(new EnhancedComboBoxHelper.Items[] {
                        new EnhancedComboBoxHelper.Items()
                        {
                            _id = patientstreatment.patientstreatments_id,
                            _value = treatment.treatments_code + " " + patientstreatment.patientstreatments_creationdate.ToShortDateString(),
                            _values = new string[]
                            {
                                treatment.treatments_code + " " + patientstreatment.patientstreatments_creationdate.ToShortDateString(),
                                treatment.treatments_code,
                                treatment.treatments_name,
                                patientstreatment.patientstreatments_creationdate.ToShortDateString()
                            }
                        }
                    }).ToArray();
            }
            EnhancedComboBoxHelper.AttachComboBox(
                patientstreatments_idComboBox,
                new string[] { "Full Name", "Code", "Name", "Date" },
                patientstreatmentsitems);
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Tax rate changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void estimateslines_taxrateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (estimateslines_taxrateComboBox.SelectedIndex != -1 && (tabElement_tabEstimatesLines.CurrentEditingMode == EditingMode.C || tabElement_tabEstimatesLines.CurrentEditingMode == EditingMode.U))
            {
                int taxes_id = -1;
                try
                {
                    taxes_id = Convert.ToInt32(estimateslines_taxrateComboBox.SelectedValue);
                }
                catch { }
                if (taxes_id != -1)
                {
                    taxes taxes = _doctcodModel.Taxes.Find(taxes_id);
                    ((estimateslines)estimateslinesBindingSource.Current).estimateslines_taxrate = taxes.taxes_rate;
                }
                estimateslinesBindingSource.ResetBindings(true);
            }
        }

        /// <summary>
        /// Treatments changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treatments_idComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (treatments_idComboBox.SelectedIndex != -1 && (tabElement_tabEstimatesLines.CurrentEditingMode == EditingMode.C || tabElement_tabEstimatesLines.CurrentEditingMode == EditingMode.U))
            {
                int estimates_id = -1;
                if (vEstimatesBindingSource.Current != null)
                {
                    estimates_id = (((DataRowView)vEstimatesBindingSource.Current).Row).Field<int>("estimates_id");
                }
                if (estimates_id != -1)
                {
                    estimates estimate = _doctcodModel.Estimates.Find(estimates_id);
                    int patients_id = -1;

                    if (estimate.patients_id != null)
                        patients_id = (int)estimate.patients_id;

                    if (patients_id != -1)
                    {
                        treatments treatment = _doctcodModel.Treatments.Find(Convert.ToInt32(treatments_idComboBox.SelectedValue));
                        if (treatment != null)
                        {
                            string code = treatment.treatments_code;
                            string description = treatment.treatments_name;
                            decimal price = treatment.treatments_price;
                            decimal taxrate = (treatment.taxes_id != null ? _doctcodModel.Taxes.Find((int)treatment.taxes_id).taxes_rate : 0);
                            if (patients_id != -1)
                            {
                                patients patient = _doctcodModel.Patients.Find(patients_id);
                                if (patient != null)
                                {
                                    treatmentsprices treatmentsprice = _doctcodModel.TreatmentsPrices.FirstOrDefault(r => r.treatments_id == treatment.treatments_id && r.treatmentspriceslists_id == patient.treatmentspriceslists_id);
                                    if (treatmentsprice != null)
                                    {
                                        price = treatmentsprice.treatmentsprices_price;
                                    }
                                }
                            }
                            ((estimateslines)estimateslinesBindingSource.Current).patientstreatments_id = null;
                            ((estimateslines)estimateslinesBindingSource.Current).estimateslines_code = code;
                            ((estimateslines)estimateslinesBindingSource.Current).estimateslines_description = description;
                            ((estimateslines)estimateslinesBindingSource.Current).estimateslines_quantity = 1;
                            ((estimateslines)estimateslinesBindingSource.Current).estimateslines_unitprice = price;
                            ((estimateslines)estimateslinesBindingSource.Current).estimateslines_taxrate = taxrate;
                        }
                    }
                }
                estimateslinesBindingSource.ResetBindings(true);
            }
        }

        /// <summary>
        /// Computed lines changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void computedlines_idComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (computedlines_idComboBox.SelectedIndex != -1 && (tabElement_tabEstimatesLines.CurrentEditingMode == EditingMode.C || tabElement_tabEstimatesLines.CurrentEditingMode == EditingMode.U))
            {
                int estimates_id = -1;
                if (vEstimatesBindingSource.Current != null)
                {
                    estimates_id = (((DataRowView)vEstimatesBindingSource.Current).Row).Field<int>("estimates_id");
                }
                if (estimates_id != -1)
                {
                    estimates estimate = _doctcodModel.Estimates.Find(estimates_id);
                    int patients_id = -1;

                    if (estimate.patients_id != null)
                        patients_id = (int)estimate.patients_id;

                    if (patients_id != -1)
                    {
                        computedlines computedline = _doctcodModel.ComputedLines.Find(Convert.ToInt32(computedlines_idComboBox.SelectedValue));
                        if (computedline != null)
                        {
                            decimal totallines = _doctcodModel.EstimatesLines.List(r => r.estimates_id == estimates_id).Sum(r => r.estimateslines_quantity * r.estimateslines_unitprice);
                            string code = computedline.computedlines_code;
                            string description = computedline.computedlines_name;
                            decimal price = totallines * (computedline.computedlines_rate / 100);
                            decimal taxrate = (computedline.taxes_id != null ? _doctcodModel.Taxes.Find((int)computedline.taxes_id).taxes_rate : 0);
                            ((estimateslines)estimateslinesBindingSource.Current).patientstreatments_id = null;
                            ((estimateslines)estimateslinesBindingSource.Current).estimateslines_code = code;
                            ((estimateslines)estimateslinesBindingSource.Current).estimateslines_description = description;
                            ((estimateslines)estimateslinesBindingSource.Current).estimateslines_quantity = 1;
                            ((estimateslines)estimateslinesBindingSource.Current).estimateslines_unitprice = price;
                            ((estimateslines)estimateslinesBindingSource.Current).estimateslines_taxrate = taxrate;
                        }
                    }
                }
                estimateslinesBindingSource.ResetBindings(true);
            }
        }

        /// <summary>
        /// Patient treatments changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_idComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (patientstreatments_idComboBox.SelectedIndex != -1 && (tabElement_tabEstimatesLines.CurrentEditingMode == EditingMode.C || tabElement_tabEstimatesLines.CurrentEditingMode == EditingMode.U))
            {
                int estimates_id = -1;
                if (vEstimatesBindingSource.Current != null)
                {
                    estimates_id = (((DataRowView)vEstimatesBindingSource.Current).Row).Field<int>("estimates_id");
                }
                if (estimates_id != -1)
                {
                    estimates estimate = _doctcodModel.Estimates.Find(estimates_id);
                    int patients_id = -1;

                    if (estimate.patients_id != null)
                        patients_id = (int)estimate.patients_id;

                    if (patients_id != -1)
                    {
                        patientstreatments patientstreatment = null;
                        try
                        {
                            patientstreatment = _doctcodModel.PatientsTreatments.Find((int)patientstreatments_idComboBox.SelectedValue);
                        }
                        catch { }
                        if (patientstreatment != null)
                        {
                            treatments treatments = _doctcodModel.Treatments.Find(patientstreatment.treatments_id);
                            if (treatments != null)
                            {
                                int quantity = 1;
                                string code = treatments.treatments_code;
                                string description = treatments.treatments_name;
                                decimal price = patientstreatment.patientstreatments_price;
                                decimal taxrate = patientstreatment.patientstreatments_taxrate;
                                ((estimateslines)estimateslinesBindingSource.Current).patientstreatments_id = patientstreatment.patientstreatments_id;
                                ((estimateslines)estimateslinesBindingSource.Current).estimateslines_code = code;
                                ((estimateslines)estimateslinesBindingSource.Current).estimateslines_description = description;
                                ((estimateslines)estimateslinesBindingSource.Current).estimateslines_quantity = quantity;
                                ((estimateslines)estimateslinesBindingSource.Current).estimateslines_unitprice = price;
                                ((estimateslines)estimateslinesBindingSource.Current).estimateslines_taxrate = taxrate;
                            }
                        }
                    }
                }
                estimateslinesBindingSource.ResetBindings(true);
            }
        }

        /// <summary>
        /// Tax rate leaved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void estimateslines_taxrateComboBox_Leave(object sender, EventArgs e)
        {
            IsBindingSourceLoading = true;
            estimateslines_taxrateComboBox.SelectedIndex = -1;
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Treatments leaved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treatments_idComboBox_Leave(object sender, EventArgs e)
        {

            IsBindingSourceLoading = true;
            treatments_idComboBox.SelectedIndex = -1;
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Computed lines leaved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void computedlines_idComboBox_Leave(object sender, EventArgs e)
        {
            IsBindingSourceLoading = true;
            computedlines_idComboBox.SelectedIndex = -1;
            IsBindingSourceLoading = false;
        }

        #endregion

    }
}
