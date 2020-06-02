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
        public void EstimatesFooters_Test1()
        {
            string[] errors = new string[] { };
            estimatesfooters t_estimatesfooters = null;

            _doctcodModel.EstimatesFooters.Remove(_doctcodModel.EstimatesFooters.List(r => r.estimatesfooters_name == "XX1").ToArray());
            _doctcodModel.EstimatesFooters.Remove(_doctcodModel.EstimatesFooters.List(r => r.estimatesfooters_name == "XX2").ToArray());

            t_estimatesfooters = new estimatesfooters()
            {
                //estimatesfooters_name = "XX1",
                estimatesfooters_doctext = "xxx"
            };
            Assert.IsFalse(_doctcodModel.EstimatesFooters.CanAdd(t_estimatesfooters));

            t_estimatesfooters = new estimatesfooters()
            {
                estimatesfooters_name = "XX1",
                //estimatesfooters_doctext = "xxx"
            };
            Assert.IsFalse(_doctcodModel.EstimatesFooters.CanAdd(t_estimatesfooters));

            t_estimatesfooters = new estimatesfooters()
            {
                estimatesfooters_name = "XX1",
                estimatesfooters_doctext = "xxx"
            };
            Assert.IsTrue(_doctcodModel.EstimatesFooters.CanAdd(t_estimatesfooters));
            _doctcodModel.EstimatesFooters.Add(t_estimatesfooters);

            t_estimatesfooters = new estimatesfooters()
            {
                estimatesfooters_name = "XX1",
                estimatesfooters_doctext = "xxx"
            };
            Assert.IsFalse(_doctcodModel.EstimatesFooters.CanAdd(t_estimatesfooters));

            t_estimatesfooters = new estimatesfooters()
            {
                estimatesfooters_name = "XX2",
                estimatesfooters_doctext = "xxx"
            };
            _doctcodModel.EstimatesFooters.Add(t_estimatesfooters);

            t_estimatesfooters = _doctcodModel.EstimatesFooters.FirstOrDefault(r => r.estimatesfooters_name == "XX1");
            t_estimatesfooters.estimatesfooters_name = "XX2";
            Assert.IsFalse(_doctcodModel.EstimatesFooters.CanUpdate(t_estimatesfooters));
            t_estimatesfooters.estimatesfooters_name = "XX3";
            Assert.IsTrue(_doctcodModel.EstimatesFooters.CanUpdate(t_estimatesfooters));

            _doctcodModel.EstimatesFooters.Remove(_doctcodModel.EstimatesFooters.List(r => r.estimatesfooters_name == "XX1").ToArray());
            _doctcodModel.EstimatesFooters.Remove(_doctcodModel.EstimatesFooters.List(r => r.estimatesfooters_name == "XX2").ToArray());
        }
    }
}
