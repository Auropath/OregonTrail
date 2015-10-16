﻿using System.Collections.ObjectModel;

namespace TrailCommon
{
    public interface IStore : ITrailMode
    {
        ReadOnlyCollection<IItem> StoreInventory { get; }
        string StoreName { get; }
        uint StoreBalance { get; }
        IStore StoreController { get; }
        void BuyItems(IItem item);
        void SellItem(IItem item);
    }
}