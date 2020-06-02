#region License
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
        public void EstimatesLines_Test1()
        {
            DateTime today = DateTime.Now;

            string[] errors = new string[] { };
            estimates t_estimates = null;
            doctors t_doctors = null;
            patients t_patients = null;
            estimateslines t_estimateslines = null;
            treatments t_treatments = null;
            treatmentstypes t_treatmentstypes = null;
            patientstreatments t_patientstreatments = null;

            _doctcodModel.Estimates.Remove(_doctcodModel.Estimates.List(r => r.estimates_number == "XX1" && r.estimates_date == today.Date).ToArray());
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

            t_estimates = new estimates()
            {
                estimates_date = today,
                estimates_number = "XX1",
                doctors_id = t_doctors.doctors_id,
                patients_id = t_patients.patients_id,
                estimates_doctor = "test",
                estimates_patient = "patient",
                estimates_footer = "footer",
                estimates_payment = "payment",
                estimates_totalnet = 0,
                estimates_totalgross = 0,
                estimates_totaldue = 0,
                estimates_deductiontaxrate = 20
            };
            _doctcodModel.Estimates.Add(t_estimates);

            t_estimateslines = new estimateslines()
            {
                estimates_id = t_estimates.estimates_id,
                estimateslines_code = "XXX",
                estimateslines_description = "test",
                estimateslines_quantity = 1,
                estimateslines_unitprice = 10,
                estimateslines_taxrate = 22,
                estimateslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsTrue(_doctcodModel.EstimatesLines.CanAdd(t_estimateslines));

            t_estimateslines = new estimateslines()
            {
                //estimates_id = t_estimates.estimates_id,
                estimateslines_code = "XXX",
                estimateslines_description = "test",
                estimateslines_quantity = 1,
                estimateslines_unitprice = 10,
                estimateslines_taxrate = 22,
                estimateslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsFalse(_doctcodModel.EstimatesLines.CanAdd(t_estimateslines));

            t_estimateslines = new estimateslines()
            {
                estimates_id = t_estimates.estimates_id,
                //estimateslines_code = "XXX",
                estimateslines_description = "test",
                estimateslines_quantity = 1,
                estimateslines_unitprice = 10,
                estimateslines_taxrate = 22,
                estimateslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsFalse(_doctcodModel.EstimatesLines.CanAdd(t_estimateslines));

            t_estimateslines = new estimateslines()
            {
                estimates_id = t_estimates.estimates_id,
                estimateslines_code = "XXX",
                //estimateslines_description = "test",
                estimateslines_quantity = 1,
                estimateslines_unitprice = 10,
                estimateslines_taxrate = 22,
                estimateslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsFalse(_doctcodModel.EstimatesLines.CanAdd(t_estimateslines));

            t_estimateslines = new estimateslines()
            {
                estimates_id = t_estimates.estimates_id,
                estimateslines_code = "XXX",
                estimateslines_description = "test",
                estimateslines_quantity = -1,
                estimateslines_unitprice = 10,
                estimateslines_taxrate = 22,
                estimateslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsFalse(_doctcodModel.EstimatesLines.CanAdd(t_estimateslines));

            t_estimateslines = new estimateslines()
            {
                estimates_id = t_estimates.estimates_id,
                estimateslines_code = "XXX",
                estimateslines_description = "test",
                estimateslines_quantity = 1,
                estimateslines_unitprice = 10,
                estimateslines_taxrate = 22,
                estimateslines_istaxesdeductionsable = true,
                patientstreatments_id = -999
            };
            Assert.IsFalse(_doctcodModel.EstimatesLines.CanAdd(t_estimateslines));

            t_estimateslines = new estimateslines()
            {
                estimates_id = t_estimates.estimates_id,
                estimateslines_code = "XXX",
                estimateslines_description = "test",
                estimateslines_quantity = 1,
                estimateslines_unitprice = 10,
                estimateslines_taxrate = 22,
                estimateslines_istaxesdeductionsable = true,
                //patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsTrue(_doctcodModel.EstimatesLines.CanAdd(t_estimateslines));

            t_estimateslines = new estimateslines()
            {
                estimates_id = t_estimates.estimates_id,
                estimateslines_code = "XXX",
                estimateslines_description = "test",
                estimateslines_quantity = 1,
                estimateslines_unitprice = 10,
                estimateslines_taxrate = 22,
                estimateslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsTrue(_doctcodModel.EstimatesLines.CanAdd(t_estimateslines));
            _doctcodModel.EstimatesLines.Add(t_estimateslines);

            t_estimateslines = new estimateslines()
            {
                estimates_id = t_estimates.estimates_id,
                estimateslines_code = "XXY",
                estimateslines_description = "test",
                estimateslines_quantity = 2,
                estimateslines_unitprice = 12,
                estimateslines_taxrate = 22,
                estimateslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsTrue(_doctcodModel.EstimatesLines.CanAdd(t_estimateslines));
            _doctcodModel.EstimatesLines.Add(t_estimateslines);

            t_estimateslines = new estimateslines()
            {
                estimates_id = t_estimates.estimates_id,
                estimateslines_code = "XXY",
                estimateslines_description = "test",
                estimateslines_quantity = 1,
                estimateslines_unitprice = -10,
                estimateslines_taxrate = 22,
                estimateslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsTrue(_doctcodModel.EstimatesLines.CanAdd(t_estimateslines));
            _doctcodModel.EstimatesLines.Add(t_estimateslines);

            t_estimateslines = new estimateslines()
            {
                estimates_id = t_estimates.estimates_id,
                estimateslines_code = "XXY",
                estimateslines_description = "test",
                estimateslines_quantity = 1,
                estimateslines_unitprice = -25,
                estimateslines_taxrate = 22,
                estimateslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsFalse(_doctcodModel.EstimatesLines.CanAdd(t_estimateslines));

            t_estimateslines = _doctcodModel.EstimatesLines.FirstOrDefault(r => r.estimateslines_code == "XXX");
            t_estimateslines.patientstreatments_id = -999;
            Assert.IsFalse(_doctcodModel.EstimatesLines.CanUpdate(t_estimateslines));
            t_estimateslines.patientstreatments_id = null;
            Assert.IsTrue(_doctcodModel.EstimatesLines.CanUpdate(t_estimateslines));

            _doctcodModel.Estimates.Remove(_doctcodModel.Estimates.List(r => r.estimates_number == "XX1" && r.estimates_date == today.Date).ToArray());
            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _doctcodModel.Doctors.Remove(_doctcodModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").ToArray());
            _doctcodModel.Treatments.Remove(_doctcodModel.Treatments.List(r => r.treatments_code == "XX1").ToArray());
            _doctcodModel.TreatmentsTypes.Remove(_doctcodModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray());
        }

    }
}
