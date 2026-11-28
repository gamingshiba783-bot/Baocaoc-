namespace Baibaocao.net.Model.SearchBuilder
{
    public class BookStatusSearchBuilder
    {
        public string? Keyword { get; set; }
        /// <summary>1 = Chưa trả, 2 = Quá hạn, 3 = Đã trả, null = tất cả</summary>
        public int? State { get; set; }
        public string? Condition { get; set; }
    }
}
