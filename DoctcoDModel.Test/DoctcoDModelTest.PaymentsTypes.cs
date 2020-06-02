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
        public void PaymentsTypes_Test1()
        {
            string[] errors = new string[] { };
            paymentstypes t_paymentstypes = null;

            _doctcodModel.PaymentsTypes.Remove(_doctcodModel.PaymentsTypes.List(r => r.paymentstypes_name == "XX1").ToArray());
            _doctcodModel.PaymentsTypes.Remove(_doctcodModel.PaymentsTypes.List(r => r.paymentstypes_name == "XX2").ToArray());

            t_paymentstypes = new paymentstypes()
            {
                //paymentstypes_name = "XX1",
                paymentstypes_doctext = "xxx"
            };
            Assert.IsFalse(_doctcodModel.PaymentsTypes.CanAdd(t_paymentstypes));

            t_paymentstypes = new paymentstypes()
            {
                paymentstypes_name = "XX1",
                //paymentstypes_doctext = "xxx"
            };
            Assert.IsFalse(_doctcodModel.PaymentsTypes.CanAdd(t_paymentstypes));

            t_paymentstypes = new paymentstypes()
            {
                paymentstypes_name = "XX1",
                paymentstypes_doctext = "xxx"
            };
            Assert.IsTrue(_doctcodModel.PaymentsTypes.CanAdd(t_paymentstypes));
            _doctcodModel.PaymentsTypes.Add(t_paymentstypes);

            t_paymentstypes = new paymentstypes()
            {
                paymentstypes_name = "XX1",
                paymentstypes_doctext = "xxx"
            };
            Assert.IsFalse(_doctcodModel.PaymentsTypes.CanAdd(t_paymentstypes));

            t_paymentstypes = new paymentstypes()
            {
                paymentstypes_name = "XX2",
                paymentstypes_doctext = "xxx"
            };
            _doctcodModel.PaymentsTypes.Add(t_paymentstypes);

            t_paymentstypes = _doctcodModel.PaymentsTypes.FirstOrDefault(r => r.paymentstypes_name == "XX1");
            t_paymentstypes.paymentstypes_name = "XX2";
            Assert.IsFalse(_doctcodModel.PaymentsTypes.CanUpdate(t_paymentstypes));
            t_paymentstypes.paymentstypes_name = "XX3";
            Assert.IsTrue(_doctcodModel.PaymentsTypes.CanUpdate(t_paymentstypes));

            _doctcodModel.PaymentsTypes.Remove(_doctcodModel.PaymentsTypes.List(r => r.paymentstypes_name == "XX1").ToArray());
            _doctcodModel.PaymentsTypes.Remove(_doctcodModel.PaymentsTypes.List(r => r.paymentstypes_name == "XX2").ToArray());
        }
    }
}
