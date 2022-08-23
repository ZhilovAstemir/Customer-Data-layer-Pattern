using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Repositories;
using FluentAssertions;
using Xunit;

namespace Customer.Datalayer.Tests
{
    public class AddressRepositoryTests
    {
        public AddressRepositoryFixture Fixture => new AddressRepositoryFixture();

        [Fact]
        public void ShouldBeAbleToCreateAddressRepository()
        {
            var repository = new AddressRepository();
            repository.Should().NotBeNull();
        }

        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            Fixture.DeleteAll();
            var repository = Fixture.CreateAddressRepository();
            var address = new Addresses()
            {
                CustomerID = repository.GetCustomerID(),
                AddressLine = "line1",
                AddressLine2 = "line2",
                AddressType = "Shipping",
                City = "Chicago",
                PostalCode = "60666",
                StateName = "Illinois",
                Country = "USA"
            };
            address.Should().NotBeNull();
            repository.Create(address);
        }
        
        [Fact]
        public void ShouldBeAbleToReadAddress()
        {
            Fixture.DeleteAll();
            var repository = Fixture.CreateAddressRepository();
            Assert.NotNull(repository.Read(repository.GetID()));
        }

        [Fact]
        public void ShouldBeAbleToUpdateAddress()
        {
            Fixture.DeleteAll();
            var addresses = Fixture.CreateMockAddress();
            var repository = Fixture.CreateAddressRepository();
            addresses.AddressLine = "newLine";

            repository.Update(addresses);
        }

        [Fact]
        public void ShouldBeAbleToDeleteAddress()
        {
            Fixture.DeleteAll();
            var repository = Fixture.CreateAddressRepository();

            repository.Delete(1);
        }
    }

    public class AddressRepositoryFixture
        {
            public void DeleteAll()
            {
                var repository = new AddressRepository();
                repository.DeleteAll();
            }
            public Addresses CreateMockAddress()
            {
                var customers = new CustomerRepository();
                int ID = customers.GetID();
                var addresses = new Addresses
                {
                    CustomerID = ID,
                    AddressLine = "line1",
                    AddressLine2 = "line2",
                    AddressType = "Shipping",
                    City = "Chicago",
                    PostalCode = "60666",
                    StateName = "Illinois",
                    Country = "USA"
                };
                var addressRepository = new AddressRepository();
                addressRepository.Create(addresses);
                return addresses;
            }
            public AddressRepository CreateAddressRepository()
            {
                return new AddressRepository();
            }
        }
    }
}
