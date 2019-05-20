//////////////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2019, National Instruments Corp.

// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:

// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
//////////////////////////////////////////////////////////////////////////////
using System;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("National Instruments Vision .NET Common")]
[assembly: AssemblyDescription("NI Vision .NET Common support")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("National Instruments")]
[assembly: AssemblyProduct("Vision 13.1 Common")]
[assembly: AssemblyCopyright("Copyright (C) National Instruments 2013.  All Rights Reserved.")]
[assembly: AssemblyTrademark("National Instruments")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: AssemblyDefaultAlias("NationalInstruments.Vision.Common.dll")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum)]
[assembly: CLSCompliant(true)]

//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers
// by using the '*' as shown below:

#if VS2005
[assembly: AssemblyVersion("13.1.20.100")]
[assembly: AssemblyInformationalVersion("13.1.20.100")]
#elif VS2008
[assembly: AssemblyVersion("13.1.35.100")]
[assembly: AssemblyInformationalVersion("13.1.35.100")]
#elif VS2010
[assembly: AssemblyVersion("13.1.40.100")]
[assembly: AssemblyInformationalVersion("13.1.40.100")]
#elif VS2015
[assembly: AssemblyVersion("13.1.40.100")]
[assembly: AssemblyInformationalVersion("13.1.40.100")]
#else
#error Need to define VS2005 or VS2008 or VS2010
#endif

//
// In order to sign your assembly you must specify a key to use. Refer to the
// Microsoft .NET Framework documentation for more information on assembly signing.
//
// Use the attributes below to control which key is used for signing.
//
// Notes:
//   (*) If no key is specified, the assembly is not signed.
//   (*) KeyName refers to a key that has been installed in the Crypto Service
//       Provider (CSP) on your machine. KeyFile refers to a file which contains
//       a key.
//   (*) If the KeyFile and the KeyName values are both specified, the
//       following processing occurs:
//       (1) If the KeyName can be found in the CSP, that key is used.
//       (2) If the KeyName does not exist and the KeyFile does exist, the key
//           in the KeyFile is installed into the CSP and used.
//   (*) In order to create a KeyFile, you can use the sn.exe (Strong Name) utility.
//       When specifying the KeyFile, the location of the KeyFile should be
//       relative to the project output directory which is
//       %Project Directory%\obj\<configuration>. For example, if your KeyFile is
//       located in the project directory, you would specify the AssemblyKeyFile
//       attribute as [assembly: AssemblyKeyFile("..\\..\\mykey.snk")]
//   (*) Delay Signing is an advanced option - see the Microsoft .NET Framework
//       documentation for more information on this.
//
[assembly: AssemblyDelaySign(false)]

#if VS2005
[assembly: InternalsVisibleToAttribute("NationalInstruments.Vision, PublicKey=00240000048000009400000006020000002400005253413100040000010001003300e3b6e53c2622ef3c5fde7236accaa9e8c5822414a8ecceff394f62385c7127ab095742b0c800d37f6a83bedf5326e161b4bd5a01034663195410c6bdf9ae6cc9f4dcb119964e7f60bd0f885fbdb99b71f8e3f54fbe1b78d45822cad8fee6db73e75b1e3d9083bfaad701a28ba849854c1944f3b788835ff4a8010138a5b1")]
[assembly: InternalsVisibleToAttribute("NationalInstruments.Vision.Acquisition.Imaqdx, PublicKey=00240000048000009400000006020000002400005253413100040000010001003300e3b6e53c2622ef3c5fde7236accaa9e8c5822414a8ecceff394f62385c7127ab095742b0c800d37f6a83bedf5326e161b4bd5a01034663195410c6bdf9ae6cc9f4dcb119964e7f60bd0f885fbdb99b71f8e3f54fbe1b78d45822cad8fee6db73e75b1e3d9083bfaad701a28ba849854c1944f3b788835ff4a8010138a5b1")]
[assembly: InternalsVisibleToAttribute("NationalInstruments.Vision.Acquisition.Imaq, PublicKey=00240000048000009400000006020000002400005253413100040000010001003300e3b6e53c2622ef3c5fde7236accaa9e8c5822414a8ecceff394f62385c7127ab095742b0c800d37f6a83bedf5326e161b4bd5a01034663195410c6bdf9ae6cc9f4dcb119964e7f60bd0f885fbdb99b71f8e3f54fbe1b78d45822cad8fee6db73e75b1e3d9083bfaad701a28ba849854c1944f3b788835ff4a8010138a5b1")]
// Temp for old combined assembly
[assembly: InternalsVisibleToAttribute("NationalInstruments.Vision.Acquisition, PublicKey=00240000048000009400000006020000002400005253413100040000010001003300e3b6e53c2622ef3c5fde7236accaa9e8c5822414a8ecceff394f62385c7127ab095742b0c800d37f6a83bedf5326e161b4bd5a01034663195410c6bdf9ae6cc9f4dcb119964e7f60bd0f885fbdb99b71f8e3f54fbe1b78d45822cad8fee6db73e75b1e3d9083bfaad701a28ba849854c1944f3b788835ff4a8010138a5b1")]
#elif VS2008
[assembly: InternalsVisibleToAttribute("NationalInstruments.Vision, PublicKey=00240000048000009400000006020000002400005253413100040000010001000133a9e3b40df1eb75ed9ff2616447323c7f4e006b534b9035aa0794890c15f2d7fbdcc6a9df515020ef121eec7ac258f2a1b286844275890ab0f33908080dbc2c370d10dfe1f6862df4f22ca94d8a3cfa300ae96e1dd9804ae6c90df138432dfae419d4770d52f2415c49f403c37789c52e3ec652af3b2b5652f3ece3ce9cc8")]
[assembly: InternalsVisibleToAttribute("NationalInstruments.Vision.Acquisition.Imaqdx, PublicKey=00240000048000009400000006020000002400005253413100040000010001000133a9e3b40df1eb75ed9ff2616447323c7f4e006b534b9035aa0794890c15f2d7fbdcc6a9df515020ef121eec7ac258f2a1b286844275890ab0f33908080dbc2c370d10dfe1f6862df4f22ca94d8a3cfa300ae96e1dd9804ae6c90df138432dfae419d4770d52f2415c49f403c37789c52e3ec652af3b2b5652f3ece3ce9cc8")]
[assembly: InternalsVisibleToAttribute("NationalInstruments.Vision.Acquisition.Imaq, PublicKey=00240000048000009400000006020000002400005253413100040000010001000133a9e3b40df1eb75ed9ff2616447323c7f4e006b534b9035aa0794890c15f2d7fbdcc6a9df515020ef121eec7ac258f2a1b286844275890ab0f33908080dbc2c370d10dfe1f6862df4f22ca94d8a3cfa300ae96e1dd9804ae6c90df138432dfae419d4770d52f2415c49f403c37789c52e3ec652af3b2b5652f3ece3ce9cc8")]
// Temp for old combined assembly
[assembly: InternalsVisibleToAttribute("NationalInstruments.Vision.Acquisition, PublicKey=00240000048000009400000006020000002400005253413100040000010001000133A9E3B40DF1EB75ED9FF2616447323C7F4E006B534B9035AA0794890C15F2D7FBDCC6A9DF515020EF121EEC7AC258F2A1B286844275890AB0F33908080DBC2C370D10DFE1F6862DF4F22CA94D8A3CFA300AE96E1DD9804AE6C90DF138432DFAE419D4770D52F2415C49F403C37789C52E3EC652AF3B2B5652F3ECE3CE9CC8")]
#elif VS2010
[assembly: InternalsVisibleToAttribute("NationalInstruments.Vision, PublicKey=0024000004800000940000000602000000240000525341310004000001000100ad0eb02d6bb55dca8dd398c8607bc1b82c002f734493e0cb0b86014bfa50db9a966b68338dee39366260b8c91ab0f16d9c9b12b97f149b2eeef6c76902b72fb068c2f99f8318d4a6f2bdf57ac07f749abf62d56e32e0fd0e20aed14d04c91baf2e0c354196340b101228492cd777f1adc70cd7edb04c885957ac43b6c52c8dce")]
[assembly: InternalsVisibleToAttribute("NationalInstruments.Vision.Acquisition.Imaqdx, PublicKey=0024000004800000940000000602000000240000525341310004000001000100d3dbebc0c8dcb9c09eb36597b38ae65028ac488baf2b19ebc3198f391da6237559f45af97939619616f99ef975b02af0b51b44ef41a110f8555c1e4be1c7c22745cf357363d1100fa865f37942984dd951a76181d1de23790c4d563a8c88e51787c6b0b1ed8f10f9772334167b1695f55f7727685d3538ca391c3970dba496f1")]
[assembly: InternalsVisibleToAttribute("NationalInstruments.Vision.Acquisition.Imaq, PublicKey=0024000004800000940000000602000000240000525341310004000001000100d3dbebc0c8dcb9c09eb36597b38ae65028ac488baf2b19ebc3198f391da6237559f45af97939619616f99ef975b02af0b51b44ef41a110f8555c1e4be1c7c22745cf357363d1100fa865f37942984dd951a76181d1de23790c4d563a8c88e51787c6b0b1ed8f10f9772334167b1695f55f7727685d3538ca391c3970dba496f1")]
// Temp for old combined assembly
[assembly: InternalsVisibleToAttribute("NationalInstruments.Vision.Acquisition, PublicKey=0024000004800000940000000602000000240000525341310004000001000100d3dbebc0c8dcb9c09eb36597b38ae65028ac488baf2b19ebc3198f391da6237559f45af97939619616f99ef975b02af0b51b44ef41a110f8555c1e4be1c7c22745cf357363d1100fa865f37942984dd951a76181d1de23790c4d563a8c88e51787c6b0b1ed8f10f9772334167b1695f55f7727685d3538ca391c3970dba496f1")]
#elif VS2015
[assembly: InternalsVisibleToAttribute("NationalInstruments.Vision")]
[assembly: InternalsVisibleToAttribute("NationalInstruments.Vision.Acquisition.Imaqdx")]
[assembly: InternalsVisibleToAttribute("NationalInstruments.Vision.Acquisition.Imaq")]
// Temp for old combined assembly
[assembly: InternalsVisibleToAttribute("NationalInstruments.Vision.Acquisition")]
#endif
