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
using SMcMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Zuby.ADGV;

namespace DG.DoctcoD.Forms
{
    public partial class FormTreatments : DGUIGHFForm
    {
        private DoctcoDModel _doctcodModel = null;

        private TabElement tabElement_tabTreatments = new TabElement();
        private TabElement tabElement_tabTreatmentsPrices = new TabElement();

        private readonly BoxLoader _boxLoader = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public FormTreatments()
        {
            InitializeComponent();
            (new TabOrderManager(this)).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);

            Initialize(Program.uighfApplication);

            _doctcodModel = new DoctcoDModel();
            _doctcodModel.LanguageHelper.LoadFromFile(Program.uighfApplication.LanguageFilename);

            _boxLoader = new BoxLoader(_doctcodModel);
        }

        /// <summary>
        /// Add components language
        /// </summary>
        public override void AddLanguageComponents()
        {
            //main
            LanguageHelper.AddComponent(this);
            LanguageHelper.AddComponent(treatmentsidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(nameDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(codeDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(typeDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(button_export);
            //tabTreatments
            LanguageHelper.AddComponent(tabPage_tabTreatments);
            LanguageHelper.AddComponent(button_tabTreatments_new);
            LanguageHelper.AddComponent(button_tabTreatments_edit);
            LanguageHelper.AddComponent(button_tabTreatments_delete);
            LanguageHelper.AddComponent(button_tabTreatments_save);
            LanguageHelper.AddComponent(button_tabTreatments_cancel);
            LanguageHelper.AddComponent(treatments_idLabel);
            LanguageHelper.AddComponent(treatments_nameLabel);
            LanguageHelper.AddComponent(treatments_codeLabel);
            LanguageHelper.AddComponent(treatmentstypes_idLabel);
            LanguageHelper.AddComponent(treatments_mexpirationLabel);
            LanguageHelper.AddComponent(treatments_mexpirationinfoLabel);
            LanguageHelper.AddComponent(treatments_priceLabel);
            LanguageHelper.AddComponent(treatments_notesLabel);
            LanguageHelper.AddComponent(taxes_idLabel);
            LanguageHelper.AddComponent(button_tabTreatments_unsettaxesid);
            //tabTreatmentsPrices
            LanguageHelper.AddComponent(tabPage_tabTreatmentsPrices);
            LanguageHelper.AddComponent(label_tabTreatmentsPrices_filterpriceslists);
            LanguageHelper.AddComponent(treatmentspricesidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(pricelistDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(priceDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(button_tabTreatmentsPrices_new);
            LanguageHelper.AddComponent(button_tabTreatmentsPrices_edit);
            LanguageHelper.AddComponent(button_tabTreatmentsPrices_delete);
            LanguageHelper.AddComponent(button_tabTreatmentsPrices_save);
            LanguageHelper.AddComponent(button_tabTreatmentsPrices_cancel);
            LanguageHelper.AddComponent(treatmentsprices_idLabel);
            LanguageHelper.AddComponent(treatmentspriceslists_idLabel);
            LanguageHelper.AddComponent(treatmentsprices_priceLabel);
        }

        /// <summary>
        /// Form language dictionary
        /// </summary>
        public class FormLanguage : IDGUIGHFLanguage
        {
            public string exportColumnCode = "Code";
            public string exportColumnType = "Type";
            public string exportColumnName = "Name";
            public string exportColumnPrice = "Price";
            public string exportSaveFileDialogTitle = "Save an Excel File";
            public string exportErrorMessage = "Error writing file '{0}'.";
            public string exportErrorTitle = "Error";
            public string exportSuccessMessage = "File created. Do you want to open it with your default application?";
            public string exportSuccessTitle = "Open";
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
            BindingSourceMain = vTreatmentsBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = panel_filters;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabTreatments
            tabElement_tabTreatments = new TabElement()
            {
                TabPageElement = tabPage_tabTreatments,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabTreatments_data,
                    PanelActions = panel_tabTreatments_actions,
                    PanelUpdates = panel_tabTreatments_updates,

                    ParentBindingSourceList = vTreatmentsBindingSource,
                    GetParentDataSourceList = GetDataSource_main,

                    BindingSourceEdit = treatmentsBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabTreatments,
                    AfterSaveAction = AfterSaveAction_tabTreatments,

                    AddButton = button_tabTreatments_new,
                    UpdateButton = button_tabTreatments_edit,
                    RemoveButton = button_tabTreatments_delete,
                    SaveButton = button_tabTreatments_save,
                    CancelButton = button_tabTreatments_cancel,

                    Add = Add_tabTreatments,
                    Update = Update_tabTreatments,
                    Remove = Remove_tabTreatments
                }
            };

            //set tabTreatmentsPrices
            tabElement_tabTreatmentsPrices = new TabElement()
            {
                TabPageElement = tabPage_tabTreatmentsPrices,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = panel_tabTreatmentsPrices_filters,
                    PanelList = panel_tabTreatmentsPrices_list,

                    PanelData = panel_tabTreatmentsPrices_data,
                    PanelActions = panel_tabTreatmentsPrices_actions,
                    PanelUpdates = panel_tabTreatmentsPrices_updates,

                    BindingSourceList = vTreatmentsPricesBindingSource,
                    GetDataSourceList = GetDataSourceList_tabTreatmentsPrices,

                    BindingSourceEdit = treatmentspricesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabTreatmentsPrices,
                    AfterSaveAction = AfterSaveAction_tabTreatmentsPrices,

                    AddButton = button_tabTreatmentsPrices_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabTreatmentsPrices_edit,
                    RemoveButton = button_tabTreatmentsPrices_delete,
                    SaveButton = button_tabTreatmentsPrices_save,
                    CancelButton = button_tabTreatmentsPrices_cancel,

                    Add = Add_tabTreatmentsPrices,
                    Update = Update_tabTreatmentsPrices,
                    Remove = Remove_tabTreatmentsPrices
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabTreatments);
            TabElements.Add(tabElement_tabTreatmentsPrices);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTreatments_Load(object sender, EventArgs e)
        {
            IsBindingSourceLoading = true;
            advancedDataGridView_main.SortASC(advancedDataGridView_main.Columns[2]);
            advancedDataGridView_main.SortASC(advancedDataGridView_main.Columns[1]);
            advancedDataGridView_main.SortASC(advancedDataGridView_main.Columns[3]);
            IsBindingSourceLoading = false;

            PreloadView();

            ReloadView();
        }

        /// <summary>
        /// Preload View
        /// </summary>
        private void PreloadView()
        {
            IsBindingSourceLoading = true;

            _boxLoader.LoadComboBoxTreatmentsTypes(treatmentstypes_idComboBox);
            _boxLoader.LoadComboBoxTreatmentsPricesLists(treatmentspriceslists_idComboBox);
            _boxLoader.LoadComboBoxTaxes(taxes_idComboBox);

            _boxLoader.LoadComboBoxFilterTreatmentsPricesLists(comboBox_tabTreatmentsPrices_filterPriceslists);

            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Reset all the tab datagrid
        /// </summary>
        private void ResetTabsDataGrid()
        {
            IsBindingSourceLoading = true;
            advancedDataGridView_tabTreatmentsPrices_list.CleanFilterAndSort();
            advancedDataGridView_tabTreatmentsPrices_list.SortASC(advancedDataGridView_tabTreatmentsPrices_list.Columns[1]);
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Get main list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSource_main()
        {
            ResetTabsDataGrid();

            IEnumerable<VTreatments> vTreatments =
                _doctcodModel.Treatments.List().Select(
                r => new VTreatments
                {
                    treatments_id = r.treatments_id,
                    code = r.treatments_code,
                    type = _doctcodModel.TreatmentsTypes.Find(r.treatmentstypes_id).treatmentstypes_name,
                    name = r.treatments_name
                }).ToList();

            return DGDataTableUtils.ToDataTable<VTreatments>(vTreatments);
        }

        /// <summary>
        /// Main list current element changed hanlder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vTreatmentsBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            //get current itme
            int treatments_id = -1;
            if (vTreatmentsBindingSource.Current != null)
            {
                treatments_id = (((DataRowView)vTreatmentsBindingSource.Current).Row).Field<int>("treatments_id");
            }

            //set treatments fields
            treatments_mexpirationTextBox.Text = "";
            if (treatments_id != -1)
            {
                treatments treatment = _doctcodModel.Treatments.Find(treatments_id);
                treatments_mexpirationTextBox.Text = treatment.treatments_mexpiration.ToString();
            }

            //reset treatments prices filter
            comboBox_tabTreatmentsPrices_filterPriceslists.SelectedIndex = -1;
        }

        /// <summary>
        /// Export click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_export_Click(object sender, EventArgs e)
        {
            string filename = null;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel|*.xls";
            saveFileDialog.Title = language.exportSaveFileDialogTitle; ;
            saveFileDialog.ShowDialog();
            filename = saveFileDialog.FileName;
            if (!String.IsNullOrEmpty(filename))
            {
                Cursor.Current = Cursors.WaitCursor;

                DataTable datatable = new DataTable();
                datatable.Clear();
                datatable.Columns.Add(language.exportColumnCode);
                datatable.Columns.Add(language.exportColumnType);
                datatable.Columns.Add(language.exportColumnName);
                datatable.Columns.Add(language.exportColumnPrice);
                foreach (treatmentspriceslists treatmentspriceslist in _doctcodModel.TreatmentsPricesLists.List().OrderBy(r => r.treatmentspriceslists_name))
                {
                    datatable.Columns.Add(language.exportColumnPrice + "-" + treatmentspriceslist.treatmentspriceslists_id);
                }

                //add datatable columns
                foreach (treatments treatment in _doctcodModel.Treatments.List().OrderBy(r => r.treatments_code))
                {
                    DataRow row = datatable.NewRow();
                    row[language.exportColumnCode] = treatment.treatments_code;
                    row[language.exportColumnType] = _doctcodModel.TreatmentsTypes.Find(treatment.treatmentstypes_id).treatmentstypes_name;
                    row[language.exportColumnName] = treatment.treatments_name;
                    row[language.exportColumnPrice] = treatment.treatments_price;
                    foreach (treatmentspriceslists treatmentspriceslist in _doctcodModel.TreatmentsPricesLists.List().OrderBy(r => r.treatmentspriceslists_name))
                    {
                        Nullable<decimal> price = null;
                        treatmentsprices treatmentsprice = _doctcodModel.TreatmentsPrices.FirstOrDefault(r => r.treatments_id == treatment.treatments_id && r.treatmentspriceslists_id == treatmentspriceslist.treatmentspriceslists_id);
                        if (treatmentsprice != null)
                        {
                            price = treatmentsprice.treatmentsprices_price;
                        }
                        row[language.exportColumnPrice + "-" + treatmentspriceslist.treatmentspriceslists_id] = price;
                    }
                    datatable.Rows.Add(row);
                }

                Cursor.Current = Cursors.Default;

                //export to excel
                DataSet dataset = new DataSet();
                dataset.Tables.Add(datatable);
                if (!String.IsNullOrEmpty(filename))
                {
                    try
                    {
                        ExcelExporter.CreateWorkbook(filename, dataset);
                    }
                    catch
                    {
                        MessageBox.Show(String.Format(language.exportErrorMessage, filename), language.exportErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (MessageBox.Show(language.exportSuccessMessage, language.exportSuccessTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        try
                        {
                            Process.Start(filename);
                        }
                        catch { }
                    }
                }
            }
        }


        #region tabTreatments

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabTreatments()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<treatments, DoctcoDModel>(_doctcodModel.Treatments, vTreatmentsBindingSource, new string[] { "treatments_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabTreatments(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<treatments, DoctcoDModel>(_doctcodModel.Treatments, item, vTreatmentsBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabTreatments(object item)
        {
            //update mexpiration
            if (!String.IsNullOrEmpty(treatments_mexpirationTextBox.Text))
                ((treatments)item).treatments_mexpiration = Convert.ToByte(treatments_mexpirationTextBox.Text);
            else
                ((treatments)item).treatments_mexpiration = null;

            DGUIGHFData.Add<treatments, DoctcoDModel>(_doctcodModel.Treatments, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabTreatments(object item)
        {
            //update mexpiration
            if (!String.IsNullOrEmpty(treatments_mexpirationTextBox.Text))
                ((treatments)item).treatments_mexpiration = Convert.ToByte(treatments_mexpirationTextBox.Text);
            else
                ((treatments)item).treatments_mexpiration = null;

            DGUIGHFData.Update<treatments, DoctcoDModel>(_doctcodModel.Treatments, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabTreatments(object item)
        {
            DGUIGHFData.Remove<treatments, DoctcoDModel>(_doctcodModel.Treatments, item);
        }

        /// <summary>
        /// Unset taxes_id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabTreatments_unsettaxesid_Click(object sender, EventArgs e)
        {
            taxes_idComboBox.SelectedIndex = -1;
        }

        #endregion

        #region tabTreatmentsPrices

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabTreatmentsPrices()
        {
            object ret = null;

            //get current treatment
            int treatments_id = -1;
            if (vTreatmentsBindingSource.Current != null)
            {
                treatments_id = (((DataRowView)vTreatmentsBindingSource.Current).Row).Field<int>("treatments_id");
            }

            //get treatments
            List<treatmentsprices> treatmentspricesl = new List<treatmentsprices>();
            if (comboBox_tabTreatmentsPrices_filterPriceslists.SelectedIndex != -1 && comboBox_tabTreatmentsPrices_filterPriceslists.SelectedIndex != 0)
            {
                int treatmentspriceslists_id = Convert.ToInt32(comboBox_tabTreatmentsPrices_filterPriceslists.SelectedValue);
                treatmentspricesl = _doctcodModel.TreatmentsPrices.List(r => r.treatments_id == treatments_id && r.treatmentspriceslists_id == treatmentspriceslists_id).ToList();
            }
            else
                treatmentspricesl = _doctcodModel.TreatmentsPrices.List(r => r.treatments_id == treatments_id).ToList();
            IEnumerable<VTreatmentsPrices> vTreatmentsPrices =
            treatmentspricesl.Select(
            r => new VTreatmentsPrices
            {
                treatmentsprices_id = r.treatmentsprices_id,
                price = (double)r.treatmentsprices_price,
                pricelist = _doctcodModel.TreatmentsPricesLists.Find(r.treatmentspriceslists_id).treatmentspriceslists_name
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VTreatmentsPrices>(vTreatmentsPrices);

            return ret;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabTreatmentsPrices()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<treatmentsprices, DoctcoDModel>(_doctcodModel.TreatmentsPrices, vTreatmentsPricesBindingSource, new string[] { "treatmentsprices_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabTreatmentsPrices(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<treatmentsprices, DoctcoDModel>(_doctcodModel.TreatmentsPrices, item, vTreatmentsPricesBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabTreatmentsPrices(object item)
        {
            DGUIGHFData.Add<treatmentsprices, DoctcoDModel>(_doctcodModel.TreatmentsPrices, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabTreatmentsPrices(object item)
        {
            DGUIGHFData.Update<treatmentsprices, DoctcoDModel>(_doctcodModel.TreatmentsPrices, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabTreatmentsPrices(object item)
        {
            DGUIGHFData.Remove<treatmentsprices, DoctcoDModel>(_doctcodModel.TreatmentsPrices, item);
        }

        /// <summary>
        /// New tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabTreatmentsPrices_new_Click(object sender, EventArgs e)
        {
            if (vTreatmentsBindingSource.Current != null)
            {
                if (AddClick(tabElement_tabTreatmentsPrices))
                {
                    ((treatmentsprices)treatmentspricesBindingSource.Current).treatments_id = (((DataRowView)vTreatmentsBindingSource.Current).Row).Field<int>("treatments_id");
                    if (comboBox_tabTreatmentsPrices_filterPriceslists.SelectedIndex != -1 && comboBox_tabTreatmentsPrices_filterPriceslists.SelectedIndex != 0)
                    {
                        ((treatmentsprices)treatmentspricesBindingSource.Current).treatmentspriceslists_id = Convert.ToInt32(comboBox_tabTreatmentsPrices_filterPriceslists.SelectedValue);
                        treatmentspriceslists_idComboBox.Enabled = false;
                    }
                    treatmentspricesBindingSource.ResetBindings(true);
                }
            }
        }

        /// <summary>
        /// Treatments prices changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_tabTreatmentsPrices_filterPriceslists_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            ReloadTab(tabElement_tabTreatmentsPrices);
        }

        /// <summary>
        /// Treatments lists changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treatmentspriceslists_idComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (treatmentspriceslists_idComboBox.SelectedIndex != -1 && (tabElement_tabTreatmentsPrices.CurrentEditingMode == EditingMode.C || tabElement_tabTreatmentsPrices.CurrentEditingMode == EditingMode.U))
            {
                int treatments_id = -1;
                if (vTreatmentsBindingSource.Current != null)
                {
                    treatments_id = (((DataRowView)vTreatmentsBindingSource.Current).Row).Field<int>("treatments_id");
                }
                if (treatments_id != -1)
                {
                    treatments treatments = _doctcodModel.Treatments.Find(treatments_id);
                    treatmentspriceslists treatmentspriceslist = _doctcodModel.TreatmentsPricesLists.Find(treatmentspriceslists_idComboBox.SelectedValue);
                    if (treatments != null && treatmentspriceslist != null)
                    {
                        ((treatmentsprices)treatmentspricesBindingSource.Current).treatmentspriceslists_id = treatmentspriceslist.treatmentspriceslists_id;
                        ((treatmentsprices)treatmentspricesBindingSource.Current).treatmentsprices_price = Math.Round(treatments.treatments_price * treatmentspriceslist.treatmentspriceslists_multiplier, 2);
                    }
                    treatmentspricesBindingSource.ResetBindings(true);
                }
            }
        }

        #endregion

    }
}
