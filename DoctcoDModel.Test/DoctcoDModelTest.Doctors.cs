#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.DoctcoD.Model.Entity;
using NUnit.Framework;
using System.Linq;

namespace DG.DoctcoD.Model.Test
{
    [TestFixture]
    public partial class DoctcoDModelTest
    {
        [Test]
        public void Doctors_Test1()
        {
            string[] errors = new string[] { };
            doctors t_doctors = null;

            _doctcodModel.Doctors.Remove(_doctcodModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").ToArray());
            _doctcodModel.Doctors.Remove(_doctcodModel.Doctors.List(r => r.doctors_name == "XX2" && r.doctors_surname == "XX2").ToArray());

            t_doctors = new doctors()
            {
                //doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1234",
                doctors_password = "123456"
            };
            Assert.IsFalse(_doctcodModel.Doctors.CanAdd(t_doctors));

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                //doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1234",
                doctors_password = "123456"
            };
            Assert.IsFalse(_doctcodModel.Doctors.CanAdd(t_doctors));

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                //doctors_doctext = "XXXXX",
                doctors_username = "xxxx1234",
                doctors_password = "123456"
            };
            Assert.IsFalse(_doctcodModel.Doctors.CanAdd(t_doctors));

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                //doctors_username = "xxxx1234",
                doctors_password = "123456"
            };
            Assert.IsFalse(_doctcodModel.Doctors.CanAdd(t_doctors));

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1234",
                //doctors_password = "123456"
            };
            Assert.IsFalse(_doctcodModel.Doctors.CanAdd(t_doctors));

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xXxx1234",
                doctors_password = "123456"
            };
            Assert.IsFalse(_doctcodModel.Doctors.CanAdd(t_doctors));

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1234",
                doctors_password = "X23456"
            };
            Assert.IsFalse(_doctcodModel.Doctors.CanAdd(t_doctors));

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1234",
                doctors_password = "123456"
            };
            Assert.IsTrue(_doctcodModel.Doctors.CanAdd(t_doctors));
            _doctcodModel.Doctors.Add(t_doctors);

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1234",
                doctors_password = "123456"
            };
            Assert.IsFalse(_doctcodModel.Doctors.CanAdd(t_doctors));

            t_doctors = new doctors()
            {
                doctors_name = "XX2",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1234",
                doctors_password = "123456"
            };
            Assert.IsFalse(_doctcodModel.Doctors.CanAdd(t_doctors));

            t_doctors = new doctors()
            {
                doctors_name = "XX2",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1235",
                doctors_password = "123456"
            };
            Assert.IsTrue(_doctcodModel.Doctors.CanAdd(t_doctors));

            t_doctors = new doctors()
            {
                doctors_name = "XX2",
                doctors_surname = "XX2",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1235",
                doctors_password = "123456"
            };
            _doctcodModel.Doctors.Add(t_doctors);

            t_doctors = _doctcodModel.Doctors.FirstOrDefault(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1");
            t_doctors.doctors_name = "XX2";
            t_doctors.doctors_surname = "XX2";
            Assert.IsFalse(_doctcodModel.Doctors.CanUpdate(t_doctors));
            t_doctors.doctors_name = "XX3";
            t_doctors.doctors_surname = "XX3";
            Assert.IsTrue(_doctcodModel.Doctors.CanUpdate(t_doctors));

            _doctcodModel.Doctors.Remove(_doctcodModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").ToArray());
            _doctcodModel.Doctors.Remove(_doctcodModel.Doctors.List(r => r.doctors_name == "XX2" && r.doctors_surname == "XX2").ToArray());
        }
    }
}
