namespace task3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Email")]
    public partial class Email
    {
        [Key]
        [StringLength(50)]
        public string ToEmail { get; set; }

        [StringLength(50)]
        public string Subject { get; set; }

        [StringLength(5000)]
        public string Contents { get; set; }

        public string filename { get; set; }

        [StringLength(5000)]
       
        public string Path { get; set; }
    }
}
