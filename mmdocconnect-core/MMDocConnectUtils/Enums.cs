using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectUtils
{
    public enum EGposType
    {
        [Description("mm.docconnect.gpos.catalog.nachsorge")]
        Aftercare,
        [Description("mm.docconnect.gpos.catalog.operation")]
        Operation,
        [Description("mm.docconnect.gpos.catalog.voruntersuchung")]
        Oct
    }

    public enum EActionType
    {
        [Description("mm.docconect.doc.app.planned.action.treatment")]
        PlannedOperation,
        [Description("mm.docconect.doc.app.planned.action.aftercare")]
        PlannedAftercare,
        [Description("mm.docconect.doc.app.planned.action.oct")]
        PlannedOct,
        [Description("mm.docconect.doc.app.performed.action.treatment")]
        PerformedOperation,
        [Description("mm.docconect.doc.app.performed.action.aftercare")]
        PerformedAftercare,
        [Description("mm.docconect.doc.app.performed.action.oct")]
        PerformedOct,
        [Description("mm.docconect.doc.app.performed.action.initial")]
        PerformedInitial
    }

    public enum ECaseProperty
    {
        [Description("mm.docconnect.case.report.downloaded")]
        ReportDownloaded,
        [Description("mm.doc.connect.case.submit.oct.until.date")]
        SubmitOctUntilDate,
        [Description("mm.doc.connect.case.is.for.documentation.only")]
        DocumentationOnly,
        [Description("mm.doc.connect.case.withdraw.oct")]
        WithdrawOct,
        [Description("mm.doc.connect.case.has.rejected.oct")]
        HasRejectedOct,
        [Description("mm.doc.connect.case.practice.invoice")]
        SendInvoiceToPractice,
        [Description("mm.doc.connect.case.treatment.year.fake")]
        FakeCase,
        [Description("mm.doc.connect.case.missing.oct.ivom")]
        MissingIvom,
        [Description("mm.doc.connect.case.order.number")]
        CaseOrderNumber
    }

    public enum EPatientProperty
    {
        [Description("mm.docconnect.patient.fee.waived")]
        FeeWaived,
        [Description("mm.docconnect.patient.external.id")]
        ExternalId,
    }

    public enum EContractParameter
    {
        [Description("Duration of participation consent – Month")]
        DurationOfParticipationConsent,
        [Description("Max number of preexaminations")]
        MaxNumberOfOcts,
        [Description("OP renews patient consent")]
        OpRenewsConsent,
        [Description("Characteristic ID")]
        CharacteristicID,
        [Description("Edifact type")]
        EdifactType,
        [Description("Encrypt edifact")]
        EncryptEdifact,
        [Description("Next edifact number")]
        NextEdifactNumber,
        [Description("Contract type")]
        ContractType,
        [Description("Message type")]
        MessageType,
        [Description("Merge for all hips")]
        MergeForAllHips,
        [Description("Use k for correction")]
        UseKForCorrection,
        [Description("Insurance number")]
        IKNumber,
        [Description("Number of days between treatment and settlement claim - Days")]
        NumberOfDaysBetweenTreatmentAndSettlement,
        [Description("Number of days between surgery and aftercare - Days")]
        NumberOfDaysBetweenTreatmentAndAftercare,
        [Description("Preexaminations - Days")]
        PreexaminationsDays,
        [Description("Use settlement year instead of treatment year")]
        UseSettlementYear,
        [Description("Doctor needs OCT certification")]
        DoctorNeedCertification
    }

    public static class EnumExtensions
    {
        public static string Value(this Enum val)
        {
            var attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes.First().Description : string.Empty;
        }
    }
}
