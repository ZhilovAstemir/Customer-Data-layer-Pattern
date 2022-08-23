using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Repositories;
using Xunit;

namespace Customer.Datalayer.Tests
{
    public class CustomerRepositoryTests
    {
        public CustomersRepositoryFixture Fixture => new CustomersRepositoryFixture();

        [Fact]
        public void ShouldBeAbleToCreateCustomerRepository()
        {
            var repository = new CustomerRepository();
            Assert.NotNull(repository);
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            Fixture.DeleteAll();
            var repository = new CustomerRepository();
            var customers = new Customers
            {
                FirstName = "name",
                LastName = "surname",
                PhoneNumber = "+11234567891123",
                Email = "mail@mail.ru",
                TotalPurchasesAmount = 1,
                Notes = "note1"
            };
            repository.Create(customers);
        }

        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            Fixture.DeleteAll();
            var repository = Fixture.CreateCustomerRepository();
            Assert.NotNull(repository.Read(repository.GetID()));
        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            Fixture.DeleteAll();
            var customers = Fixture.CreateMockCustomer();
            var repository = Fixture.CreateCustomerRepository();
            customers.FirstName = "newName";

            repository.Update(customers);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            Fixture.DeleteAll();
            var repository = Fixture.CreateCustomerRepository();

            repository.Delete(1);
        }
    }

    public class CustomersRepositoryFixture
    {
        public void DeleteAll()
        {
            var repository = new CustomerRepository();
            repository.DeleteAll();
        }
        public Customers CreateMockCustomer()
        {
            var customers = new Customers
            {
                FirstName = "name",
                LastName = "surname",
                PhoneNumber = "+11234567891123",
                Email = "mail@mail.ru",
                TotalPurchasesAmount = 1,
                Notes = "note1"
            };
            var customerRepository = new CustomerRepository();
            customerRepository.Create(customers);
            return customers;
        }
        public CustomerRepository CreateCustomerRepository()
        {
            return new CustomerRepository();
        }
    }
}
