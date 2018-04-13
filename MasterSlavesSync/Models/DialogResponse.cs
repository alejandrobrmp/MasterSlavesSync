using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSlavesSync.Models
{
    public enum DialogQuestionResponse
    {
        Positive,
        Negative
    }

    public class DialogResponse<T>
    {
        public DialogQuestionResponse response { get; set; }
        public T ObjectResponse { get; set; }
        public object AdditionalInfo { get; set; }
    }
}
