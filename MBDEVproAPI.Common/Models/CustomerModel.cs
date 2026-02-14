
namespace MBDEVproAPI.Common.Models
{
        public class Customer
        {

            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int CustomerID { get; set; }

            //[Required]
            //[Display(Name = "User name")]
            //public string Username { get; set; }

            //[Required]
            //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            //[DataType(DataType.Password)]
            //[Display(Name = "Password")]
            //public string Password { get; set; }

            //[DataType(DataType.Password)]
            //[Display(Name = "Confirm password")]
            //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            //public string ConfirmPassword { get; set; }


            [StringLength(50)]
            [DataType(DataType.Text)]
            public string Company { get; set; }

            [StringLength(25)]
            [DataType(DataType.Text)]
            public string FirstName { get; set; }

            [StringLength(25)]
            [DataType(DataType.Text)]
            public string LastName { get; set; }

            [Required]
            [StringLength(75)]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [StringLength(50)]
            [DataType(DataType.Text)]
            public string Title { get; set; }

            [StringLength(25)]
            [DataType(DataType.Text)]
            public string BPhone { get; set; }

            [StringLength(25)]
            [DataType(DataType.Text)]
            public string HPhone { get; set; }

            [StringLength(25)]
            [DataType(DataType.Text)]
            public string MPhone { get; set; }

            [StringLength(25)]
            [DataType(DataType.Text)]
            public string Fax { get; set; }

            [StringLength(75)]
            [DataType(DataType.Text)]
            public string Address { get; set; }

            [StringLength(75)]
            [DataType(DataType.Text)]
            public string City { get; set; }

            [StringLength(75)]
            [DataType(DataType.Text)]
            public string State { get; set; }

            [StringLength(15)]
            [DataType(DataType.Text)]
            public string ZIPCode { get; set; }

            [StringLength(30)]
            [DataType(DataType.Text)]
            public string Country { get; set; }

            [StringLength(30)]
            [DataType(DataType.Text)]
            public string Category { get; set; }

            [StringLength(75)]
            [DataType(DataType.Text)]
            public string WebPage { get; set; }

            [StringLength(4010)]
            [DataType(DataType.MultilineText)]
            public string Notes { get; set; }

            [StringLength(75)]
            [DataType(DataType.Text)]
            public string Photo { get; set; }

            [StringLength(300)]
            [DataType(DataType.Text)]
            public string Map { get; set; }

        }

}
