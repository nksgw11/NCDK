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
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA 02110-1301 USA.
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCDK.Silent;
using System;

namespace NCDK.Formula.Rules
{
    // @cdk.module test-formula
    [TestClass()]
    public class ChargeRuleTest : FormulaRuleTest
    {
        private static readonly IChemObjectBuilder builder = ChemObjectBuilder.Instance;
        protected override Type RuleClass => typeof(ChargeRule);

        [TestMethod()]
        public void TestChargeRule()
        {
            IRule rule = new ChargeRule();
            Assert.IsNotNull(rule);
        }

        [TestMethod()]
        public void TestDefault()
        {
            IRule rule = new ChargeRule();
            var objects = rule.Parameters;
            Assert.AreEqual(1, objects.Count);

            double charge = (double)objects[0];
            Assert.AreEqual(0.0, charge, 0.00001);
        }

        [TestMethod()]
        public void TestSetParameters()
        {
            IRule rule = new ChargeRule { Parameters = new object[] { -1.0 } };

            var objects = rule.Parameters;
            Assert.AreEqual(1, objects.Count);

            double charge = (double)objects[0];
            Assert.AreEqual(-1.0, charge, 0.00001);
        }

        [TestMethod()]
        public void TestDefaultValidFalse()
        {
            IRule rule = new ChargeRule();

            var formula = new MolecularFormula();
            formula.Add(builder.NewIsotope("C"), 2);
            formula.Add(builder.NewIsotope("H"), 200);
            formula.Charge = 1;

            Assert.AreEqual(0.0, rule.Validate(formula), 0.0001);
        }

        [TestMethod()]
        public void TestDefaultValidFalseSetParam()
        {
            IRule rule = new ChargeRule();
            var formula = new MolecularFormula();
            formula.Add(builder.NewIsotope("C"), 2);
            formula.Add(builder.NewIsotope("H"), 200);
            formula.Charge = 1;
            rule.Parameters = new object[] { -1.0 };

            Assert.AreEqual(0.0, rule.Validate(formula), 0.0001);
        }

        [TestMethod()]
        public void TestDefaultValidTrue()
        {
            IRule rule = new ChargeRule();

            var formula = new MolecularFormula();
            formula.Add(builder.NewIsotope("C"), 2);
            formula.Add(builder.NewIsotope("H"), 6);
            formula.Charge = 0;

            Assert.AreEqual(1.0, rule.Validate(formula), 0.0001);
        }
    }
}
