using SampleProject.Dtos;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Services.Product;

public class ProductService
{
    private readonly IProductRepository _repository;
    private readonly IEmailService _emailService;
    private readonly IUserRepository _userRepository;
    private readonly IOrderRepository _orderRepository;

    public ProductService(IProductRepository productRepository , IEmailService emailService , IUserRepository userRepository,IOrderRepository orderRepository)
    {
        _repository = productRepository;
        _emailService = emailService;
        _userRepository = userRepository;
        _orderRepository = orderRepository;
    }

    public async Task AddAsync(ProductDto productDto)
    {
        if (productDto is null)
            throw new ArgumentNullException();
        
        ProductModel productModel = new ProductModel(productDto.Name, productDto.Price, 10);
        _repository.Save(productModel);
    }
    
    public async Task<ProductDto> GetAsync(int id)
    {
        ProductModel model =await _repository.GetAsync(id);
        if (model is null)
            throw new Exception("given id was not found");

        ProductDto dto = new(model.Id, model.Name, model.Price);
        return dto;
    }

    public async Task<(bool isSuccessfull , string message)> OrderAsync(int  id , int userId)
    {
        ProductModel product =await _repository.GetAsync(id);
        if (product is null)
           return (false,"given id was not found");

        UserModel user = await _userRepository.GetAsync(userId);
        if(user is null)
            return (false,"user was not found");

        decimal userBalance = _userRepository.GetBalance(userId);
        
        if(userBalance < product.Price)
            return (false, "balance is not enough");
        
        if (product.Inventory <= 0)
            return (false, "inventory is not enough");

        OrderModel orderModel = new()
        {
            UserId = userId,
            ProductId = id
        };
        
       await _orderRepository.AddAsync(orderModel);
       await _emailService.SendAsync("nikoo@gmail.com", user.Email, "Order Completed", "Order was completed");

       return (true, "Order was successfull");

    }
}