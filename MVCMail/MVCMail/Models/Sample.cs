using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMail.Models
{    
    public class Sample
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your mail"), EmailAddress(ErrorMessage = "Enter your mail type of mail")]
        public string Email { get; set; }

        public Guid? activationCode { get; set; }

        public bool IsActive { get; set; }

        public Sample()
        {
            IsActive = false;
            activationCode = Guid.NewGuid();
        }

    }
}