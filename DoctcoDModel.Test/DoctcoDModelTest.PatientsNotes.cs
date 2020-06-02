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
        public void PatientsNotes_Test1()
        {
            string[] errors = new string[] { };
            patients t_patients = null;
            patientsnotes t_patientsnotes = null;

            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());

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

            t_patientsnotes = new patientsnotes()
            {
                //patients_id = t_patients.patients_id
                patientsnotes_text = "XX",
                patientsnotes_date = DateTime.Now
            };
            Assert.IsFalse(_doctcodModel.PatientsNotes.CanAdd(t_patientsnotes));

            t_patientsnotes = new patientsnotes()
            {
                patients_id = t_patients.patients_id,
                //contactstypes_id = t_contactstypes.contactstypes_id,
                patientsnotes_date = DateTime.Now
            };
            Assert.IsFalse(_doctcodModel.PatientsNotes.CanAdd(t_patientsnotes));

            t_patientsnotes = new patientsnotes()
            {
                patients_id = t_patients.patients_id,
                patientsnotes_text = "XX",
                patientsnotes_date = DateTime.Now
            };
            Assert.IsTrue(_doctcodModel.PatientsNotes.CanAdd(t_patientsnotes));
            _doctcodModel.PatientsNotes.Add(t_patientsnotes);

            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
        }
    }
}
