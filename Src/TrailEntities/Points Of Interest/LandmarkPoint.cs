﻿using System.Collections.Generic;
using TrailCommon;

namespace TrailEntities
{
    public sealed class LandmarkPoint : LocationPoint
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:TrailEntities.Settlement" /> class.
        /// </summary>
        public LandmarkPoint(string name, ulong distanceLength, IEnumerable<Item> pointInventory = null) :
            base(name, distanceLength, true, pointInventory)
        {
        }
    }
}