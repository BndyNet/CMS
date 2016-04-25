using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common
{
    [DataContract]
    public class Pagination<T> : IPagination
    {
        private IList<T> _data;
        [DataMember]
        public IList<T> Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
                if (!this.PageSize.HasValue)
                {
                    _recordCount = _data.Count;
                    this.RecordCountOfCurrentPage = _recordCount;
                }
            }
        }
        [DataMember]
        public int? PageSize { get; set; }
        private int _recordCount;
        [DataMember]
        public int RecordCount
        {
            get
            {
                return _recordCount;
            }
            set
            {
                _recordCount = value;

                if (_recordCount > 0)
                {
                    // set page count
                    if (this.PageSize > 0)
                    {
                        if (_recordCount % this.PageSize == 0)
                        {
                            this.PageCount = _recordCount / this.PageSize.Value;
                        }
                        else
                        {
                            this.PageCount = _recordCount / this.PageSize.Value + 1;
                        }
                    }
                    else
                    {
                        this.PageCount = 1;
                    }
                    // check current page
                    if (this.CurrentPage < 1)
                        this.CurrentPage = 1;
                    else if (this.CurrentPage > this.PageCount)
                        this.CurrentPage = this.PageCount;
                    // set the max item count
                    if (this.CurrentPage == this.PageCount)
                    {
                        this.RecordCountOfCurrentPage = _recordCount;
                    }
                    else
                    {
                        this.RecordCountOfCurrentPage = this.CurrentPage * this.PageSize.Value;
                    }
                    // set start and end page numbers
                    if (this.PageCount <= 10)
                    {
                        this.DisplayPageNumbers.AddRange(Math.Range(this.PageCount));
                    }
                    else
                    {
                        this.DisplayPageNumbers.AddRange(new int[] { 1, 2 });

                        var b = 0;
                        var e = 0;

                        if (this.CurrentPage <= 5)
                        {
                            b = 3;
                            e = b + 4;
                        }
                        else if (this.CurrentPage >= this.PageCount - 5)
                        {
                            e = this.PageCount - 2;
                            b = e - 4;
                        }
                        else
                        {
                            b = this.CurrentPage - 2;
                            e = this.CurrentPage + 2;
                        }


                        if (b > 3)
                            this.DisplayPageNumbers.Add(-1);

                        this.DisplayPageNumbers.AddRange(
                            Math.Range(b, e));

                        if (e < this.PageCount - 3)
                            this.DisplayPageNumbers.Add(-2);

                        this.DisplayPageNumbers.AddRange(new int[] { this.PageCount - 1, this.PageCount });
                    }
                }
            }
        }
        [DataMember]
        public int CurrentPage { get; set; }
        [DataMember]
        public int PageCount { get; set; }
        [DataMember]
        public List<int> DisplayPageNumbers { get; set; }
        [DataMember]
        public int RecordCountOfCurrentPage { get; set; }
        [DataMember]
        public dynamic Extra { get; set; }
        public Pagination(int? pageSize = null,
            int currentPage = 1)
        {
            this.PageSize = pageSize;
            this.CurrentPage = currentPage;
            this.Data = new List<T>();
            this.Extra = new Dictionary<string, string>();
            this.DisplayPageNumbers = new List<int>();
        }
    }

    public interface IPagination
    {
        int? PageSize { get; set; }
        int RecordCount { get; set; }
        int CurrentPage { get; set; }
        int PageCount { get; set; }
        int RecordCountOfCurrentPage { get; set; }
        List<int> DisplayPageNumbers { get; set; }
    }
}
