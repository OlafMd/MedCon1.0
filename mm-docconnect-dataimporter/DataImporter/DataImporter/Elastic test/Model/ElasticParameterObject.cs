using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Elastic_test.Model
{
    public class ElasticParameterObject
    {
        public string sort_by { get; set; }
        public bool isAsc { get; set; }
        public int start_row_index { get; set; }
        public string search_params { get; set; }
    }
}
