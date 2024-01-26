namespace Game.Domain.Entity
{
    public class Category:BaseEntity
    {
        public ICollection<GameEntity> Games { get; set; }=new List<GameEntity>();
    }
}
