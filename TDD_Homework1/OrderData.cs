﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Homework1
{
    public class OrderData<T>
    {
        IEnumerable<T> dataSource { get; set; }

        public OrderData()
        {

        }

        public void SetDatasource(IEnumerable<T> _dataSource)
        {
            dataSource = _dataSource;
        }

        public List<int> GetDataByGroup(decimal groupNumber, Func<T, int> selectProperty)
        {
            var groupList = new List<int>();

            if(dataSource != null)
            {
                var subList = dataSource.Select(selectProperty).ToList<int>();//取出指定屬性組成List

                groupList = subList
                    .Select((x, i) => new { index = i + 1, value = x })//針對每一筆建立索引
                    .GroupBy(g => Math.Ceiling(g.index / groupNumber))//針對索引組合群組
                    .Select(grp => grp.Select(v => v.value).ToList().Sum())//針對群組做Sum
                    .ToList();
            }

            return groupList;
        }
    }
}
