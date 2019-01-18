using System;
using System.ComponentModel.DataAnnotations;

namespace MicroservicesQuickStart.ApiGateway.Models
{
    using Core;

    public class MicroService : IMicroService
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(64)]
        public string Name { get; set; }

        [Url, Required, StringLength(250)]
        public string EndpointUrl { get; set; }

        public bool IsOnline { get; set; }
    }
}
