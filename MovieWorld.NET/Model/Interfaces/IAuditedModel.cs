namespace Model.Interfaces
{
    public interface IAuditedModel
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
