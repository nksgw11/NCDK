/*
 * MX Cheminformatics Tools for Java
 *
 * Copyright (c) 2007-2009 Metamolecular, LLC
 *
 * http://metamolecular.com
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 *
 * Copyright (C) 2009-2010  Syed Asad Rahman <asad@ebi.ac.uk>
 *
 * Contact: cdk-devel@lists.sourceforge.net
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
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA 02110-1301 USA.
 */

using System;
using System.Collections.Generic;

namespace NCDK.SMSD.Rings
{
    /// <summary>
    /// Finds the Set of all Rings. This is an implementation of the algorithm
    /// published in <token>cdk-cite-HAN96</token>. Some of the comments refer to pseudo code
    /// fragments listed in this article. The concept is that a regular molecular
    /// graph is first converted into a path graph (refer PathGraph.java),
    /// i.e. a graph where the edges are actually paths. This can list several
    /// nodes that are implicitly connecting the two nodes between the path
    /// is formed (refer PathEdge.java).
    ///
    /// The paths that join source and sink node are step by step fused and the joined
    /// nodes are deleted from the path graph (collapsed path). What remains is a graph
    /// of paths that have the same start and endpoint and are thus rings (source=sink=ring).
    /// </summary>
    // @cdk.module smsd
    // @author Syed Asad Rahman <asad@ebi.ac.uk> 2009-2010
    [Obsolete]
    public class HanserRingFinder : IRingFinder
    {

        private IList<IList<IAtom>> rings;

        public HanserRingFinder()
        {
            rings = new List<IList<IAtom>>();
        }

        /// <summary>
        /// Returns a collection of rings.
        /// </summary>
        /// <param name="molecule"></param>
        /// <returns>a <see cref="IEnumerable{T}"/> of <see cref="IList{T}"/>s containing one ring each</returns>
        /// <seealso cref="IRingFinder.FindRings(IAtomContainer)"/>
        public IEnumerable<IList<IAtom>> FindRings(IAtomContainer molecule)
        {
            if (molecule == null) return null;
            rings.Clear();
            PathGraph graph = new PathGraph(molecule);

            for (int i = 0; i < molecule.Atoms.Count; i++)
            {
                var edges = graph.Remove(molecule.Atoms[i]);

                foreach (var edge in edges)
                {
                    var ring = edge.Atoms;
                    rings.Add(ring);
                }
            }

            return rings;
        }

        /// <summary>
        /// Returns Ring set based on Hanser Ring Finding method
        /// <param name="molecule"></param>
        /// </summary>
        /// <returns>report collected the rings</returns>
        /// <seealso cref="IRingFinder.GetRingSet(IAtomContainer)"/>
        public IRingSet GetRingSet(IAtomContainer molecule)
        {
            var cycles = FindRings(molecule);

            IRingSet ringSet = molecule.Builder.NewRingSet();

            foreach (var ringAtoms in cycles)
            {
                IRing ring = molecule.Builder.NewRing();
                foreach (var atom in ringAtoms)
                {
                    atom.IsInRing = true;
                    ring.Atoms.Add(atom);
                    foreach (var atomNext in ringAtoms)
                    {
                        if (!atom.Equals(atomNext))
                        {
                            IBond bond = molecule.GetBond(atom, atomNext);
                            if (bond != null)
                            {
                                bond.IsInRing = true;
                                ring.Bonds.Add(bond);
                            }
                        }
                    }
                }
                ringSet.Add(ring);
            }
            return ringSet;
        }
    }
}
