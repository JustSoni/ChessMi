namespace ChessMi.Core.Data.Models
{
    public class MoveInfo
    {
        public MoveInfo(bool isAllowed)
        {
            IsAllowed = isAllowed;
            FigureTaken = false;
        }
        public bool IsAllowed { get; set; }
        public bool FigureTaken { get; set; }
    }
}