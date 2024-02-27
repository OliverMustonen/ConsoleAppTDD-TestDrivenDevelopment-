
namespace ConsoleAppTDD.Interface;

public interface ICustomerService
{
    bool AddToList(ICustomer customer);
    IEnumerable<ICustomer> GetAllFromList();
}
