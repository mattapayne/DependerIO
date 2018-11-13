using System;
using System.ComponentModel.DataAnnotations;

namespace DependerIO.Api.Models {
    public class Handler : IModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name {get; set; }
        public Service Service {get; set;}
        public Guid ServiceId {get; set; }
    }
}