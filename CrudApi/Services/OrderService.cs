using CrudApi.Interfaces.Repositories;
using CrudApi.Interfaces.Services;
using CrudApi.Models.Entities;
using CrudApi.Utils;

namespace CrudApi.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerService _customerService;

    public OrderService(IOrderRepository orderRepository, ICustomerService customerService)
    {
        _orderRepository = orderRepository;
        _customerService = customerService;
    }

    public async Task<Result<Order>> Insert(Order order)
    {
        var resultCustomer = await _customerService.Get(order.CustomerId);
        if (!resultCustomer.IsSuccess)
            return Result.Failure<Order>(resultCustomer.Error);

        order.Id = await _orderRepository.Insert(order);

        order.OrderItems.ForEach(item => item.OrderId = order.Id);
        await _orderRepository.InsertItems(order.OrderItems);

        return Result.Success(order);
    }

    public async Task<Result<Order>> Get(int id)
    {
        var order = await _orderRepository.Get(id);
        if (order is null)
            return Result.Failure<Order>("Order not found");

        return Result.Success(order);
    }

    public async Task<Result<List<Order>>> Get(int pageNumber, int pageSize)
    {
        var orders = await _orderRepository.Get(pageNumber, pageSize);
        return Result.Success(orders);
    }

    public async Task<Result<Order>> GetWithItems(int id)
    {
        var order = await _orderRepository.GetWithItems(id);
        if (order is null)
            return Result.Failure<Order>("Order not found");

        return Result.Success(order);
    }

    public async Task<Result<Order>> Update(int id, Order order)
    {
        var currentOrder = await _orderRepository.Get(id);
        if (currentOrder is null)
            return Result.Failure<Order>("Order not found");

        var resultCustomer = await _customerService.Get(order.CustomerId);
        if (!resultCustomer.IsSuccess)
            return Result.Failure<Order>(resultCustomer.Error);

        currentOrder.OrderDate = order.OrderDate;
        currentOrder.Total = order.Total;
        currentOrder.CustomerId = order.CustomerId;
        currentOrder.OrderItems = order.OrderItems;

        var success = await _orderRepository.Update(currentOrder);
        if (!success)
            return Result.Failure<Order>("Update failed");

        await _orderRepository.DeleteItems(currentOrder.Id);
        await _orderRepository.InsertItems(currentOrder.OrderItems);

        return Result.Success(currentOrder);
    }

    public async Task<Result<string>> Delete(int id)
    {
        var currentOrder = await _orderRepository.Get(id);
        if (currentOrder is null)
            return Result.Failure<string>("Order not found");

        await _orderRepository.DeleteItems(id);

        var success = await _orderRepository.Delete(currentOrder);
        if (!success)
            return Result.Failure<string>("Delete failed");

        return Result.Success("Ok");
    }
}
