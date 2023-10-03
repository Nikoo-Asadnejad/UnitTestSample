using SampleProject.Models;

namespace SampleProject.Interfaces;

public interface IOrderRepository
{
    Task AddAsync(OrderModel order);
}