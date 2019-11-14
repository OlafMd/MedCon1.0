using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOp.Providers.TrustRelation
{
    public enum TrustRequestStatus
    {
        /// <summary>
        /// Unknown
        /// </summary>
        None = -1,
        /// <summary>
        /// The trust relation request is pending
        /// </summary>
        Pending = 0,
        /// <summary>
        /// The trust relation request was accepted
        /// </summary>
        Accepted = 1,
        /// <summary>
        /// The trust relation request was rejected
        /// </summary>
        Rejected = 2,
        /// <summary>
        /// The trust relation request was revoked by sender
        /// </summary>
        Revoked = 3,
        /// <summary>
        /// The trust relation request was automatically rejected by gateway. Receiving tenant has probably blocked this sender or this message type for this sender.
        /// </summary>
        RejectedByGateway = 4,
        /// <summary>
        /// The trust relation was terminated
        /// </summary>
        Terminated = 5,

    }
}
