
namespace BLRecords
{
    public class CustomerRepository
    {
        public Customer Retrive(int CustomerId)
        {
            var customer = new Customer(CustomerId);

            if(CustomerId == 1)
            {
                customer.FirstName = "Hebraheem";
                customer.LastName = "Movic";
                customer.Email = "hebraheem@movic.com";
            }

            return customer;
        }

        public bool Save()
        {
            return true;
        }
    }
}