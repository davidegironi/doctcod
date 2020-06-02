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
    public partial class FormAddressesTypes : DGUIGHFForm
    {
        private DoctcoDModel _doctcodModel = null;

        private TabElement tabElement_tabAddressesTypes = new TabElement();

        /// <summary>
        /// Constructor
        /// </summary>
        public FormAddressesTypes()
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
            LanguageHelper.AddComponent(addressestypesidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(nameDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            //tabAddressesTypes
            LanguageHelper.AddComponent(tabPage_tabAddressesTypes);
            LanguageHelper.AddComponent(button_tabAddressesTypes_new);
            LanguageHelper.AddComponent(button_tabAddressesTypes_edit);
            LanguageHelper.AddComponent(button_tabAddressesTypes_delete);
            LanguageHelper.AddComponent(button_tabAddressesTypes_save);
            LanguageHelper.AddComponent(button_tabAddressesTypes_cancel);
            LanguageHelper.AddComponent(addressestypes_idLabel);
            LanguageHelper.AddComponent(addressestypes_nameLabel);
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
            BindingSourceMain = vAddressesTypesBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = panel_filters;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabAddressesTypes
            tabElement_tabAddressesTypes = new TabElement()
            {
                TabPageElement = tabPage_tabAddressesTypes,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabAddressesTypes_data,
                    PanelActions = panel_tabAddressesTypes_actions,
                    PanelUpdates = panel_tabAddressesTypes_updates,

                    ParentBindingSourceList = vAddressesTypesBindingSource,
                    GetParentDataSourceList = GetDataSource_main,

                    BindingSourceEdit = addressestypesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabAddressesTypes,
                    AfterSaveAction = AfterSaveAction_tabAddressesTypes,

                    AddButton = button_tabAddressesTypes_new,
                    UpdateButton = button_tabAddressesTypes_edit,
                    RemoveButton = button_tabAddressesTypes_delete,
                    SaveButton = button_tabAddressesTypes_save,
                    CancelButton = button_tabAddressesTypes_cancel,

                    Add = Add_tabAddressesTypes,
                    Update = Update_tabAddressesTypes,
                    Remove = Remove_tabAddressesTypes
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabAddressesTypes);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAddressesTypes_Load(object sender, EventArgs e)
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
            IEnumerable<VAddressesTypes> vAddressesTypes =
                _doctcodModel.AddressesTypes.List().Select(
                r => new VAddressesTypes
                {
                    addressestypes_id = r.addressestypes_id,
                    name = r.addressestypes_name
                }).ToList();

            return DGDataTableUtils.ToDataTable<VAddressesTypes>(vAddressesTypes);
        }


        #region tabAddressesTypes

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabAddressesTypes()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<addressestypes, DoctcoDModel>(_doctcodModel.AddressesTypes, vAddressesTypesBindingSource, new string[] { "addressestypes_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabAddressesTypes(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<addressestypes, DoctcoDModel>(_doctcodModel.AddressesTypes, item, vAddressesTypesBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabAddressesTypes(object item)
        {
            DGUIGHFData.Add<addressestypes, DoctcoDModel>(_doctcodModel.AddressesTypes, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabAddressesTypes(object item)
        {
            DGUIGHFData.Update<addressestypes, DoctcoDModel>(_doctcodModel.AddressesTypes, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabAddressesTypes(object item)
        {
            DGUIGHFData.Remove<addressestypes, DoctcoDModel>(_doctcodModel.AddressesTypes, item);
        }

        #endregion

    }
}
