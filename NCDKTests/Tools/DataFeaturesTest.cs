/* Copyright (C) 2006-2007  The Chemistry Development Kit (CDK) project
 *
 * Contact: cdk-devel@lists.sourceforge.net
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public License
 * as published by the Free Software Foundation; either version 2.1
 * of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT Any WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA 02110-1301 USA.
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NCDK.Tools
{
    /// <summary>
    /// Included so that CoreCoverageTest won't complain. The class does not have
    /// methods, only constants, so there is nothing to test.
    /// </summary>
    /// <seealso cref="CDKPropertyName"/>
    // @cdk.module test-core
    [TestClass()]
    public class DataFeaturesTest : CDKTestCase
    {
        [TestMethod()]
        public void TestDataFeatures()
        {
            Assert.IsFalse(DataFeatures.Has2DCoordinates == (DataFeatures)(-1));
        }

        // FIXME: should add a test here that used introspection and test whether there
        // are not constant conflicts
    }
}
