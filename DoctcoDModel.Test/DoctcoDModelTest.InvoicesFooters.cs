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
        public void InvoicesFooters_Test1()
        {
            string[] errors = new string[] { };
            invoicesfooters t_invoicesfooters = null;

            _doctcodModel.InvoicesFooters.Remove(_doctcodModel.InvoicesFooters.List(r => r.invoicesfooters_name == "XX1").ToArray());
            _doctcodModel.InvoicesFooters.Remove(_doctcodModel.InvoicesFooters.List(r => r.invoicesfooters_name == "XX2").ToArray());

            t_invoicesfooters = new invoicesfooters()
            {
                //invoicesfooters_name = "XX1",
                invoicesfooters_doctext = "xxx"
            };
            Assert.IsFalse(_doctcodModel.InvoicesFooters.CanAdd(t_invoicesfooters));

            t_invoicesfooters = new invoicesfooters()
            {
                invoicesfooters_name = "XX1",
                //invoicesfooters_doctext = "xxx"
            };
            Assert.IsFalse(_doctcodModel.InvoicesFooters.CanAdd(t_invoicesfooters));

            t_invoicesfooters = new invoicesfooters()
            {
                invoicesfooters_name = "XX1",
                invoicesfooters_doctext = "xxx"
            };
            Assert.IsTrue(_doctcodModel.InvoicesFooters.CanAdd(t_invoicesfooters));
            _doctcodModel.InvoicesFooters.Add(t_invoicesfooters);

            t_invoicesfooters = new invoicesfooters()
            {
                invoicesfooters_name = "XX1",
                invoicesfooters_doctext = "xxx"
            };
            Assert.IsFalse(_doctcodModel.InvoicesFooters.CanAdd(t_invoicesfooters));

            t_invoicesfooters = new invoicesfooters()
            {
                invoicesfooters_name = "XX2",
                invoicesfooters_doctext = "xxx"
            };
            _doctcodModel.InvoicesFooters.Add(t_invoicesfooters);

            t_invoicesfooters = _doctcodModel.InvoicesFooters.FirstOrDefault(r => r.invoicesfooters_name == "XX1");
            t_invoicesfooters.invoicesfooters_name = "XX2";
            Assert.IsFalse(_doctcodModel.InvoicesFooters.CanUpdate(t_invoicesfooters));
            t_invoicesfooters.invoicesfooters_name = "XX3";
            Assert.IsTrue(_doctcodModel.InvoicesFooters.CanUpdate(t_invoicesfooters));

            _doctcodModel.InvoicesFooters.Remove(_doctcodModel.InvoicesFooters.List(r => r.invoicesfooters_name == "XX1").ToArray());
            _doctcodModel.InvoicesFooters.Remove(_doctcodModel.InvoicesFooters.List(r => r.invoicesfooters_name == "XX2").ToArray());
        }
    }
}
