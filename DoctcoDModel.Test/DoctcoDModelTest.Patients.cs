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
        public void Patients_Test1()
        {
            string[] errors = new string[] { };
            patients t_patients = null;

            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());

            t_patients = new patients()
            {
                //patients_name = "XX1",
                patients_surname = "XX1",
                patients_birthdate = DateTime.Now,
                patients_birthcity = "xxx",
                patients_doctext = "xxx",
                patients_sex = "M",
                patients_username = "xxxx1234",
                patients_password = "123456"
            };
            Assert.IsFalse(_doctcodModel.Patients.CanAdd(t_patients));

            t_patients = new patients()
            {
                patients_name = "XX1",
                //patients_surname = "XX1",
                patients_birthdate = DateTime.Now,
                patients_birthcity = "xxx",
                patients_doctext = "xxx",
                patients_sex = "M",
                patients_username = "xxxx1234",
                patients_password = "123456"
            };
            Assert.IsFalse(_doctcodModel.Patients.CanAdd(t_patients));

            t_patients = new patients()
            {
                patients_name = "XX1",
                patients_surname = "XX1",
                patients_birthdate = DateTime.Now,
                //patients_birthcity = "xxx",
                patients_doctext = "xxx",
                patients_sex = "M",
                patients_username = "xxxx1234",
                patients_password = "123456"
            };
            Assert.IsFalse(_doctcodModel.Patients.CanAdd(t_patients));

            t_patients = new patients()
            {
                patients_name = "XX1",
                patients_surname = "XX1",
                patients_birthdate = DateTime.Now,
                patients_birthcity = "xxx",
                //patients_doctext = "xxx",
                patients_sex = "M",
                patients_username = "xxxx1234",
                patients_password = "123456"
            };
            Assert.IsFalse(_doctcodModel.Patients.CanAdd(t_patients));

            t_patients = new patients()
            {
                patients_name = "XX1",
                patients_surname = "XX1",
                patients_birthdate = DateTime.Now,
                patients_birthcity = "xxx",
                patients_doctext = "xxx",
                patients_sex = "X",
                patients_username = "xxxx1234",
                patients_password = "123456"
            };
            Assert.IsFalse(_doctcodModel.Patients.CanAdd(t_patients));

            t_patients = new patients()
            {
                patients_name = "XX1",
                patients_surname = "XX1",
                patients_birthdate = DateTime.Now,
                patients_birthcity = "xxx",
                patients_doctext = "xxx",
                patients_sex = "M",
                treatmentspriceslists_id = -1,
                patients_username = "xxxx1234",
                patients_password = "123456"
            };
            Assert.IsFalse(_doctcodModel.Patients.CanAdd(t_patients));

            t_patients = new patients()
            {
                patients_name = "XX1",
                patients_surname = "XX1",
                patients_birthdate = DateTime.Now,
                patients_birthcity = "xxx",
                patients_doctext = "xxx",
                patients_sex = "M",
                //patients_username = "xxxx1234",
                patients_password = "123456"
            };
            Assert.IsFalse(_doctcodModel.Patients.CanAdd(t_patients));

            t_patients = new patients()
            {
                patients_name = "XX1",
                patients_surname = "XX1",
                patients_birthdate = DateTime.Now,
                patients_birthcity = "xxx",
                patients_doctext = "xxx",
                patients_sex = "M",
                patients_username = "xxxx1234",
                //patients_password = "123456"
            };
            Assert.IsFalse(_doctcodModel.Patients.CanAdd(t_patients));

            t_patients = new patients()
            {
                patients_name = "XX1",
                patients_surname = "XX1",
                patients_birthdate = DateTime.Now,
                patients_birthcity = "xxx",
                patients_doctext = "xxx",
                patients_sex = "M",
                patients_username = "xXxx1234",
                patients_password = "123456"
            };
            Assert.IsFalse(_doctcodModel.Patients.CanAdd(t_patients));

            t_patients = new patients()
            {
                patients_name = "XX1",
                patients_surname = "XX1",
                patients_birthdate = DateTime.Now,
                patients_birthcity = "xxx",
                patients_doctext = "xxx",
                patients_sex = "M",
                patients_username = "xxxx1234",
                patients_password = "X23456"
            };
            Assert.IsFalse(_doctcodModel.Patients.CanAdd(t_patients));

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
            Assert.IsTrue(_doctcodModel.Patients.CanAdd(t_patients));
            _doctcodModel.Patients.Add(t_patients);

            t_patients = new patients()
            {
                patients_name = "XX2",
                patients_surname = "XX2",
                patients_birthdate = DateTime.Now,
                patients_birthcity = "xxx",
                patients_doctext = "xxx",
                patients_sex = "M",
                patients_username = "xxxx1234",
                patients_password = "123456"
            };
            Assert.IsFalse(_doctcodModel.Patients.CanAdd(t_patients));

            t_patients = new patients()
            {
                patients_name = "XX2",
                patients_surname = "XX2",
                patients_birthdate = DateTime.Now,
                patients_birthcity = "xxx",
                patients_doctext = "xxx",
                patients_sex = "M",
                patients_username = "xxxx1235",
                patients_password = "123456"
            };
            Assert.IsTrue(_doctcodModel.Patients.CanAdd(t_patients));

            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
        }
    }
}
