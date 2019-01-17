using System;
using System.ComponentModel.DataAnnotations;

namespace TVX.Test.Core
{
    public interface IMicroService
    {
        int Id { get; set; }

        string Name { get; set; }

        string EndpointUrl { get; set; }

        bool IsOnline { get; set; }
    }
}
