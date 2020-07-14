﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Giprojivmash.DAL.Entities
{
    [Table("servicesecondlayer")]
    public class ServiceSecondLayerEntity : BaseEntity
    {
        public string Description { get; set; }

        public int ServiceFirstLayerId { get; set; }
    }
}
