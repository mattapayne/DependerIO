using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DependerIO.Api.Models {

    public class Service : IModel {

        [Key]
        public Guid Id {get;set;}
        [Required]
        [MaxLength(255)]
        public string Name {get;set;}
        public string Description {get;set;}

        public ICollection<Handler> Handlers {get; set; }
    }
}