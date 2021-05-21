﻿using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Artech.Architecture.Common.Packages;
using Artech.Architecture.Common.Descriptors;
using Acme.Packages.Widgets;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Acme.Packages.Widgets")]
[assembly: AssemblyDescription("Widgets")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("GeneXus")]
[assembly: AssemblyProduct("GXsample")]
[assembly: AssemblyCopyright("Copyright © GeneXus, 2007")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// The following attributes are declarations related to this assembly
// as a GeneXus Package
[assembly: PackageAttribute(typeof(Acme.Packages.Widgets.Package))]

[assembly: KBObjectsDeclarationAttribute(
	typeof(Widgetry)
	)]


[assembly: KBObjectPartsDeclarationAttribute(
	typeof(WidgetsPart)
	)]


// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("baed9020-3ec0-4e9c-becf-c053caf01609")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
