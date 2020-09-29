using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class QuestionAnswerModel
    {
        public int QuestionId { get; set; }
        public bool? IsNone { get; set; } = false;
        public bool? IsBeginner { get; set; } = false;
        public bool? IsIntermediate { get; set; } = false;
    }
}
