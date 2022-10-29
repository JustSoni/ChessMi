namespace ChessMi.Core.Data.Models
{
    public class MoveInfo
    {
        public MoveInfo(bool isAllowed)
        {
            IsAllowed = isAllowed;
        }
        public bool IsAllowed { get; set; }
    }
}