namespace Game.Domain.Entity
{
    public class GameDevice
    {
        public int GameId { get; set; }
        public GameEntity Game { get; set; }
        public int DeviceId { get; set; } = default;
        public Device Device { get; set; } = default;
    }
}
