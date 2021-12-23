namespace GymApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SignUpForGroupLessons
    {
        [Key]
        public int SignUp_Id { get; set; }

        public int GroupLessons_Id { get; set; }

        public int Client_Id { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public virtual Clients Clients { get; set; }

        public virtual GroupLessons GroupLessons { get; set; }
    }
}
