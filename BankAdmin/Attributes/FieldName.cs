using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAdmin
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class FieldName : System.Attribute
    {
        public string value;
        public bool readOnly;
        public bool isId;
        public FieldName(string value, bool readOnly, bool isId)
        {
            this.value = value;
            this.readOnly = readOnly;
            this.isId = isId;
        }
        public FieldName(string value, bool readOnly)
        {
            this.value = value;
            this.readOnly = readOnly;
            this.isId = false;
        }
        public FieldName(string value)
        {
            this.value = value;
            this.readOnly = false;
            this.isId = false;
        }
    }
}
