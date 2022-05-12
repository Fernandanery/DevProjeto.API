namespace DevProjeto.API.Entities
{
    public class Packege
    {
        public Packege(string title, decimal weigth)
        {
            Code = Guid.NewGuid().ToString();
            Title = title;
            Weigth = weigth;
            Delivered = false;
            PostedAt = DateTime.Now;
            Updates = new List<PackegeUpdate>();
        }
        public void AddUpdate (string status, bool Delivered) {
            var update = new PackegeUpdate(status, Id) ;
            Updates.Add(update);

            if (Delivered) {
                Delivered = true;
            }



        }

        public int Id { get; private set; }
        public string Code { get; private set; }
        public string Title { get; private set; }
        public decimal Weigth { get; private set; }
        public bool Delivered { get; private set; }
        public DateTime PostedAt { get; private set; }
        public List<PackegeUpdate> Updates { get; private set; }

        
    }
}