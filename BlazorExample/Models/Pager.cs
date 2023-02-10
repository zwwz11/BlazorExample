using System.Net;

namespace BlazorExample.Models
{
    public class Pager<T>
    {
        /// <summary>
        /// 한 번에 보여줄 게시글 수
        /// </summary>
        public int PageSize { get; } = 10;
        /// <summary>
        /// ex) 한 번에 누를수 있는 페이지 수
        /// </summary>
        public int PageCount { get; } = 10;
        /// <summary>
        /// 현재 페이지
        /// </summary>
        public int CurrentPage { get; set; } = 1;
        /// <summary>
        /// 총 페이지 수량
        /// </summary>
        public int TotalPage { get; set; } = 0;
        /// <summary>
        /// 페이징된 데이터
        /// </summary>
        public List<T> Values { get; set; } = new List<T>();

        public int StartPage 
        { 
            get
            {
                return ((CurrentPage - 1) / PageSize) * PageSize + 1;
            }
        }
        public int EndPage 
        { 
            get
            {
                if (StartPage + PageCount - 1 > TotalPage)
                {
                    return TotalPage;
                }
                else
                {
                    return StartPage + PageCount - 1;
                }
            }
        }
        public bool Prev => (CurrentPage - 1 >= 1);
        public bool Next => (CurrentPage + 1 <= TotalPage);
    }
}
