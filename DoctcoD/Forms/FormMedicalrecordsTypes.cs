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
    public partial class FormMedicalrecordsTypes : DGUIGHFForm
    {
        private DoctcoDModel _doctcodModel = null;

        private TabElement tabElement_tabMedicalrecordsTypes = new TabElement();

        /// <summary>
        /// Constructor
        /// </summary>
        public FormMedicalrecordsTypes()
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
            LanguageHelper.AddComponent(medicalrecordstypesidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(nameDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            //tabMedicalrecordsTypes
            LanguageHelper.AddComponent(tabPage_tabMedicalrecordsTypes);
            LanguageHelper.AddComponent(button_tabMedicalrecordsTypes_new);
            LanguageHelper.AddComponent(button_tabMedicalrecordsTypes_edit);
            LanguageHelper.AddComponent(button_tabMedicalrecordsTypes_delete);
            LanguageHelper.AddComponent(button_tabMedicalrecordsTypes_save);
            LanguageHelper.AddComponent(button_tabMedicalrecordsTypes_cancel);
            LanguageHelper.AddComponent(medicalrecordstypes_idLabel);
            LanguageHelper.AddComponent(medicalrecordstypes_nameLabel);
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
            BindingSourceMain = vMedicalrecordsTypesBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = panel_filters;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabMedicalrecordsTypes
            tabElement_tabMedicalrecordsTypes = new TabElement()
            {
                TabPageElement = tabPage_tabMedicalrecordsTypes,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabMedicalrecordsTypes_data,
                    PanelActions = panel_tabMedicalrecordsTypes_actions,
                    PanelUpdates = panel_tabMedicalrecordsTypes_updates,

                    ParentBindingSourceList = vMedicalrecordsTypesBindingSource,
                    GetParentDataSourceList = GetDataSource_main,

                    BindingSourceEdit = medicalrecordstypesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabMedicalrecordsTypes,
                    AfterSaveAction = AfterSaveAction_tabMedicalrecordsTypes,

                    AddButton = button_tabMedicalrecordsTypes_new,
                    UpdateButton = button_tabMedicalrecordsTypes_edit,
                    RemoveButton = button_tabMedicalrecordsTypes_delete,
                    SaveButton = button_tabMedicalrecordsTypes_save,
                    CancelButton = button_tabMedicalrecordsTypes_cancel,

                    Add = Add_tabMedicalrecordsTypes,
                    Update = Update_tabMedicalrecordsTypes,
                    Remove = Remove_tabMedicalrecordsTypes
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabMedicalrecordsTypes);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMedicalrecordsTypes_Load(object sender, EventArgs e)
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
            IEnumerable<VMedicalrecordsTypes> vMedicalrecordsTypes =
                _doctcodModel.MedicalrecordsTypes.List().Select(
                r => new VMedicalrecordsTypes
                {
                    medicalrecordstypes_id = r.medicalrecordstypes_id,
                    name = r.medicalrecordstypes_name
                }).ToList();

            return DGDataTableUtils.ToDataTable<VMedicalrecordsTypes>(vMedicalrecordsTypes);
        }


        #region tabMedicalrecordsTypes

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabMedicalrecordsTypes()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<medicalrecordstypes, DoctcoDModel>(_doctcodModel.MedicalrecordsTypes, vMedicalrecordsTypesBindingSource, new string[] { "medicalrecordstypes_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabMedicalrecordsTypes(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<medicalrecordstypes, DoctcoDModel>(_doctcodModel.MedicalrecordsTypes, item, vMedicalrecordsTypesBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabMedicalrecordsTypes(object item)
        {
            DGUIGHFData.Add<medicalrecordstypes, DoctcoDModel>(_doctcodModel.MedicalrecordsTypes, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabMedicalrecordsTypes(object item)
        {
            DGUIGHFData.Update<medicalrecordstypes, DoctcoDModel>(_doctcodModel.MedicalrecordsTypes, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabMedicalrecordsTypes(object item)
        {
            DGUIGHFData.Remove<medicalrecordstypes, DoctcoDModel>(_doctcodModel.MedicalrecordsTypes, item);
        }

        #endregion

    }
}
