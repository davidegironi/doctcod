#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.DoctcoD.Model;
using DG.UI.Helpers;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DG.DoctcoD.Helpers
{
    public class BoxLoader
    {
        private DoctcoDModel _doctcodModel = null;

        public BoxLoader(DoctcoDModel doctcodModel)
        {
            this._doctcodModel = doctcodModel;
        }

        /// <summary>
        /// Load combobox addresses types
        /// </summary>
        /// <param name="comboBox"></param>
        public void LoadComboBoxAddressesTypes(ComboBox comboBox)
        {
            EnhancedComboBoxHelper.AttachComboBox(
                comboBox,
                new string[] { "Name" },
                _doctcodModel.AddressesTypes.List().OrderBy(r => r.addressestypes_name).Select(
                r => new EnhancedComboBoxHelper.Items()
                {
                    _id = r.addressestypes_id,
                    _value = r.addressestypes_name,
                    _values = new string[]
                    {
                        r.addressestypes_name
                    }
                }).ToArray());
        }

        /// <summary>
        /// Load combobox computed lines
        /// </summary>
        /// <param name="comboBox"></param>
        public void LoadComboBoxComputedLines(ComboBox comboBox)
        {
            EnhancedComboBoxHelper.AttachComboBox(
                comboBox,
                new string[] { "Name" },
                _doctcodModel.ComputedLines.List().OrderBy(r => r.computedlines_name).Select(
                r => new EnhancedComboBoxHelper.Items()
                {
                    _id = r.computedlines_id,
                    _value = r.computedlines_name,
                    _values = new string[]
                    {
                        r.computedlines_name
                    }
                }).ToArray());
        }

        /// <summary>
        /// Load combobox contacts types
        /// </summary>
        /// <param name="comboBox"></param>
        public void LoadComboBoxContactsTypes(ComboBox comboBox)
        {
            EnhancedComboBoxHelper.AttachComboBox(
                comboBox,
                new string[] { "Name" },
                _doctcodModel.ContactsTypes.List().OrderBy(r => r.contactstypes_name).Select(
                r => new EnhancedComboBoxHelper.Items()
                {
                    _id = r.contactstypes_id,
                    _value = r.contactstypes_name,
                    _values = new string[]
                    {
                        r.contactstypes_name
                    }
                }).ToArray());
        }

        /// <summary>
        /// Load combobox description templates treatments
        /// </summary>
        /// <param name="comboBox"></param>
        public void LoadComboBoxDescriptiontemplatesTreatments(ComboBox comboBox)
        {
            EnhancedComboBoxHelper.AttachComboBox(
                comboBox,
                new string[] { "Name" },
                _doctcodModel.DescriptiontemplatesTreatments.List().OrderBy(r => r.descriptiontemplatestreatments_name).Select(
                r => new EnhancedComboBoxHelper.Items()
                {
                    _id = r.descriptiontemplatestreatments_id,
                    _value = r.descriptiontemplatestreatments_name,
                    _values = new string[]
                    {
                        r.descriptiontemplatestreatments_name
                    }
                }).ToArray());
        }

        /// <summary>
        /// Load combobox doctors
        /// </summary>
        /// <param name="comboBox"></param>
        public void LoadComboBoxDoctors(ComboBox comboBox)
        {
            EnhancedComboBoxHelper.AttachComboBox(
                comboBox,
                new string[] { "Name" },
                _doctcodModel.Doctors.List().OrderBy(r => r.doctors_surname).ThenBy(r => r.doctors_name).Select(
                r => new EnhancedComboBoxHelper.Items()
                {
                    _id = r.doctors_id,
                    _value = r.doctors_surname + " " + r.doctors_name,
                    _values = new string[]
                    {
                        r.doctors_surname + " " + r.doctors_name
                    }
                }).ToArray());
        }

        /// <summary>
        /// Load combobox estimates footers
        /// </summary>
        /// <param name="comboBox"></param>
        public void LoadComboBoxEstimatesFooters(ComboBox comboBox)
        {
            EnhancedComboBoxHelper.AttachComboBox(
                comboBox,
                new string[] { "Name" },
                _doctcodModel.EstimatesFooters.List().OrderBy(r => r.estimatesfooters_name).Select(
                r => new EnhancedComboBoxHelper.Items()
                {
                    _id = r.estimatesfooters_id,
                    _value = r.estimatesfooters_name,
                    _values = new string[]
                    {
                        r.estimatesfooters_name
                    }
                }).ToArray());
        }

        /// <summary>
        /// Load combobox medial records types
        /// </summary>
        /// <param name="comboBox"></param>
        public void LoadComboBoxMedicalrecordsTypes(ComboBox comboBox)
        {
            EnhancedComboBoxHelper.AttachComboBox(
                comboBox,
                new string[] { "Name" },
                _doctcodModel.MedicalrecordsTypes.List().OrderBy(r => r.medicalrecordstypes_name).Select(
                r => new EnhancedComboBoxHelper.Items()
                {
                    _id = r.medicalrecordstypes_id,
                    _value = r.medicalrecordstypes_name,
                    _values = new string[]
                    {
                        r.medicalrecordstypes_name
                    }
                }).ToArray());
        }

        /// <summary>
        /// Load combobox invoices footers
        /// </summary>
        /// <param name="comboBox"></param>
        public void LoadComboBoxInvoicesFooters(ComboBox comboBox)
        {
            EnhancedComboBoxHelper.AttachComboBox(
                comboBox,
                new string[] { "Name" },
                _doctcodModel.InvoicesFooters.List().OrderBy(r => r.invoicesfooters_name).Select(
                r => new EnhancedComboBoxHelper.Items()
                {
                    _id = r.invoicesfooters_id,
                    _value = r.invoicesfooters_name,
                    _values = new string[]
                    {
                        r.invoicesfooters_name
                    }
                }).ToArray());
        }

        /// <summary>
        /// Load combobox payments types
        /// </summary>
        /// <param name="comboBox"></param>
        public void LoadComboBoxPaymentsTypes(ComboBox comboBox)
        {
            EnhancedComboBoxHelper.AttachComboBox(
                comboBox,
                new string[] { "Name" },
                _doctcodModel.PaymentsTypes.List().OrderBy(r => r.paymentstypes_name).Select(
                r => new EnhancedComboBoxHelper.Items()
                {
                    _id = r.paymentstypes_id,
                    _value = r.paymentstypes_name,
                    _values = new string[]
                    {
                        r.paymentstypes_name
                    }
                }).ToArray());
        }

        /// <summary>
        /// Load combobox patients
        /// </summary>
        /// <param name="comboBox"></param>
        public void LoadComboBoxPatients(ComboBox comboBox)
        {
            EnhancedComboBoxHelper.AttachComboBox(
                comboBox,
                new string[] { "Name" },
                _doctcodModel.Patients.List().OrderBy(r => r.patients_surname).ThenBy(r => r.patients_name).Select(
                r => new EnhancedComboBoxHelper.Items()
                {
                    _id = r.patients_id,
                    _value = r.patients_surname + " " + r.patients_name,
                    _values = new string[]
                    {
                        r.patients_surname + " " + r.patients_name
                    }
                }).ToArray());
        }

        /// <summary>
        /// Load combobox patients attachments types
        /// </summary>
        /// <param name="comboBox"></param>
        public void LoadComboBoxPatientsAttachmentsTypes(ComboBox comboBox)
        {
            EnhancedComboBoxHelper.AttachComboBox(
                comboBox,
                new string[] { "Name" },
                _doctcodModel.PatientsAttachmentsTypes.List().OrderBy(r => r.patientsattachmentstypes_name).Select(
                r => new EnhancedComboBoxHelper.Items()
                {
                    _id = r.patientsattachmentstypes_id,
                    _value = r.patientsattachmentstypes_name,
                    _values = new string[]
                    {
                        r.patientsattachmentstypes_name
                    }
                }).ToArray());
        }

        /// <summary>
        /// Load combobox patients attributes types
        /// </summary>
        /// <param name="comboBox"></param>
        public void LoadComboBoxPatientsAttributesTypes(ComboBox comboBox)
        {
            EnhancedComboBoxHelper.AttachComboBox(
                comboBox,
                new string[] { "Name" },
                _doctcodModel.PatientsAttributesTypes.List().OrderBy(r => r.patientsattributestypes_name).Select(
                r => new EnhancedComboBoxHelper.Items()
                {
                    _id = r.patientsattributestypes_id,
                    _value = r.patientsattributestypes_name,
                    _values = new string[]
                    {
                        r.patientsattributestypes_name
                    }
                }).ToArray());
        }

        /// <summary>
        /// Load combobox rooms
        /// </summary>
        /// <param name="comboBox"></param>
        public void LoadComboBoxRooms(ComboBox comboBox)
        {
            EnhancedComboBoxHelper.AttachComboBox(
                comboBox,
                new string[] { "Name" },
                _doctcodModel.Rooms.List().OrderBy(r => r.rooms_name).Select(
                r => new EnhancedComboBoxHelper.Items()
                {
                    _id = r.rooms_id,
                    _value = r.rooms_name,
                    _values = new string[]
                    {
                        r.rooms_name
                    }
                }).ToArray());
        }

        /// <summary>
        /// Load combobox taxes
        /// </summary>
        /// <param name="comboBox"></param>
        public void LoadComboBoxTaxes(ComboBox comboBox)
        {
            EnhancedComboBoxHelper.AttachComboBox(
                comboBox,
                new string[] { "Name", "Rate" },
                _doctcodModel.Taxes.List().OrderBy(r => r.taxes_name).Select(
                r => new EnhancedComboBoxHelper.Items()
                {
                    _id = r.taxes_id,
                    _value = r.taxes_name,
                    _values = new string[]
                    {
                        r.taxes_name,
                        String.Format("{0:#.00}", r.taxes_rate)
                    }
                }).ToArray());
        }

        /// <summary>
        /// Load combobox taxes deductions
        /// </summary>
        /// <param name="comboBox"></param>
        public void LoadComboBoxTaxesDeductions(ComboBox comboBox)
        {
            EnhancedComboBoxHelper.AttachComboBox(
                comboBox,
                new string[] { "Name", "Rate" },
                _doctcodModel.TaxesDeductions.List().OrderBy(r => r.taxesdeductions_name).Select(
                r => new EnhancedComboBoxHelper.Items()
                {
                    _id = r.taxesdeductions_id,
                    _value = r.taxesdeductions_name,
                    _values = new string[]
                    {
                        r.taxesdeductions_name,
                        String.Format("{0:#.00}", r.taxesdeductions_rate)
                    }
                }).ToArray());
        }

        /// <summary>
        /// Load combobox treatments
        /// </summary>
        /// <param name="comboBox"></param>
        public void LoadComboBoxTreatments(ComboBox comboBox)
        {
            EnhancedComboBoxHelper.AttachComboBox(
                comboBox,
                new string[] { "Code", "Name" },
                _doctcodModel.Treatments.List().OrderBy(r => r.treatments_name).Select(
                r => new EnhancedComboBoxHelper.Items()
                {
                    _id = r.treatments_id,
                    _value = r.treatments_code + " - " + r.treatments_name,
                    _values = new string[]
                    {
                        r.treatments_code,
                        r.treatments_name
                    }
                }).ToArray());
        }

        /// <summary>
        /// Load combobox treatments prices lists
        /// </summary>
        /// <param name="comboBox"></param>
        public void LoadComboBoxTreatmentsPricesLists(ComboBox comboBox)
        {
            EnhancedComboBoxHelper.AttachComboBox(
                comboBox,
                new string[] { "Name" },
                _doctcodModel.TreatmentsPricesLists.List().OrderBy(r => r.treatmentspriceslists_name).Select(
                r => new EnhancedComboBoxHelper.Items()
                {
                    _id = r.treatmentspriceslists_id,
                    _value = r.treatmentspriceslists_name,
                    _values = new string[]
                    {
                        r.treatmentspriceslists_name
                    }
                }).ToArray());
        }

        /// <summary>
        /// Load combobox treatments types
        /// </summary>
        /// <param name="comboBox"></param>
        public void LoadComboBoxTreatmentsTypes(ComboBox comboBox)
        {
            EnhancedComboBoxHelper.AttachComboBox(
                comboBox,
                new string[] { "Name" },
                _doctcodModel.TreatmentsTypes.List().OrderBy(r => r.treatmentstypes_name).Select(
                r => new EnhancedComboBoxHelper.Items()
                {
                    _id = r.treatmentstypes_id,
                    _value = r.treatmentstypes_name,
                    _values = new string[]
                    {
                        r.treatmentstypes_name
                    }
                }).ToArray());
        }

        /// <summary>
        /// Load combobox filter doctors
        /// </summary>
        /// <param name="comboBox"></param>
        public void LoadComboBoxFilterDoctors(ComboBox comboBox)
        {
            EnhancedComboBoxHelper.Items[] items = new EnhancedComboBoxHelper.Items[] { };
            items = items.Concat(new EnhancedComboBoxHelper.Items[] {
                    new EnhancedComboBoxHelper.Items()
                    {
                         _id = -1,
                        _value = "",
                        _values = new string[]
                        {
                            "/"
                        }
                    }
                }).ToArray();
            foreach (var r in _doctcodModel.Doctors.List().OrderBy(r => r.doctors_surname).ThenBy(r => r.doctors_name))
            {
                items = items.Concat(new EnhancedComboBoxHelper.Items[] {
                        new EnhancedComboBoxHelper.Items()
                        {
                            _id = r.doctors_id,
                            _value = r.doctors_surname + " " + r.doctors_name,
                            _values = new string[]
                            {
                                r.doctors_surname + " " + r.doctors_name
                            }
                        }
                    }).ToArray();
            }

            EnhancedComboBoxHelper.AttachComboBox(
                comboBox,
                new string[] { "Name" },
                items);
        }

        /// <summary>
        /// Load combobox filter rooms
        /// </summary>
        /// <param name="comboBox"></param>
        public void LoadComboBoxFilterRooms(ComboBox comboBox)
        {
            EnhancedComboBoxHelper.Items[] items = new EnhancedComboBoxHelper.Items[] { };
            items = items.Concat(new EnhancedComboBoxHelper.Items[] {
                    new EnhancedComboBoxHelper.Items()
                    {
                         _id = -1,
                        _value = "",
                        _values = new string[]
                        {
                            "/"
                        }
                    }
                }).ToArray();
            foreach (var r in _doctcodModel.Rooms.List().OrderBy(r => r.rooms_name))
            {
                items = items.Concat(new EnhancedComboBoxHelper.Items[] {
                        new EnhancedComboBoxHelper.Items()
                        {
                            _id = r.rooms_id,
                            _value = r.rooms_name,
                            _values = new string[]
                            {
                                r.rooms_name
                            }
                        }
                    }).ToArray();
            }

            EnhancedComboBoxHelper.AttachComboBox(
                comboBox,
                new string[] { "Name" },
                items);
        }

        /// <summary>
        /// Load combobox filter reports
        /// </summary>
        /// <param name="comboBox"></param>
        public void LoadComboBoxFilterReports(ComboBox comboBox)
        {
            EnhancedComboBoxHelper.Items[] items = new EnhancedComboBoxHelper.Items[] { };
            items = items.Concat(new EnhancedComboBoxHelper.Items[] {
                    new EnhancedComboBoxHelper.Items()
                    {
                         _id = -1,
                        _value = "",
                        _values = new string[]
                        {
                            "/"
                        }
                    }
                }).ToArray();
            foreach (var r in _doctcodModel.Reports.List().OrderBy(r => r.reports_name))
            {
                items = items.Concat(new EnhancedComboBoxHelper.Items[] {
                        new EnhancedComboBoxHelper.Items()
                        {
                            _id = r.reports_id,
                            _value = r.reports_name,
                            _values = new string[]
                            {
                                r.reports_name
                            }
                        }
                    }).ToArray();
            }

            EnhancedComboBoxHelper.AttachComboBox(
                comboBox,
                new string[] { "Name" },
                items);
        }

        /// <summary>
        /// Load combobox filter treatments prices lists
        /// </summary>
        /// <param name="comboBox"></param>
        public void LoadComboBoxFilterTreatmentsPricesLists(ComboBox comboBox)
        {
            EnhancedComboBoxHelper.Items[] items = new EnhancedComboBoxHelper.Items[] { };
            items = items.Concat(new EnhancedComboBoxHelper.Items[] {
                    new EnhancedComboBoxHelper.Items()
                    {
                         _id = -1,
                        _value = "",
                        _values = new string[]
                        {
                            "/"
                        }
                    }
                }).ToArray();
            foreach (var r in _doctcodModel.TreatmentsPricesLists.List().OrderBy(r => r.treatmentspriceslists_name))
            {
                items = items.Concat(new EnhancedComboBoxHelper.Items[] {
                        new EnhancedComboBoxHelper.Items()
                        {
                            _id = r.treatmentspriceslists_id,
                            _value = r.treatmentspriceslists_name,
                            _values = new string[]
                            {
                                r.treatmentspriceslists_name
                            }
                        }
                    }).ToArray();
            }

            EnhancedComboBoxHelper.AttachComboBox(
                comboBox,
                new string[] { "Name" },
                items);
        }
    }
}