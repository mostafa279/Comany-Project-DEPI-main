
using DEPI_Final_Project.ViewModels.RoleVM;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DEPI_Final_Project.ViewModels.AccountVM
{
    public class AdminRegisterVM
    {
        public RegisterUserVM RegisterUserVM { get; set; } = null!;
        public IEnumerable<SelectListItem> RolesList { get; set; } = Enumerable.Empty<SelectListItem>();
        public string SelectedRole { get; set; } = null!;
    }
}
