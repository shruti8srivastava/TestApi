using TestApi.DataBase;
using TestApi.Model;

namespace TestApi.Service;

public class EmployeeService{
    private readonly ApplicationDbContext _context;

    public EmployeeService(ApplicationDbContext context)
{
        _context = context;
    }
    public List<EmployeeModel> GetAllEmployees(){
        return _context.Employees.ToList();
    }
}