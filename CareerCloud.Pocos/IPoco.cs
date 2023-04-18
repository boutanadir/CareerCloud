using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CareerCloud.Pocos
{
    public interface IPoco
    {
        Guid Id { get; set; } // Id property is public by default inside the interface
    }
}