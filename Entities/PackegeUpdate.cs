namespace DevProjeto.API.Entities
{
    public class PackegeUpdate
    {
        public PackegeUpdate (string status, int PackegeId) {
            this.PackegeId = PackegeId ;
            Status = status ;
            UpdateDate = DateTime.Now; 
            }
        public int Id { get; private set; }
        public int PackegeId { get; private set; }
        public string Status { get; private set; }
        public DateTime UpdateDate { get; private set; }
    }
}