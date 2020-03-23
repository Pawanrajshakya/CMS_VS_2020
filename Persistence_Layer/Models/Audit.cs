using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence_Layer.Models
{
    public class Audit
    {
        public int CreatedBy { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
        public int LastModifiedBy { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastModifiedDate { get; set; }
        public bool IsVisible { get; set; }
        public bool IsActive { get; set; }
        //Handling Concurrency with the Entity Framework 6 in an ASP.NET MVC 5 Application (10 of 12)
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}