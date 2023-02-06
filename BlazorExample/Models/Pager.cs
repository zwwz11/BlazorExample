using System.Net;

namespace BlazorExample.Models
{
    public class Pager<T> where T : class
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
        public int CurretPage { get; set; } = 1;
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
                return CurretPage - (CurretPage % PageSize) + 1;
            }
        }
        public int EndPage 
        { 
            get
            {
                if (CurretPage - (CurretPage % 10) + PageCount > TotalPage)
                {
                    return TotalPage;
                }
                else
                {
                    return CurretPage - (CurretPage % 10) + PageCount;
                }
            }
        }
    }
}
