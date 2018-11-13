using System;
using System.ComponentModel.DataAnnotations;

namespace DependerIO.Api.DTO {
    public class Handler
    {
        public string Id { get; set; }
        public string Name {get; set; }
        public string ServiceId {get; set; }
        
        public string ServiceName {get; set; }
    }
}