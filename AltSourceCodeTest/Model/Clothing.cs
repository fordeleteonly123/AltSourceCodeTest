using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Clothing
    {
        public int Id { get; set; }
        public CType Type { get; set; }
        public CSize Size { get; set; }
        public CColor MyProperty { get; set; }
    }

    public class StockInRecord
    {
        public int Id { get; set; }
        public Clothing Clothing { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public int SupplierId { get; set; }
    }

    public class StockOutRecord
    {
        public int Id { get; set; }
        public Clothing Clothing { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public int OrderId { get; set; }
    }

    public class CurrentStock
    {
        public Clothing Clothing { get; set; }
        public int Count { get; set; }
    }
}
