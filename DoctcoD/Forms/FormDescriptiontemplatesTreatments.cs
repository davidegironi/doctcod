#region License
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
    public partial class FormDescriptiontemplatesTreatments : DGUIGHFForm
    {
        private DoctcoDModel _doctcodModel = null;

        private TabElement tabElement_tabDescriptiontemplatesTreatments = new TabElement();

        /// <summary>
        /// Constructor
        /// </summary>
        public FormDescriptiontemplatesTreatments()
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
            LanguageHelper.AddComponent(descriptiontemplatestreatmentsidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(nameDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            //tabDescriptiontemplatesTreatments
            LanguageHelper.AddComponent(tabPage_tabDescriptiontemplatesTreatments);
            LanguageHelper.AddComponent(button_tabDescriptiontemplatesTreatments_new);
            LanguageHelper.AddComponent(button_tabDescriptiontemplatesTreatments_edit);
            LanguageHelper.AddComponent(button_tabDescriptiontemplatesTreatments_delete);
            LanguageHelper.AddComponent(button_tabDescriptiontemplatesTreatments_save);
            LanguageHelper.AddComponent(button_tabDescriptiontemplatesTreatments_cancel);
            LanguageHelper.AddComponent(descriptiontemplatestreatments_idLabel);
            LanguageHelper.AddComponent(descriptiontemplatestreatments_nameLabel);
            LanguageHelper.AddComponent(descriptiontemplatestreatments_templateLabel);
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
            BindingSourceMain = vDescriptiontemplatesTreatmentsBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = panel_filters;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabDescriptiontemplatesTreatments
            tabElement_tabDescriptiontemplatesTreatments = new TabElement()
            {
                TabPageElement = tabPage_tabDescriptiontemplatesTreatments,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabDescriptiontemplatesTreatments_data,
                    PanelActions = panel_tabDescriptiontemplatesTreatments_actions,
                    PanelUpdates = panel_tabDescriptiontemplatesTreatments_updates,

                    ParentBindingSourceList = vDescriptiontemplatesTreatmentsBindingSource,
                    GetParentDataSourceList = GetDataSource_main,

                    BindingSourceEdit = descriptiontemplatestreatmentsBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabDescriptiontemplatesTreatments,
                    AfterSaveAction = AfterSaveAction_tabDescriptiontemplatesTreatments,

                    AddButton = button_tabDescriptiontemplatesTreatments_new,
                    UpdateButton = button_tabDescriptiontemplatesTreatments_edit,
                    RemoveButton = button_tabDescriptiontemplatesTreatments_delete,
                    SaveButton = button_tabDescriptiontemplatesTreatments_save,
                    CancelButton = button_tabDescriptiontemplatesTreatments_cancel,

                    Add = Add_tabDescriptiontemplatesTreatments,
                    Update = Update_tabDescriptiontemplatesTreatments,
                    Remove = Remove_tabDescriptiontemplatesTreatments
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabDescriptiontemplatesTreatments);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormDescriptiontemplatesTreatments_Load(object sender, EventArgs e)
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
            IEnumerable<VDescriptiontemplatesTreatments> vDescriptiontemplatesTreatments =
                _doctcodModel.DescriptiontemplatesTreatments.List().Select(
                r => new VDescriptiontemplatesTreatments
                {
                    descriptiontemplatestreatments_id = r.descriptiontemplatestreatments_id,
                    name = r.descriptiontemplatestreatments_name
                }).ToList();

            return DGDataTableUtils.ToDataTable<VDescriptiontemplatesTreatments>(vDescriptiontemplatesTreatments);
        }


        #region tabDescriptiontemplatesTreatments

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabDescriptiontemplatesTreatments()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<descriptiontemplatestreatments, DoctcoDModel>(_doctcodModel.DescriptiontemplatesTreatments, vDescriptiontemplatesTreatmentsBindingSource, new string[] { "descriptiontemplatestreatments_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabDescriptiontemplatesTreatments(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<descriptiontemplatestreatments, DoctcoDModel>(_doctcodModel.DescriptiontemplatesTreatments, item, vDescriptiontemplatesTreatmentsBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabDescriptiontemplatesTreatments(object item)
        {
            DGUIGHFData.Add<descriptiontemplatestreatments, DoctcoDModel>(_doctcodModel.DescriptiontemplatesTreatments, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabDescriptiontemplatesTreatments(object item)
        {
            DGUIGHFData.Update<descriptiontemplatestreatments, DoctcoDModel>(_doctcodModel.DescriptiontemplatesTreatments, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabDescriptiontemplatesTreatments(object item)
        {
            DGUIGHFData.Remove<descriptiontemplatestreatments, DoctcoDModel>(_doctcodModel.DescriptiontemplatesTreatments, item);
        }

        #endregion

    }
}
