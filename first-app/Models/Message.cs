using System.ComponentModel.DataAnnotations;

namespace ContactUs.Models
{
    public class Message
    {
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string FullName { get; set; }

        [Display(Name = "موضوع پیام")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Subject { get; set; }

        [Display(Name = "شماره تماس")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(11,ErrorMessage = "{0} نامعتبر است")]
        [MinLength(11, ErrorMessage = "{0} نامعتبر است")]
        public string PhoneNumber { get; set; }

        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string MessageBody { get; set; }


        [Compare("PhoneNumber",ErrorMessage = "شماره تلفن مثل هم نیستند")]
        public string ConfirmPhoneNumber { get; set; }
    }
}