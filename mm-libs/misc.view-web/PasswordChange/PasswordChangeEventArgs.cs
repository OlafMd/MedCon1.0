using System;

namespace PasswordChange
{
    public class PasswordChangeEventArgs : EventArgs
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
