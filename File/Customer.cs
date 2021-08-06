using System.Collections.Generic;
using System.Text;
using System;
namespace BLRecords
{
    public class Customer
    {
        public Customer()
        {
            
        }
        public Customer(int CustomerId)
        {
            CustomerId = CustomerID;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }        
        public int CustomerID { get; private set; }
        public string FullName
        {
            get 
            { 
                var _fullName = FirstName;
                if(!string.IsNullOrWhiteSpace(LastName))
                {
                    if(!string.IsNullOrWhiteSpace(_fullName))
                    {
                        _fullName += ", ";
                    }
                    _fullName += LastName;
                }
                return  _fullName; 
            }
            
        }

        public bool Validate()
        {
            var isValid = false;

            if(!string.IsNullOrWhiteSpace(LastName)) isValid = true;
            if(!string.IsNullOrWhiteSpace(FirstName)) isValid = true;

            return isValid;
        }
        
        public Customer Retrive(int CustomerId)
        {
            return new Customer();
        }
        
        public List<Customer>  Retrive()
        {
            return new List<Customer>();
        }

        public void Save()
        {

        }
                
    }
}