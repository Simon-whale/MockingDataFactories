namespace DataFactoryMocking.Models;

public class Account
{
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }
    public int Status { get; set; }
    public int AllowedPaymentSchemes { get; set; }
}