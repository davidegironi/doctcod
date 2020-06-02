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
        public void Rooms_Test1()
        {
            string[] errors = new string[] { };
            rooms t_rooms = null;

            _doctcodModel.Rooms.Remove(_doctcodModel.Rooms.List(r => r.rooms_name == "XX1").ToArray());
            _doctcodModel.Rooms.Remove(_doctcodModel.Rooms.List(r => r.rooms_name == "XX2").ToArray());

            t_rooms = new rooms()
            {
                //rooms_name = "XX1",
                rooms_color = "#dddddd"
            };
            Assert.IsFalse(_doctcodModel.Rooms.CanAdd(t_rooms));

            t_rooms = new rooms()
            {
                rooms_name = "XX1",
                //rooms_color = "#dddddd"
            };
            Assert.IsTrue(_doctcodModel.Rooms.CanAdd(t_rooms));

            t_rooms = new rooms()
            {
                rooms_name = "XX1",
                rooms_color = "#ddd"
            };
            Assert.IsFalse(_doctcodModel.Rooms.CanAdd(t_rooms));

            t_rooms = new rooms()
            {
                rooms_name = "XX1",
                rooms_color = "blue"
            };
            Assert.IsFalse(_doctcodModel.Rooms.CanAdd(t_rooms));

            t_rooms = new rooms()
            {
                rooms_name = "XX1",
                rooms_color = "#dddddd"
            };
            Assert.IsTrue(_doctcodModel.Rooms.CanAdd(t_rooms));
            _doctcodModel.Rooms.Add(t_rooms);

            t_rooms = new rooms()
            {
                rooms_name = "XX1"
            };
            Assert.IsFalse(_doctcodModel.Rooms.CanAdd(t_rooms));

            t_rooms = new rooms()
            {
                rooms_name = "XX2"
            };
            _doctcodModel.Rooms.Add(t_rooms);

            t_rooms = _doctcodModel.Rooms.FirstOrDefault(r => r.rooms_name == "XX1");
            t_rooms.rooms_name = "XX2";
            Assert.IsFalse(_doctcodModel.Rooms.CanUpdate(t_rooms));
            t_rooms.rooms_name = "XX3";
            Assert.IsTrue(_doctcodModel.Rooms.CanUpdate(t_rooms));

            _doctcodModel.Rooms.Remove(_doctcodModel.Rooms.List(r => r.rooms_name == "XX1").ToArray());
            _doctcodModel.Rooms.Remove(_doctcodModel.Rooms.List(r => r.rooms_name == "XX2").ToArray());
        }

        [Test]
        public void Rooms_Test2()
        {
            string[] errors = new string[] { };
            patients t_patients = null;
            doctors t_doctors = null;
            rooms t_rooms = null;
            appointments t_appointments = null;

            t_patients = _doctcodModel.Patients.FirstOrDefault(r => r.patients_name == "XX1" && r.patients_surname == "XX1");
            if (t_patients != null)
                _doctcodModel.Appointments.Remove(_doctcodModel.Appointments.List(r => r.patients_id == t_patients.patients_id).ToArray());
            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _doctcodModel.Doctors.Remove(_doctcodModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").ToArray());
            _doctcodModel.Rooms.Remove(_doctcodModel.Rooms.List(r => r.rooms_name == "XX1").ToArray());

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

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1236",
                doctors_password = "123456"
            };
            _doctcodModel.Doctors.Add(t_doctors);

            t_rooms = new rooms()
            {
                rooms_name = "XX1"
            };
            _doctcodModel.Rooms.Add(t_rooms);

            t_appointments = new appointments()
            {
                patients_id = t_patients.patients_id,
                doctors_id = t_doctors.doctors_id,
                rooms_id = t_rooms.rooms_id,
                appointments_title = "xxx",
                appointments_from = DateTime.Now,
                appointments_to = DateTime.Now.AddMinutes(40)
            };
            _doctcodModel.Appointments.Add(t_appointments);

            Assert.IsFalse(_doctcodModel.Rooms.CanRemove(_doctcodModel.Rooms.List(r => r.rooms_name == "XX1").ToArray()));

            t_patients = _doctcodModel.Patients.FirstOrDefault(r => r.patients_name == "XX1" && r.patients_surname == "XX1");
            if (t_patients != null)
                _doctcodModel.Appointments.Remove(_doctcodModel.Appointments.List(r => r.patients_id == t_patients.patients_id).ToArray());

            Assert.IsTrue(_doctcodModel.Rooms.CanRemove(_doctcodModel.Rooms.List(r => r.rooms_name == "XX1").ToArray()));

            _doctcodModel.Patients.Remove(_doctcodModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _doctcodModel.Doctors.Remove(_doctcodModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").ToArray());
            _doctcodModel.Rooms.Remove(_doctcodModel.Rooms.List(r => r.rooms_name == "XX1").ToArray());
        }
    }
}
