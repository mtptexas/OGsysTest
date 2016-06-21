using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CRM_Application.Models
{
    public class CustomerMetadata
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int CustomerID { get; set; }

        [StringLength(50)]
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [StringLength(50)]
        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Please enter your email address")] 
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string EmailAddress { get; set; }

        [StringLength(50)]
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        //[Display(Name = "Phone Number")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:(###) ###-####}")]
        //[Required(ErrorMessage ="Phone number is required")]
        //[RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]

        [Required(ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid number")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:(###) ###-####}")]
        public string PhoneNumber { get; set; }
    }

    public partial class CustomerNoteMetadata
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int CustomerNoteID { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Note is required")]
        [Display(Name = "Note")]
        public string Body { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.DateTime)]
        public System.DateTime DateAdded { get; set; }

        [Display(Name = "Created by user")]
        public string CreatedByUser { get; set; }
    }
}