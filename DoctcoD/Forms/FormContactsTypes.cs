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
    public partial class FormContactsTypes : DGUIGHFForm
    {
        private DoctcoDModel _doctcodModel = null;

        private TabElement tabElement_tabContactsTypes = new TabElement();

        /// <summary>
        /// Constructor
        /// </summary>
        public FormContactsTypes()
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
            LanguageHelper.AddComponent(contactstypesidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(nameDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            //tabContactsTypes
            LanguageHelper.AddComponent(tabPage_tabContactsTypes);
            LanguageHelper.AddComponent(button_tabContactsTypes_new);
            LanguageHelper.AddComponent(button_tabContactsTypes_edit);
            LanguageHelper.AddComponent(button_tabContactsTypes_delete);
            LanguageHelper.AddComponent(button_tabContactsTypes_save);
            LanguageHelper.AddComponent(button_tabContactsTypes_cancel);
            LanguageHelper.AddComponent(contactstypes_idLabel);
            LanguageHelper.AddComponent(contactstypes_nameLabel);
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
            BindingSourceMain = vContactsTypesBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = panel_filters;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabContactsTypes
            tabElement_tabContactsTypes = new TabElement()
            {
                TabPageElement = tabPage_tabContactsTypes,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabContactsTypes_data,
                    PanelActions = panel_tabContactsTypes_actions,
                    PanelUpdates = panel_tabContactsTypes_updates,

                    ParentBindingSourceList = vContactsTypesBindingSource,
                    GetParentDataSourceList = GetDataSource_main,

                    BindingSourceEdit = contactstypesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabContactsTypes,
                    AfterSaveAction = AfterSaveAction_tabContactsTypes,

                    AddButton = button_tabContactsTypes_new,
                    UpdateButton = button_tabContactsTypes_edit,
                    RemoveButton = button_tabContactsTypes_delete,
                    SaveButton = button_tabContactsTypes_save,
                    CancelButton = button_tabContactsTypes_cancel,

                    Add = Add_tabContactsTypes,
                    Update = Update_tabContactsTypes,
                    Remove = Remove_tabContactsTypes
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabContactsTypes);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormContactsTypes_Load(object sender, EventArgs e)
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
            IEnumerable<VContactsTypes> vContactsTypes =
                _doctcodModel.ContactsTypes.List().Select(
                r => new VContactsTypes
                {
                    contactstypes_id = r.contactstypes_id,
                    name = r.contactstypes_name
                }).ToList();

            return DGDataTableUtils.ToDataTable<VContactsTypes>(vContactsTypes);
        }


        #region tabContactsTypes

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabContactsTypes()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<contactstypes, DoctcoDModel>(_doctcodModel.ContactsTypes, vContactsTypesBindingSource, new string[] { "contactstypes_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabContactsTypes(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<contactstypes, DoctcoDModel>(_doctcodModel.ContactsTypes, item, vContactsTypesBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabContactsTypes(object item)
        {
            DGUIGHFData.Add<contactstypes, DoctcoDModel>(_doctcodModel.ContactsTypes, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabContactsTypes(object item)
        {
            DGUIGHFData.Update<contactstypes, DoctcoDModel>(_doctcodModel.ContactsTypes, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabContactsTypes(object item)
        {
            DGUIGHFData.Remove<contactstypes, DoctcoDModel>(_doctcodModel.ContactsTypes, item);
        }

        #endregion

    }
}
