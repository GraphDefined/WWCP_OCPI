﻿/*
 * Copyright (c) 2015-2020 GraphDefined GmbH
 * This file is part of WWCP OCPI <https://github.com/OpenChargingCloud/WWCP_OCPI>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#region Usings

using System;
using System.Linq;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;

using org.GraphDefined.Vanaheimr.Illias;

#endregion

namespace cloud.charging.open.protocols.OCPIv2_2
{

    /// <summary>
    /// A charging tariff element.
    /// </summary>
    public struct TariffElement
    {

        #region Properties

        /// <summary>
        /// Enumeration of price components that make up the pricing of this tariff.
        /// </summary>
        public IEnumerable<PriceComponent>     PriceComponents     { get; }

        /// <summary>
        /// Enumeration of tariff restrictions.
        /// </summary>
        public IEnumerable<TariffRestriction>  TariffRestrictions  { get;  }

        #endregion

        #region Constructor(s)

        #region TariffElement(params PriceComponents)

        /// <summary>
        /// Create a new charging tariff element.
        /// </summary>
        /// <param name="PriceComponents">Enumeration of price components that make up the pricing of this tariff.</param>
        public TariffElement(params PriceComponent[]  PriceComponents)

            : this(PriceComponents, new TariffRestriction[0])

        { }

        #endregion

        #region TariffElement(PriceComponents, TariffRestrictions = null)

        /// <summary>
        /// Create a new charging tariff element.
        /// </summary>
        /// <param name="PriceComponents">Enumeration of price components that make up the pricing of this tariff.</param>
        /// <param name="TariffRestrictions">Enumeration of tariff restrictions.</param>
        public TariffElement(IEnumerable<PriceComponent>     PriceComponents,
                             IEnumerable<TariffRestriction>  TariffRestrictions = null)
        {

            #region Initial checks

            if (PriceComponents == null)
                throw new ArgumentNullException(nameof(PriceComponents),  "The given parameter must not be null!");

            if (!PriceComponents.Any())
                throw new ArgumentNullException(nameof(PriceComponents),  "The given enumeration must not be empty!");

            #endregion

            this.PriceComponents     = PriceComponents;
            this.TariffRestrictions  = TariffRestrictions;

        }

        #endregion

        #region TariffElement(PriceComponent, TariffRestriction)

        /// <summary>
        /// Create a new charging tariff element.
        /// </summary>
        /// <param name="PriceComponent">A price component that makes up the pricing of this tariff.</param>
        /// <param name="TariffRestriction">A tariff restriction.</param>
        public TariffElement(PriceComponent     PriceComponent,
                             TariffRestriction  TariffRestriction)
        {

            #region Initial checks

            if (TariffRestriction == null)
                throw new ArgumentNullException(nameof(TariffRestriction),  "The given enumeration must not be empty!");

            #endregion

            this.PriceComponents     = new PriceComponent[]    { PriceComponent };
            this.TariffRestrictions  = new TariffRestriction[] { TariffRestriction };

        }

        #endregion

        #endregion


        #region ToJSON()

        /// <summary>
        /// Return a JSON representation of this object.
        /// </summary>
        public JObject ToJSON()

            => JSONObject.Create(new JProperty("price_components", new JArray(PriceComponents.Select(PriceComponent => PriceComponent.ToJSON()))),

                   (TariffRestrictions != null && TariffRestrictions.Any())
                       ? new JProperty("restrictions", new JArray(TariffRestrictions.Select(TariffRestriction => TariffRestriction.ToJSON())))
                       : null);

        #endregion

    }

}
