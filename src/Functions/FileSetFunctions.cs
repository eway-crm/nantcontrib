// NAnt - A .NET build tool
// Copyright (C) 2001-2004 Gerry Shaw
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
// Bill Martin
//

using System;
using NAnt.Core;
using NAnt.Core.Types;
using NAnt.Core.Attributes;

namespace NAnt.Contrib.Functions {
    
    /// <summary>
    /// Provides methods for interrogating Filesets.
    /// </summary>
    [FunctionSet("fileset", "FileSet")]
    public class FileSetFunctions : FunctionSetBase {
        
        #region Public Instance Constructors
        
        public FileSetFunctions(Project project, PropertyDictionary properties) : base(project, properties) { }
        
        #endregion Public Instance Constructors

        #region Public Instance Methods
        
        /// <summary>
        /// Determines the number of files within a <see cref="FileSet"/>.
        /// </summary>
        /// <param name="fileset">The FileSet to scan.</param>
        /// <returns>The number of files included in the FileSet</returns>
        [Function("get-file-count")]
        public int GetFileCount(string fileset) {
            //Try to retrieve the specified fileset from the Data References on the project
            FileSet fs = base.Project.DataTypeReferences[fileset] as FileSet;
            //If the value was missing or the referenced type was not a fileset, then throw an exception
            if (fs == null) {
                throw new ArgumentException(string.Format("'{0}' is not a valid fileset reference", fileset));
            }
            //Otherwise return the number of files in the fileset.
            return fs.FileNames.Count;
        }

        /// <summary>
        /// Determines whether <see cref="FileSet"/> contains any files.
        /// </summary>
        /// <param name="fileset">The fileset to check.</param>
        /// <returns><c>true</c> if the FileSet contains one or more files, otherwise <c>false</c></returns>
        [Function("has-files")]
        public bool HasFiles(string fileset) {
            //Try to retrieve the specified fileset from the Data References on the project
            FileSet fs = base.Project.DataTypeReferences[fileset] as FileSet;
            //If the value was missing or the referenced type was not a fileset, then throw an exception
            if (fs == null) {
                throw new ArgumentException(string.Format("'{0}' is not a valid fileset reference", fileset));
            }
            //Otherwise return whether or not the fileset contains files.
            return (fs.FileNames.Count > 0);
        }
        
        #endregion Public Instance Methods
    }
}
