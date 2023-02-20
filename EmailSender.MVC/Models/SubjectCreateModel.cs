using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmailSender.MVC.Models
{
    public class SubjectCreateModel
    {
        [Required, MinLength(3, ErrorMessage = "The Length Of Subject Must Be More Than 3 Chars")]
        [Display(Name = "Subject")]
        public string Subject { get; set; }
        [Required, MinLength(10, ErrorMessage = "The Length Of Message Must Be More Than 10 Chars")]
        [Display(Name = "Message")]
        public string Message { get; set; }

    }
}
