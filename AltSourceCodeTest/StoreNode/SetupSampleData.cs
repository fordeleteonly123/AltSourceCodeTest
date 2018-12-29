using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseCase;

namespace StoreNode
{
    public static class SetupSampleData
    {
        public static void Setup(StoreLogic storeLogic)
        {
            var c1 = new Clothing(1, CType.T_Shirt, CSize.Ma_L, CColor.Blue);
            var c2 = new Clothing(2, CType.T_Shirt, CSize.Ma_L, CColor.Grey);

            var c3 = new Clothing(3, CType.T_Shirt, CSize.Fe_M, CColor.Blue);
            var c4 = new Clothing(4, CType.T_Shirt, CSize.Fe_S, CColor.Pink);

            var c5 = new Clothing(5, CType.DressShirt, CSize.Ma_S, CColor.Grey);
            var c6 = new Clothing(6, CType.DressShirt, CSize.Ma_S, CColor.Blue);

            var c7 = new Clothing(7, CType.DressShirt, CSize.Fe_S, CColor.Pink);
            var c8 = new Clothing(8, CType.DressShirt, CSize.Fe_S, CColor.Blue);

            storeLogic.Register(c1);
            storeLogic.Register(c2);
            storeLogic.Register(c3);
            storeLogic.Register(c4);
            storeLogic.Register(c5);
            storeLogic.Register(c6);
            storeLogic.Register(c7);
            storeLogic.Register(c8);

            var inRecord1 = new StockInRecord(1, 1, 10, 6m, DateTime.Now, 1);
            var inRecord2 = new StockInRecord(2, 3, 10, 8m, DateTime.Now, 2);
            var inRecord3 = new StockInRecord(3, 5, 10, 7m, DateTime.Now, 3);
            var inRecord4 = new StockInRecord(4, 7, 10, 9m, DateTime.Now, 4);

            storeLogic.RecordClothingFromSupplier(inRecord1);
            storeLogic.RecordClothingFromSupplier(inRecord2);
            storeLogic.RecordClothingFromSupplier(inRecord3);
            storeLogic.RecordClothingFromSupplier(inRecord4);
        }
    }
}
