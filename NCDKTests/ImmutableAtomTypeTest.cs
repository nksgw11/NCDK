﻿/* Copyright (C) 2016  Egon Willighagen <egon.willighagen@gmail.com>
 *
 * Contact: cdk-devel@lists.sourceforge.net
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public License
 * as published by the Free Software Foundation; either version 2.1
 * of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA 02110-1301 USA.
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCDK.Config;

namespace NCDK
{
    /// <summary>
    /// Checks the functionality of the <see cref="ImmutableAtomType"/>.
    /// </summary>
    // @cdk.module test-core 
    [TestClass()]
    public class ImmutableAtomTypeTest 
        : CDKTestCase
    {
        [TestMethod()]
        public void TestToString()
        {
            var factory = AtomTypeFactory.GetInstance("NCDK.Dict.Data.cdk-atom-types.owl");
            var type = factory.GetAtomType("C.sp3");
            Assert.IsTrue(type is ImmutableAtomType);
            var output = type.ToString();
            Assert.IsTrue(output.Contains("ImmutableAtomType("));
            Assert.IsTrue(output.Contains("MBO:"));
        }
    }
}
