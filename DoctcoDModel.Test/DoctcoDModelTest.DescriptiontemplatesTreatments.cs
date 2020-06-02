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
        public void DescriptiontemplatesTreatments_Test1()
        {
            string[] errors = new string[] { };
            descriptiontemplatestreatments t_decriptiontemplatestreatments = null;

            _doctcodModel.DescriptiontemplatesTreatments.Remove(_doctcodModel.DescriptiontemplatesTreatments.List(r => r.descriptiontemplatestreatments_name == "XX1").ToArray());
            _doctcodModel.DescriptiontemplatesTreatments.Remove(_doctcodModel.DescriptiontemplatesTreatments.List(r => r.descriptiontemplatestreatments_name == "XX2").ToArray());

            t_decriptiontemplatestreatments = new descriptiontemplatestreatments()
            {
                //descriptiontemplatestreatments_name = "XX1",
                descriptiontemplatestreatments_template = "Template description"
            };
            Assert.IsFalse(_doctcodModel.DescriptiontemplatesTreatments.CanAdd(t_decriptiontemplatestreatments));

            t_decriptiontemplatestreatments = new descriptiontemplatestreatments()
            {
                descriptiontemplatestreatments_name = "XX1",
                //descriptiontemplatestreatments_template = "Template description"
            };
            Assert.IsFalse(_doctcodModel.DescriptiontemplatesTreatments.CanAdd(t_decriptiontemplatestreatments));

            t_decriptiontemplatestreatments = new descriptiontemplatestreatments()
            {
                descriptiontemplatestreatments_name = "XX1",
                descriptiontemplatestreatments_template = "Template description"
            };
            Assert.IsTrue(_doctcodModel.DescriptiontemplatesTreatments.CanAdd(t_decriptiontemplatestreatments));
            _doctcodModel.DescriptiontemplatesTreatments.Add(t_decriptiontemplatestreatments);

            t_decriptiontemplatestreatments = new descriptiontemplatestreatments()
            {
                descriptiontemplatestreatments_name = "XX1",
                descriptiontemplatestreatments_template = "Template description"
            };
            Assert.IsFalse(_doctcodModel.DescriptiontemplatesTreatments.CanAdd(t_decriptiontemplatestreatments));

            t_decriptiontemplatestreatments = new descriptiontemplatestreatments()
            {
                descriptiontemplatestreatments_name = "XX2",
                descriptiontemplatestreatments_template = "Template description"
            };
            _doctcodModel.DescriptiontemplatesTreatments.Add(t_decriptiontemplatestreatments);

            t_decriptiontemplatestreatments = _doctcodModel.DescriptiontemplatesTreatments.FirstOrDefault(r => r.descriptiontemplatestreatments_name == "XX1");
            t_decriptiontemplatestreatments.descriptiontemplatestreatments_name = "XX2";
            Assert.IsFalse(_doctcodModel.DescriptiontemplatesTreatments.CanUpdate(t_decriptiontemplatestreatments));
            t_decriptiontemplatestreatments.descriptiontemplatestreatments_name = "XX3";
            Assert.IsTrue(_doctcodModel.DescriptiontemplatesTreatments.CanUpdate(t_decriptiontemplatestreatments));

            _doctcodModel.DescriptiontemplatesTreatments.Remove(_doctcodModel.DescriptiontemplatesTreatments.List(r => r.descriptiontemplatestreatments_name == "XX1").ToArray());
            _doctcodModel.DescriptiontemplatesTreatments.Remove(_doctcodModel.DescriptiontemplatesTreatments.List(r => r.descriptiontemplatestreatments_name == "XX2").ToArray());
        }

    }
}
