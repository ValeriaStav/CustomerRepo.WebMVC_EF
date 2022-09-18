using CustomerManagement.BusinessEntities;
using CustomerManagement.EFRepositories;
using FluentAssertions;
using Xunit;

namespace CustomerManagement.Integration.Tests
{
    public class EFCustomerRepositoryTest
    {

        public EFCustomerRepositoryFixture Fixture => new EFCustomerRepositoryFixture();

        [Fact]
        public void ShouldBeAbleToCreateEFCustomerRepository()
        {
            var customerRepository = new EFCustomerRepository();
            Assert.NotNull(customerRepository);
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            var customerRepository = new EFCustomerRepository();
            var fixture = new EFCustomerRepositoryFixture();

            //customerRepository.DeleteAll();
            var customer = fixture.MockCustomer();
            customerRepository.Create(customer);

            customer.Should().NotBe(null);
        }

        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            //Fixture.DeleteAll();
            Fixture.MockCustomer();
            var createdCustomer = Fixture.CreateEFCustomerRepository().Read(1);

            createdCustomer.Should().NotBe(null);
            createdCustomer.CustomerId.Should().Be(1);
        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            //Fixture.DeleteAll();
            var customer = Fixture.MockCustomer();
            var customerRepository = Fixture.CreateEFCustomerRepository();
            customer.LastName = "Black";

            customerRepository.Update(customer);
            customer.LastName.Should().Be("Black");
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            //Fixture.DeleteAll();
            Fixture.MockCustomer();
            var customerRepository = Fixture.CreateEFCustomerRepository();

            customerRepository.Delete(1);
            var deletedCustomer = customerRepository.Read(1);
            deletedCustomer.Should().Be(null);

        }

        public class EFCustomerRepositoryFixture
        {
            public void DeleteAll()
            {
                var customerRepository = new EFCustomerRepository();
                customerRepository.DeleteAll();
            }

            public Customer MockCustomer()
            {
                var customer = new Customer
                {
                    CustomerId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    CustomerPhoneNumber = "1234567890",
                    CustomerEmail = "JohnD555@gmail.com",
                    TotalPurchaseAmount = 10000
                };

                var customerRepository = new EFCustomerRepository();
                customerRepository.Create(customer);
                return customer;
            }
            public EFCustomerRepository CreateEFCustomerRepository()
            {
                return new EFCustomerRepository();
            }
        }

    }
}
