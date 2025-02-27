



// .NET Framework port by Kazuya Ujihara
// Copyright (C) 2016-2017  Kazuya Ujihara <ujihara.kazuya@gmail.com>

/* Copyright (C) 1997-2007  Christoph Steinbeck <steinbeck@users.sf.net>
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

using System;

namespace NCDK.Default
{
    /// <summary>
    /// Base class for entities containing electrons, like bonds, orbitals, lone-pairs.
    /// </summary>
    // @cdk.keyword orbital
    // @cdk.keyword lone-pair
    // @cdk.keyword bond 
    public class ElectronContainer 
        : ChemObject, IElectronContainer, ICloneable
    {
        /// <summary>
        /// Constructs an empty ElectronContainer.
        /// </summary>
        private int? electronCount = 0;

        /// <summary>
        /// Returns the number of electrons in this electron container.
        /// </summary>
        /// <returns>The number of electrons in this electron container.</returns>
        /// <seealso cref="ElectronCount"/>
        public ElectronContainer()
            : base()
        {
        }

        /// <summary>
        /// The number of electrons in this electron container.
        /// </summary>
        public virtual int? ElectronCount
        {
            get { return electronCount; }
            set
            {
                electronCount = value;
                NotifyChanged();
            }
        }

        public new IElectronContainer Clone() => (IElectronContainer)Clone(new CDKObjectMap());
        object ICloneable.Clone() => Clone();
    }
}
namespace NCDK.Silent
{
    /// <summary>
    /// Base class for entities containing electrons, like bonds, orbitals, lone-pairs.
    /// </summary>
    // @cdk.keyword orbital
    // @cdk.keyword lone-pair
    // @cdk.keyword bond 
    public class ElectronContainer 
        : ChemObject, IElectronContainer, ICloneable
    {
        /// <summary>
        /// Constructs an empty ElectronContainer.
        /// </summary>
        private int? electronCount = 0;

        /// <summary>
        /// Returns the number of electrons in this electron container.
        /// </summary>
        /// <returns>The number of electrons in this electron container.</returns>
        /// <seealso cref="ElectronCount"/>
        public ElectronContainer()
            : base()
        {
        }

        /// <summary>
        /// The number of electrons in this electron container.
        /// </summary>
        public virtual int? ElectronCount
        {
            get { return electronCount; }
            set
            {
                electronCount = value;
            }
        }

        public new IElectronContainer Clone() => (IElectronContainer)Clone(new CDKObjectMap());
        object ICloneable.Clone() => Clone();
    }
}
