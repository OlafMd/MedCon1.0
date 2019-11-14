using System.ComponentModel;

namespace DLCore_DBCommons.MRMS
{
    public enum MeasurementRunStatus
    {
        [Description("measurement-run-status.uploaded")]
        Uploaded,
        [Description("measurement-run-status.published")]
        Published,
        [Description("measurement-run-status.finalized")]
        Finalized
    }
}
