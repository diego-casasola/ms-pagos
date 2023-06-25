using ShareKernel.Core;
using ShareKernel.Rules;

namespace SharedKernel.ValueObjects
{
    public record DonanteNameValue : ValueObject
    {
        public string Name { get; set; }

        public DonanteNameValue(string name)
        {
            CheckRule(new StringNotNullOrEmptyRule(name));
            if(name.Length > 100)
            {
                throw new BussinessRuleValidationException("DonanteName can't be more than 100 characters");
            }
            Name = name;
        }

        public static implicit operator string(DonanteNameValue value)
        {
            return value.Name;
        }

        public static implicit operator DonanteNameValue(string name)
        {
            return new DonanteNameValue(name);
        }
    }
}
