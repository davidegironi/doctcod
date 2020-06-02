#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.Data.Model;
using DG.DoctcoD.Model.Entity;
using System.Linq;

namespace DG.DoctcoD.Model.Repositories
{
    public class PatientsTreatmentsRepository : GenericDataRepository<patientstreatments, DoctcoDModel>
    {
        public PatientsTreatmentsRepository() : base() { }

        /// <summary>
        /// Repository language dictionary
        /// </summary>
        public class RepositoryLanguage : IGenericDataRepositoryLanguage
        {
            public string text001 = "Doctors is mandatory.";
            public string text002 = "Patient is mandatory.";
            public string text003 = "Treatments type is mandatory.";
            public string text004 = "Invalid sex. Can be 'M' or 'F'.";
            public string text005 = "Invalid tax rate. Can not be less than zero.";
            public string text101 = "Arches";
            public string text102 = "Upper Arch";
            public string text103 = "Lower Arch";
            public string text104 = "None";
        }

        /// <summary>
        /// Repository language
        /// </summary>
        public RepositoryLanguage language = new RepositoryLanguage();

        /// <summary>
        /// Check if an item can be added
        /// </summary>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public override bool CanAdd(ref string[] errors, params patientstreatments[] items)
        {
            errors = new string[] { };

            bool ret = Validate(false, ref errors, items);
            if (!ret)
                return ret;

            ret = base.CanAdd(ref errors, items);

            return ret;
        }

        /// <summary>
        /// Check if an item can be updated
        /// </summary>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public override bool CanUpdate(ref string[] errors, params patientstreatments[] items)
        {
            errors = new string[] { };

            bool ret = Validate(true, ref errors, items);
            if (!ret)
                return ret;

            ret = base.CanUpdate(ref errors, items);

            return ret;
        }

        /// <summary>
        /// Validate an item
        /// </summary>
        /// <param name="isUpdate"></param>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        private bool Validate(bool isUpdate, ref string[] errors, params patientstreatments[] items)
        {
            bool ret = true;

            foreach (patientstreatments item in items)
            {
                if (item.patientstreatments_taxrate < 0)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text005 }).ToArray();
                }

                if (!ret)
                    break;

                if (BaseModel.Doctors.Find(item.doctors_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text001 }).ToArray();
                }
                if (BaseModel.Patients.Find(item.patients_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text002 }).ToArray();
                }
                if (BaseModel.Treatments.Find(item.treatments_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text003 }).ToArray();
                }

                if (!ret)
                    break;
            }

            return ret;
        }

        /// <summary>
        /// Check if an item can be removed
        /// </summary>
        /// <param name="checkForeingKeys"></param>
        /// <param name="excludedForeingKeys"></param>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public override bool CanRemove(bool checkForeingKeys, string[] excludedForeingKeys, ref string[] errors, params patientstreatments[] items)
        {
            bool ret = true;

            errors = new string[] { };

            if (excludedForeingKeys == null)
                excludedForeingKeys = new string[] { };
            if (!excludedForeingKeys.Contains("FK_estimateslines_patientstreatments"))
                excludedForeingKeys = excludedForeingKeys.Concat(new string[] { "FK_estimateslines_patientstreatments" }).ToArray();
            if (!excludedForeingKeys.Contains("FK_invoiceslines_patientstreatments"))
                excludedForeingKeys = excludedForeingKeys.Concat(new string[] { "FK_invoiceslines_patientstreatments" }).ToArray();

            ret = base.CanRemove(checkForeingKeys, excludedForeingKeys, ref errors, items);

            return ret;
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="items"></param>
        public override void Remove(params patientstreatments[] items)
        {
            //remove or unset all related items
            foreach (patientstreatments item in items)
            {
                foreach (invoiceslines invoiceline in BaseModel.InvoicesLines.List(r => r.patientstreatments_id == item.patientstreatments_id))
                {
                    invoiceline.patientstreatments_id = null;
                    BaseModel.InvoicesLines.Update(invoiceline);
                }
                foreach (estimateslines estimateline in BaseModel.EstimatesLines.List(r => r.patientstreatments_id == item.patientstreatments_id))
                {
                    estimateline.patientstreatments_id = null;
                    BaseModel.EstimatesLines.Update(estimateline);
                }
            }

            base.Remove(items);
        }
    }

}

