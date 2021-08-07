using System.Collections.Generic;
using common;

namespace BLRecords
{
    public class Customer : EntityBase, ILoggable
    {
        public Customer()
        {

        }
        public Customer(int CustomerId)
        {
            CustomerID = CustomerId;
        }
        public string CustomerType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CustomerID { get; private set; }

        public string Log() => $"Id: {CustomerID} \n Name: {FullName} \n Email: {Email}";
        public string FullName
        {
            get
            {
                var _fullName = FirstName;
                if (!string.IsNullOrWhiteSpace(LastName))
                {
                    if (!string.IsNullOrWhiteSpace(_fullName))
                    {
                        _fullName += ", ";
                    }
                    _fullName += LastName;
                }
                return _fullName;
            }

        }

        public override bool Validate()
        {
            var isValid = false;

            if (!string.IsNullOrWhiteSpace(LastName)) isValid = true;
            if (!string.IsNullOrWhiteSpace(FirstName)) isValid = true;

            return isValid;
        }

        public List<Customer> Retrive()
        {
            return new List<Customer>();
        }

    }
}