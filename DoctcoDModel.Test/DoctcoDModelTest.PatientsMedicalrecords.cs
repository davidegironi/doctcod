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
        public void PatientsMedicalrecords_Test1()
        {
            string[] errors = new string[] { };
            patients t_patients = null;
            medicalrecordstypes t_medicalrecordstypes = null;
            patientsmedicalrecords t_patientsmedicalrecords = null;

            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _doctcodModel.MedicalrecordsTypes.Remove(_doctcodModel.MedicalrecordsTypes.List(r => r.medicalrecordstypes_name == "XX1").ToArray());

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

            t_medicalrecordstypes = new medicalrecordstypes()
            {
                medicalrecordstypes_name = "XX1"
            };
            _doctcodModel.MedicalrecordsTypes.Add(t_medicalrecordstypes);

            t_patientsmedicalrecords = new patientsmedicalrecords()
            {
                //patients_id = t_patients.patients_id,
                medicalrecordstypes_id = t_medicalrecordstypes.medicalrecordstypes_id,
                patientsmedicalrecords_value = "ttt"
            };
            Assert.IsFalse(_doctcodModel.PatientsMedicalrecords.CanAdd(t_patientsmedicalrecords));

            t_patientsmedicalrecords = new patientsmedicalrecords()
            {
                patients_id = t_patients.patients_id,
                //medicalrecordstypes_id = t_medicalrecordstypes.medicalrecordstypes_id,
                patientsmedicalrecords_value = "ttt"
            };
            Assert.IsFalse(_doctcodModel.PatientsMedicalrecords.CanAdd(t_patientsmedicalrecords));

            t_patientsmedicalrecords = new patientsmedicalrecords()
            {
                patients_id = t_patients.patients_id,
                medicalrecordstypes_id = t_medicalrecordstypes.medicalrecordstypes_id,
                patientsmedicalrecords_value = "ttt"
            };
            Assert.IsTrue(_doctcodModel.PatientsMedicalrecords.CanAdd(t_patientsmedicalrecords));
            _doctcodModel.PatientsMedicalrecords.Add(t_patientsmedicalrecords);

            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _doctcodModel.MedicalrecordsTypes.Remove(_doctcodModel.MedicalrecordsTypes.List(r => r.medicalrecordstypes_name == "XX1").ToArray());
        }
    }
}
