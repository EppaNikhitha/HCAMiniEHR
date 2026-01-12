namespace HCAMiniEHR.DTO
{
    public class PendingLabDto
    {
        public string PatientName { get; set; }
        public string TestName { get; set; }
        public DateTime? OrderedAt { get; set; }
    }
}
