using Model.Abstracts;
using Model.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class CastType : FullAuditModel
    {
        [Required]
        [StringLength(ModelConstants.MAX_CASTTYPE_NAME_LENGTH)]
        public string? Name { get; set; }

    }
}
