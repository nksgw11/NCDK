/* Copyright (C) 2007  Miguel Rojasch <miguelrojasch@users.sf.net>
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
using NCDK.Silent;

namespace NCDK.Formula
{
    /// <summary>
    /// Checks the functionality of the MolecularFormula.
    /// </summary>
    /// <seealso cref="MolecularFormula"/>
    // @cdk.module test-data
    [TestClass()]
    public class MolecularFormulaTest : AbstractMolecularFormulaTest
    {
        protected override IChemObjectBuilder Builder
            => ChemObjectBuilder.Instance;

        [TestMethod()]
        public void TestMolecularFormula()
        {

            IMolecularFormula mf = Builder.NewMolecularFormula();
            Assert.IsNotNull(mf);
        }

        [TestMethod()]
        public void TestIsTheSame_IIsotope_IIsotope()
        {
            IIsotope carb = Builder.NewIsotope("C");
            IIsotope anotherCarb = Builder.NewIsotope("C");
            IIsotope h = Builder.NewIsotope("H");

            carb.ExactMass = 12.0;
            anotherCarb.ExactMass = 12.0;
            h.ExactMass = 1.0;

            carb.Abundance = 34.0;
            anotherCarb.Abundance = 34.0;
            h.Abundance = 99.0;

            Assert.IsTrue(MolecularFormula.IsTheSame(carb, carb));
            Assert.IsTrue(MolecularFormula.IsTheSame(carb, anotherCarb));
            Assert.IsFalse(MolecularFormula.IsTheSame(carb, h));
        }
    }
}
