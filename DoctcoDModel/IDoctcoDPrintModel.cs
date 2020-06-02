#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.DoctcoD.Model;
using DG.DoctcoD.Model.Entity;

namespace DG.DoctcoD
{
    /// <summary>
    /// DoctcoD print model interface
    /// each class implementing this interface must be in namespace "DG.DoctcoD" with name DoctcoDPrintModel
    /// i.e. public class DG.DoctcoD.DoctcoDPrintModel : IDoctcoDPrintModel
    /// </summary>
    public interface IDoctcoDPrintModel
    {
        /// <summary>
        /// Build a file for an estimate
        /// </summary>
        /// <param name="doctcodModel"></param>
        /// <param name="estimates_id"></param>
        /// <param name="language"></param>
        /// <param name="filename"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        bool BuildEstimate(DoctcoDModel doctcodModel, int estimates_id, string language, string filename, ref string[] errors);

        /// <summary>
        /// Check if estimate builder is enabled
        /// </summary>
        /// <returns></returns>
        bool IsBuildEstimateEnabled();

        /// <summary>
        /// Get the estimate builder template name
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        string BuildEstimateTemplateName(string language);

        /// <summary>
        /// Get the estimate filename
        /// </summary>
        /// <param name="doctcodModel"></param>
        /// <param name="estimates_id"></param>
        /// <param name="filefolder"></param>
        /// <returns></returns>
        string BuildEstimateGetFilename(DoctcoDModel doctcodModel, int estimates_id, string filefolder);

        /// <summary>
        /// Build a file for an invoice
        /// </summary>
        /// <param name="doctcodModel"></param>
        /// <param name="invoices_id"></param>
        /// <param name="language"></param>
        /// <param name="filename"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        bool BuildInvoice(DoctcoDModel doctcodModel, int invoices_id, string language, string filename, ref string[] errors);

        /// <summary>
        /// Check if invoice builder is enabled
        /// </summary>
        /// <returns></returns>
        bool IsBuildInvoiceEnabled();

        /// <summary>
        /// Get the invoice builder template name
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        string BuildInvoiceTemplateName(string language);

        /// <summary>
        /// Get the invoice filename
        /// </summary>
        /// <param name="doctcodModel"></param>
        /// <param name="invoices_id"></param>
        /// <param name="filefolder"></param>
        /// <returns></returns>
        string BuildInvoiceGetFilename(DoctcoDModel doctcodModel, int invoices_id, string filefolder);

        /// <summary>
        /// Build a file for patient treatments
        /// </summary>
        /// <param name="doctcodModel"></param>
        /// <param name="patients_id"></param>
        /// <param name="patientstreatmentsl"></param>
        /// <param name="language"></param>
        /// <param name="filename"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        bool BuildPatientTreatments(DoctcoDModel doctcodModel, int patients_id, patientstreatments[] patientstreatmentsl, string language, string filename, ref string[] errors);

        /// <summary>
        /// Check if patient treatments builder is enabled
        /// </summary>
        /// <returns></returns>
        bool IsBuildPatientTreatmentsEnabled();

        /// <summary>
        /// Get the patient treatments builder template name
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        string BuildPatientTreatmentsTemplateName(string language);

        /// <summary>
        /// Get the patient treatments filename
        /// </summary>
        /// <param name="filefolder"></param>
        /// <returns></returns>
        string BuildPatientTreatmentsGetFilename(string filefolder);
    }
}
