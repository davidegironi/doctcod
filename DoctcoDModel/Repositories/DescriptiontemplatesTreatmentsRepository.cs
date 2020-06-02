#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.Data.Model;
using DG.DoctcoD.Model.Entity;
using System;
using System.Linq;

namespace DG.DoctcoD.Model.Repositories
{
    public class DescriptiontemplatesTreatmentsRepository : GenericDataRepository<descriptiontemplatestreatments, DoctcoDModel>
    {
        public DescriptiontemplatesTreatmentsRepository() : base() { }

        /// <summary>
        /// Repository language dictionary
        /// </summary>
        public class RepositoryLanguage : IGenericDataRepositoryLanguage
        {
            public string text001 = "Name can not be empty.";
            public string text002 = "Template can not be empty.";
            public string text003 = "Description template for treatments already inserted.";
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
        public override bool CanAdd(ref string[] errors, params descriptiontemplatestreatments[] items)
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
        public override bool CanUpdate(ref string[] errors, params descriptiontemplatestreatments[] items)
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
        private bool Validate(bool isUpdate, ref string[] errors, params descriptiontemplatestreatments[] items)
        {
            bool ret = true;

            foreach (descriptiontemplatestreatments item in items)
            {
                if (String.IsNullOrEmpty(item.descriptiontemplatestreatments_name))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text001 }).ToArray();
                }
                if (String.IsNullOrEmpty(item.descriptiontemplatestreatments_template))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text002 }).ToArray();
                }

                if (!ret)
                    break;

                if (!isUpdate)
                {
                    if (Any(r => r.descriptiontemplatestreatments_name == item.descriptiontemplatestreatments_name))
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text003 }).ToArray();
                    }
                }
                else
                {
                    if (Any(r => r.descriptiontemplatestreatments_id != item.descriptiontemplatestreatments_id && r.descriptiontemplatestreatments_name == item.descriptiontemplatestreatments_name))
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text003 }).ToArray();
                    }
                }

                if (!ret)
                    break;
            }

            return ret;
        }

    }

}

