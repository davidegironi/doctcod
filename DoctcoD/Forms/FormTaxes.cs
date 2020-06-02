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
    public partial class FormTaxes : DGUIGHFForm
    {
        private DoctcoDModel _doctcodModel = null;

        private TabElement tabElement_tabTaxes = new TabElement();

        /// <summary>
        /// Constructor
        /// </summary>
        public FormTaxes()
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
            LanguageHelper.AddComponent(taxesidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(nameDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(isdefaultDataGridViewCheckBoxColumn, this.GetType().Name, "HeaderText");
            //tabTaxes
            LanguageHelper.AddComponent(tabPage_tabTaxes);
            LanguageHelper.AddComponent(button_tabTaxes_new);
            LanguageHelper.AddComponent(button_tabTaxes_edit);
            LanguageHelper.AddComponent(button_tabTaxes_delete);
            LanguageHelper.AddComponent(button_tabTaxes_save);
            LanguageHelper.AddComponent(button_tabTaxes_cancel);
            LanguageHelper.AddComponent(taxes_idLabel);
            LanguageHelper.AddComponent(taxes_nameLabel);
            LanguageHelper.AddComponent(taxes_rateLabel);
            LanguageHelper.AddComponent(taxes_isdefaultCheckBox);
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
            BindingSourceMain = vTaxesBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = panel_filters;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabTaxes
            tabElement_tabTaxes = new TabElement()
            {
                TabPageElement = tabPage_tabTaxes,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabTaxes_data,
                    PanelActions = panel_tabTaxes_actions,
                    PanelUpdates = panel_tabTaxes_updates,

                    ParentBindingSourceList = vTaxesBindingSource,
                    GetParentDataSourceList = GetDataSource_main,

                    BindingSourceEdit = taxesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabTaxes,
                    AfterSaveAction = AfterSaveAction_tabTaxes,

                    AddButton = button_tabTaxes_new,
                    UpdateButton = button_tabTaxes_edit,
                    RemoveButton = button_tabTaxes_delete,
                    SaveButton = button_tabTaxes_save,
                    CancelButton = button_tabTaxes_cancel,

                    Add = Add_tabTaxes,
                    Update = Update_tabTaxes,
                    Remove = Remove_tabTaxes
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabTaxes);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTaxes_Load(object sender, EventArgs e)
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
            IEnumerable<VTaxes> vTaxes =
                _doctcodModel.Taxes.List().Select(
                r => new VTaxes
                {
                    taxes_id = r.taxes_id,
                    name = r.taxes_name,
                    isdefault = r.taxes_isdefault
                }).ToList();

            return DGDataTableUtils.ToDataTable<VTaxes>(vTaxes);
        }


        #region tabTaxes

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabTaxes()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<taxes, DoctcoDModel>(_doctcodModel.Taxes, vTaxesBindingSource, new string[] { "taxes_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabTaxes(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<taxes, DoctcoDModel>(_doctcodModel.Taxes, item, vTaxesBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabTaxes(object item)
        {
            DGUIGHFData.Add<taxes, DoctcoDModel>(_doctcodModel.Taxes, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabTaxes(object item)
        {
            DGUIGHFData.Update<taxes, DoctcoDModel>(_doctcodModel.Taxes, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabTaxes(object item)
        {
            DGUIGHFData.Remove<taxes, DoctcoDModel>(_doctcodModel.Taxes, item);
        }

        #endregion

    }
}
