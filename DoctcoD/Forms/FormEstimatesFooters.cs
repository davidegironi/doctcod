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
    public partial class FormEstimatesFooters : DGUIGHFForm
    {
        private DoctcoDModel _doctcodModel = null;

        private TabElement tabElement_tabEstimatesFooters = new TabElement();

        /// <summary>
        /// Constructor
        /// </summary>
        public FormEstimatesFooters()
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
            LanguageHelper.AddComponent(estimatesfootersidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(nameDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(isdefaultDataGridViewCheckBoxColumn, this.GetType().Name, "HeaderText");
            //tabEstimatesFooters
            LanguageHelper.AddComponent(tabPage_tabEstimatesFooters);
            LanguageHelper.AddComponent(button_tabEstimatesFooters_new);
            LanguageHelper.AddComponent(button_tabEstimatesFooters_edit);
            LanguageHelper.AddComponent(button_tabEstimatesFooters_delete);
            LanguageHelper.AddComponent(button_tabEstimatesFooters_save);
            LanguageHelper.AddComponent(button_tabEstimatesFooters_cancel);
            LanguageHelper.AddComponent(estimatesfooters_idLabel);
            LanguageHelper.AddComponent(estimatesfooters_nameLabel);
            LanguageHelper.AddComponent(estimatesfooters_doctextLabel);
            LanguageHelper.AddComponent(estimatesfooters_isdefaultCheckBox);
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
            BindingSourceMain = vEstimatesFootersBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = panel_filters;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabEstimatesFooters
            tabElement_tabEstimatesFooters = new TabElement()
            {
                TabPageElement = tabPage_tabEstimatesFooters,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabEstimatesFooters_data,
                    PanelActions = panel_tabEstimatesFooters_actions,
                    PanelUpdates = panel_tabEstimatesFooters_updates,

                    ParentBindingSourceList = vEstimatesFootersBindingSource,
                    GetParentDataSourceList = GetDataSource_main,

                    BindingSourceEdit = estimatesfootersBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabEstimatesFooters,
                    AfterSaveAction = AfterSaveAction_tabEstimatesFooters,

                    AddButton = button_tabEstimatesFooters_new,
                    UpdateButton = button_tabEstimatesFooters_edit,
                    RemoveButton = button_tabEstimatesFooters_delete,
                    SaveButton = button_tabEstimatesFooters_save,
                    CancelButton = button_tabEstimatesFooters_cancel,

                    Add = Add_tabEstimatesFooters,
                    Update = Update_tabEstimatesFooters,
                    Remove = Remove_tabEstimatesFooters
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabEstimatesFooters);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormEstimatesFooters_Load(object sender, EventArgs e)
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
            IEnumerable<VEstimatesFooters> vEstimatesFooters =
                _doctcodModel.EstimatesFooters.List().Select(
                r => new VEstimatesFooters
                {
                    estimatesfooters_id = r.estimatesfooters_id,
                    name = r.estimatesfooters_name,
                    isdefault = r.estimatesfooters_isdefault
                }).ToList();

            return DGDataTableUtils.ToDataTable<VEstimatesFooters>(vEstimatesFooters);
        }


        #region tabEstimatesFooters

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabEstimatesFooters()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<estimatesfooters, DoctcoDModel>(_doctcodModel.EstimatesFooters, vEstimatesFootersBindingSource, new string[] { "estimatesfooters_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabEstimatesFooters(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<estimatesfooters, DoctcoDModel>(_doctcodModel.EstimatesFooters, item, vEstimatesFootersBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabEstimatesFooters(object item)
        {
            DGUIGHFData.Add<estimatesfooters, DoctcoDModel>(_doctcodModel.EstimatesFooters, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabEstimatesFooters(object item)
        {
            DGUIGHFData.Update<estimatesfooters, DoctcoDModel>(_doctcodModel.EstimatesFooters, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabEstimatesFooters(object item)
        {
            DGUIGHFData.Remove<estimatesfooters, DoctcoDModel>(_doctcodModel.EstimatesFooters, item);
        }

        #endregion

    }
}
