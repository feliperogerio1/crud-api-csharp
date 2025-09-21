using CrudApi.Models.DTOs;
using CrudApi.Models.Entities;

namespace CrudApi.Extensions.Mappers;

public static class CustomerMapper
{
    public static Customer ToCustomer(this CustomerRequestDTO customerDTO)
    {
        return new Customer()
        {
            Id = customerDTO.Id,
            Name = customerDTO.Name
        };
    }

    public static CustomerResponseDTO ToCustomerResponseDTO(this Customer customer)
    {
        return new CustomerResponseDTO()
        {
            Id = customer.Id,
            Name = customer.Name,
        };
    }

    public static List<CustomerResponseDTO> ToCustomersResponseDTO(this List<Customer> customers)
    {
        return customers.Select(ToCustomerResponseDTO).ToList();
    }
}
