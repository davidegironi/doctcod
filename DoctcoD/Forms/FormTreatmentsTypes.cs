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
    public partial class FormTreatmentsTypes : DGUIGHFForm
    {
        private DoctcoDModel _doctcodModel = null;

        private TabElement tabElement_tabTreatmentsTypes = new TabElement();

        /// <summary>
        /// Constructor
        /// </summary>
        public FormTreatmentsTypes()
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
            LanguageHelper.AddComponent(treatmentstypesidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(nameDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            //tabTreatmentsTypes
            LanguageHelper.AddComponent(tabPage_tabTreatmentsTypes);
            LanguageHelper.AddComponent(button_tabTreatmentsTypes_new);
            LanguageHelper.AddComponent(button_tabTreatmentsTypes_edit);
            LanguageHelper.AddComponent(button_tabTreatmentsTypes_delete);
            LanguageHelper.AddComponent(button_tabTreatmentsTypes_save);
            LanguageHelper.AddComponent(button_tabTreatmentsTypes_cancel);
            LanguageHelper.AddComponent(treatmentstypes_idLabel);
            LanguageHelper.AddComponent(treatmentstypes_nameLabel);
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
            BindingSourceMain = vTreatmentsTypesBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = panel_filters;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabTreatmentsTypes
            tabElement_tabTreatmentsTypes = new TabElement()
            {
                TabPageElement = tabPage_tabTreatmentsTypes,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabTreatmentsTypes_data,
                    PanelActions = panel_tabTreatmentsTypes_actions,
                    PanelUpdates = panel_tabTreatmentsTypes_updates,

                    ParentBindingSourceList = vTreatmentsTypesBindingSource,
                    GetParentDataSourceList = GetDataSource_main,

                    BindingSourceEdit = treatmentstypesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabTreatmentsTypes,
                    AfterSaveAction = AfterSaveAction_tabTreatmentsTypes,

                    AddButton = button_tabTreatmentsTypes_new,
                    UpdateButton = button_tabTreatmentsTypes_edit,
                    RemoveButton = button_tabTreatmentsTypes_delete,
                    SaveButton = button_tabTreatmentsTypes_save,
                    CancelButton = button_tabTreatmentsTypes_cancel,

                    Add = Add_tabTreatmentsTypes,
                    Update = Update_tabTreatmentsTypes,
                    Remove = Remove_tabTreatmentsTypes
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabTreatmentsTypes);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTreatmentsTypes_Load(object sender, EventArgs e)
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
            IEnumerable<VTreatmentsTypes> vTreatmentsTypes =
                _doctcodModel.TreatmentsTypes.List().Select(
                r => new VTreatmentsTypes
                {
                    treatmentstypes_id = r.treatmentstypes_id,
                    name = r.treatmentstypes_name
                }).ToList();

            return DGDataTableUtils.ToDataTable<VTreatmentsTypes>(vTreatmentsTypes);
        }


        #region tabTreatmentsTypes

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabTreatmentsTypes()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<treatmentstypes, DoctcoDModel>(_doctcodModel.TreatmentsTypes, vTreatmentsTypesBindingSource, new string[] { "treatmentstypes_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabTreatmentsTypes(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<treatmentstypes, DoctcoDModel>(_doctcodModel.TreatmentsTypes, item, vTreatmentsTypesBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabTreatmentsTypes(object item)
        {
            DGUIGHFData.Add<treatmentstypes, DoctcoDModel>(_doctcodModel.TreatmentsTypes, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabTreatmentsTypes(object item)
        {
            DGUIGHFData.Update<treatmentstypes, DoctcoDModel>(_doctcodModel.TreatmentsTypes, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabTreatmentsTypes(object item)
        {
            DGUIGHFData.Remove<treatmentstypes, DoctcoDModel>(_doctcodModel.TreatmentsTypes, item);
        }

        #endregion

    }
}
