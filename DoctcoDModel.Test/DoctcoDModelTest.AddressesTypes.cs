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
        public void AddressesTypes_Test1()
        {
            string[] errors = new string[] { };
            addressestypes t_addressestypes = null;

            _doctcodModel.AddressesTypes.Remove(_doctcodModel.AddressesTypes.List(r => r.addressestypes_name == "XX1").ToArray());
            _doctcodModel.AddressesTypes.Remove(_doctcodModel.AddressesTypes.List(r => r.addressestypes_name == "XX2").ToArray());

            t_addressestypes = new addressestypes()
            {
                //addressestypes_name = "XX1"
            };
            Assert.IsFalse(_doctcodModel.AddressesTypes.CanAdd(t_addressestypes));

            t_addressestypes = new addressestypes()
            {
                addressestypes_name = "XX1"
            };
            Assert.IsTrue(_doctcodModel.AddressesTypes.CanAdd(t_addressestypes));
            _doctcodModel.AddressesTypes.Add(t_addressestypes);

            t_addressestypes = new addressestypes()
            {
                addressestypes_name = "XX1"
            };
            Assert.IsFalse(_doctcodModel.AddressesTypes.CanAdd(t_addressestypes));

            t_addressestypes = new addressestypes()
            {
                addressestypes_name = "XX2"
            };
            _doctcodModel.AddressesTypes.Add(t_addressestypes);

            t_addressestypes = _doctcodModel.AddressesTypes.FirstOrDefault(r => r.addressestypes_name == "XX1");
            t_addressestypes.addressestypes_name = "XX2";
            Assert.IsFalse(_doctcodModel.AddressesTypes.CanUpdate(t_addressestypes));
            t_addressestypes.addressestypes_name = "XX3";
            Assert.IsTrue(_doctcodModel.AddressesTypes.CanUpdate(t_addressestypes));

            _doctcodModel.AddressesTypes.Remove(_doctcodModel.AddressesTypes.List(r => r.addressestypes_name == "XX1").ToArray());
            _doctcodModel.AddressesTypes.Remove(_doctcodModel.AddressesTypes.List(r => r.addressestypes_name == "XX2").ToArray());
        }

        [Test]
        public void AddressesTypes_Test2()
        {
            string[] errors = new string[] { };
            patients t_patients = null;
            addressestypes t_addressestypes = null;
            patientsaddresses t_patientsaddresses = null;

            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _doctcodModel.AddressesTypes.Remove(_doctcodModel.AddressesTypes.List(r => r.addressestypes_name == "XX1").ToArray());

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

            t_addressestypes = new addressestypes()
            {
                addressestypes_name = "XX1"
            };
            _doctcodModel.AddressesTypes.Add(t_addressestypes);

            t_patientsaddresses = new patientsaddresses()
            {
                patients_id = t_patients.patients_id,
                addressestypes_id = t_addressestypes.addressestypes_id,
                patientsaddresses_state = "XX",
                patientsaddresses_city = "XX",
                patientsaddresses_street = "XX",
                patientsaddresses_zipcode = "XX"
            };
            _doctcodModel.PatientsAddresses.Add(t_patientsaddresses);

            Assert.IsFalse(_doctcodModel.AddressesTypes.CanRemove(_doctcodModel.AddressesTypes.List(r => r.addressestypes_name == "XX1").ToArray()));

            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());

            Assert.IsTrue(_doctcodModel.AddressesTypes.CanRemove(_doctcodModel.AddressesTypes.List(r => r.addressestypes_name == "XX1").ToArray()));

            _doctcodModel.AddressesTypes.Remove(_doctcodModel.AddressesTypes.List(r => r.addressestypes_name == "XX1").ToArray());
        }
    }
}
