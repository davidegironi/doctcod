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
    public partial class FormInvoicesFooters : DGUIGHFForm
    {
        private DoctcoDModel _doctcodModel = null;

        private TabElement tabElement_tabInvoicesFooters = new TabElement();

        /// <summary>
        /// Constructor
        /// </summary>
        public FormInvoicesFooters()
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
            LanguageHelper.AddComponent(invoicesfootersidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(nameDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(isdefaultDataGridViewCheckBoxColumn, this.GetType().Name, "HeaderText");
            //tabInvoicesFooters
            LanguageHelper.AddComponent(tabPage_tabInvoicesFooters);
            LanguageHelper.AddComponent(button_tabInvoicesFooters_new);
            LanguageHelper.AddComponent(button_tabInvoicesFooters_edit);
            LanguageHelper.AddComponent(button_tabInvoicesFooters_delete);
            LanguageHelper.AddComponent(button_tabInvoicesFooters_save);
            LanguageHelper.AddComponent(button_tabInvoicesFooters_cancel);
            LanguageHelper.AddComponent(invoicesfooters_idLabel);
            LanguageHelper.AddComponent(invoicesfooters_nameLabel);
            LanguageHelper.AddComponent(invoicesfooters_doctextLabel);
            LanguageHelper.AddComponent(invoicesfooters_isdefaultCheckBox);
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
            BindingSourceMain = vInvoicesFootersBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = panel_filters;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabInvoicesFooters
            tabElement_tabInvoicesFooters = new TabElement()
            {
                TabPageElement = tabPage_tabInvoicesFooters,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabInvoicesFooters_data,
                    PanelActions = panel_tabInvoicesFooters_actions,
                    PanelUpdates = panel_tabInvoicesFooters_updates,

                    ParentBindingSourceList = vInvoicesFootersBindingSource,
                    GetParentDataSourceList = GetDataSource_main,

                    BindingSourceEdit = invoicesfootersBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabInvoicesFooters,
                    AfterSaveAction = AfterSaveAction_tabInvoicesFooters,

                    AddButton = button_tabInvoicesFooters_new,
                    UpdateButton = button_tabInvoicesFooters_edit,
                    RemoveButton = button_tabInvoicesFooters_delete,
                    SaveButton = button_tabInvoicesFooters_save,
                    CancelButton = button_tabInvoicesFooters_cancel,

                    Add = Add_tabInvoicesFooters,
                    Update = Update_tabInvoicesFooters,
                    Remove = Remove_tabInvoicesFooters
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabInvoicesFooters);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormInvoicesFooters_Load(object sender, EventArgs e)
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
            IEnumerable<VInvoicesFooters> vInvoicesFooters =
                _doctcodModel.InvoicesFooters.List().Select(
                r => new VInvoicesFooters
                {
                    invoicesfooters_id = r.invoicesfooters_id,
                    name = r.invoicesfooters_name,
                    isdefault = r.invoicesfooters_isdefault
                }).ToList();

            return DGDataTableUtils.ToDataTable<VInvoicesFooters>(vInvoicesFooters);
        }


        #region tabInvoicesFooters

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabInvoicesFooters()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<invoicesfooters, DoctcoDModel>(_doctcodModel.InvoicesFooters, vInvoicesFootersBindingSource, new string[] { "invoicesfooters_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabInvoicesFooters(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<invoicesfooters, DoctcoDModel>(_doctcodModel.InvoicesFooters, item, vInvoicesFootersBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabInvoicesFooters(object item)
        {
            DGUIGHFData.Add<invoicesfooters, DoctcoDModel>(_doctcodModel.InvoicesFooters, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabInvoicesFooters(object item)
        {
            DGUIGHFData.Update<invoicesfooters, DoctcoDModel>(_doctcodModel.InvoicesFooters, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabInvoicesFooters(object item)
        {
            DGUIGHFData.Remove<invoicesfooters, DoctcoDModel>(_doctcodModel.InvoicesFooters, item);
        }

        #endregion

    }
}
