/* Copyright (C) 2004-2007  The Chemistry Development Kit (CDK) project
 *
 * Contact: cdk-devel@slists.sourceforge.net
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public License
 * as published by the Free Software Foundation; either version 2.1
 * of the License, or (at your option) any later version.
 * All we ask is that proper credit is given for our work, which includes
 * - but is not limited to - adding the above copyright notice to the beginning
 * of your source code files, and to any copyright notice that you may distribute
 * with programs based on this work.
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
using System;
using System.IO;

namespace NCDK.IO
{
    /// <summary>
    /// TestCase for the writer MDL rxn files using one test file.
    /// </summary>
    /// <seealso cref="MDLRXNWriter"/>
    // @cdk.module test-io
    [TestClass()]
    public class MDLRXNWriterTest : ChemObjectIOTest
    {
        protected override Type ChemObjectIOToTestType => typeof(MDLRXNWriter);
        private static IChemObjectBuilder builder = ChemObjectBuilder.Instance;

        [TestMethod()]
        public void TestAccepts()
        {
            MDLRXNWriter reader = new MDLRXNWriter(new StringWriter());
            Assert.IsTrue(reader.Accepts(typeof(Reaction)));
        }

        [TestMethod()]
        public void TestRoundtrip()
        {
            IReaction reaction = builder.NewReaction();
            IAtomContainer hydroxide = builder.NewAtomContainer();
            hydroxide.Atoms.Add(builder.NewAtom("O"));
            reaction.Reactants.Add(hydroxide);
            IAtomContainer proton = builder.NewAtomContainer();
            proton.Atoms.Add(builder.NewAtom("H"));
            reaction.Reactants.Add(proton);
            IAtomContainer water = builder.NewAtomContainer();
            water.Atoms.Add(builder.NewAtom("O"));
            reaction.Products.Add(water);
            reaction.Mappings.Add(new Mapping(hydroxide.Atoms[0], water.Atoms[0]));

            // now serialize to MDL RXN
            StringWriter writer = new StringWriter();
            string file = "";
            MDLRXNWriter mdlWriter = new MDLRXNWriter(writer);
            mdlWriter.Write(reaction);
            mdlWriter.Close();
            file = writer.ToString();

            Assert.IsTrue(file.Length > 0);

            // now deserialize the MDL RXN output
            IReaction reaction2 = builder.NewReaction();
            MDLRXNReader reader = new MDLRXNReader(new StringReader(file));
            reaction2 = (IReaction)reader.Read(reaction2);
            reader.Close();

            Assert.AreEqual(2, reaction2.Reactants.Count);
            Assert.AreEqual(1, reaction2.Products.Count);
            Assert.AreEqual(1, reaction2.Mappings.Count);
        }

        [TestMethod()]
        public void TestReactionSet_1()
        {
            IReaction reaction11 = builder.NewReaction();
            IAtomContainer hydroxide = builder.NewAtomContainer();
            hydroxide.Atoms.Add(builder.NewAtom("O"));
            reaction11.Reactants.Add(hydroxide);
            IAtomContainer proton = builder.NewAtomContainer();
            proton.Atoms.Add(builder.NewAtom("H"));
            reaction11.Reactants.Add(proton);

            IAtomContainer water = builder.NewAtomContainer();
            water.Atoms.Add(builder.NewAtom("O"));
            reaction11.Products.Add(water);

            IReactionSet reactionSet = new ReactionSet();
            reactionSet.Add(reaction11);

            // now serialize to MDL RXN
            StringWriter writer = new StringWriter();
            string file = "";
            MDLRXNWriter mdlWriter = new MDLRXNWriter(writer);
            mdlWriter.Write(reactionSet);
            mdlWriter.Close();
            file = writer.ToString();

            Assert.IsTrue(file.Length > 0);

            // now deserialize the MDL RXN output
            IReaction reaction2 = builder.NewReaction();
            MDLRXNReader reader = new MDLRXNReader(new StringReader(file));
            reaction2 = (IReaction)reader.Read(reaction2);
            reader.Close();

            Assert.AreEqual(2, reaction2.Reactants.Count);
            Assert.AreEqual(1, reaction2.Reactants[0].Atoms.Count);
            Assert.AreEqual(1, reaction2.Reactants[1].Atoms.Count);
            Assert.AreEqual(1, reaction2.Products.Count);
            Assert.AreEqual(1, reaction2.Products[0].Atoms.Count);
        }

        [TestMethod()]
        public void TestReactionSet_2()
        {
            IReaction reaction11 = builder.NewReaction();
            IAtomContainer hydroxide = builder.NewAtomContainer();
            hydroxide.Atoms.Add(builder.NewAtom("O"));
            reaction11.Reactants.Add(hydroxide);
            IAtomContainer proton = builder.NewAtomContainer();
            proton.Atoms.Add(builder.NewAtom("H"));
            reaction11.Reactants.Add(proton);

            IAtomContainer water = builder.NewAtomContainer();
            water.Atoms.Add(builder.NewAtom("O"));
            reaction11.Products.Add(water);

            IReaction reaction12 = builder.NewReaction();
            IAtomContainer h = builder.NewAtomContainer();
            h.Atoms.Add(builder.NewAtom("H"));
            IAtomContainer n = builder.NewAtomContainer();
            n.Atoms.Add(builder.NewAtom("N"));
            reaction12.Reactants.Add(h);
            reaction12.Reactants.Add(n);
            IAtomContainer ammonia = builder.NewAtomContainer();
            ammonia.Atoms.Add(builder.NewAtom("N"));
            ammonia.Atoms.Add(builder.NewAtom("H"));
            ammonia.AddBond(ammonia.Atoms[0], ammonia.Atoms[1], BondOrder.Single);
            reaction12.Products.Add(ammonia);

            IReactionSet reactionSet = builder.NewReactionSet();
            reactionSet.Add(reaction11);
            reactionSet.Add(reaction12);

            // now serialize to MDL RXN
            StringWriter writer = new StringWriter();
            string file = "";
            MDLRXNWriter mdlWriter = new MDLRXNWriter(writer);
            mdlWriter.Write(reactionSet);
            mdlWriter.Close();
            file = writer.ToString();

            Assert.IsTrue(file.Length > 0);

            // now deserialize the MDL RXN output
            IReactionSet reactionSetF = builder.NewReactionSet();
            MDLRXNReader reader = new MDLRXNReader(new StringReader(file));
            reactionSetF = (IReactionSet)reader.Read(reactionSetF);
            reader.Close();

            Assert.AreEqual(2, reactionSetF.Count);
            Assert.AreEqual(1, reactionSetF[0].Reactants[0].Atoms.Count);
            Assert.AreEqual(1, reactionSetF[0].Reactants[1].Atoms.Count);
            Assert.AreEqual(1, reactionSetF[0].Products.Count);
            Assert.AreEqual(1, reactionSetF[0].Products[0].Atoms.Count);
        }
    }
}
