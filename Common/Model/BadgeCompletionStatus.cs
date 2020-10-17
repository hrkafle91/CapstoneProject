using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class BadgeCompletionStatus
    {
        public int BadgeId { get; set; }
        public int CompletionStatus { get; set; }
    }

    public enum CompletionStatus
    {
        Incomplete,
        Complete
    }
}
