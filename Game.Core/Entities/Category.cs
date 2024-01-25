namespace Game.Domain.Entity
{
    public class Category:BaseEntity
    {
        public ICollection<Game> Games { get; set; }=new List<Game>();
    }
}
