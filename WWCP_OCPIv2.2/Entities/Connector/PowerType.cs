﻿/*
 * Copyright (c) 2015-2016 GraphDefined GmbH
 * This file is part of WWCP OCPI <https://github.com/GraphDefined/WWCP_OCPI>
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

namespace org.GraphDefined.WWCP.OCPIv2_1
{

    /// <summary>
    /// The format of the connector, whether it is a socket or a plug.
    /// </summary>
    public enum PowerType
    {

        /// <summary>
        /// AC single phase.
        /// </summary>
        AC_1_PHASE  = 1,

        /// <summary>
        /// AC three phases.
        /// </summary>
        AC_3_PHASE  = 2,

        /// <summary>
        /// Direct Current.
        /// </summary>
        DC          = 3

    }

}
