using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface IPersistance
    {
        // Exceptions:
        //      If there are more than one this Id
        bool HasItem(int Id);

        void Register(Clothing item);

        void StockIn(StockInRecord record);

        void StockOut(StockOutRecord record);

        CurrentStock[] GetAllCurrentStocks();

        void AddOrUpdateCurrentStock(int clothingId, int count);

        // Returns:
        //      Number of item has in store which is equal or larger than 1.
        //      -1: Clothing item is not in store yet
        int GetCurrentStock(int clothingId);
    }
}
