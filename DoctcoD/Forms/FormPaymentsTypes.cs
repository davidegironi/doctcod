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
    public partial class FormPaymentsTypes : DGUIGHFForm
    {
        private DoctcoDModel _doctcodModel = null;

        private TabElement tabElement_tabPaymentsTypes = new TabElement();

        /// <summary>
        /// Constructor
        /// </summary>
        public FormPaymentsTypes()
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
            LanguageHelper.AddComponent(paymentstypesidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(nameDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(isdefaultDataGridViewCheckBoxColumn, this.GetType().Name, "HeaderText");
            //tabPaymentsTypes
            LanguageHelper.AddComponent(tabPage_tabPaymentsTypes);
            LanguageHelper.AddComponent(button_tabPaymentsTypes_new);
            LanguageHelper.AddComponent(button_tabPaymentsTypes_edit);
            LanguageHelper.AddComponent(button_tabPaymentsTypes_delete);
            LanguageHelper.AddComponent(button_tabPaymentsTypes_save);
            LanguageHelper.AddComponent(button_tabPaymentsTypes_cancel);
            LanguageHelper.AddComponent(paymentstypes_idLabel);
            LanguageHelper.AddComponent(paymentstypes_nameLabel);
            LanguageHelper.AddComponent(paymentstypes_doctextLabel);
            LanguageHelper.AddComponent(paymentstypes_isdefaultCheckBox);
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
            BindingSourceMain = vPaymentsTypesBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = panel_filters;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabPaymentsTypes
            tabElement_tabPaymentsTypes = new TabElement()
            {
                TabPageElement = tabPage_tabPaymentsTypes,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabPaymentsTypes_data,
                    PanelActions = panel_tabPaymentsTypes_actions,
                    PanelUpdates = panel_tabPaymentsTypes_updates,

                    ParentBindingSourceList = vPaymentsTypesBindingSource,
                    GetParentDataSourceList = GetDataSource_main,

                    BindingSourceEdit = paymentstypesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabPaymentsTypes,
                    AfterSaveAction = AfterSaveAction_tabPaymentsTypes,

                    AddButton = button_tabPaymentsTypes_new,
                    UpdateButton = button_tabPaymentsTypes_edit,
                    RemoveButton = button_tabPaymentsTypes_delete,
                    SaveButton = button_tabPaymentsTypes_save,
                    CancelButton = button_tabPaymentsTypes_cancel,

                    Add = Add_tabPaymentsTypes,
                    Update = Update_tabPaymentsTypes,
                    Remove = Remove_tabPaymentsTypes
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabPaymentsTypes);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPaymentsTypes_Load(object sender, EventArgs e)
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
            IEnumerable<VPaymentsTypes> vPaymentsTypes =
                _doctcodModel.PaymentsTypes.List().Select(
                r => new VPaymentsTypes
                {
                    paymentstypes_id = r.paymentstypes_id,
                    name = r.paymentstypes_name,
                    isdefault = r.paymentstypes_isdefault
                }).ToList();

            return DGDataTableUtils.ToDataTable<VPaymentsTypes>(vPaymentsTypes);
        }


        #region tabPaymentsTypes

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabPaymentsTypes()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<paymentstypes, DoctcoDModel>(_doctcodModel.PaymentsTypes, vPaymentsTypesBindingSource, new string[] { "paymentstypes_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabPaymentsTypes(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<paymentstypes, DoctcoDModel>(_doctcodModel.PaymentsTypes, item, vPaymentsTypesBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabPaymentsTypes(object item)
        {
            DGUIGHFData.Add<paymentstypes, DoctcoDModel>(_doctcodModel.PaymentsTypes, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabPaymentsTypes(object item)
        {
            DGUIGHFData.Update<paymentstypes, DoctcoDModel>(_doctcodModel.PaymentsTypes, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabPaymentsTypes(object item)
        {
            DGUIGHFData.Remove<paymentstypes, DoctcoDModel>(_doctcodModel.PaymentsTypes, item);
        }

        #endregion

    }
}
