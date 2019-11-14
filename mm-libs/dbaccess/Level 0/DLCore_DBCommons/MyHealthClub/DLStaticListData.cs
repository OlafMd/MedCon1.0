using System.ComponentModel;

namespace DLCore_DBCommons.MyHealthClub
{
    public enum AvailabilityType
    {
        [Description("availability-types.standard")]
        Standard,
        [Description("availability-types.webbooking")]
        WebBooking,
        [Description("availability-types.exception")]
        Exception
    }
}
