using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Model.Constants;
using Model.Interfaces;

namespace Model.Abstracts
{
    public abstract class FullAuditModel : IIdentityModel, IAuditedModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
