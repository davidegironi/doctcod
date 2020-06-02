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
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Zuby.ADGV;

namespace DG.DoctcoD.Forms
{
    public partial class FormRooms : DGUIGHFForm
    {
        private DoctcoDModel _doctcodModel = null;

        private TabElement tabElement_tabRooms = new TabElement();

        /// <summary>
        /// Constructor
        /// </summary>
        public FormRooms()
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
            LanguageHelper.AddComponent(roomsidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(nameDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            //tabRooms
            LanguageHelper.AddComponent(tabPage_tabRooms);
            LanguageHelper.AddComponent(button_tabRooms_new);
            LanguageHelper.AddComponent(button_tabRooms_edit);
            LanguageHelper.AddComponent(button_tabRooms_delete);
            LanguageHelper.AddComponent(button_tabRooms_save);
            LanguageHelper.AddComponent(button_tabRooms_cancel);
            LanguageHelper.AddComponent(rooms_idLabel);
            LanguageHelper.AddComponent(rooms_nameLabel);
            LanguageHelper.AddComponent(rooms_colorLabel);
            LanguageHelper.AddComponent(button_tabRooms_colorselect);
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
            BindingSourceMain = vRoomsBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = panel_filters;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabRooms
            tabElement_tabRooms = new TabElement()
            {
                TabPageElement = tabPage_tabRooms,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabRooms_data,
                    PanelActions = panel_tabRooms_actions,
                    PanelUpdates = panel_tabRooms_updates,

                    ParentBindingSourceList = vRoomsBindingSource,
                    GetParentDataSourceList = GetDataSource_main,

                    BindingSourceEdit = roomsBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabRooms,
                    AfterSaveAction = AfterSaveAction_tabRooms,

                    AddButton = button_tabRooms_new,
                    UpdateButton = button_tabRooms_edit,
                    RemoveButton = button_tabRooms_delete,
                    SaveButton = button_tabRooms_save,
                    CancelButton = button_tabRooms_cancel,

                    Add = Add_tabRooms,
                    Update = Update_tabRooms,
                    Remove = Remove_tabRooms
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabRooms);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormRooms_Load(object sender, EventArgs e)
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
            IEnumerable<VRooms> vRooms =
                _doctcodModel.Rooms.List().Select(
                r => new VRooms
                {
                    rooms_id = r.rooms_id,
                    name = r.rooms_name
                }).ToList();

            return DGDataTableUtils.ToDataTable<VRooms>(vRooms);
        }


        #region tabRooms

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabRooms()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<rooms, DoctcoDModel>(_doctcodModel.Rooms, vRoomsBindingSource, new string[] { "rooms_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabRooms(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<rooms, DoctcoDModel>(_doctcodModel.Rooms, item, vRoomsBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabRooms(object item)
        {
            if (String.IsNullOrEmpty(((rooms)item).rooms_color))
                ((rooms)item).rooms_color = null;

            DGUIGHFData.Add<rooms, DoctcoDModel>(_doctcodModel.Rooms, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabRooms(object item)
        {
            if (String.IsNullOrEmpty(((rooms)item).rooms_color))
                ((rooms)item).rooms_color = null;

            DGUIGHFData.Update<rooms, DoctcoDModel>(_doctcodModel.Rooms, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabRooms(object item)
        {
            DGUIGHFData.Remove<rooms, DoctcoDModel>(_doctcodModel.Rooms, item);
        }

        /// <summary>
        /// Color text changed handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rooms_colorTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(rooms_colorTextBox.Text))
            {
                try
                {
                    rooms_colorTextBox.BackColor = ColorTranslator.FromHtml(rooms_colorTextBox.Text);
                }
                catch
                {
                    rooms_colorTextBox.BackColor = Color.Empty;
                }
            }
            else
            {
                rooms_colorTextBox.BackColor = Color.Empty;
            }
        }

        /// <summary>
        /// Select color handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabRooms_colorselect_Click(object sender, EventArgs e)
        {
            if (tabElement_tabRooms.CurrentEditingMode == EditingMode.C || tabElement_tabRooms.CurrentEditingMode == EditingMode.U)
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ((rooms)roomsBindingSource.Current).rooms_color = "#" + colorDialog.Color.R.ToString("X2") + colorDialog.Color.G.ToString("X2") + colorDialog.Color.B.ToString("X2");
                        roomsBindingSource.ResetBindings(true);
                    }
                    catch { }
                }
            }
        }

        #endregion

    }
}
