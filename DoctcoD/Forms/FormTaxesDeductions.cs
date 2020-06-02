﻿#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.Data.Model.Helpers;
using DG.DoctcoD.Forms.Objects;
using DG.DoctcoD.Model;
using DG.DoctcoD.Model.Entity;
using DG.UI.GHF;
using SMcMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Zuby.ADGV;

namespace DG.DoctcoD.Forms
{
    public partial class FormTaxesDeductions : DGUIGHFForm
    {
        private DoctcoDModel _doctcodModel = null;

        private TabElement tabElement_tabTaxesDeductions = new TabElement();

        /// <summary>
        /// Constructor
        /// </summary>
        public FormTaxesDeductions()
        {
            InitializeComponent();
            (new TabOrderManager(this)).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);

            Initialize(Program.uighfApplication);

            _doctcodModel = new DoctcoDModel();
            _doctcodModel.LanguageHelper.LoadFromFile(Program.uighfApplication.LanguageFilename);
        }

        /// <summary>
        /// Add components language
        /// </summary>
        public override void AddLanguageComponents()
        {
            //main
            LanguageHelper.AddComponent(this);
            LanguageHelper.AddComponent(taxesdeductionsidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(nameDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(isdefaultDataGridViewCheckBoxColumn, this.GetType().Name, "HeaderText");
            //tabTaxesDeductions
            LanguageHelper.AddComponent(tabPage_tabTaxesDeductions);
            LanguageHelper.AddComponent(button_tabTaxesDeductions_new);
            LanguageHelper.AddComponent(button_tabTaxesDeductions_edit);
            LanguageHelper.AddComponent(button_tabTaxesDeductions_delete);
            LanguageHelper.AddComponent(button_tabTaxesDeductions_save);
            LanguageHelper.AddComponent(button_tabTaxesDeductions_cancel);
            LanguageHelper.AddComponent(taxesdeductions_idLabel);
            LanguageHelper.AddComponent(taxesdeductions_nameLabel);
            LanguageHelper.AddComponent(taxesdeductions_rateLabel);
            LanguageHelper.AddComponent(taxesdeductions_isdefaultCheckBox);
        }

        /// <summary>
        /// Initialize TabElements
        /// </summary>
        protected override void InitializeTabElements()
        {
            //set Readonly OnSetEditingMode for Controls
            DisableReadonlyCheckOnSetEditingModeControlCollection.Add(typeof(DataGridView));
            DisableReadonlyCheckOnSetEditingModeControlCollection.Add(typeof(AdvancedDataGridView));

            //set Main BindingSource
            BindingSourceMain = vTaxesDeductionsBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = panel_filters;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabTaxesDeductions
            tabElement_tabTaxesDeductions = new TabElement()
            {
                TabPageElement = tabPage_tabTaxesDeductions,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabTaxesDeductions_data,
                    PanelActions = panel_tabTaxesDeductions_actions,
                    PanelUpdates = panel_tabTaxesDeductions_updates,

                    ParentBindingSourceList = vTaxesDeductionsBindingSource,
                    GetParentDataSourceList = GetDataSource_main,

                    BindingSourceEdit = taxesdeductionsBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabTaxesDeductions,
                    AfterSaveAction = AfterSaveAction_tabTaxesDeductions,

                    AddButton = button_tabTaxesDeductions_new,
                    UpdateButton = button_tabTaxesDeductions_edit,
                    RemoveButton = button_tabTaxesDeductions_delete,
                    SaveButton = button_tabTaxesDeductions_save,
                    CancelButton = button_tabTaxesDeductions_cancel,

                    Add = Add_tabTaxesDeductions,
                    Update = Update_tabTaxesDeductions,
                    Remove = Remove_tabTaxesDeductions
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabTaxesDeductions);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTaxesDeductions_Load(object sender, EventArgs e)
        {
            IsBindingSourceLoading = true;
            advancedDataGridView_main.SortASC(advancedDataGridView_main.Columns[1]);
            IsBindingSourceLoading = false;

            ReloadView();
        }

        /// <summary>
        /// Get main list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSource_main()
        {
            IEnumerable<VTaxesDeductions> vTaxesDeductions =
                _doctcodModel.TaxesDeductions.List().Select(
                r => new VTaxesDeductions
                {
                    taxesdeductions_id = r.taxesdeductions_id,
                    name = r.taxesdeductions_name,
                    isdefault = r.taxesdeductions_isdefault
                }).ToList();

            return DGDataTableUtils.ToDataTable<VTaxesDeductions>(vTaxesDeductions);
        }


        #region tabTaxesDeductions

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabTaxesDeductions()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<taxesdeductions, DoctcoDModel>(_doctcodModel.TaxesDeductions, vTaxesDeductionsBindingSource, new string[] { "taxesdeductions_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabTaxesDeductions(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<taxesdeductions, DoctcoDModel>(_doctcodModel.TaxesDeductions, item, vTaxesDeductionsBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabTaxesDeductions(object item)
        {
            DGUIGHFData.Add<taxesdeductions, DoctcoDModel>(_doctcodModel.TaxesDeductions, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabTaxesDeductions(object item)
        {
            DGUIGHFData.Update<taxesdeductions, DoctcoDModel>(_doctcodModel.TaxesDeductions, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabTaxesDeductions(object item)
        {
            DGUIGHFData.Remove<taxesdeductions, DoctcoDModel>(_doctcodModel.TaxesDeductions, item);
        }

        #endregion

    }
}
