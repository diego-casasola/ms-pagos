using Shared.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Rules
{
    public class NotNullRule : IBussinessRule
    {
        private readonly object _value;

        public NotNullRule(object value)
        {
            _value = value;
        }

        public string Message => "Objeto no puede ser nulo";

        public bool IsValid()
        {
            return _value != null;
        }
    }
}
