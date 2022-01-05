namespace WebApi.Models.InputModels
{
    public class UserWatchInputModel
    {
        public int UsrWatchId { get; set; }
        public int? UsrId { get; set; }
        public int? MvId { get; set; }
        public int? SeId { get; set; }
        public bool? Watched { get; set; }
    }
}
