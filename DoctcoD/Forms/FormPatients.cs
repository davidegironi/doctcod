#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.Data.Model.Helpers;
using DG.DoctcoD.Forms.Objects;
using DG.DoctcoD.Helpers;
using DG.DoctcoD.Model;
using DG.DoctcoD.Model.Entity;
using DG.DoctcoD.Model.Repositories;
using DG.UI.GHF;
using SMcMaster;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using Zuby.ADGV;

namespace DG.DoctcoD.Forms
{
    public partial class FormPatients : DGUIGHFForm
    {
        private DoctcoDModel _doctcodModel = null;

        private TabElement tabElement_tabPatients = new TabElement();
        private TabElement tabElement_tabPatients_tabPatients = new TabElement();
        private TabElement tabElement_tabPatients_tabPatientsAddresses = new TabElement();
        private TabElement tabElement_tabPatients_tabPatientsContacts = new TabElement();
        private TabElement tabElement_tabPatientsMedicalrecords = new TabElement();
        private TabElement tabElement_tabPatientsTreatments = new TabElement();
        private TabElement tabElement_tabPayments = new TabElement();
        private TabElement tabElement_tabAppointments = new TabElement();
        private TabElement tabElement_tabPatientsAttachments = new TabElement();
        private TabElement tabElement_tabInvoices = new TabElement();
        private TabElement tabElement_tabEstimates = new TabElement();
        private TabElement tabElement_tabPatientsNotes = new TabElement();
        private TabElement tabElement_tabPatientsAttributes = new TabElement();

        private readonly BoxLoader _boxLoader = null;

        private const int MaxRowValueLength = 60;

        private const string ExplorerBinary = "explorer.exe";

        private enum FilterShow { NotArchived, Archived, All };

        private readonly string _patientsDatadir = "";
        private readonly string _patientsAttachmentsdir = "";
        private readonly bool _doSecureDelete = false;
        private readonly bool _resetPatientstreatmentsFilterOnChange = false;
        private readonly bool _resetPatientstreatmentsFilterOnSave = false;
        private readonly bool _patientsAttachmentsSaveandedit = true;

        private enum PatientsFilter { All, NotArchived, Archived };
        private readonly PatientsFilter _patientsFilter = PatientsFilter.NotArchived;

        private enum PaymentsReference { Nothing, Treatments, Invoices };
        private readonly PaymentsReference _paymentsReference = PaymentsReference.Treatments;

        private enum AttachmentsOpenMode { Application, Folder };
        private readonly AttachmentsOpenMode _attachmentsOpenMode = AttachmentsOpenMode.Folder;

        private enum PatientsTreatmentsFulfilledFilter { All, NotFulfilled, Fulfilled };
        private readonly PatientsTreatmentsFulfilledFilter _patientsTreatmentsFulfilledFilter = PatientsTreatmentsFulfilledFilter.All;

        private enum PatientsTreatmentsPaidFilter { All, NotPaid, Paid };
        private readonly PatientsTreatmentsPaidFilter _patientsTreatmentsPaidFilter = PatientsTreatmentsPaidFilter.All;

        public int invoices_id_toload = -1;
        public int estimates_id_toload = -1;

        private bool _loadPatientsTreatmentsFilter = true;

        /// <summary>
        /// Constructor
        /// </summary>
        public FormPatients()
        {
            InitializeComponent();
            (new TabOrderManager(this)).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);

            Initialize(Program.uighfApplication);

            _doctcodModel = new DoctcoDModel();
            _doctcodModel.LanguageHelper.LoadFromFile(Program.uighfApplication.LanguageFilename);

            _boxLoader = new BoxLoader(_doctcodModel);

            _patientsDatadir = ConfigurationManager.AppSettings["patientsDatadir"];
            _patientsAttachmentsdir = ConfigurationManager.AppSettings["patientsAttachmentsdir"];
            _doSecureDelete = Convert.ToBoolean(ConfigurationManager.AppSettings["doSecureDelete"]);
            if (ConfigurationManager.AppSettings["paymentReference"] == "N")
                _paymentsReference = PaymentsReference.Nothing;
            else if (ConfigurationManager.AppSettings["paymentReference"] == "T")
                _paymentsReference = PaymentsReference.Treatments;
            else if (ConfigurationManager.AppSettings["paymentReference"] == "I")
                _paymentsReference = PaymentsReference.Invoices;
            _resetPatientstreatmentsFilterOnChange = Convert.ToBoolean(ConfigurationManager.AppSettings["resetPatientstreatmentsFilterOnChange"]);
            _resetPatientstreatmentsFilterOnSave = Convert.ToBoolean(ConfigurationManager.AppSettings["resetPatientstreatmentsFilterOnSave"]);
            if (ConfigurationManager.AppSettings["patientsDefaultFilter"] == "A")
                _patientsFilter = PatientsFilter.All;
            else if (ConfigurationManager.AppSettings["patientsDefaultFilter"] == "N")
                _patientsFilter = PatientsFilter.NotArchived;
            else if (ConfigurationManager.AppSettings["patientsDefaultFilter"] == "C")
                _patientsFilter = PatientsFilter.Archived;
            if (ConfigurationManager.AppSettings["patientsAttachmentsOpenMode"] == "A")
                _attachmentsOpenMode = AttachmentsOpenMode.Application;
            else if (ConfigurationManager.AppSettings["patientsAttachmentsOpenMode"] == "F")
                _attachmentsOpenMode = AttachmentsOpenMode.Folder;
            _patientsAttachmentsSaveandedit = Convert.ToBoolean(ConfigurationManager.AppSettings["patientsAttachmentsSaveandedit"]);

            if (_paymentsReference == PaymentsReference.Nothing)
            {
                label_tabPayments_inforeference.Text = "";
                label_tabPayments_total.Text = "";
                label_tabPayments_lefttotal.Text = "";
                label_tabPayments_inforeference.Visible = false;
                label_tabPayments_total.Visible = false;
                label_tabPayments_lefttotal.Visible = false;
                label_tabPayments_totalvalue.Visible = false;
                label_tabPayments_lefttotalvalue.Visible = false;
            }
            else if (_paymentsReference == PaymentsReference.Treatments)
            {
                label_tabPayments_inforeference.Text = language.paymentsInfoReferenceLabelTreatments;
                label_tabPayments_total.Text = language.paymentsTotalLabelTreatments;
                label_tabPayments_lefttotal.Text = language.paymentsLeftTotalLabelTreatments;
            }
            else if (_paymentsReference == PaymentsReference.Invoices)
            {
                label_tabPayments_inforeference.Text = language.paymentsInfoReferenceLabelInvoices;
                label_tabPayments_total.Text = language.paymentsTotalLabelInvoices;
                label_tabPayments_lefttotal.Text = language.paymentsLeftTotalLabelInvoices;
            }
        }

        /// <summary>
        /// Add components language
        /// </summary>
        public override void AddLanguageComponents()
        {
            //main
            LanguageHelper.AddComponent(this);
            LanguageHelper.AddComponent(patientsidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(nameDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(isarchivedDataGridViewCheckBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(label_filterShow);
            LanguageHelper.AddComponent(countLabel);
            //tabPatients
            LanguageHelper.AddComponent(tabPage_tabPatients);
            //tabPatients_tabPatients
            LanguageHelper.AddComponent(tabPage_tabPatients_tabPatients);
            LanguageHelper.AddComponent(button_tabPatients_tabPatients_new);
            LanguageHelper.AddComponent(button_tabPatients_tabPatients_edit);
            LanguageHelper.AddComponent(button_tabPatients_tabPatients_delete);
            LanguageHelper.AddComponent(button_tabPatients_tabPatients_save);
            LanguageHelper.AddComponent(button_tabPatients_tabPatients_cancel);
            LanguageHelper.AddComponent(button_tabPatients_tabPatients_datadir);
            LanguageHelper.AddComponent(patients_idLabel);
            LanguageHelper.AddComponent(patients_nameLabel);
            LanguageHelper.AddComponent(patients_surnameLabel);
            LanguageHelper.AddComponent(patients_sexLabel);
            LanguageHelper.AddComponent(patients_birthdateLabel);
            LanguageHelper.AddComponent(patients_birthcityLabel);
            LanguageHelper.AddComponent(patients_notesLabel);
            LanguageHelper.AddComponent(treatmentspriceslists_idLabel);
            LanguageHelper.AddComponent(patients_doctextLabel);
            LanguageHelper.AddComponent(patients_isarchivedCheckBox);
            LanguageHelper.AddComponent(patients_sexMRadioButton);
            LanguageHelper.AddComponent(patients_sexFRadioButton);
            LanguageHelper.AddComponent(button_tabPatients_tabPatients_priceslistsreset);
            LanguageHelper.AddComponent(patients_usernameLabel);
            LanguageHelper.AddComponent(patients_passwordLabel);
            LanguageHelper.AddComponent(patients_lastloginLabel);
            LanguageHelper.AddComponent(button_tabPatients_tabPatients_resetusernamepassword);
            //tabPatients_tabPatientsContacts
            LanguageHelper.AddComponent(tabPage_tabPatients_tabPatientsContacts);
            LanguageHelper.AddComponent(patientscontactsidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(contactstypeDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(contactDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(button_tabPatients_tabPatientsContacts_new);
            LanguageHelper.AddComponent(button_tabPatients_tabPatientsContacts_edit);
            LanguageHelper.AddComponent(button_tabPatients_tabPatientsContacts_delete);
            LanguageHelper.AddComponent(button_tabPatients_tabPatientsContacts_save);
            LanguageHelper.AddComponent(button_tabPatients_tabPatientsContacts_cancel);
            LanguageHelper.AddComponent(patientscontacts_idLabel);
            LanguageHelper.AddComponent(contactstypes_idLabel);
            LanguageHelper.AddComponent(patientscontacts_valueLabel);
            LanguageHelper.AddComponent(patientscontacts_noteLabel);
            //tabPatients_tabPatientsAddresses
            LanguageHelper.AddComponent(tabPage_tabPatients_tabPatientsAddresses);
            LanguageHelper.AddComponent(patientsaddressesidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(addresstypeDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(addressDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(button_tabPatients_tabPatientsAddresses_new);
            LanguageHelper.AddComponent(button_tabPatients_tabPatientsAddresses_edit);
            LanguageHelper.AddComponent(button_tabPatients_tabPatientsAddresses_delete);
            LanguageHelper.AddComponent(button_tabPatients_tabPatientsAddresses_save);
            LanguageHelper.AddComponent(button_tabPatients_tabPatientsAddresses_cancel);
            LanguageHelper.AddComponent(patientsaddresses_idLabel);
            LanguageHelper.AddComponent(addressestypes_idLabel);
            LanguageHelper.AddComponent(patientsaddresses_stateLabel);
            LanguageHelper.AddComponent(patientsaddresses_cityLabel);
            LanguageHelper.AddComponent(patientsaddresses_zipcodeLabel);
            LanguageHelper.AddComponent(patientsaddresses_streetLabel);
            //tabPatientsMedicalrecords
            LanguageHelper.AddComponent(tabPage_tabPatientsMedicalrecords);
            LanguageHelper.AddComponent(patientsmedicalrecordsidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(medicalrecordstypeDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(valueDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(button_tabPatientsMedicalrecords_new);
            LanguageHelper.AddComponent(button_tabPatientsMedicalrecords_edit);
            LanguageHelper.AddComponent(button_tabPatientsMedicalrecords_delete);
            LanguageHelper.AddComponent(button_tabPatientsMedicalrecords_save);
            LanguageHelper.AddComponent(button_tabPatientsMedicalrecords_cancel);
            LanguageHelper.AddComponent(patientsmedicalrecords_idLabel);
            LanguageHelper.AddComponent(medicalrecordstypes_idLabel);
            LanguageHelper.AddComponent(patientsmedicalrecords_valueLabel);
            LanguageHelper.AddComponent(patientsmedicalrecords_noteLabel);
            //tabPatientsTreatments
            LanguageHelper.AddComponent(tabPage_tabPatientsTreatments);
            LanguageHelper.AddComponent(label_tabPatientsTreatments_filterfulfilled);
            LanguageHelper.AddComponent(label_tabPatientsTreatments_filterpaid);
            LanguageHelper.AddComponent(button_tabPatientsTreatments_filterprint);
            LanguageHelper.AddComponent(dateDataGridViewTextBoxColumn1, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(treatmentDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(isfulfilledDataGridViewCheckBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(ispaidDataGridViewCheckBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(button_tabPatientsTreatments_new);
            LanguageHelper.AddComponent(button_tabPatientsTreatments_edit);
            LanguageHelper.AddComponent(button_tabPatientsTreatments_delete);
            LanguageHelper.AddComponent(button_tabPatientsTreatments_save);
            LanguageHelper.AddComponent(button_tabPatientsTreatments_cancel);
            LanguageHelper.AddComponent(button_tabPatientsTreatments_setfulfilled);
            LanguageHelper.AddComponent(button_tabPatientsTreatments_setpaid);
            LanguageHelper.AddComponent(patientstreatments_idLabel);
            LanguageHelper.AddComponent(patientstreatments_creationdateLabel);
            LanguageHelper.AddComponent(patientstreatments_expirationdateLabel);
            LanguageHelper.AddComponent(patientstreatments_fulfilldateLabel);
            LanguageHelper.AddComponent(patientstreatments_invoiceLabel);
            LanguageHelper.AddComponent(doctors_idLabel1);
            LanguageHelper.AddComponent(treatments_idLabel);
            LanguageHelper.AddComponent(patientstreatments_priceLabel);
            LanguageHelper.AddComponent(patientstreatments_taxrateLabel);
            LanguageHelper.AddComponent(patientstreatments_descriptionLabel);
            LanguageHelper.AddComponent(patientstreatments_notesLabel);
            LanguageHelper.AddComponent(patientstreatments_ispaidCheckBox);
            LanguageHelper.AddComponent(descriptiontemplatestreatments_idLabel);
            //tabPayments
            LanguageHelper.AddComponent(tabPage_tabPayments);
            LanguageHelper.AddComponent(paymentsidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(dateDataGridViewTextBoxColumn2, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(noteDataGridViewTextBoxColumn1, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(amountDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(label_tabPayments_paidtotal);
            LanguageHelper.AddComponent(label_tabPayments_total);
            LanguageHelper.AddComponent(label_tabPayments_lefttotal);
            LanguageHelper.AddComponent(button_tabPayments_new);
            LanguageHelper.AddComponent(button_tabPayments_edit);
            LanguageHelper.AddComponent(button_tabPayments_delete);
            LanguageHelper.AddComponent(button_tabPayments_save);
            LanguageHelper.AddComponent(button_tabPayments_cancel);
            LanguageHelper.AddComponent(payments_idLabel);
            LanguageHelper.AddComponent(payments_dateLabel);
            LanguageHelper.AddComponent(payments_amountLabel);
            LanguageHelper.AddComponent(label_tabPayments_inforeference);
            LanguageHelper.AddComponent(payments_notesLabel);
            //tabAppointments
            LanguageHelper.AddComponent(tabPage_tabAppointments);
            LanguageHelper.AddComponent(appointmentsidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(fromdayDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(fromDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(toDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(titleDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(appointments_idLabel);
            LanguageHelper.AddComponent(rooms_idLabel);
            LanguageHelper.AddComponent(doctors_idLabel);
            LanguageHelper.AddComponent(appointments_titleLabel);
            LanguageHelper.AddComponent(appointments_notesLabel);
            //tabPatientsAttachments
            LanguageHelper.AddComponent(tabPage_tabPatientsAttachments);
            LanguageHelper.AddComponent(patientsattachmentsidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(attachmentstypeDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(dateDataGridViewTextBoxColumn5, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(attachmentDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(button_tabPatientsAttachments_new);
            LanguageHelper.AddComponent(button_tabPatientsAttachments_edit);
            LanguageHelper.AddComponent(button_tabPatientsAttachments_delete);
            LanguageHelper.AddComponent(button_tabPatientsAttachments_save);
            LanguageHelper.AddComponent(button_tabPatientsAttachments_cancel);
            LanguageHelper.AddComponent(button_tabPatientsAttachments_filepathopenfolder);
            LanguageHelper.AddComponent(patientsattachments_idLabel);
            LanguageHelper.AddComponent(patientsattachments_dateLabel);
            LanguageHelper.AddComponent(patientsattachmentstypes_idLabel);
            LanguageHelper.AddComponent(patientsattachments_valueLabel);
            LanguageHelper.AddComponent(patientsattachments_filenameLabel);
            LanguageHelper.AddComponent(patientsattachments_noteLabel);
            LanguageHelper.AddComponent(button_tabPatientsAttachments_filepathselect);
            LanguageHelper.AddComponent(button_tabPatientsAttachments_filepathdelete);
            //tabInvoices
            LanguageHelper.AddComponent(tabPage_tabInvoices);
            LanguageHelper.AddComponent(numberDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(dateDataGridViewTextBoxColumn3, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(doctorDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(ispaidDataGridViewCheckBoxColumn1, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(totalDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(label_tabInvoices_paidtotaldue);
            LanguageHelper.AddComponent(label_tabInvoices_invoicestotaldue);
            LanguageHelper.AddComponent(label_tabInvoices_invoiceslefttotaldue);
            LanguageHelper.AddComponent(button_tabInvoices_view);
            //tabEstimates
            LanguageHelper.AddComponent(tabPage_tabEstimates);
            LanguageHelper.AddComponent(numberDataGridViewTextBoxColumn1, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(dateDataGridViewTextBoxColumn4, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(doctorDataGridViewTextBoxColumn1, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(isinvoicedDataGridViewCheckBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(totalDataGridViewTextBoxColumn1, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(label_tabEstimates_invoicedtotaldue);
            LanguageHelper.AddComponent(label_tabEstimates_estimatestotaldue);
            LanguageHelper.AddComponent(label_tabEstimates_estimateslefttotaldue);
            LanguageHelper.AddComponent(button_tabEstimates_view);
            //tabPatientsNotes
            LanguageHelper.AddComponent(tabPage_tabPatientsNotes);
            LanguageHelper.AddComponent(patientsnotesidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(dateDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(noteDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(button_tabPatientsNotes_new);
            LanguageHelper.AddComponent(button_tabPatientsNotes_edit);
            LanguageHelper.AddComponent(button_tabPatientsNotes_delete);
            LanguageHelper.AddComponent(button_tabPatientsNotes_save);
            LanguageHelper.AddComponent(button_tabPatientsNotes_cancel);
            LanguageHelper.AddComponent(patientsnotes_idLabel);
            LanguageHelper.AddComponent(patientsnotes_dateLabel);
            LanguageHelper.AddComponent(patientsnotes_textLabel);
            //tabPatientsAttributes
            LanguageHelper.AddComponent(tabPage_tabPatientsAttributes);
            LanguageHelper.AddComponent(patientsattributesidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(attributestypeDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(valueDataGridViewTextBoxColumn1, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(button_tabPatientsAttributes_new);
            LanguageHelper.AddComponent(button_tabPatientsAttributes_edit);
            LanguageHelper.AddComponent(button_tabPatientsAttributes_delete);
            LanguageHelper.AddComponent(button_tabPatientsAttributes_save);
            LanguageHelper.AddComponent(button_tabPatientsAttributes_cancel);
            LanguageHelper.AddComponent(patientsattributes_idLabel);
            LanguageHelper.AddComponent(patientsattributestypes_idLabel);
            LanguageHelper.AddComponent(patientsattributes_valueLabel);
            LanguageHelper.AddComponent(patientsattributes_noteLabel);
        }

        /// <summary>
        /// Form language dictionary
        /// </summary>
        public class FormLanguage : IDGUIGHFLanguage
        {
            public string filtershowAll = "All";
            public string filtershowNotarchived = "Not Archived";
            public string filtershowArchived = "Archived";
            public string filedeleteerrorMessage = "Error deleting file from folder.";
            public string filedeleteerrorTitle = "Error";
            public string folderdeleteerrorMessage = "Can not remove folder '{0}'.";
            public string folderdeleteerrorTitle = "Error";
            public string foldercreateerrorMessage = "Can not create folder '{0}'.";
            public string foldercreateerrorTitle = "Error";
            public string attachmentselectTitle = "Select a file";
            public string attachmentcopyerrorMessage = "Error copying file to folder.";
            public string attachmentcopyerrorTitle = "Error";
            public string paymentsInfoReferenceLabelTreatments = "Payments above are referred to patient treatments total.";
            public string paymentsInfoReferenceLabelInvoices = "Payments above are referred to patient invoices due.";
            public string paymentsTotalLabelTreatments = "Treatments total:";
            public string paymentsLeftTotalLabelTreatments = "Treatments to be paid:";
            public string paymentsTotalLabelInvoices = "Invoices total:";
            public string paymentsLeftTotalLabelInvoices = "Invoices to be paid:";
            public string patientstreatmentsfilterfulfilledAll = "All";
            public string patientstreatmentsfilterfulfilledN = "Not fullfilled";
            public string patientstreatmentsfilterfulfilledY = "Fullfilled";
            public string patientstreatmentsfilterpaidAll = "All";
            public string patientstreatmentsfilterpaidN = "Not paid";
            public string patientstreatmentsfilterpaidY = "Paid";
            public string descriptiontemplatestreatmentsTitle = "Select template";
            public string printmodelerrorMessage = "Can not instantiate the print model.";
            public string printmodelerrorTitle = "Error";
            public string printmodelerrorNone = "No print model available";
            public string printmodelselectMessage = "Select a print template:";
            public string printmodelselectTitle = "Print template";
            public string printcreatefoldererrorMessage = "Can not create destination folder '{0}'.";
            public string printcreatefoldererrorTitle = "Error";
            public string printvalidfilenameerrorMessage = "Can not found a valid filename.";
            public string printvalidfilenameerrorTitle = "Error";
            public string printoverwritefilenamewarningMessage = "The file '{0}' already exists, press 'Yes' to overwrite it, 'No' to open that file, 'Cancel' to exit.";
            public string printoverwritefilenamewarningTitle = "Warning";
            public string printbuildpdferrorMessage = "Can not build the PDF file '{0}'.";
            public string printbuildpdferrorTitle = "Error";
            public string printopenfilenameMessage = "File '{0}' built successful.";
            public string printopenfilenameTitle = "Info";
        }

        /// <summary>
        /// Form language
        /// </summary>
        public FormLanguage language = new FormLanguage();

        /// <summary>
        /// Initialize TabElements
        /// </summary>
        protected override void InitializeTabElements()
        {
            //set Readonly OnSetEditingMode for Controls
            DisableReadonlyCheckOnSetEditingModeControlCollection.Add(typeof(DataGridView));
            DisableReadonlyCheckOnSetEditingModeControlCollection.Add(typeof(AdvancedDataGridView));

            //set Main BindingSource
            BindingSourceMain = vPatientsBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = panel_filters;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabPatients_tabPatients
            tabElement_tabPatients_tabPatients = new TabElement()
            {
                TabPageElement = tabPage_tabPatients_tabPatients,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabPatients_tabPatients_data,
                    PanelActions = panel_tabPatients_tabPatients_actions,
                    PanelUpdates = panel_tabPatients_tabPatients_updates,

                    ParentBindingSourceList = vPatientsBindingSource,
                    GetParentDataSourceList = GetDataSource_main,

                    BindingSourceEdit = patientsBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabPatients,
                    AfterSaveAction = AfterSaveAction_tabPatients,

                    AddButton = button_tabPatients_tabPatients_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabPatients_tabPatients_edit,
                    IsUpdateButtonDefaultClickEventAttached = false,
                    RemoveButton = button_tabPatients_tabPatients_delete,
                    SaveButton = button_tabPatients_tabPatients_save,
                    CancelButton = button_tabPatients_tabPatients_cancel,

                    Add = Add_tabPatients,
                    Update = Update_tabPatients,
                    Remove = Remove_tabPatients
                }
            };

            //set tabPatients_tabPatientsContacts
            tabElement_tabPatients_tabPatientsContacts = new TabElement()
            {
                TabPageElement = tabPage_tabPatients_tabPatientsContacts,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = null,
                    PanelList = panel_tabPatients_tabPatientsContacts_list,

                    PanelData = panel_tabPatients_tabPatientsContacts_data,
                    PanelActions = panel_tabPatients_tabPatientsContacts_actions,
                    PanelUpdates = panel_tabPatients_tabPatientsContacts_updates,

                    BindingSourceList = vPatientsContactsBindingSource,
                    GetDataSourceList = GetDataSourceList_tabPatients_tabPatientsContacts,

                    BindingSourceEdit = patientscontactsBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabPatients_tabPatientsContacts,
                    AfterSaveAction = AfterSaveAction_tabPatients_tabPatientsContacts,

                    AddButton = button_tabPatients_tabPatientsContacts_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabPatients_tabPatientsContacts_edit,
                    RemoveButton = button_tabPatients_tabPatientsContacts_delete,
                    SaveButton = button_tabPatients_tabPatientsContacts_save,
                    CancelButton = button_tabPatients_tabPatientsContacts_cancel,

                    Add = Add_tabPatients_tabPatientsContacts,
                    Update = Update_tabPatients_tabPatientsContacts,
                    Remove = Remove_tabPatients_tabPatientsContacts
                }
            };

            //set tabPatients_tabPatientsAddresses
            tabElement_tabPatients_tabPatientsAddresses = new TabElement()
            {
                TabPageElement = tabPage_tabPatients_tabPatientsAddresses,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = null,
                    PanelList = panel_tabPatients_tabPatientsAddresses_list,

                    PanelData = panel_tabPatients_tabPatientsAddresses_data,
                    PanelActions = panel_tabPatients_tabPatientsAddresses_actions,
                    PanelUpdates = panel_tabPatients_tabPatientsAddresses_updates,

                    BindingSourceList = vPatientsAddressesBindingSource,
                    GetDataSourceList = GetDataSourceList_tabPatients_tabPatientsAddresses,

                    BindingSourceEdit = patientsaddressesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabPatients_tabPatientsAddresses,
                    AfterSaveAction = AfterSaveAction_tabPatients_tabPatientsAddresses,

                    AddButton = button_tabPatients_tabPatientsAddresses_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabPatients_tabPatientsAddresses_edit,
                    RemoveButton = button_tabPatients_tabPatientsAddresses_delete,
                    SaveButton = button_tabPatients_tabPatientsAddresses_save,
                    CancelButton = button_tabPatients_tabPatientsAddresses_cancel,

                    Add = Add_tabPatients_tabPatientsAddresses,
                    Update = Update_tabPatients_tabPatientsAddresses,
                    Remove = Remove_tabPatients_tabPatientsAddresses
                }
            };

            //set tabPatientsMedicalrecords
            tabElement_tabPatientsMedicalrecords = new TabElement()
            {
                TabPageElement = tabPage_tabPatientsMedicalrecords,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = null,
                    PanelList = panel_tabPatientsMedicalrecords_list,

                    PanelData = panel_tabPatientsMedicalrecords_data,
                    PanelActions = panel_tabPatientsMedicalrecords_actions,
                    PanelUpdates = panel_tabPatientsMedicalrecords_updates,

                    BindingSourceList = vPatientsMedicalrecordsBindingSource,
                    GetDataSourceList = GetDataSourceList_tabPatientsMedicalrecords,

                    BindingSourceEdit = patientsmedicalrecordsBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabPatientsMedicalrecords,
                    AfterSaveAction = AfterSaveAction_tabPatientsMedicalrecords,

                    AddButton = button_tabPatientsMedicalrecords_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabPatientsMedicalrecords_edit,
                    RemoveButton = button_tabPatientsMedicalrecords_delete,
                    SaveButton = button_tabPatientsMedicalrecords_save,
                    CancelButton = button_tabPatientsMedicalrecords_cancel,

                    Add = Add_tabPatientsMedicalrecords,
                    Update = Update_tabPatientsMedicalrecords,
                    Remove = Remove_tabPatientsMedicalrecords
                }
            };

            //set tabPatientsTreatments
            tabElement_tabPatientsTreatments = new TabElement()
            {
                TabPageElement = tabPage_tabPatientsTreatments,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = panel_tabPatientsTreatments_filters,
                    PanelList = panel_tabPatientsTreatments_list,

                    PanelData = panel_tabPatientsTreatments_data,
                    PanelActions = panel_tabPatientsTreatments_actions,
                    PanelUpdates = panel_tabPatientsTreatments_updates,

                    BindingSourceList = vPatientsTreatmentsBindingSource,
                    GetDataSourceList = GetDataSourceList_tabPatientsTreatments,

                    BindingSourceEdit = patientstreatmentsBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabPatientsTreatments,
                    AfterSaveAction = AfterSaveAction_tabPatientsTreatments,

                    AddButton = button_tabPatientsTreatments_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabPatientsTreatments_edit,
                    IsUpdateButtonDefaultClickEventAttached = false,
                    RemoveButton = button_tabPatientsTreatments_delete,
                    SaveButton = button_tabPatientsTreatments_save,
                    CancelButton = button_tabPatientsTreatments_cancel,

                    Add = Add_tabPatientsTreatments,
                    Update = Update_tabPatientsTreatments,
                    Remove = Remove_tabPatientsTreatments
                }
            };
            tabElement_tabPatientsTreatments.ElementListItem.BindingSourceListChanged += tabPatientsTreatments_BindingSourceListChanged;

            //set tabPayments
            tabElement_tabPayments = new TabElement()
            {
                TabPageElement = tabPage_tabPayments,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = null,
                    PanelList = panel_tabPayments_list,

                    PanelData = panel_tabPayments_data,
                    PanelActions = panel_tabPayments_actions,
                    PanelUpdates = panel_tabPayments_updates,

                    BindingSourceList = vPatientsPaymentsBindingSource,
                    GetDataSourceList = GetDataSourceList_tabPayments,

                    BindingSourceEdit = paymentsBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabPayments,
                    AfterSaveAction = AfterSaveAction_tabPayments,

                    AddButton = button_tabPayments_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabPayments_edit,
                    RemoveButton = button_tabPayments_delete,
                    SaveButton = button_tabPayments_save,
                    CancelButton = button_tabPayments_cancel,

                    Add = Add_tabPayments,
                    Update = Update_tabPayments,
                    Remove = Remove_tabPayments
                }
            };

            //set tabAppointments
            tabElement_tabAppointments = new TabElement()
            {
                TabPageElement = tabPage_tabAppointments,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = null,
                    PanelList = panel_tabAppointments_list,

                    PanelData = panel_tabAppointments_data,
                    PanelActions = null,
                    PanelUpdates = null,

                    BindingSourceList = vPatientsAppointmentsBindingSource,
                    GetDataSourceList = GetDataSourceList_tabAppointments,

                    BindingSourceEdit = appointmentsBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabAppointments,
                    AfterSaveAction = null,

                    AddButton = null,
                    UpdateButton = null,
                    RemoveButton = null,
                    SaveButton = null,
                    CancelButton = null,

                    Add = null,
                    Update = null,
                    Remove = null
                }
            };

            //set tabPatientsAttachments
            tabElement_tabPatientsAttachments = new TabElement()
            {
                TabPageElement = tabPage_tabPatientsAttachments,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = null,
                    PanelList = panel_tabPatientsAttachments_list,

                    PanelData = panel_tabPatientsAttachments_data,
                    PanelActions = panel_tabPatientsAttachments_actions,
                    PanelUpdates = panel_tabPatientsAttachments_updates,

                    BindingSourceList = vPatientsAttachmentsBindingSource,
                    GetDataSourceList = GetDataSourceList_tabPatientsAttachments,

                    BindingSourceEdit = patientsattachmentsBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabPatientsAttachments,
                    AfterSaveAction = AfterSaveAction_tabPatientsAttachments,

                    AddButton = button_tabPatientsAttachments_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabPatientsAttachments_edit,
                    IsUpdateButtonDefaultClickEventAttached = false,
                    RemoveButton = button_tabPatientsAttachments_delete,
                    SaveButton = button_tabPatientsAttachments_save,
                    CancelButton = button_tabPatientsAttachments_cancel,

                    Add = Add_tabPatientsAttachments,
                    Update = Update_tabPatientsAttachments,
                    Remove = Remove_tabPatientsAttachments
                }
            };

            //set tabInvoices
            tabElement_tabInvoices = new TabElement()
            {
                TabPageElement = tabPage_tabInvoices,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = null,
                    PanelList = panel_tabInvoices_list,

                    PanelData = null,
                    PanelActions = panel_tabInvoices_actions,
                    PanelUpdates = null,

                    BindingSourceList = vPatientsInvoicesBindingSource,
                    GetDataSourceList = GetDataSourceList_tabInvoices,

                    BindingSourceEdit = invoicesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabInvoices,
                    AfterSaveAction = null,

                    AddButton = null,
                    UpdateButton = null,
                    RemoveButton = null,
                    SaveButton = null,
                    CancelButton = null,

                    Add = null,
                    Update = null,
                    Remove = null
                }
            };

            //set tabEstimates
            tabElement_tabEstimates = new TabElement()
            {
                TabPageElement = tabPage_tabEstimates,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = null,
                    PanelList = panel_tabEstimates_list,

                    PanelData = null,
                    PanelActions = panel_tabEstimates_actions,
                    PanelUpdates = null,

                    BindingSourceList = vPatientsEstimatesBindingSource,
                    GetDataSourceList = GetDataSourceList_tabEstimates,

                    BindingSourceEdit = estimatesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabEstimates,
                    AfterSaveAction = null,

                    AddButton = null,
                    UpdateButton = null,
                    RemoveButton = null,
                    SaveButton = null,
                    CancelButton = null,

                    Add = null,
                    Update = null,
                    Remove = null
                }
            };

            //set tabPatientsNotes
            tabElement_tabPatientsNotes = new TabElement()
            {
                TabPageElement = tabPage_tabPatientsNotes,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = null,
                    PanelList = panel_tabPatientsNotes_list,

                    PanelData = panel_tabPatientsNotes_data,
                    PanelActions = panel_tabPatientsNotes_actions,
                    PanelUpdates = panel_tabPatientsNotes_updates,

                    BindingSourceList = vPatientsNotesBindingSource,
                    GetDataSourceList = GetDataSourceList_tabPatientsNotes,

                    BindingSourceEdit = patientsnotesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabPatientsNotes,
                    AfterSaveAction = AfterSaveAction_tabPatientsNotes,

                    AddButton = button_tabPatientsNotes_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabPatientsNotes_edit,
                    RemoveButton = button_tabPatientsNotes_delete,
                    SaveButton = button_tabPatientsNotes_save,
                    CancelButton = button_tabPatientsNotes_cancel,

                    Add = Add_tabPatientsNotes,
                    Update = Update_tabPatientsNotes,
                    Remove = Remove_tabPatientsNotes
                }
            };

            //set tabPatientsAttributes
            tabElement_tabPatientsAttributes = new TabElement()
            {
                TabPageElement = tabPage_tabPatientsAttributes,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = null,
                    PanelList = panel_tabPatientsAttributes_list,

                    PanelData = panel_tabPatientsAttributes_data,
                    PanelActions = panel_tabPatientsAttributes_actions,
                    PanelUpdates = panel_tabPatientsAttributes_updates,

                    BindingSourceList = vPatientsAttributesBindingSource,
                    GetDataSourceList = GetDataSourceList_tabPatientsAttributes,

                    BindingSourceEdit = patientsattributesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabPatientsAttributes,
                    AfterSaveAction = AfterSaveAction_tabPatientsAttributes,

                    AddButton = button_tabPatientsAttributes_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabPatientsAttributes_edit,
                    RemoveButton = button_tabPatientsAttributes_delete,
                    SaveButton = button_tabPatientsAttributes_save,
                    CancelButton = button_tabPatientsAttributes_cancel,

                    Add = Add_tabPatientsAttributes,
                    Update = Update_tabPatientsAttributes,
                    Remove = Remove_tabPatientsAttributes
                }
            };

            //set tabPatients
            tabElement_tabPatients = new TabElement()
            {
                TabPageElement = tabPage_tabPatients,
                ElementTabs = new TabElement.TabElementTabs()
                {
                    PanelData = panel_tabPatients_data,

                    TabControlElement = tabControl_tabPatients,
                    TabElements = new List<TabElement>()
                    {
                        tabElement_tabPatients_tabPatients,
                        tabElement_tabPatients_tabPatientsContacts,
                        tabElement_tabPatients_tabPatientsAddresses,
                    }
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabPatients);
            TabElements.Add(tabElement_tabPatientsMedicalrecords);
            TabElements.Add(tabElement_tabPatientsTreatments);
            TabElements.Add(tabElement_tabPayments);
            TabElements.Add(tabElement_tabAppointments);
            TabElements.Add(tabElement_tabPatientsAttachments);
            TabElements.Add(tabElement_tabInvoices);
            TabElements.Add(tabElement_tabEstimates);
            TabElements.Add(tabElement_tabPatientsNotes);
            TabElements.Add(tabElement_tabPatientsAttributes);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPatients_Load(object sender, EventArgs e)
        {
            IsBindingSourceLoading = true;
            advancedDataGridView_main.SortASC(advancedDataGridView_main.Columns[1]);
            IsBindingSourceLoading = false;

            PreloadView();

            //select a patient on load patient
            int patients_id = -1;
            patients patient = null;
            foreach (Form form in this.MdiParent.MdiChildren)
            {
                if (form.GetType() == typeof(FormAppointments))
                {
                    patients_id = ((FormAppointments)form).patients_id_toload;
                    ((FormAppointments)form).patients_id_toload = -1;
                }

                if (patients_id != -1)
                {
                    textBox_filterPatient.Text = "";
                    IsBindingSourceLoading = true;
                    patient = _doctcodModel.Patients.Find(patients_id);
                    if (patient != null)
                    {
                        comboBox_filterArchived.SelectedIndex = 0;
                    }
                    IsBindingSourceLoading = false;
                    break;
                }
            }

            ReloadView();

            vPatientsBindingSource_CurrentChanged(sender, e);

            //select a patient on load patient
            if (patient != null)
            {
                DGUIGHFData.SetBindingSourcePosition<patients, DoctcoDModel>(_doctcodModel.Patients, patient, vPatientsBindingSource);
                tabControl_main.SelectedTab = tabPage_tabPatients;
                tabControl_tabPatients.SelectedTab = tabPage_tabPatients_tabPatients;
            }
        }

        /// <summary>
        /// Preload View
        /// </summary>
        private void PreloadView()
        {
            IsBindingSourceLoading = true;

            _boxLoader.LoadComboBoxTreatmentsPricesLists(treatmentspriceslists_idComboBox);
            _boxLoader.LoadComboBoxContactsTypes(contactstypes_idComboBox);
            _boxLoader.LoadComboBoxAddressesTypes(addressestypes_idComboBox);
            _boxLoader.LoadComboBoxMedicalrecordsTypes(medicalrecordstypes_idComboBox);
            _boxLoader.LoadComboBoxPatientsAttachmentsTypes(patientsattachmentstypes_idComboBox);
            _boxLoader.LoadComboBoxPatientsAttributesTypes(patientsattributestypes_idComboBox);
            _boxLoader.LoadComboBoxRooms(rooms_idComboBox);
            _boxLoader.LoadComboBoxDoctors(doctors_idComboBox);
            _boxLoader.LoadComboBoxDoctors(doctors_idComboBox1);
            _boxLoader.LoadComboBoxTreatments(treatments_idComboBox);
            _boxLoader.LoadComboBoxDescriptiontemplatesTreatments(descriptiontemplatestreatments_idComboBox);

            //load doctors filter type
            comboBox_filterArchived.DataSource = (new[] {
                    new { name = language.filtershowAll, value = FilterShow.All.ToString() },
                    new { name = language.filtershowNotarchived, value = FilterShow.NotArchived.ToString() },
                    new { name = language.filtershowArchived, value = FilterShow.Archived.ToString() }
                }).ToArray();
            comboBox_filterArchived.DisplayMember = "name";
            comboBox_filterArchived.ValueMember = "value";
            comboBox_filterArchived.SelectedIndex = 0;
            if (_patientsFilter == PatientsFilter.All)
                comboBox_filterArchived.SelectedIndex = 0;
            else if (_patientsFilter == PatientsFilter.NotArchived)
                comboBox_filterArchived.SelectedIndex = 1;
            else if (_patientsFilter == PatientsFilter.Archived)
                comboBox_filterArchived.SelectedIndex = 2;

            //load patientstreatments filter fullfilled
            comboBox_tabPatientsTreatments_filterfulfilled.DataSource = (new[] {
                    new { name = language.patientstreatmentsfilterfulfilledAll, value = PatientsTreatmentsFulfilledFilter.All.ToString() },
                    new { name = language.patientstreatmentsfilterfulfilledN, value = PatientsTreatmentsFulfilledFilter.NotFulfilled.ToString() },
                    new { name = language.patientstreatmentsfilterfulfilledY, value = PatientsTreatmentsFulfilledFilter.Fulfilled.ToString() }
                }).ToArray();
            comboBox_tabPatientsTreatments_filterfulfilled.DisplayMember = "name";
            comboBox_tabPatientsTreatments_filterfulfilled.ValueMember = "value";
            comboBox_tabPatientsTreatments_filterfulfilled.SelectedIndex = 0;
            if (_patientsTreatmentsFulfilledFilter == PatientsTreatmentsFulfilledFilter.All)
                comboBox_tabPatientsTreatments_filterfulfilled.SelectedIndex = 0;
            else if (_patientsTreatmentsFulfilledFilter == PatientsTreatmentsFulfilledFilter.NotFulfilled)
                comboBox_tabPatientsTreatments_filterfulfilled.SelectedIndex = 1;
            else if (_patientsTreatmentsFulfilledFilter == PatientsTreatmentsFulfilledFilter.Fulfilled)
                comboBox_tabPatientsTreatments_filterfulfilled.SelectedIndex = 2;

            //load patientstreatments filter paid
            comboBox_tabPatientsTreatments_filterpaid.DataSource = (new[] {
                    new { name = language.patientstreatmentsfilterpaidAll, value = PatientsTreatmentsPaidFilter.All.ToString() },
                    new { name = language.patientstreatmentsfilterpaidN, value = PatientsTreatmentsPaidFilter.NotPaid.ToString() },
                    new { name = language.patientstreatmentsfilterpaidY, value = PatientsTreatmentsPaidFilter.Paid.ToString() }
                }).ToArray();
            comboBox_tabPatientsTreatments_filterpaid.DisplayMember = "name";
            comboBox_tabPatientsTreatments_filterpaid.ValueMember = "value";
            comboBox_tabPatientsTreatments_filterpaid.SelectedIndex = 0;
            if (_patientsTreatmentsPaidFilter == PatientsTreatmentsPaidFilter.All)
                comboBox_tabPatientsTreatments_filterpaid.SelectedIndex = 0;
            else if (_patientsTreatmentsPaidFilter == PatientsTreatmentsPaidFilter.NotPaid)
                comboBox_tabPatientsTreatments_filterpaid.SelectedIndex = 1;
            else if (_patientsTreatmentsPaidFilter == PatientsTreatmentsPaidFilter.Paid)
                comboBox_tabPatientsTreatments_filterpaid.SelectedIndex = 2;

            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Reset all the tab datagrid
        /// </summary>
        private void ResetTabsDataGrid()
        {
            IsBindingSourceLoading = true;
            advancedDataGridView_tabPatients_tabPatientsContacts_list.CleanFilterAndSort();
            advancedDataGridView_tabPatients_tabPatientsContacts_list.SortASC(advancedDataGridView_tabPatients_tabPatientsContacts_list.Columns[1]);
            advancedDataGridView_tabPatients_tabPatientsAddresses_list.CleanFilterAndSort();
            advancedDataGridView_tabPatients_tabPatientsAddresses_list.SortASC(advancedDataGridView_tabPatients_tabPatientsAddresses_list.Columns[1]);
            advancedDataGridView_tabPatientsMedicalrecords_list.CleanFilterAndSort();
            advancedDataGridView_tabPatientsMedicalrecords_list.SortASC(advancedDataGridView_tabPatientsMedicalrecords_list.Columns[1]);
            advancedDataGridView_tabPatientsTreatments_list.CleanFilterAndSort();
            advancedDataGridView_tabPatientsTreatments_list.SortDESC(advancedDataGridView_tabPatientsTreatments_list.Columns[0]);
            advancedDataGridView_tabPatientsTreatments_list.SortASC(advancedDataGridView_tabPatientsTreatments_list.Columns[1]);
            advancedDataGridView_tabPayments_list.CleanFilterAndSort();
            advancedDataGridView_tabPayments_list.SortDESC(advancedDataGridView_tabPayments_list.Columns[1]);
            advancedDataGridView_tabAppointments_list.CleanFilterAndSort();
            advancedDataGridView_tabAppointments_list.SortDESC(advancedDataGridView_tabAppointments_list.Columns[1]);
            advancedDataGridView_tabAppointments_list.SortASC(advancedDataGridView_tabAppointments_list.Columns[2]);
            advancedDataGridView_tabPatientsAttachments_list.CleanFilterAndSort();
            advancedDataGridView_tabPatientsAttachments_list.SortASC(advancedDataGridView_tabPatientsAttachments_list.Columns[1]);
            advancedDataGridView_tabPatientsAttachments_list.SortDESC(advancedDataGridView_tabPatientsAttachments_list.Columns[2]);
            advancedDataGridView_tabPatientsAttachments_list.SortASC(advancedDataGridView_tabPatientsAttachments_list.Columns[3]);
            advancedDataGridView_tabInvoices_list.CleanFilterAndSort();
            advancedDataGridView_tabInvoices_list.SortDESC(advancedDataGridView_tabInvoices_list.Columns[1]);
            advancedDataGridView_tabEstimates_list.CleanFilterAndSort();
            advancedDataGridView_tabEstimates_list.SortDESC(advancedDataGridView_tabEstimates_list.Columns[1]);
            advancedDataGridView_tabPatientsNotes_list.CleanFilterAndSort();
            advancedDataGridView_tabPatientsNotes_list.SortDESC(advancedDataGridView_tabPatientsNotes_list.Columns[1]);
            advancedDataGridView_tabPatientsAttributes_list.CleanFilterAndSort();
            advancedDataGridView_tabPatientsAttributes_list.SortASC(advancedDataGridView_tabPatientsAttributes_list.Columns[1]);
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Get main list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSource_main()
        {
            ResetTabsDataGrid();

            List<patients> patients = new List<patients>();
            if (comboBox_filterArchived.SelectedIndex != -1)
            {
                string filterShow = comboBox_filterArchived.SelectedValue.ToString();
                if (filterShow == FilterShow.NotArchived.ToString())
                    patients = _doctcodModel.Patients.List(r => !r.patients_isarchived).ToList();
                else if (filterShow == FilterShow.Archived.ToString())
                    patients = _doctcodModel.Patients.List(r => r.patients_isarchived).ToList();
                else
                    patients = _doctcodModel.Patients.List().ToList();
            }
            else
                patients = _doctcodModel.Patients.List().ToList();

            IEnumerable<VPatients> vPatients =
                patients.Select(
                r => new VPatients
                {
                    patients_id = r.patients_id,
                    name = r.patients_surname + " " + r.patients_name,
                    isarchived = r.patients_isarchived
                }).ToList();

            return DGDataTableUtils.ToDataTable<VPatients>(vPatients);
        }

        /// <summary>
        /// Main Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_FilterStringChanged(object sender, AdvancedDataGridView.FilterEventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox_filterPatient.Text))
                e.FilterString += (!String.IsNullOrEmpty(e.FilterString) ? " AND " : "") + String.Format("name LIKE '%{0}%'", textBox_filterPatient.Text.Replace("'", "''"));
        }

        /// <summary>
        /// Main filter changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_filterArchived_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            ReloadView();

            vPatientsBindingSource_CurrentChanged(sender, e);
        }

        /// <summary>
        /// Main BindingSource changed handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vPatientsBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (_resetPatientstreatmentsFilterOnChange)
                ResetPatientstreatmentsFilter();

            if (IsBindingSourceLoading)
                return;

            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            patients_lastloginDateTimePicker.Visible = false;
            patients_lastloginLabel.Visible = false;
            if (patients_id != -1)
            {
                patients patient = _doctcodModel.Patients.Find(patients_id);
                if (patient.patients_sex == "F")
                    patients_sexFRadioButton.Checked = true;
                else
                    patients_sexMRadioButton.Checked = true;
                if (patient.patients_lastlogin != null)
                {
                    patients_lastloginDateTimePicker.Visible = true;
                    patients_lastloginLabel.Visible = true;
                }
            }
        }

        /// <summary>
        ///  Main BindingSource list changed handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vPatientsBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            countTextBox.Text = vPatientsBindingSource.Count.ToString();
        }

        /// <summary>
        /// Search a patient name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_filterPatient_TextChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            advancedDataGridView_main.TriggerFilterStringChanged();
        }


        #region tabPatients_tabPatients

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabPatients()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<patients, DoctcoDModel>(_doctcodModel.Patients, vPatientsBindingSource, new string[] { "patients_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabPatients(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<patients, DoctcoDModel>(_doctcodModel.Patients, item, vPatientsBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabPatients(object item)
        {
            if (patients_sexFRadioButton.Checked)
                ((patients)patientsBindingSource.Current).patients_sex = "F";
            else
                ((patients)patientsBindingSource.Current).patients_sex = "M";

            DGUIGHFData.Add<patients, DoctcoDModel>(_doctcodModel.Patients, item);

            textBox_filterPatient.Text = "";
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabPatients(object item)
        {
            if (patients_sexFRadioButton.Checked)
                ((patients)patientsBindingSource.Current).patients_sex = "F";
            else
                ((patients)patientsBindingSource.Current).patients_sex = "M";

            DGUIGHFData.Update<patients, DoctcoDModel>(_doctcodModel.Patients, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabPatients(object item)
        {
            patients patient = (patients)item;

            if (Directory.Exists(_patientsAttachmentsdir + "\\" + patient.patients_id))
            {
                if (!FileHelper.DeleteFolder(_patientsAttachmentsdir + "\\" + patient.patients_id, _doSecureDelete))
                {
                    MessageBox.Show(String.Format(language.folderdeleteerrorMessage, _patientsAttachmentsdir + "\\" + patient.patients_id), language.filedeleteerrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (Directory.Exists(_patientsDatadir + "\\" + patient.patients_id))
            {
                if (!FileHelper.DeleteFolder(_patientsDatadir + "\\" + patient.patients_id, _doSecureDelete))
                {
                    MessageBox.Show(String.Format(language.folderdeleteerrorMessage, _patientsDatadir + "\\" + patient.patients_id), language.filedeleteerrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            DGUIGHFData.Remove<patients, DoctcoDModel>(_doctcodModel.Patients, item);
        }

        /// <summary>
        /// New tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatients_tabPatients_new_Click(object sender, EventArgs e)
        {
            if (AddClick(tabElement_tabPatients_tabPatients))
            {
                ((patients)patientsBindingSource.Current).patients_birthdate = new DateTime(1970, 1, 1, 0, 0, 0);
                ((patients)patientsBindingSource.Current).patients_username = Randomizer.BuildRandomNumberString(8).ToLower();
                ((patients)patientsBindingSource.Current).patients_password = Randomizer.BuildRandomNumber(6);
                ((patients)patientsBindingSource.Current).patients_token = null;
                ((patients)patientsBindingSource.Current).patients_lastlogin = null;
                patients_sexMRadioButton.Checked = true;
                patientsBindingSource.ResetBindings(true);

                patients_lastloginDateTimePicker.Enabled = false;
            }
        }

        /// <summary>
        /// Edit tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatients_tabPatients_edit_Click(object sender, EventArgs e)
        {
            if (UpdateClick(tabElement_tabPatients_tabPatients))
            {
                patients_lastloginDateTimePicker.Enabled = false;
            }
        }

        /// <summary>
        /// Reset username and password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatients_tabPatients_resetusernamepassword_Click(object sender, EventArgs e)
        {
            ((patients)patientsBindingSource.Current).patients_username = Randomizer.BuildRandomNumberString(8).ToLower();
            ((patients)patientsBindingSource.Current).patients_password = Randomizer.BuildRandomNumber(6);
            ((patients)patientsBindingSource.Current).patients_token = null;
            ((patients)patientsBindingSource.Current).patients_lastlogin = null;
            patientsBindingSource.ResetBindings(true);

            patients_lastloginDateTimePicker.Visible = false;
            patients_lastloginLabel.Visible = false;
        }

        /// <summary>
        /// Price lists reset to default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatients_tabPatients_priceslistsreset_Click(object sender, EventArgs e)
        {
            treatmentspriceslists_idComboBox.SelectedIndex = -1;
        }

        /// <summary>
        /// Data dir button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatients_tabPatients_datadir_Click(object sender, EventArgs e)
        {
            if (vPatientsBindingSource.Current != null)
            {
                if (!Directory.Exists(_patientsDatadir))
                {
                    try
                    {
                        Directory.CreateDirectory(_patientsDatadir);
                    }
                    catch
                    {
                        MessageBox.Show(String.Format(language.foldercreateerrorMessage, _patientsDatadir), language.foldercreateerrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                string patientsDatadir = _patientsDatadir + "\\" + ((patients)patientsBindingSource.Current).patients_id;
                if (!Directory.Exists(patientsDatadir))
                {
                    try
                    {
                        Directory.CreateDirectory(patientsDatadir);
                    }
                    catch
                    {
                        MessageBox.Show(String.Format(language.foldercreateerrorMessage, _patientsDatadir), language.foldercreateerrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                try
                {
                    Process.Start(ExplorerBinary, patientsDatadir);
                }
                catch { }
            }
        }

        #endregion


        #region tabPatients_tabPatientsContacts

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabPatients_tabPatientsContacts()
        {
            object ret = null;

            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            IEnumerable<VPatientsContacts> vPatientsContacts =
            _doctcodModel.PatientsContacts.List(r => r.patients_id == patients_id).Select(
            r => new VPatientsContacts
            {
                patientscontacts_id = r.patientscontacts_id,
                contactstype = _doctcodModel.ContactsTypes.Find(r.contactstypes_id).contactstypes_name,
                contact = (r.patientscontacts_value.Length > MaxRowValueLength ? r.patientscontacts_value.Substring(0, MaxRowValueLength) + "..." : r.patientscontacts_value)
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VPatientsContacts>(vPatientsContacts);

            return ret;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabPatients_tabPatientsContacts()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<patientscontacts, DoctcoDModel>(_doctcodModel.PatientsContacts, vPatientsContactsBindingSource, new string[] { "patientscontacts_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabPatients_tabPatientsContacts(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<patientscontacts, DoctcoDModel>(_doctcodModel.PatientsContacts, item, vPatientsContactsBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabPatients_tabPatientsContacts(object item)
        {
            DGUIGHFData.Add<patientscontacts, DoctcoDModel>(_doctcodModel.PatientsContacts, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabPatients_tabPatientsContacts(object item)
        {
            DGUIGHFData.Update<patientscontacts, DoctcoDModel>(_doctcodModel.PatientsContacts, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabPatients_tabPatientsContacts(object item)
        {
            DGUIGHFData.Remove<patientscontacts, DoctcoDModel>(_doctcodModel.PatientsContacts, item);
        }

        /// <summary>
        /// New tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatients_tabPatientsContacts_new_Click(object sender, EventArgs e)
        {
            if (vPatientsBindingSource.Current != null)
            {
                if (AddClick(tabElement_tabPatients_tabPatientsContacts))
                {
                    ((patientscontacts)patientscontactsBindingSource.Current).patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
                    patientscontactsBindingSource.ResetBindings(true);
                }
            }
        }

        #endregion


        #region tabPatients_tabPatientsAddresses

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabPatients_tabPatientsAddresses()
        {
            object ret = null;

            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            IEnumerable<VPatientsAddresses> vPatientsAddresses =
            _doctcodModel.PatientsAddresses.List(r => r.patients_id == patients_id).Select(
            r => new VPatientsAddresses
            {
                patientsaddresses_id = r.patientsaddresses_id,
                addresstype = _doctcodModel.AddressesTypes.Find(r.addressestypes_id).addressestypes_name,
                address = ((r.patientsaddresses_city + " " + r.patientsaddresses_street).Length > MaxRowValueLength ? (r.patientsaddresses_city + " " + r.patientsaddresses_street).Substring(0, MaxRowValueLength) + "..." : (r.patientsaddresses_city + " " + r.patientsaddresses_street))
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VPatientsAddresses>(vPatientsAddresses);

            return ret;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabPatients_tabPatientsAddresses()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<patientsaddresses, DoctcoDModel>(_doctcodModel.PatientsAddresses, vPatientsAddressesBindingSource, new string[] { "patientsaddresses_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabPatients_tabPatientsAddresses(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<patientsaddresses, DoctcoDModel>(_doctcodModel.PatientsAddresses, item, vPatientsAddressesBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabPatients_tabPatientsAddresses(object item)
        {
            DGUIGHFData.Add<patientsaddresses, DoctcoDModel>(_doctcodModel.PatientsAddresses, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabPatients_tabPatientsAddresses(object item)
        {
            DGUIGHFData.Update<patientsaddresses, DoctcoDModel>(_doctcodModel.PatientsAddresses, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabPatients_tabPatientsAddresses(object item)
        {
            DGUIGHFData.Remove<patientsaddresses, DoctcoDModel>(_doctcodModel.PatientsAddresses, item);
        }

        /// <summary>
        /// New tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatients_tabPatientsAddresses_new_Click(object sender, EventArgs e)
        {
            if (vPatientsBindingSource.Current != null)
            {
                if (AddClick(tabElement_tabPatients_tabPatientsAddresses))
                {
                    ((patientsaddresses)patientsaddressesBindingSource.Current).patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
                    patientsaddressesBindingSource.ResetBindings(true);
                }
            }
        }

        #endregion


        #region tabPatientsMedicalrecords

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabPatientsMedicalrecords()
        {
            object ret = null;

            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            IEnumerable<VPatientsMedicalrecords> vPatientsMedicalrecords =
            _doctcodModel.PatientsMedicalrecords.List(r => r.patients_id == patients_id).Select(
            r => new VPatientsMedicalrecords
            {
                patientsmedicalrecords_id = r.patientsmedicalrecords_id,
                medicalrecordstype = _doctcodModel.MedicalrecordsTypes.Find(r.medicalrecordstypes_id).medicalrecordstypes_name,
                value = (r.patientsmedicalrecords_value != null ? (r.patientsmedicalrecords_value.Length > MaxRowValueLength ? r.patientsmedicalrecords_value.Substring(0, MaxRowValueLength) + "..." : r.patientsmedicalrecords_value) : "")
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VPatientsMedicalrecords>(vPatientsMedicalrecords);

            return ret;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabPatientsMedicalrecords()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<patientsmedicalrecords, DoctcoDModel>(_doctcodModel.PatientsMedicalrecords, vPatientsMedicalrecordsBindingSource, new string[] { "patientsmedicalrecords_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabPatientsMedicalrecords(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<patientsmedicalrecords, DoctcoDModel>(_doctcodModel.PatientsMedicalrecords, item, vPatientsMedicalrecordsBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabPatientsMedicalrecords(object item)
        {
            DGUIGHFData.Add<patientsmedicalrecords, DoctcoDModel>(_doctcodModel.PatientsMedicalrecords, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabPatientsMedicalrecords(object item)
        {
            DGUIGHFData.Update<patientsmedicalrecords, DoctcoDModel>(_doctcodModel.PatientsMedicalrecords, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabPatientsMedicalrecords(object item)
        {
            DGUIGHFData.Remove<patientsmedicalrecords, DoctcoDModel>(_doctcodModel.PatientsMedicalrecords, item);
        }

        /// <summary>
        /// New tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsMedicalrecords_new_Click(object sender, EventArgs e)
        {
            if (vPatientsBindingSource.Current != null)
            {
                if (AddClick(tabElement_tabPatientsMedicalrecords))
                {
                    ((patientsmedicalrecords)patientsmedicalrecordsBindingSource.Current).patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
                    patientsmedicalrecordsBindingSource.ResetBindings(true);
                }
            }
        }

        #endregion


        #region tabPatientsTreatments

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabPatientsTreatments()
        {
            object ret = null;

            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            //get predicate
            Expression<Func<patientstreatments, bool>> predicate = GetDataSourceList_tabPatientsTreatmentsPredicate(patients_id);

            //set the filter numbers
            IsBindingSourceLoading = true;
            SetPatientstreatmentsFiltert();
            IsBindingSourceLoading = false;

            IEnumerable<VPatientsTreatments> vPatientsTreatments =
            _doctcodModel.PatientsTreatments.List(predicate).Select(
            r => new VPatientsTreatments
            {
                patientstreatments_id = r.patientstreatments_id,
                treatment = _doctcodModel.Treatments.Find(r.treatments_id).treatments_code,
                isfulfilled = (r.patientstreatments_fulfilldate != null ? true : false),
                ispaid = r.patientstreatments_ispaid,
                date = r.patientstreatments_creationdate
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VPatientsTreatments>(vPatientsTreatments);

            return ret;
        }

        /// <summary>
        /// Get predicate for patientstreatments to show
        /// </summary>
        /// <param name="patients_id"></param>
        /// <returns></returns>
        private Expression<Func<patientstreatments, bool>> GetDataSourceList_tabPatientsTreatmentsPredicate(int patients_id)
        {
            //set predicate
            Expression<Func<patientstreatments, bool>> predicate = DGPredicateBuilder.True<patientstreatments>();
            Expression<Func<patientstreatments, bool>> predicateor = DGPredicateBuilder.False<patientstreatments>();
            predicate = predicate.And(r => r.patients_id == patients_id);
            if (comboBox_tabPatientsTreatments_filterfulfilled.SelectedIndex != -1)
            {
                string filterfulfilled = comboBox_tabPatientsTreatments_filterfulfilled.SelectedValue.ToString();
                if (filterfulfilled == PatientsTreatmentsFulfilledFilter.NotFulfilled.ToString())
                    predicate = predicate.And(r => r.patientstreatments_fulfilldate == null);
                else if (filterfulfilled == PatientsTreatmentsFulfilledFilter.Fulfilled.ToString())
                    predicate = predicate.And(r => r.patientstreatments_fulfilldate != null);
            }
            if (comboBox_tabPatientsTreatments_filterpaid.SelectedIndex != -1)
            {
                string filterpaid = comboBox_tabPatientsTreatments_filterpaid.SelectedValue.ToString();
                if (filterpaid == PatientsTreatmentsPaidFilter.NotPaid.ToString())
                    predicate = predicate.And(r => r.patientstreatments_ispaid == false);
                else if (filterpaid == PatientsTreatmentsPaidFilter.Paid.ToString())
                    predicate = predicate.And(r => r.patientstreatments_ispaid == true);
            }

            return predicate;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabPatientsTreatments()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<patientstreatments, DoctcoDModel>(_doctcodModel.PatientsTreatments, vPatientsTreatmentsBindingSource, new string[] { "patientstreatments_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabPatientsTreatments(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<patientstreatments, DoctcoDModel>(_doctcodModel.PatientsTreatments, item, vPatientsTreatmentsBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabPatientsTreatments(object item)
        {
            SetCurrentPatientstreatmentsBindingSource();

            //scroll up
            tabPage_tabPatientsTreatments.AutoScrollPosition = new Point(0, 0);

            if (_paymentsReference == PaymentsReference.Treatments)
            {
                //unset lazy load for payments tab, to reload totals
                tabElement_tabPayments.IsLazyLoaded = false;
            }

            if (_resetPatientstreatmentsFilterOnSave)
                ResetPatientstreatmentsFilter();

            DGUIGHFData.Add<patientstreatments, DoctcoDModel>(_doctcodModel.PatientsTreatments, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabPatientsTreatments(object item)
        {
            SetCurrentPatientstreatmentsBindingSource();

            //scroll up
            tabPage_tabPatientsTreatments.AutoScrollPosition = new Point(0, 0);

            if (_paymentsReference == PaymentsReference.Treatments)
            {
                //unset lazy load for payments tab, to reload totals
                tabElement_tabPayments.IsLazyLoaded = false;
            }

            if (_resetPatientstreatmentsFilterOnSave)
                ResetPatientstreatmentsFilter();

            DGUIGHFData.Update<patientstreatments, DoctcoDModel>(_doctcodModel.PatientsTreatments, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabPatientsTreatments(object item)
        {
            if (_paymentsReference == PaymentsReference.Treatments)
            {
                //unset lazy load for payments tab, to reload totals
                tabElement_tabPayments.IsLazyLoaded = false;
            }

            if (_resetPatientstreatmentsFilterOnSave)
                ResetPatientstreatmentsFilter();

            DGUIGHFData.Remove<patientstreatments, DoctcoDModel>(_doctcodModel.PatientsTreatments, item);
        }

        /// <summary>
        /// New tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsTreatments_new_Click(object sender, EventArgs e)
        {
            if (vPatientsBindingSource.Current != null)
            {
                if (AddClick(tabElement_tabPatientsTreatments))
                {
                    ((patientstreatments)patientstreatmentsBindingSource.Current).patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
                    ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_creationdate = DateTime.Now;
                    if (_doctcodModel.Doctors.Count() == 1)
                    {
                        doctors doctor = _doctcodModel.Doctors.FirstOrDefault();
                        if (doctor != null)
                            ((patientstreatments)patientstreatmentsBindingSource.Current).doctors_id = doctor.doctors_id;
                    }
                    ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_ispaid = false;
                    patientstreatmentsBindingSource.ResetBindings(true);

                    patientstreatments_invoiceTextBox.Text = "";
                    patientstreatments_expirationdateenabledCheckBox.Checked = false;
                    patientstreatments_expirationdateenabledCheckBox_CheckedChanged(null, null);
                    patientstreatments_fulfilldateenabledCheckBox.Checked = false;
                    patientstreatments_fulfilldateenabledCheckBox_CheckedChanged(null, null);
                }
            }
        }

        /// <summary>
        /// Edii tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsTreatments_edit_Click(object sender, EventArgs e)
        {
            if (vPatientsBindingSource.Current != null)
            {
                if (UpdateClick(tabElement_tabPatientsTreatments))
                {
                    doctors_idComboBox1.Enabled = false;
                    treatments_idComboBox.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Set current treatment fulfilled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsTreatments_setfulfilled_Click(object sender, EventArgs e)
        {
            int patientstreatments_id = -1;
            if (vPatientsTreatmentsBindingSource.Current != null)
            {
                patientstreatments_id = (((DataRowView)vPatientsTreatmentsBindingSource.Current).Row).Field<int>("patientstreatments_id");
            }

            if (patientstreatments_id != -1)
            {
                patientstreatments patientstreatment = _doctcodModel.PatientsTreatments.Find(patientstreatments_id);
                patientstreatment.patientstreatments_fulfilldate = DateTime.Now;
                _doctcodModel.PatientsTreatments.Update(patientstreatment);

                if (_paymentsReference == PaymentsReference.Treatments)
                {
                    //unset lazy load for payments tab, to reload totals
                    tabElement_tabPayments.IsLazyLoaded = false;
                }

                //reload tab
                ReloadTab(tabElement_tabPatientsTreatments);
            }
        }

        /// <summary>
        /// Set current treatment paid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsTreatments_setpaid_Click(object sender, EventArgs e)
        {
            int patientstreatments_id = -1;
            if (vPatientsTreatmentsBindingSource.Current != null)
            {
                patientstreatments_id = (((DataRowView)vPatientsTreatmentsBindingSource.Current).Row).Field<int>("patientstreatments_id");
            }

            if (patientstreatments_id != -1)
            {
                patientstreatments patientstreatment = _doctcodModel.PatientsTreatments.Find(patientstreatments_id);
                patientstreatment.patientstreatments_ispaid = true;
                _doctcodModel.PatientsTreatments.Update(patientstreatment);

                //reload tab
                ReloadTab(tabElement_tabPatientsTreatments);
            }
        }

        /// <summary>
        /// Print treatments for this patient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsTreatments_filterprint_Click(object sender, EventArgs e)
        {
            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            if (patients_id != -1)
            {
                //get predicate
                Expression<Func<patientstreatments, bool>> predicate = GetDataSourceList_tabPatientsTreatmentsPredicate(patients_id);
                List<int> patientstreatments_ids = new List<int>();
                DataRow[] dataRows = ((DataTable)vPatientsTreatmentsBindingSource.DataSource).DefaultView.ToTable().Select();
                for (int i = 0; i < dataRows.Length; i++)
                {
                    try
                    {
                        patientstreatments_ids.Add(Convert.ToInt32(dataRows[i]["patientstreatments_id"]));
                    }
                    catch { }
                }
                predicate = predicate.And(r => patientstreatments_ids.Contains(r.patientstreatments_id));
                patientstreatments[] patientstreatmentsl = _doctcodModel.PatientsTreatments.List(predicate).ToArray();

                //do print
                PrintPatientsTreatments(patients_id, patientstreatmentsl);
            }
        }

        /// <summary>
        /// Print patient treatments
        /// </summary>
        /// <param name="patients_id"></param>
        /// <param name="patientstreatmentsl"></param>
        private void PrintPatientsTreatments(int patients_id, patientstreatments[] patientstreatmentsl)
        {
            if (patientstreatmentsl == null || patientstreatmentsl.Count() == 0)
                return;

            //load print templates
            string[] templates = new string[] { };
            Dictionary<string, IDoctcoDPrintModel> templatesModels = new Dictionary<string, IDoctcoDPrintModel>();
            foreach (string assemblyPath in ConfigurationManager.AppSettings["printModels"].Split(','))
            {
                IDoctcoDPrintModel printModelt = DoctcoDPrintModelHelper.DoctcoDPrintModelInstance(assemblyPath);
                if (printModelt != null)
                {
                    if (printModelt.IsBuildPatientTreatmentsEnabled())
                    {
                        string modelname = printModelt.BuildPatientTreatmentsTemplateName(ConfigurationManager.AppSettings["language"]);
                        if (!templatesModels.ContainsKey(modelname))
                        {
                            templatesModels.Add(modelname, printModelt);
                            templates = templates.Concat(new string[] { modelname }).ToArray();
                        }
                    }
                }
            }
            if (templates.Count() == 0)
            {
                MessageBox.Show(language.printmodelerrorMessage, language.printmodelerrorNone, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //select printmodel from print template
            IDoctcoDPrintModel printModel = null;
            if (templates.Count() == 1)
                printModel = templatesModels.FirstOrDefault().Value;
            else
            {
                string template = null;
                if (SelectorBox.Show(language.printmodelselectMessage, language.printmodelselectTitle, templates, ref template) == DialogResult.OK)
                {
                    if (templatesModels.Any(r => r.Key == template))
                        printModel = templatesModels.FirstOrDefault(r => r.Key == template).Value;
                }
                else
                    return;
            }
            if (printModel == null)
            {
                MessageBox.Show(language.printmodelerrorMessage, language.printmodelerrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //prepare folders
            string destfolder = ConfigurationManager.AppSettings["tmpdir"];
            if (!FileHelper.CreateFolder(destfolder))
            {
                MessageBox.Show(String.Format(language.printcreatefoldererrorMessage, destfolder), language.printcreatefoldererrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //make new filename
            bool buildfile = true;
            string filename = printModel.BuildPatientTreatmentsGetFilename(destfolder);
            if (String.IsNullOrEmpty(filename))
            {
                MessageBox.Show(language.printvalidfilenameerrorMessage, language.printvalidfilenameerrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (File.Exists(filename))
            {
                DialogResult dialogResult = MessageBox.Show(String.Format(language.printoverwritefilenamewarningMessage, filename), language.printoverwritefilenamewarningTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                { }
                else if (dialogResult == DialogResult.No)
                    buildfile = false;
                else
                    return;
            }

            //build patient treatments
            if (buildfile)
            {
                string[] errors = new string[] { };
                if (!printModel.BuildPatientTreatments(_doctcodModel, patients_id, patientstreatmentsl, ConfigurationManager.AppSettings["language"], filename, ref errors))
                {
                    MessageBox.Show(String.Format(language.printbuildpdferrorMessage, filename) + (errors.Length > 0 ? " " + String.Join("\n", errors) : null), language.printbuildpdferrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //try to start the process
            if (!String.IsNullOrEmpty(filename))
            {
                try
                {
                    Process.Start(filename);
                }
                catch
                {
                    MessageBox.Show(String.Format(language.printopenfilenameMessage, filename), language.printopenfilenameTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        ///  Patients treatments view BindingSourceList event raised
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tabPatientsTreatments_BindingSourceListChanged(object sender, EventArgs e)
        {
            vPatientsTreatmentsBindingSource_CurrentChanged(sender, e);
        }

        /// <summary>
        /// Patients treatments view BindingSource changed handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vPatientsTreatmentsBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            int patientstreatments_id = -1;
            if (vPatientsTreatmentsBindingSource.Current != null)
            {
                patientstreatments_id = (((DataRowView)vPatientsTreatmentsBindingSource.Current).Row).Field<int>("patientstreatments_id");
            }

            IsBindingSourceLoading = true;

            patientstreatments_expirationdateenabledCheckBox.Checked = false;
            patientstreatments_fulfilldateenabledCheckBox.Checked = false;
            patientstreatments_invoiceTextBox.Text = "";

            if (patientstreatments_id != -1)
            {
                invoiceslines invoiceline = _doctcodModel.InvoicesLines.FirstOrDefault(r => r.patientstreatments_id == patientstreatments_id);
                if (invoiceline != null)
                {
                    invoices invoice = _doctcodModel.Invoices.Find(invoiceline.invoices_id);
                    doctors doctors = null;
                    if (invoice.doctors_id != null)
                        doctors = _doctcodModel.Doctors.Find(invoice.doctors_id);
                    patientstreatments_invoiceTextBox.Text = invoice.invoices_number + "/" + invoice.invoices_date.Year + (doctors != null ? " " + doctors.doctors_surname + " " + doctors.doctors_name + " (" + invoice.invoices_id + ")" : " (" + invoice.invoices_id + ")");
                }

                patientstreatments patientstreatments = _doctcodModel.PatientsTreatments.Find(patientstreatments_id);
                if (patientstreatments.patientstreatments_expirationdate != null)
                    patientstreatments_expirationdateenabledCheckBox.Checked = true;
                if (patientstreatments.patientstreatments_fulfilldate != null)
                    patientstreatments_fulfilldateenabledCheckBox.Checked = true;
            }

            IsBindingSourceLoading = false;

            patientstreatments_expirationdateenabledCheckBox_CheckedChanged(null, null);
            patientstreatments_fulfilldateenabledCheckBox_CheckedChanged(null, null);
        }

        /// <summary>
        /// Treatment combobox changed handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treatments_idComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (treatments_idComboBox.SelectedIndex != -1 && tabElement_tabPatientsTreatments.CurrentEditingMode == EditingMode.C || tabElement_tabPatientsTreatments.CurrentEditingMode == EditingMode.U)
            {
                int patients_id = -1;
                if (vPatientsBindingSource.Current != null)
                {
                    patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
                }
                if (patients_id != -1)
                {
                    treatments treatment = _doctcodModel.Treatments.Find(treatments_idComboBox.SelectedValue);
                    if (treatment != null)
                    {
                        string description = null;
                        decimal price = treatment.treatments_price;
                        decimal taxrate = (treatment.taxes_id != null ? _doctcodModel.Taxes.Find((int)treatment.taxes_id).taxes_rate : 0);
                        byte expirationmonths = 0;
                        if (treatment.treatments_mexpiration != null)
                            expirationmonths = (byte)treatment.treatments_mexpiration;
                        if (patients_id != -1)
                        {
                            patients patient = _doctcodModel.Patients.Find(patients_id);
                            if (patient != null)
                            {
                                treatmentsprices treatmentsprice = _doctcodModel.TreatmentsPrices.FirstOrDefault(r => r.treatments_id == treatment.treatments_id && r.treatmentspriceslists_id == patient.treatmentspriceslists_id);
                                if (treatmentsprice != null)
                                {
                                    price = treatmentsprice.treatmentsprices_price;
                                }
                            }
                        }

                        if (expirationmonths != 0)
                        {
                            patientstreatments_expirationdateDateTimePicker.Value = ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_creationdate.AddMonths((int)expirationmonths);
                            patientstreatments_expirationdateenabledCheckBox.Checked = true;
                        }
                        else
                            patientstreatments_expirationdateenabledCheckBox.Checked = false;

                        ((patientstreatments)patientstreatmentsBindingSource.Current).treatments_id = treatment.treatments_id;
                        ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_price = price;
                        ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_taxrate = taxrate;
                        ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_description = description;
                    }
                    patientstreatmentsBindingSource.ResetBindings(true);
                }
            }
        }

        /// <summary>
        /// Patients treatments expiration date enabler checked handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_expirationdateenabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (patientstreatments_expirationdateenabledCheckBox.Checked)
                patientstreatments_expirationdateDateTimePicker.Visible = true;
            else
                patientstreatments_expirationdateDateTimePicker.Visible = false;
        }

        /// <summary>
        /// Patients treatments fulfill checked handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_fulfilldateenabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (patientstreatments_fulfilldateenabledCheckBox.Checked)
                patientstreatments_fulfilldateDateTimePicker.Visible = true;
            else
                patientstreatments_fulfilldateDateTimePicker.Visible = false;
        }

        /// <summary>
        /// Set the current patient treatments before update the record
        /// </summary>
        private void SetCurrentPatientstreatmentsBindingSource()
        {
            if (patientstreatmentsBindingSource.Current != null)
            {
                if (!patientstreatments_expirationdateenabledCheckBox.Checked)
                    ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_expirationdate = null;
                else
                    ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_expirationdate = patientstreatments_expirationdateDateTimePicker.Value;

                if (!patientstreatments_fulfilldateenabledCheckBox.Checked)
                    ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_fulfilldate = null;
                else
                    ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_fulfilldate = patientstreatments_fulfilldateDateTimePicker.Value;
            }
        }


        /// <summary>
        /// Description templates treatments changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void descriptiontemplatestreatments_idComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (descriptiontemplatestreatments_idComboBox.SelectedIndex != -1 && tabElement_tabPatientsTreatments.CurrentEditingMode == EditingMode.C || tabElement_tabPatientsTreatments.CurrentEditingMode == EditingMode.U)
            {
                descriptiontemplatestreatments descriptiontemplatestreatments = _doctcodModel.DescriptiontemplatesTreatments.Find(Convert.ToInt32(descriptiontemplatestreatments_idComboBox.SelectedValue));
                if (descriptiontemplatestreatments != null)
                {
                    string description = descriptiontemplatestreatments.descriptiontemplatestreatments_template;
                    ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_description = description;
                }
                patientstreatmentsBindingSource.ResetBindings(true);
                //reset the template selector
                IsBindingSourceLoading = true;
                descriptiontemplatestreatments_idComboBox.SelectedIndex = -1;
                IsBindingSourceLoading = false;
            }
        }

        /// <summary>
        /// Enlarge description text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsTreatments_descriptionform_Click(object sender, EventArgs e)
        {
            if (tabElement_tabPatientsTreatments.CurrentEditingMode == EditingMode.C || tabElement_tabPatientsTreatments.CurrentEditingMode == EditingMode.U)
            {
                string description = null;
                if (MiniHTMLTextBoxForm.Show(language.descriptiontemplatestreatmentsTitle, ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_description, this, ref description) == DialogResult.OK)
                {
                    ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_description = description;
                    patientstreatmentsBindingSource.ResetBindings(true);
                }
            }
        }

        #region patients treatments filter

        /// <summary>
        /// Set the current patient treatments filter text
        /// </summary>
        private void SetPatientstreatmentsFiltert()
        {
            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            //set predicate
            Expression<Func<patientstreatments, bool>> predicate = DGPredicateBuilder.True<patientstreatments>();
            predicate = predicate.And(r => r.patients_id == patients_id);
            if (comboBox_tabPatientsTreatments_filterfulfilled.SelectedIndex != -1)
            {
                string filterfulfilled = comboBox_tabPatientsTreatments_filterfulfilled.SelectedValue.ToString();
                if (filterfulfilled == PatientsTreatmentsFulfilledFilter.NotFulfilled.ToString())
                    predicate = predicate.And(r => r.patientstreatments_fulfilldate == null);
                else if (filterfulfilled == PatientsTreatmentsFulfilledFilter.Fulfilled.ToString())
                    predicate = predicate.And(r => r.patientstreatments_fulfilldate != null);
            }
            if (comboBox_tabPatientsTreatments_filterpaid.SelectedIndex != -1)
            {
                string filterpaid = comboBox_tabPatientsTreatments_filterpaid.SelectedValue.ToString();
                if (filterpaid == PatientsTreatmentsPaidFilter.NotPaid.ToString())
                    predicate = predicate.And(r => r.patientstreatments_ispaid == false);
                else if (filterpaid == PatientsTreatmentsPaidFilter.Paid.ToString())
                    predicate = predicate.And(r => r.patientstreatments_ispaid == true);
            }
        }

        /// <summary>
        /// Reset the current patient treatments filter text
        /// </summary>
        private void ResetPatientstreatmentsFilter()
        {
            _loadPatientsTreatmentsFilter = false;
            IsBindingSourceLoading = true;
            comboBox_tabPatientsTreatments_filterfulfilled.SelectedIndex = 0;
            comboBox_tabPatientsTreatments_filterpaid.SelectedIndex = 0;
            IsBindingSourceLoading = false;
            _loadPatientsTreatmentsFilter = true;
        }

        /// <summary>
        /// Patients Treatment filter change
        /// </summary>
        private void PatientsTreatmentsFilter()
        {
            if (IsBindingSourceLoading)
                return;

            if (!_loadPatientsTreatmentsFilter)
                return;

            //reload tab
            ReloadTab(tabElement_tabPatientsTreatments);
        }

        /// <summary>
        /// Treatments filter changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_tabPatientsTreatments_filterfulfilled_SelectedIndexChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatments filter changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_tabPatientsTreatments_filterpaid_SelectedIndexChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        #endregion


        #endregion


        #region tabPayments

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabPayments()
        {
            object ret = null;

            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            //update totals
            decimal paidtotalnum = Math.Round(_doctcodModel.Payments.List(r => r.patients_id == patients_id).Sum(r => r.payments_amount), 2);
            decimal totalvalue = 0;
            decimal lefttotalvalue = 0;
            if (_paymentsReference == PaymentsReference.Treatments)
            {
                foreach (patientstreatments patientstreatment in _doctcodModel.PatientsTreatments.List(r => r.patients_id == patients_id && r.patientstreatments_fulfilldate != null))
                {
                    totalvalue += patientstreatment.patientstreatments_price + (patientstreatment.patientstreatments_price * patientstreatment.patientstreatments_taxrate / 100);
                }
                totalvalue = Math.Round(totalvalue, 2);
                lefttotalvalue = Math.Round(totalvalue - paidtotalnum, 2);
            }
            else if (_paymentsReference == PaymentsReference.Invoices)
            {
                totalvalue = Math.Round(_doctcodModel.Invoices.List(r => r.patients_id == patients_id).Sum(r => r.invoices_totaldue), 2);
                lefttotalvalue = Math.Round(totalvalue - paidtotalnum, 2);
            }
            label_tabPayments_paidtotalvalue.Text = String.Format("{0:0.00}", paidtotalnum);
            label_tabPayments_totalvalue.Text = String.Format("{0:0.00}", totalvalue);
            label_tabPayments_lefttotalvalue.Text = String.Format("{0:0.00}", lefttotalvalue);

            IEnumerable<VPatientsPayments> vPayments =
            _doctcodModel.Payments.List(r => r.patients_id == patients_id).Select(
            r => new VPatientsPayments
            {
                payments_id = r.payments_id,
                amount = (double)r.payments_amount,
                date = r.payments_date,
                note = (!String.IsNullOrEmpty(r.payments_notes) ? (r.payments_notes.Length > MaxRowValueLength ? r.payments_notes.Substring(0, MaxRowValueLength) + "..." : r.payments_notes) : "")
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VPatientsPayments>(vPayments);

            return ret;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabPayments()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<payments, DoctcoDModel>(_doctcodModel.Payments, vPatientsPaymentsBindingSource, new string[] { "payments_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabPayments(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<payments, DoctcoDModel>(_doctcodModel.Payments, item, vPatientsPaymentsBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabPayments(object item)
        {
            DGUIGHFData.Add<payments, DoctcoDModel>(_doctcodModel.Payments, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabPayments(object item)
        {
            DGUIGHFData.Update<payments, DoctcoDModel>(_doctcodModel.Payments, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabPayments(object item)
        {
            DGUIGHFData.Remove<payments, DoctcoDModel>(_doctcodModel.Payments, item);
        }

        /// <summary>
        /// New tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPayments_new_Click(object sender, EventArgs e)
        {
            if (vPatientsBindingSource.Current != null)
            {
                if (AddClick(tabElement_tabPayments))
                {
                    ((payments)paymentsBindingSource.Current).patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
                    ((payments)paymentsBindingSource.Current).payments_date = DateTime.Now;
                    paymentsBindingSource.ResetBindings(true);
                }
            }
        }

        #endregion


        #region tabAppointments

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabAppointments()
        {
            object ret = null;

            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            IEnumerable<VPatientsAppointments> vPatientsAppointments =
            _doctcodModel.Appointments.List(r => r.patients_id == patients_id).Select(
            r => new VPatientsAppointments
            {
                appointments_id = r.appointments_id,
                fromday = r.appointments_from,
                from = r.appointments_from,
                to = r.appointments_to,
                title = (r.appointments_title.Length > MaxRowValueLength ? r.appointments_title.Substring(0, MaxRowValueLength) + "..." : r.appointments_title)
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VPatientsAppointments>(vPatientsAppointments);

            return ret;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabAppointments()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<appointments, DoctcoDModel>(_doctcodModel.Appointments, vPatientsAppointmentsBindingSource, new string[] { "appointments_id" });
        }

        #endregion


        #region tabPatientsAttachments

        private bool _tabPatientsAttachments_isnewsave = false;

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabPatientsAttachments()
        {
            object ret = null;

            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            IEnumerable<VPatientsAttachments> vPatientsAttachments =
            _doctcodModel.PatientsAttachments.List(r => r.patients_id == patients_id).Select(
            r => new VPatientsAttachments
            {
                patientsattachments_id = r.patientsattachments_id,
                attachmentstype = _doctcodModel.PatientsAttachmentsTypes.Find(r.patientsattachmentstypes_id).patientsattachmentstypes_name,
                date = r.patientsattachments_date.Date,
                attachment = (r.patientsattachments_value.Length > MaxRowValueLength ? r.patientsattachments_value.Substring(0, MaxRowValueLength) + "..." : r.patientsattachments_value)
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VPatientsAttachments>(vPatientsAttachments);

            return ret;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabPatientsAttachments()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<patientsattachments, DoctcoDModel>(_doctcodModel.PatientsAttachments, vPatientsAttachmentsBindingSource, new string[] { "patientsattachments_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabPatientsAttachments(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<patientsattachments, DoctcoDModel>(_doctcodModel.PatientsAttachments, item, vPatientsAttachmentsBindingSource);
            if (_tabPatientsAttachments_isnewsave && _patientsAttachmentsSaveandedit)
            {
                button_tabPatientsAttachments_edit_Click(null, null);
            }
            _tabPatientsAttachments_isnewsave = false;
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabPatientsAttachments(object item)
        {
            DGUIGHFData.Add<patientsattachments, DoctcoDModel>(_doctcodModel.PatientsAttachments, item);
            _tabPatientsAttachments_isnewsave = true;
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabPatientsAttachments(object item)
        {
            DGUIGHFData.Update<patientsattachments, DoctcoDModel>(_doctcodModel.PatientsAttachments, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabPatientsAttachments(object item)
        {
            patientsattachments patientsattachments = (patientsattachments)item;
            if (!String.IsNullOrEmpty(patientsattachments.patientsattachments_filename))
            {
                if (!FileHelper.DeleteFile(_patientsAttachmentsdir + "\\" + patientsattachments.patients_id + "\\" + patientsattachments.patientsattachments_filename, _doSecureDelete))
                {
                    MessageBox.Show(language.filedeleteerrorMessage, language.filedeleteerrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            DGUIGHFData.Remove<patientsattachments, DoctcoDModel>(_doctcodModel.PatientsAttachments, item);
        }

        /// <summary>
        /// New tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsAttachments_new_Click(object sender, EventArgs e)
        {
            if (vPatientsBindingSource.Current != null)
            {
                if (AddClick(tabElement_tabPatientsAttachments))
                {
                    ((patientsattachments)patientsattachmentsBindingSource.Current).patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
                    ((patientsattachments)patientsattachmentsBindingSource.Current).patientsattachments_date = DateTime.Now;
                    patientsattachmentsBindingSource.ResetBindings(true);

                    button_tabPatientsAttachments_filepathselect.Enabled = false;
                    button_tabPatientsAttachments_filepathdelete.Enabled = false;
                    patientsattachments_filenameTextBox.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Edit tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsAttachments_edit_Click(object sender, EventArgs e)
        {
            if (vPatientsBindingSource.Current != null)
            {
                if (UpdateClick(tabElement_tabPatientsAttachments))
                {
                    patientsattachmentstypes_idComboBox.Enabled = false;
                    patientsattachments_filenameTextBox.Enabled = false;
                }
            }
        }

        /// <summary>
        /// File attachment delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsAttachments_filepathdelete_Click(object sender, EventArgs e)
        {
            string patients_id = (((patientsattachments)patientsattachmentsBindingSource.Current).patients_id).ToString();
            if (!String.IsNullOrEmpty(patients_id))
            {
                if (patientsattachments_filenameTextBox.Text != "")
                {
                    if (!FileHelper.DeleteFile(_patientsAttachmentsdir + "\\" + patients_id + "\\" + patientsattachments_filenameTextBox.Text, _doSecureDelete))
                    {
                        MessageBox.Show(language.filedeleteerrorMessage, language.filedeleteerrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    patientsattachments_filenameTextBox.Text = "";
                }
            }
        }

        /// <summary>
        /// File attachment new
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsAttachments_filepathselect_Click(object sender, EventArgs e)
        {
            string patients_id = (((patientsattachments)patientsattachmentsBindingSource.Current).patients_id).ToString();
            if (!String.IsNullOrEmpty(patients_id))
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = language.attachmentselectTitle;
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    openFileDialog.Filter = "Images (*.jpg;*.gif;*.png;*.tiff)|*.jpg;*.gif;*.png;*.tiff|ZIP Files (*.zip)|*.zip|PDF Files (*.pdf)|*.pdf|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (!Directory.Exists(_patientsAttachmentsdir + "\\" + patients_id))
                            Directory.CreateDirectory(_patientsAttachmentsdir + "\\" + patients_id);

                        //delete old file
                        if (!String.IsNullOrEmpty(patientsattachments_filenameTextBox.Text))
                        {
                            FileHelper.DeleteFile(_patientsAttachmentsdir + "\\" + patients_id + "\\" + patientsattachments_filenameTextBox.Text, _doSecureDelete);
                            patientsattachments_filenameTextBox.Text = "";
                        }

                        try
                        {
                            //build a new file
                            string destinationFilePath = _patientsAttachmentsdir + "\\" + patients_id + "\\" + Path.GetFileName(openFileDialog.FileName);
                            string extention = Path.GetExtension(openFileDialog.FileName);
                            destinationFilePath = FileHelper.FindRandomFileName(_patientsAttachmentsdir + "\\" + patients_id, null, extention.Substring(1, extention.Length - 1));
                            File.Copy(openFileDialog.FileName, destinationFilePath);
                            patientsattachments_filenameTextBox.Text = Path.GetFileName(destinationFilePath);
                        }
                        catch
                        {
                            MessageBox.Show(language.attachmentcopyerrorMessage, language.attachmentcopyerrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// File attachment open folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsAttachments_filepathopenfolder_Click(object sender, EventArgs e)
        {
            string patients_id = (((patientsattachments)patientsattachmentsBindingSource.Current).patients_id).ToString();
            if (!String.IsNullOrEmpty(patients_id))
            {
                if (patientsattachments_filenameTextBox.Text != "")
                {
                    if (File.Exists(_patientsAttachmentsdir + "\\" + patients_id + "\\" + patientsattachments_filenameTextBox.Text))
                    {
                        if (_attachmentsOpenMode == AttachmentsOpenMode.Application)
                        {
                            try
                            {
                                Process.Start(_patientsAttachmentsdir + "\\" + patients_id + "\\" + patientsattachments_filenameTextBox.Text);
                            }
                            catch
                            { }
                        }
                        else if (_attachmentsOpenMode == AttachmentsOpenMode.Folder)
                        {
                            try
                            {
                                Process.Start(ExplorerBinary, _patientsAttachmentsdir + "\\" + patients_id);
                            }
                            catch { }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Attachement type changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientsattachmentstypes_idComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (patientsattachmentstypes_idComboBox.SelectedIndex != -1 && tabElement_tabPatientsAttachments.CurrentEditingMode == EditingMode.C || tabElement_tabPatientsAttachments.CurrentEditingMode == EditingMode.U)
            {
                int patients_id = -1;
                if (vPatientsBindingSource.Current != null)
                {
                    patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
                }

                if (patients_id != -1)
                {
                    patientsattachmentstypes patientsattachmentstype = _doctcodModel.PatientsAttachmentsTypes.Find(patientsattachmentstypes_idComboBox.SelectedValue);
                    if (patientsattachmentstype != null)
                    {
                        if (patientsattachmentstype.patientsattachmentstypes_valueautofunc == PatientsAttachmentsTypesRepository.ValueAutoFuncCode.AMG.ToString())
                        {
                            int maxvalue = 0;
                            foreach (patientsattachments patientsattachment in _doctcodModel.PatientsAttachments.List(r => r.patientsattachmentstypes_id == patientsattachmentstype.patientsattachmentstypes_id))
                            {
                                try
                                {
                                    int n = Convert.ToInt32(patientsattachment.patientsattachments_value);
                                    if (n > maxvalue)
                                        maxvalue = n;
                                }
                                catch { }
                            }
                            maxvalue++;
                            if (maxvalue == 0)
                                maxvalue++;
                            patientsattachmentsBindingSource.EndEdit();
                            ((patientsattachments)patientsattachmentsBindingSource.Current).patientsattachments_value = maxvalue.ToString();
                            patientsattachmentsBindingSource.ResetBindings(true);
                        }
                        else if (patientsattachmentstype.patientsattachmentstypes_valueautofunc == PatientsAttachmentsTypesRepository.ValueAutoFuncCode.AML.ToString())
                        {
                            int maxvalue = 0;
                            foreach (patientsattachments patientsattachment in _doctcodModel.PatientsAttachments.List(r => r.patientsattachmentstypes_id == patientsattachmentstype.patientsattachmentstypes_id && r.patients_id == patients_id))
                            {
                                try
                                {
                                    int n = Convert.ToInt32(patientsattachment.patientsattachments_value);
                                    if (n > maxvalue)
                                        maxvalue = n;
                                }
                                catch { }
                            }
                            maxvalue++;
                            if (maxvalue == 0)
                                maxvalue++;
                            patientsattachmentsBindingSource.EndEdit();
                            ((patientsattachments)patientsattachmentsBindingSource.Current).patientsattachments_value = maxvalue.ToString();
                            patientsattachmentsBindingSource.ResetBindings(true);
                        }
                        else if (patientsattachmentstype.patientsattachmentstypes_valueautofunc == PatientsAttachmentsTypesRepository.ValueAutoFuncCode.AMD.ToString())
                        {
                            int maxvalue = 0;
                            foreach (patientsattachments patientsattachment in _doctcodModel.PatientsAttachments.List(r => r.patientsattachmentstypes_id == patientsattachmentstype.patientsattachmentstypes_id && r.patients_id == patients_id && DbFunctions.TruncateTime(r.patientsattachments_date) == ((patientsattachments)patientsattachmentsBindingSource.Current).patientsattachments_date.Date))
                            {
                                try
                                {
                                    int n = Convert.ToInt32(patientsattachment.patientsattachments_value);
                                    if (n > maxvalue)
                                        maxvalue = n;
                                }
                                catch { }
                            }
                            maxvalue++;
                            if (maxvalue == 0)
                                maxvalue++;
                            patientsattachmentsBindingSource.EndEdit();
                            ((patientsattachments)patientsattachmentsBindingSource.Current).patientsattachments_value = maxvalue.ToString();
                            patientsattachmentsBindingSource.ResetBindings(true);
                        }
                    }
                }
            }
        }

        #endregion


        #region tabInvoices

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabInvoices()
        {
            object ret = null;

            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            //update totals
            double paidtotalnum = Convert.ToDouble(_doctcodModel.Invoices.List(r => r.patients_id == patients_id && r.invoices_ispaid).Sum(r => r.invoices_totaldue));
            double invoicestotalnum = Convert.ToDouble(_doctcodModel.Invoices.List(r => r.patients_id == patients_id).Sum(r => r.invoices_totaldue));
            double invoiceslefttotalnum = Convert.ToDouble(_doctcodModel.Invoices.List(r => r.patients_id == patients_id && !r.invoices_ispaid).Sum(r => r.invoices_totaldue));
            label_tabInvoices_paidtotalduevalue.Text = String.Format("{0:0.00}", paidtotalnum);
            label_tabInvoices_invoicestotalduevalue.Text = String.Format("{0:0.00}", invoicestotalnum);
            label_tabInvoices_invoiceslefttotalduevalue.Text = String.Format("{0:0.00}", invoiceslefttotalnum);

            IEnumerable<VPatientsInvoices> vPatientsInvoices =
            _doctcodModel.Invoices.List(r => r.patients_id == patients_id).Select(
            r => new VPatientsInvoices
            {
                invoices_id = r.invoices_id,
                date = r.invoices_date,
                doctor = (r.doctors_id != null ? _doctcodModel.Doctors.Find(r.doctors_id).doctors_surname + " " + _doctcodModel.Doctors.Find(r.doctors_id).doctors_name : ""),
                number = r.invoices_number,
                total = (double)r.invoices_totaldue,
                ispaid = r.invoices_ispaid
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VPatientsInvoices>(vPatientsInvoices);

            return ret;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabInvoices()
        {
            return null;
        }

        /// <summary>
        /// Invoices button view click handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabInvoices_view_Click(object sender, EventArgs e)
        {
            if (vPatientsInvoicesBindingSource.Current != null)
            {
                int invoices_id = -1;
                if (vPatientsInvoicesBindingSource.Current != null)
                {
                    invoices_id = (((DataRowView)vPatientsInvoicesBindingSource.Current).Row).Field<int>("invoices_id");
                }

                if (invoices_id != -1)
                {
                    invoices_id_toload = invoices_id;
                    FormMain mainForm = (FormMain)this.MdiParent;
                    mainForm.ShowFormProtected(mainForm, typeof(FormInvoices));
                }
            }
        }

        #endregion


        #region tabEstimates

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabEstimates()
        {
            object ret = null;

            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            //update totals
            double invoicedtotalnum = Convert.ToDouble(_doctcodModel.Estimates.List(r => r.patients_id == patients_id && r.invoices_id == null).Sum(r => r.estimates_totaldue));
            double estimatestotalnum = Convert.ToDouble(_doctcodModel.Estimates.List(r => r.patients_id == patients_id).Sum(r => r.estimates_totaldue));
            double estimateslefttotalnum = Convert.ToDouble(_doctcodModel.Estimates.List(r => r.patients_id == patients_id && r.invoices_id != null).Sum(r => r.estimates_totaldue));
            label_tabEstimates_invoicedtotalduevalue.Text = String.Format("{0:0.00}", invoicedtotalnum);
            label_tabEstimates_estimatestotalduevalue.Text = String.Format("{0:0.00}", estimatestotalnum);
            label_tabEstimates_estimateslefttotalduevalue.Text = String.Format("{0:0.00}", estimateslefttotalnum);

            IEnumerable<VPatientsEstimates> vPatientsEstimates =
            _doctcodModel.Estimates.List(r => r.patients_id == patients_id).Select(
            r => new VPatientsEstimates
            {
                estimates_id = r.estimates_id,
                date = r.estimates_date,
                doctor = (r.doctors_id != null ? _doctcodModel.Doctors.Find(r.doctors_id).doctors_surname + " " + _doctcodModel.Doctors.Find(r.doctors_id).doctors_name : ""),
                number = r.estimates_number,
                total = (double)r.estimates_totaldue,
                isinvoiced = (r.invoices_id != null ? true : false)
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VPatientsEstimates>(vPatientsEstimates);

            return ret;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabEstimates()
        {
            return null;
        }

        /// <summary>
        /// Estimates button view click handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabEstimates_view_Click(object sender, EventArgs e)
        {
            if (vPatientsEstimatesBindingSource.Current != null)
            {
                int estimates_id = -1;
                if (vPatientsEstimatesBindingSource.Current != null)
                {
                    estimates_id = (((DataRowView)vPatientsEstimatesBindingSource.Current).Row).Field<int>("estimates_id");
                }

                if (estimates_id != -1)
                {
                    estimates_id_toload = estimates_id;
                    FormMain mainForm = (FormMain)this.MdiParent;
                    mainForm.ShowFormProtected(mainForm, typeof(FormEstimates));
                }
            }
        }

        #endregion


        #region tabPatientsNotes

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabPatientsNotes()
        {
            object ret = null;

            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            IEnumerable<VPatientsNotes> vPatientsNotes =
            _doctcodModel.PatientsNotes.List(r => r.patients_id == patients_id).Select(
            r => new VPatientsNotes
            {
                patientsnotes_id = r.patientsnotes_id,
                date = r.patientsnotes_date,
                note = (r.patientsnotes_text.Length > MaxRowValueLength ? r.patientsnotes_text.Substring(0, MaxRowValueLength) + "..." : r.patientsnotes_text)
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VPatientsNotes>(vPatientsNotes);

            return ret;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabPatientsNotes()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<patientsnotes, DoctcoDModel>(_doctcodModel.PatientsNotes, vPatientsNotesBindingSource, new string[] { "patientsnotes_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabPatientsNotes(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<patientsnotes, DoctcoDModel>(_doctcodModel.PatientsNotes, item, vPatientsNotesBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabPatientsNotes(object item)
        {
            DGUIGHFData.Add<patientsnotes, DoctcoDModel>(_doctcodModel.PatientsNotes, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabPatientsNotes(object item)
        {
            DGUIGHFData.Update<patientsnotes, DoctcoDModel>(_doctcodModel.PatientsNotes, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabPatientsNotes(object item)
        {
            DGUIGHFData.Remove<patientsnotes, DoctcoDModel>(_doctcodModel.PatientsNotes, item);
        }

        /// <summary>
        /// New tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsNotes_new_Click(object sender, EventArgs e)
        {
            if (vPatientsBindingSource.Current != null)
            {
                if (AddClick(tabElement_tabPatientsNotes))
                {
                    ((patientsnotes)patientsnotesBindingSource.Current).patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
                    ((patientsnotes)patientsnotesBindingSource.Current).patientsnotes_date = DateTime.Now;
                    patientsnotesBindingSource.ResetBindings(true);
                }
            }
        }

        #endregion


        #region tabPatientsAttributes

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabPatientsAttributes()
        {
            object ret = null;

            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            IEnumerable<VPatientsAttributes> vPatientsAttributes =
            _doctcodModel.PatientsAttributes.List(r => r.patients_id == patients_id).Select(
            r => new VPatientsAttributes
            {
                patientsattributes_id = r.patientsattributes_id,
                attributestype = _doctcodModel.PatientsAttributesTypes.Find(r.patientsattributestypes_id).patientsattributestypes_name,
                value = (!String.IsNullOrEmpty(r.patientsattributes_value) ? (r.patientsattributes_value.Length > MaxRowValueLength ? r.patientsattributes_value.Substring(0, MaxRowValueLength) + "..." : r.patientsattributes_value) : null)
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VPatientsAttributes>(vPatientsAttributes);

            return ret;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabPatientsAttributes()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<patientsattributes, DoctcoDModel>(_doctcodModel.PatientsAttributes, vPatientsAttributesBindingSource, new string[] { "patientsattributes_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabPatientsAttributes(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<patientsattributes, DoctcoDModel>(_doctcodModel.PatientsAttributes, item, vPatientsAttributesBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabPatientsAttributes(object item)
        {
            DGUIGHFData.Add<patientsattributes, DoctcoDModel>(_doctcodModel.PatientsAttributes, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabPatientsAttributes(object item)
        {
            DGUIGHFData.Update<patientsattributes, DoctcoDModel>(_doctcodModel.PatientsAttributes, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabPatientsAttributes(object item)
        {
            DGUIGHFData.Remove<patientsattributes, DoctcoDModel>(_doctcodModel.PatientsAttributes, item);
        }

        /// <summary>
        /// New tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsAttributes_new_Click(object sender, EventArgs e)
        {
            if (vPatientsBindingSource.Current != null)
            {
                if (AddClick(tabElement_tabPatientsAttributes))
                {
                    ((patientsattributes)patientsattributesBindingSource.Current).patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
                    patientsattributesBindingSource.ResetBindings(true);
                }
            }
        }

        #endregion
    }
}
