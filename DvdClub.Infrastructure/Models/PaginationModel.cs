namespace DvdClub.Infrastructure.Models {
    public class PaginationModel<T> {
        public List<T> Items { get; set; }

        public int PageNum { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPagesCount { get; set; }
        public List<int> Pages { get; set; }
        public string SearchString { get; set; }
        public string Genre { get; set; }

        public PaginationModel() {
            Items = new List<T>();
        }

        public PaginationModel(List<T> items) {
            Items = items;
        }

        public PaginationModel(List<T> items, int pageNum, int pageSize, int totalItems, int totalPagesCount, List<int> pages, string searchString, string genre) {
            Items = items;
            PageNum = pageNum;
            PageSize = pageSize;
            TotalItems = totalItems;
            this.TotalPagesCount = totalPagesCount;
            this.Pages = pages;
            this.SearchString = searchString;
            this.Genre = genre;
        }
    }
}
