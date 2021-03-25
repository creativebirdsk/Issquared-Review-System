using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BegginerLevelTask.Models
{
    public class Rough
    {

    }
}
//using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Web.Mvc;

//    public partial class Employee
//{
//    public long EmployeeID { get; set; }

//    [Required(ErrorMessage = "This field is required.")]
//    public string FirstName { get; set; }

//    [Required(ErrorMessage = "This field is required.")]
//    public string LastName { get; set; }

//    [Required(ErrorMessage = "This field is required.")]
//    [Column(TypeName = "date")]
//    public Nullable<System.DateTime> DOB { get; set; }
//    public string Gender { get; set; }

//    [Required(ErrorMessage = "This field is required.")]
//    public string DesignationEmp { get; set; }

//    [Required(ErrorMessage = "This field is required.")]
//    [Column(TypeName = "date")]
//    public Nullable<System.DateTime> DOJ { get; set; }

//    [Required(ErrorMessage = "This field is required.")]
//    public string DepartmentEmp { get; set; }

//    [Required(ErrorMessage = "This field is required.")]
//    public string AddressEmp { get; set; }
//    public string EmployeeType { get; set; }

//    [Required(ErrorMessage = "This field is required.")]
//    [EmailAddress]
//    public string EmailEmp { get; set; }
//    public string Status { get; set; }

//    [Required(ErrorMessage = "This field is required.")]
//    [Remote("CheckUsernameAvailability", "Employee", HttpMethod = "POST", ErrorMessage = "User name already exists.")]
//    public string UserNameEmp { get; set; }

//    [Required(ErrorMessage = "This field is required.")]
//    public string PasswordEmp { get; set; }

//    [Required(ErrorMessage = "This field is required.")]
//    public string PhoneNumEmp { get; set; }
//}
//}
///////////////
/////using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.Web.Mvc;

//    public partial class tbl_Organisation
//{

//    public int UserID { get; set; }

//    [Required(ErrorMessage = "This field is required.")]
//    public string Name { get; set; }

//    [Required(ErrorMessage = "This field is required.")]
//    public string PhoneNumber { get; set; }

//    [Required(ErrorMessage = "This field is required.")]
//    [EmailAddress]
//    public string Email { get; set; }

//    [Required(ErrorMessage = "This field is required.")]
//    public string Password { get; set; }

//    [Required(ErrorMessage = "This field is required.")]
//    public string Country { get; set; }

//    [Required(ErrorMessage = "This field is required.")]
//    public string State { get; set; }

//    [Required(ErrorMessage = "This field is required.")]
//    public string City { get; set; }
//    public string MaritalStatus { get; set; }
//    public string Description { get; set; }

//    [Required(ErrorMessage = "This field is required.")]
//    [Remote("CheckUsernameAvailability", "Organisation", HttpMethod = "POST", ErrorMessage = "User name already exists.")]
//    public string UserName { get; set; }
//}
//}