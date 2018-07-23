﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Aikido.DAO
{
    public class DAI_DAN
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public String Name { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime Day_Create { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? Day_Update { get; set; }

        public Boolean Delete_Flag { get; set; }
    }
}
