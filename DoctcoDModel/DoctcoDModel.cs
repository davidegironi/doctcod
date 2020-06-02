﻿#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.Data.Model;
using DG.DoctcoD.Model.Entity;
using DG.DoctcoD.Model.Repositories;
using System;

namespace DG.DoctcoD.Model
{
    public class DoctcoDModel : GenericDataModel
    {
        //Repositories
        public DoctorsRepository Doctors { get; private set; }
        public RoomsRepository Rooms { get; private set; }
        public TaxesRepository Taxes { get; private set; }
        public TaxesDeductionsRepository TaxesDeductions { get; private set; }
        public ComputedLinesRepository ComputedLines { get; private set; }
        public TreatmentsTypesRepository TreatmentsTypes { get; private set; }
        public TreatmentsPricesListsRepository TreatmentsPricesLists { get; private set; }
        public TreatmentsRepository Treatments { get; private set; }
        public TreatmentsPricesRepository TreatmentsPrices { get; private set; }
        public PaymentsTypesRepository PaymentsTypes { get; private set; }
        public InvoicesFootersRepository InvoicesFooters { get; private set; }
        public EstimatesFootersRepository EstimatesFooters { get; private set; }
        public AddressesTypesRepository AddressesTypes { get; private set; }
        public ContactsTypesRepository ContactsTypes { get; private set; }
        public MedicalrecordsTypesRepository MedicalrecordsTypes { get; private set; }
        public PatientsAttachmentsTypesRepository PatientsAttachmentsTypes { get; private set; }
        public PatientsAttributesTypesRepository PatientsAttributesTypes { get; private set; }
        public PatientsAttributesRepository PatientsAttributes { get; private set; }
        public PatientsRepository Patients { get; private set; }
        public PatientsAddressesRepository PatientsAddresses { get; private set; }
        public PatientsContactsRepository PatientsContacts { get; private set; }
        public PatientsMedicalrecordsRepository PatientsMedicalrecords { get; private set; }
        public PatientsAttachmentsRepository PatientsAttachments { get; private set; }
        public PatientsNotesRepository PatientsNotes { get; private set; }
        public AppointmentsRepository Appointments { get; private set; }
        public PatientsTreatmentsRepository PatientsTreatments { get; private set; }
        public PaymentsRepository Payments { get; private set; }
        public InvoicesRepository Invoices { get; private set; }
        public InvoicesLinesRepository InvoicesLines { get; private set; }
        public EstimatesRepository Estimates { get; private set; }
        public EstimatesLinesRepository EstimatesLines { get; private set; }
        public ReportsRepository Reports { get; private set; }
        public DescriptiontemplatesTreatmentsRepository DescriptiontemplatesTreatments { get; private set; }

        /// <summary>
        /// Initialize the Model
        /// </summary>
        public DoctcoDModel()
            : base()
        {
            Type contextType = typeof(doctcodEntities);
            object[] contextParameters = null;

            Initialize(contextType, contextParameters);
        }
    }
}
