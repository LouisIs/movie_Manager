using Rabaswende002.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Rabaswende002.App_Start;


namespace Rabaswende002.Dtos
{
    
    public class CustomerDto
    {

            public int Id { get; set; }
            [Required]
            [StringLength(225)]
            public string Name { get; set; }

            public bool IsSubscribToNewsLetter { get; set; }

            public MembershipTypeDto MembershipType { get; set; }
       
            public byte MembershipTypeId { get; set; }

            
    //    [min18YearsIfAMember]
            public DateTime? Birthdate { get; set; }
        

    }
}