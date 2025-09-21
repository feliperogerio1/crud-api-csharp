using CrudApi.Interfaces.Repositories;
using CrudApi.Interfaces.Services;
using CrudApi.Models.Entities;
using CrudApi.Utils;

namespace CrudApi.Services;

public sealed class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Result<Customer>> Insert(Customer customer)
    {
        customer.Id = await _customerRepository.Insert(customer);
        return Result.Success<Customer>(customer);
    }

    public async Task<Result<Customer>> Get(int id)
    {
        var customer = await _customerRepository.Get(id);
        if (customer is null)
            return Result.Failure<Customer>("Customer not found");

        return Result.Success<Customer>(customer);
    }

    public async Task<Result<List<Customer>>> Get(int pageNumber, int pageSize)
    {
        var customers = await _customerRepository.Get(pageNumber, pageSize);
        return Result.Success<List<Customer>>(customers);
    }

    public async Task<Result<Customer>> Update(int id, Customer customer)
    {
        var currentCustomer = await _customerRepository.Get(id);
        if (currentCustomer is null)
            return Result.Failure<Customer>("Customer not found");

        currentCustomer.Name = customer.Name;
        var success = await _customerRepository.Update(currentCustomer);
        if (!success)
            return Result.Failure<Customer>("Update failed");

        return Result.Success<Customer>(currentCustomer);
    }

    public async Task<Result<string>> Delete(int id)
    {
        var currentCustomer = await _customerRepository.Get(id);
        if (currentCustomer is null)
            return Result.Failure<string>("Customer not found");

        var success = await _customerRepository.Delete(currentCustomer);
        if (!success)
            return Result.Failure<string>("Delete failed");

        return Result.Success<string>("Ok");
    }
}
