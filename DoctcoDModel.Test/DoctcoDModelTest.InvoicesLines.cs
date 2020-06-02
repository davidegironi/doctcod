﻿#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.DoctcoD.Model.Entity;
using NUnit.Framework;
using System;
using System.Linq;

namespace DG.DoctcoD.Model.Test
{
    [TestFixture]
    public partial class DoctcoDModelTest
    {
        [Test]
        public void InvoicesLines_Test1()
        {
            DateTime today = DateTime.Now;

            string[] errors = new string[] { };
            invoices t_invoices = null;
            doctors t_doctors = null;
            patients t_patients = null;
            invoiceslines t_invoiceslines = null;
            treatments t_treatments = null;
            treatmentstypes t_treatmentstypes = null;
            patientstreatments t_patientstreatments = null;

            _doctcodModel.Invoices.Remove(_doctcodModel.Invoices.List(r => r.invoices_number == "XX1" && r.invoices_date == today.Date).ToArray());
            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _doctcodModel.Doctors.Remove(_doctcodModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").ToArray());
            _doctcodModel.Treatments.Remove(_doctcodModel.Treatments.List(r => r.treatments_code == "XX1").ToArray());
            _doctcodModel.TreatmentsTypes.Remove(_doctcodModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray());

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1236",
                doctors_password = "123456"
            };
            _doctcodModel.Doctors.Add(t_doctors);

            t_patients = new patients()
            {
                patients_name = "XX1",
                patients_surname = "XX1",
                patients_birthdate = DateTime.Now,
                patients_birthcity = "xxx",
                patients_doctext = "xxx",
                patients_sex = "M",
                patients_username = "xxxx1234",
                patients_password = "123456"
            };
            _doctcodModel.Patients.Add(t_patients);

            t_treatmentstypes = new treatmentstypes()
            {
                treatmentstypes_name = "XX1"
            };
            _doctcodModel.TreatmentsTypes.Add(t_treatmentstypes);

            t_treatments = new treatments()
            {
                treatmentstypes_id = t_treatmentstypes.treatmentstypes_id,
                treatments_code = "XX1",
                treatments_name = "XX1",
                treatments_price = 10
            };
            _doctcodModel.Treatments.Add(t_treatments);

            t_patientstreatments = new patientstreatments()
            {
                doctors_id = t_doctors.doctors_id,
                patients_id = t_patients.patients_id,
                treatments_id = t_treatments.treatments_id,
                patientstreatments_creationdate = DateTime.Now,
                patientstreatments_price = 10
            };
            _doctcodModel.PatientsTreatments.Add(t_patientstreatments);

            t_invoices = new invoices()
            {
                invoices_date = today,
                invoices_number = "XX1",
                doctors_id = t_doctors.doctors_id,
                patients_id = t_patients.patients_id,
                invoices_doctor = "test",
                invoices_patient = "patient",
                invoices_footer = "footer",
                invoices_payment = "payment",
                invoices_totalnet = 0,
                invoices_totalgross = 0,
                invoices_totaldue = 0,
                invoices_deductiontaxrate = 20
            };
            _doctcodModel.Invoices.Add(t_invoices);

            t_invoiceslines = new invoiceslines()
            {
                invoices_id = t_invoices.invoices_id,
                invoiceslines_code = "XXX",
                invoiceslines_description = "test",
                invoiceslines_quantity = 1,
                invoiceslines_unitprice = 10,
                invoiceslines_taxrate = 22,
                invoiceslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsTrue(_doctcodModel.InvoicesLines.CanAdd(t_invoiceslines));

            t_invoiceslines = new invoiceslines()
            {
                //invoices_id = t_invoices.invoices_id,
                invoiceslines_code = "XXX",
                invoiceslines_description = "test",
                invoiceslines_quantity = 1,
                invoiceslines_unitprice = 10,
                invoiceslines_taxrate = 22,
                invoiceslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsFalse(_doctcodModel.InvoicesLines.CanAdd(t_invoiceslines));

            t_invoiceslines = new invoiceslines()
            {
                invoices_id = t_invoices.invoices_id,
                //invoiceslines_code = "XXX",
                invoiceslines_description = "test",
                invoiceslines_quantity = 1,
                invoiceslines_unitprice = 10,
                invoiceslines_taxrate = 22,
                invoiceslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsFalse(_doctcodModel.InvoicesLines.CanAdd(t_invoiceslines));

            t_invoiceslines = new invoiceslines()
            {
                invoices_id = t_invoices.invoices_id,
                invoiceslines_code = "XXX",
                //invoiceslines_description = "test",
                invoiceslines_quantity = 1,
                invoiceslines_unitprice = 10,
                invoiceslines_taxrate = 22,
                invoiceslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsFalse(_doctcodModel.InvoicesLines.CanAdd(t_invoiceslines));

            t_invoiceslines = new invoiceslines()
            {
                invoices_id = t_invoices.invoices_id,
                invoiceslines_code = "XXX",
                invoiceslines_description = "test",
                invoiceslines_quantity = -1,
                invoiceslines_unitprice = 10,
                invoiceslines_taxrate = 22,
                invoiceslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsFalse(_doctcodModel.InvoicesLines.CanAdd(t_invoiceslines));

            t_invoiceslines = new invoiceslines()
            {
                invoices_id = t_invoices.invoices_id,
                invoiceslines_code = "XXX",
                invoiceslines_description = "test",
                invoiceslines_quantity = 1,
                invoiceslines_unitprice = 10,
                invoiceslines_taxrate = 22,
                invoiceslines_istaxesdeductionsable = true,
                patientstreatments_id = -999
            };
            Assert.IsFalse(_doctcodModel.InvoicesLines.CanAdd(t_invoiceslines));

            t_invoiceslines = new invoiceslines()
            {
                invoices_id = t_invoices.invoices_id,
                invoiceslines_code = "XXX",
                invoiceslines_description = "test",
                invoiceslines_quantity = 1,
                invoiceslines_unitprice = 10,
                invoiceslines_taxrate = 22,
                invoiceslines_istaxesdeductionsable = true,
                //patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsTrue(_doctcodModel.InvoicesLines.CanAdd(t_invoiceslines));

            t_invoiceslines = new invoiceslines()
            {
                invoices_id = t_invoices.invoices_id,
                invoiceslines_code = "XXX",
                invoiceslines_description = "test",
                invoiceslines_quantity = 1,
                invoiceslines_unitprice = 10,
                invoiceslines_taxrate = 22,
                invoiceslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsTrue(_doctcodModel.InvoicesLines.CanAdd(t_invoiceslines));
            _doctcodModel.InvoicesLines.Add(t_invoiceslines);

            t_invoiceslines = new invoiceslines()
            {
                invoices_id = t_invoices.invoices_id,
                invoiceslines_code = "XXY",
                invoiceslines_description = "test",
                invoiceslines_quantity = 2,
                invoiceslines_unitprice = 12,
                invoiceslines_taxrate = 22,
                invoiceslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsTrue(_doctcodModel.InvoicesLines.CanAdd(t_invoiceslines));
            _doctcodModel.InvoicesLines.Add(t_invoiceslines);

            t_invoiceslines = new invoiceslines()
            {
                invoices_id = t_invoices.invoices_id,
                invoiceslines_code = "XXY",
                invoiceslines_description = "test",
                invoiceslines_quantity = 1,
                invoiceslines_unitprice = -10,
                invoiceslines_taxrate = 22,
                invoiceslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsTrue(_doctcodModel.InvoicesLines.CanAdd(t_invoiceslines));
            _doctcodModel.InvoicesLines.Add(t_invoiceslines);

            t_invoiceslines = new invoiceslines()
            {
                invoices_id = t_invoices.invoices_id,
                invoiceslines_code = "XXY",
                invoiceslines_description = "test",
                invoiceslines_quantity = 1,
                invoiceslines_unitprice = -25,
                invoiceslines_taxrate = 22,
                invoiceslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsFalse(_doctcodModel.InvoicesLines.CanAdd(t_invoiceslines));

            t_invoiceslines = _doctcodModel.InvoicesLines.FirstOrDefault(r => r.invoiceslines_code == "XXX");
            t_invoiceslines.patientstreatments_id = -999;
            Assert.IsFalse(_doctcodModel.InvoicesLines.CanUpdate(t_invoiceslines));
            t_invoiceslines.patientstreatments_id = null;
            Assert.IsTrue(_doctcodModel.InvoicesLines.CanUpdate(t_invoiceslines));

            _doctcodModel.Invoices.Remove(_doctcodModel.Invoices.List(r => r.invoices_number == "XX1" && r.invoices_date == today.Date).ToArray());
            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _doctcodModel.Doctors.Remove(_doctcodModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").ToArray());
            _doctcodModel.Treatments.Remove(_doctcodModel.Treatments.List(r => r.treatments_code == "XX1").ToArray());
            _doctcodModel.TreatmentsTypes.Remove(_doctcodModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray());
        }

    }
}
