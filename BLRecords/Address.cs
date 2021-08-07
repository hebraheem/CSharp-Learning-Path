using System;

namespace BLRecords
{
    public class Address
    {
        public Address()
        {
            
        }
        public Address(int addressId)
        {
            AddressId = addressId;
        }
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public int? PostalCode { get; set; }
        public string Country { get; set; }
        public string AddressType { get; set; }
        public int AddressId { get; private set; }
        
        public bool Validate()
        {
            var isValid = false;

            if(!string.IsNullOrWhiteSpace(StreetLine1)) isValid = true;
            if(!string.IsNullOrWhiteSpace(City)) isValid = true;
            if(!string.IsNullOrWhiteSpace(StateProvince)) isValid = true;
            if(!string.IsNullOrWhiteSpace(Country)) isValid = true;
            if(!string.IsNullOrWhiteSpace(AddressType)) isValid = true;
            if(PostalCode != null) isValid = true;

            return isValid;
        }
        
    }
}
