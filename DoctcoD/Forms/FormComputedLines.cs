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
using System.Linq;
using System.Windows.Forms;
using Zuby.ADGV;

namespace DG.DoctcoD.Forms
{
    public partial class FormComputedLines : DGUIGHFForm
    {
        private DoctcoDModel _doctcodModel = null;

        private TabElement tabElement_tabComputedLines = new TabElement();

        private readonly BoxLoader _boxLoader = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public FormComputedLines()
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
            LanguageHelper.AddComponent(computedlinesidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(codeDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(nameDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            //tabComputedLines
            LanguageHelper.AddComponent(tabPage_tabComputedLines);
            LanguageHelper.AddComponent(button_tabComputedLines_new);
            LanguageHelper.AddComponent(button_tabComputedLines_edit);
            LanguageHelper.AddComponent(button_tabComputedLines_delete);
            LanguageHelper.AddComponent(button_tabComputedLines_save);
            LanguageHelper.AddComponent(button_tabComputedLines_cancel);
            LanguageHelper.AddComponent(computedlines_idLabel);
            LanguageHelper.AddComponent(computedlines_nameLabel);
            LanguageHelper.AddComponent(computedlines_rateLabel);
            LanguageHelper.AddComponent(taxes_idLabel);
            LanguageHelper.AddComponent(button_tabComputedLines_unsettaxesid);
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
            BindingSourceMain = vComputedLinesBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = panel_filters;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabComputedLines
            tabElement_tabComputedLines = new TabElement()
            {
                TabPageElement = tabPage_tabComputedLines,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabComputedLines_data,
                    PanelActions = panel_tabComputedLines_actions,
                    PanelUpdates = panel_tabComputedLines_updates,

                    ParentBindingSourceList = vComputedLinesBindingSource,
                    GetParentDataSourceList = GetDataSource_main,

                    BindingSourceEdit = computedlinesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabComputedLines,
                    AfterSaveAction = AfterSaveAction_tabComputedLines,

                    AddButton = button_tabComputedLines_new,
                    UpdateButton = button_tabComputedLines_edit,
                    RemoveButton = button_tabComputedLines_delete,
                    SaveButton = button_tabComputedLines_save,
                    CancelButton = button_tabComputedLines_cancel,

                    Add = Add_tabComputedLines,
                    Update = Update_tabComputedLines,
                    Remove = Remove_tabComputedLines
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabComputedLines);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormComputedLines_Load(object sender, EventArgs e)
        {
            IsBindingSourceLoading = true;
            advancedDataGridView_main.SortASC(advancedDataGridView_main.Columns[1]);
            advancedDataGridView_main.SortASC(advancedDataGridView_main.Columns[2]);
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

            _boxLoader.LoadComboBoxTaxes(taxes_idComboBox);

            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Get main list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSource_main()
        {
            IEnumerable<VComputedLines> vComputedLines =
                _doctcodModel.ComputedLines.List().Select(
                r => new VComputedLines
                {
                    computedlines_id = r.computedlines_id,
                    code = r.computedlines_code,
                    name = r.computedlines_name
                }).ToList();

            return DGDataTableUtils.ToDataTable<VComputedLines>(vComputedLines);
        }


        #region tabComputedLines

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabComputedLines()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<computedlines, DoctcoDModel>(_doctcodModel.ComputedLines, vComputedLinesBindingSource, new string[] { "computedlines_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabComputedLines(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<computedlines, DoctcoDModel>(_doctcodModel.ComputedLines, item, vComputedLinesBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabComputedLines(object item)
        {
            DGUIGHFData.Add<computedlines, DoctcoDModel>(_doctcodModel.ComputedLines, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabComputedLines(object item)
        {
            DGUIGHFData.Update<computedlines, DoctcoDModel>(_doctcodModel.ComputedLines, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabComputedLines(object item)
        {
            DGUIGHFData.Remove<computedlines, DoctcoDModel>(_doctcodModel.ComputedLines, item);
        }

        /// <summary>
        /// Unset taxesid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabComputedLines_unsettaxesid_Click(object sender, EventArgs e)
        {
            taxes_idComboBox.SelectedIndex = -1;
        }
        
        #endregion

    }
}
