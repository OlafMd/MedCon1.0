using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Models
{
    public class ElasticParameterObject
    {
        private DateTime _orders_date_from;
        private DateTime _orders_date_to;

        public string sort_by { get; set; }
        public bool isAsc { get; set; }
        public int start_row_index { get; set; }
        public int page_size { get; set; }
        public string search_params { get; set; }
        public string date_from { get; set; }
        public string date_to { get; set; }
        public Filter filter_by { get; set; }
        public DateTime min_treatment_year_start_date { get; set; }
        public DateTime max_treatment_year_start_date { get; set; }
        public double max_octs_per_treatment_year { get; set; }
        public double default_shipping_date_offset { get; set; }
        public IEnumerable<Guid> deselected_ids { get; set; }
        public bool omit_withdrawn { get; set; }
        public bool show_only_with_rejected_octs { get; set; }
        public string hip_name { get; set; }
        public bool this_practice { get; set; }
        public bool different_practice { get; set; }
        public bool invalid_consent { get; set; }
        public double treatment_year_length { get; set; }
        public double max_days_to_submit_oct { get; set; }

        public DateTime orders_from_date
        {
            get
            {
                return _orders_date_from.ToLocalTime();
            }
            set
            {
                _orders_date_from = value.ToUniversalTime();
            }
        }

        public DateTime orders_to_date
        {
            get
            {
                return _orders_date_to.ToLocalTime();
            }
            set
            {
                _orders_date_to = value.ToUniversalTime();
            }
        }

        public ElasticParameterObject()
        {
            filter_by = new Filter();
        }
    }

    public class Filter
    {
        public string[] filter_type { get; set; }
        public string[] filter_status { get; set; }
        public bool filter_current { get; set; }
        public bool has_rejected_oct { get; set; }
        public string localization { get; set; }
        public bool? orders { get; set; }
        public bool ops_with_overdue_acs { get; set; }
        public bool ordered_drugs { get; set; }
    }

    public class ElasticParameterObjectMultiSubmit : ElasticParameterObject
    {
        public IEnumerable<Guid> selected_ids { get; set; }
        public bool all_selected { get; set; }
        public string submission_date { get; set; }
        public Guid oct_doctor_id { get; set; }
    }
}